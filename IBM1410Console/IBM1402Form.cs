/* 
 *  COPYRIGHT 2026 Jay R. Jaeger
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  (file COPYING.txt) along with this program.  
 *  If not, see <https://www.gnu.org/licenses/>.
*/

//  Right now, this just implements a 1402 on channel 1. 
//  It should not be *too* hard to generalize this by adding a 
//  channel number field.

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace IBM1410Console
{
    public partial class IBM1402Form : Form {

        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;
        private SerialDataPublisher serialDataPublisher;
        private UDPDataPublisher udpDataPublisher;
        private UdpClient udpClient = null;
        private SemaphoreSlim udpOutputSemaphore = null;

        private FileStream readerFileStream = null;
        private Boolean readerReady = false;
        private Boolean readerLastCard = false;
        private Boolean readerDataCheck = false;
        private Boolean readerWLR = false;
        private Boolean readerBusy = false;
        private Boolean readerEOF = false;
        private IBM1410Card readStation = null;
        private IBM1410Card checkStation = null;
        private String stackerBaseName = "stacker";

        private int currentUnitRecordDevice = 0;
        private int currentReaderOperation = 0;
        private bool currentReaderSkippingBytes = false;

        private IBM1402Stacker readerStacker0;
        private IBM1402Stacker readerStacker1;
        private IBM1402Stacker readerStacker2;        // AKA PunchStacker8
        private IBM1402Stacker punchStacker0;
        private IBM1402Stacker punchStacker4;
        private IBM1402Stacker punchStacker8;

        public const int readerIsReady = 0x01;      // Reader is ready with cards
        public const int readerIsBusy = 0x02;       // Reader is busy (NOT currently used)
        public const int readerIsDataCheck = 0x04;  // (if we can't translate an ASCII char to BCD)
        public const int readerIsWLR = 0x08;        // Card image is more than 80 characters
        public const int readerIsLastCard = 0x10;   // EOF Button is pressed, active and last card in station
        public const int readerStackerFull = 0x20;  // Stacker is full
        
        public const byte UNITRECORDFLAG = 0x85;
        public const byte READERCH1FLAG = 0x01;
        public const byte PUNCHCH1FLAG = 0x04;
        public const byte READERCH2FLAG = 0x41;
        public const byte PUNCHCH2FLAG = 0x44;

        public const byte STATUSUPDATEOPERATION = 0x01;
        public const byte SENDCARDOPERATION = 0x02;

        public const byte READERFEEDOPERATION = 0x10;
        public const byte STACKER1 = 0x1;
        public const byte STACKER2 = 0x2;

        private byte readerStatus = 0;               // Not ready by default.

        public IBM1402Form(SerialDataPublisher serialDataPublisher,
            UDPDataPublisher udpDataPublisher,
            SerialPort serialPort, SemaphoreSlim serialOutputSemaphore,
            UdpClient udpClient, SemaphoreSlim udpOutputSemaphore) {

            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;
            this.udpDataPublisher = udpDataPublisher;
            this.udpClient = udpClient;
            this.udpOutputSemaphore = udpOutputSemaphore;

            //  Create the various stackers.

            readerStacker0 = new IBM1402Stacker();
            readerStacker1 = new IBM1402Stacker();
            readerStacker2 = new IBM1402Stacker();
            punchStacker0 = new IBM1402Stacker();
            punchStacker4 = new IBM1402Stacker();
            punchStacker8 = readerStacker2;

            InitializeComponent();
            this.CreateHandle();    // Ensures controls are created before we get FPGA data

            readerStartButton.Enabled = false;
            readerStopButton.Enabled = false;
            readerEOFButton.Enabled = true;
            readStation = checkStation = null;
            readerReady = readerLastCard = false;
            readerFileStream = null;

            serialDataPublisher.ReaderChannel1OutputEvent +=
                new EventHandler<UnitRecordChannelEventArgs>(readerChannel1OperationAvailable);

            udpDataPublisher.UDPReaderChannel1OutputEvent +=
                new EventHandler<UDPUnitRecordChannelEventArgs>(readerChannel1UDPOperationAvailable);
        }

        void readerChannel1OperationAvailable(object sender, UnitRecordChannelEventArgs e) {
            //  Right now, just using UDP, so ignore serial port requests.
        }

        void readerChannel1UDPOperationAvailable(object sender, UDPUnitRecordChannelEventArgs e) {
            
            //  The CPU has asked the 1414 to have the reader to do something...

            //  If this really isn't for us, ignore it.

            if(e.DispatchCode != UNITRECORDFLAG) {
                return;
            }

            //  Loop through the bytes (hopefully / typically, the entire packet)

            for (int i = 0; i < e.UDPLen; i++) {
                if (currentUnitRecordDevice == 0) {
                    //  If we are not currently processing a device, this byte is
                    //  the device code.
                    currentUnitRecordDevice = e.UDPBytes[i];
                    currentReaderOperation = 0;
                }
                else if (currentUnitRecordDevice != READERCH1FLAG) {
                    //  This unit record request isn't for the reader, so ignore it,
                    //  until we see a terminating 0x00
                    if (e.UDPBytes[i] == 0) {
                        currentUnitRecordDevice = 0;
                    }
                }
                else {
                    //  The current unit record device is the reader, so
                    //  process it.
                    readerMessageInputAvailable((byte)e.UDPBytes[i]);
                }
            }
        }

        //  Method to actually handle a byte of data from the FPGA (IBM 1414, if you will)

        void readerMessageInputAvailable(byte c) {

            //  0 Terminates the reader request.

            if (c == 0) {
                currentReaderOperation = 0;
                currentUnitRecordDevice = 0;
                currentReaderSkippingBytes = false;
                return;
            }

            //  The first byte should be an operation code.  And for the reader,
            //  That is ALL we expect

            if(currentReaderOperation == 0) {
                if((c & READERFEEDOPERATION) != READERFEEDOPERATION) {
                    currentReaderOperation = READERFEEDOPERATION;
                    doSelectStackerFeed();
                }
            }

            else {
                if(!currentReaderSkippingBytes) {
                    Debug.WriteLine("IBM1402Form:readerMessageInputAvailable: " +
                        "Expected a 0 byte after the operation/stacker byte");
                    MessageBox.Show("IBM1402Form:readerMessageInputAvailable: " +
                        "Expected a 0 byte after the operation/stacker byte");
                    currentReaderSkippingBytes = true;
                }
            }
        }

        //  Method to stack the card in the raed station, if any, and feed the next card

        private void doSelectStackerFeed() {


            //  If the reader is currently busy or not ready, report that.

            if(readerBusy || !readerReady) {
                sendReaderStatus();
                return;
            }

            //  If there is a card at the read station, stack it.

            if (readStation != null) {
                //  Stack it
                readStation = null;
            }

            //  If there is no card presently at the check station, we are done.

            if (checkStation == null) {
                return;
            }

            //  At this point, the readStation is gauranteed to be empty, and
            //  and check station is guarnateed to NOT be empty.

            readStation = checkStation;
            checkStation = FeedCard();

            //  If there is no new card, and there has been a card read and it is at 
            //  the read station, and the EOF button was pressed that is the last card.

            if (checkStation == null && readStation != null && readerEOF) {
                readStation.setLastCard(true);
            }

            //  If there is a card at the check station, or, if EOF is pressed, 
            //  there is at least a card at the read station, all is OK.  If so,
            //  Then send the card image to the buffer on the 1414 (i.e., the FPGA)

            if (checkStation != null || (readStation != null && readStation.getLastCard())) {
                readerReady = true;
            }
            else {
                readerReady = false;
            }

            //  TODO: The following code is identical to the startButton code, and should be
            //  factored out some day

            //  Set the ready light to the correct state

            labelReaderReady.ForeColor = readerReady ? Color.DimGray : Color.SeaGreen;
            labelReaderStop.ForeColor = Color.DimGray;
            readerStartButton.Enabled = !readerReady;
            readerStopButton.Enabled = readerReady;

            //  Send the reader status to the FPGA (1414)

            sendReaderStatus();

            //  If there is data at the read station, send that off to the 1414 (FPGA)

            if (readStation != null) {
                sendReadStation();

                //  If we just sent the last card, reset the EOF status

                if (readStation.lastCard) {
                    readerEOF = false;
                }
            }
        }

        //  Method to set the status bits for the reader, and send them off to the FPGA

        private void sendReaderStatus() {

            byte[] statusBuffer = new byte[4];

            readerStatus = 0;
            if(readerReady) {
                readerStatus |= readerIsReady;
            }
            if(readerBusy) {
                readerStatus |= readerIsBusy;
            }
            if(readerDataCheck) {
                readerStatus |= readerIsDataCheck;
            }
            if(readerLastCard) {
                readerStatus |= readerIsLastCard;
            }
            if(readerWLR) {
                readerStatus |= readerIsWLR;
            }

            //  For now, serial port version NOT implemented.

            //  Send the updated status to the FPGA...

            udpOutputSemaphore.Wait();
            statusBuffer[0] = UNITRECORDFLAG;
            statusBuffer[1] = READERCH1FLAG;
            statusBuffer[2] = STATUSUPDATEOPERATION;
            statusBuffer[3] = readerStatus;
            udpClient.Send(statusBuffer,statusBuffer.Length);
            udpOutputSemaphore.Release();
        }

        //  Method to process the 1402 Reader Load Button - as though we just
        //  loaded in some cards.  It does not actually feed the cards, though.

        private void loadButton_Click(object sender, EventArgs e) {
            if (readerOpenFileDialog.ShowDialog() == DialogResult.OK) {
                if (readerFileStream != null) {
                    readerFileStream.Close();
                    readerFileStream = null;
                }
                try {
                    readerFileStream = new FileStream(readerOpenFileDialog.FileName,
                        FileMode.Open, FileAccess.Read);
                    loadButton.Enabled = false;
                    labelReaderReady.ForeColor = Color.SeaGreen;
                    readerReady = true;
                    readerLastCard = false;
                    readerStartButton.Enabled = true;
                }
                catch (Exception e2) {
                    Debug.WriteLine("ERROR: IBM1402: Load: new FileStream failed on reader");
                    Debug.WriteLine(e2.ToString());
                    MessageBox.Show("Open of file name " + readerOpenFileDialog.FileName + " Failed.");
                    loadButton.Enabled = true;
                    labelReaderReady.ForeColor = Color.DimGray;
                    readerReady = false;
                    readerLastCard = false;
                    readerStartButton.Enabled = false;
                }
            }
        }

        //  Method to process the 1402 Reader Start Button

        private void readerStartButton_Click(object sender, EventArgs e) {

            if (readerFileStream == null || readerReady == false) {
                MessageBox.Show("ERROR: Unexpected Reader Start when no file or not ready");
                return;
            }

            readerReady = false;

            //  TODO: There will probably be very similar logic needed when we get a
            //  request to stack a card.

            //  Feed a card into the check station if it is empty

            if (checkStation == null) {
                checkStation = FeedCard();
            }

            //  If there is no card at the Read station, and there is (now) a card
            //  at the check station, move the card at the check station to the read station
            //  and feed another card.  

            if (readStation == null && checkStation != null) {
                readStation = checkStation;
                checkStation = FeedCard();
            }

            //  If there is no new card, and there has been a card read and it is at 
            //  the read station, and the EOF button was pressed that is the last card.
            if (checkStation == null && readStation != null && readerEOF) {
                readStation.setLastCard(true);
            }


            //  If there is a card at the check station, or, if EOF is pressed, 
            //  there is at least a card at the read station, all is OK.  If so,
            //  Then send the card image to the buffer on the 1414 (i.e., the FPGA)

            if (checkStation != null || (readStation != null && readStation.getLastCard())) {
                readerReady = true;
            }

            //  Set the ready light to the correct state

            labelReaderReady.ForeColor = readerReady ? Color.DimGray : Color.SeaGreen;
            labelReaderStop.ForeColor = Color.DimGray;
            readerStartButton.Enabled = !readerReady;
            readerStopButton.Enabled = readerReady;

            //  Send the reader status to the FPGA (1414)

            sendReaderStatus();

            //  If there is data at the read station, send that off to the FPGA

            if(readStation != null) {
                sendReadStation();

                //  If we just sent the last card, reset the EOF status

                if(readStation.lastCard) {
                    readerEOF = false;
                }
            }
        }

        //  Method to process the 1402 Reader STOP button

        private void readerStopButton_Click(object sender, EventArgs e) {
            readerReady = false;
            readerEOF = false;
            readerLastCard = false;
            readerBusy = false;
            readerStartButton.Enabled = true;
            readerStopButton.Enabled = false;
            labelReaderReady.ForeColor = Color.DimGray;
            sendReaderStatus();
        }


        //  Method to process the 1402 reader EOF button

        private void readerEOFButton_Click(object sender, EventArgs e) {
            readerEOF = true;
        }
        
        //  Method to feed a card on the IBM 1402 reader.

        private IBM1410Card FeedCard() {
            IBM1410Card card = new IBM1410Card();
            byte[] temp = new byte[82];
            int i;
            int c = 0;

            if(readerFileStream == null || card == null ) {
                readerReady = false;
                return (null);
            }

            //  Read up to 80 columns, looking for a newline.  If we hit EOF first before
            //  the newline, throw away the card.  Turn any trailing \r or \n into spaces.
            //  We have up to 82 characters to get to the newline.  If we don't signal WLR.

            for (i = 0; i < temp.Length; ++i) {
                c = readerFileStream.ReadByte();
                if (c < 1) {
                    card = null;
                    readerFileStream.Close();
                    readerFileStream = null;
                    return (null);
                }
                temp[i] = (byte)c;
                if (c == '\n') {
                    break;
                }
            }

            //  The last character we saw should be the newline.

            if (c != '\n') {
                Debug.WriteLine("Warning: IBM1402Form.Feed: No newline found within 82 characters of card image.");
                MessageBox.Show("Warning: IBM1402Form.Feed: No newline found within 82 characters of card image.");
                card.setWrongLengthRecord(true);
            }

            if (i > 0 && temp[i - 1] == '\r') {
                temp[i - 1] = (byte)' ';
            }

            //  Change the newline and any trailing garbage to spaces

            for (; i < 80; ++i) {
                temp[i] = (byte)' ';
            }

            //  Assign the data to the card image.

            card.image = temp[0..79];

            return (card);
        }

        //  Method to send a card image to the FPGA (1414 IO Synchronizer)

        private void sendReadStation() {
            int i, n;
            byte[] card = readStation.image;
            byte[] message = new byte[readStation.image.Length + 4];

            readerDataCheck = false;
            message[0] = UNITRECORDFLAG;
            message[1] = READERCH1FLAG;
            message[2] = SENDCARDOPERATION;
            n = 3;

            //  Convert the data from ASCII to BCD, filling in the message along the way.
            //  If invalid data is found, set that status too...

            for(i=0; i < card.Length; ++i) {
                if ((message[n++] = IBM1410BCD.ASCIItoBCD((char)card[i])) == 0xff) {
                    readStation.setDataCheck(true);
                }
            }

            message[n++] = 0;  //  Trailing 0 on the card image in the message by convention.

            //  Update the reader status first.  That will either set or clear the WLR and data check in the FPGA

            readerWLR = readStation.getWrongLengthRecord();
            readerDataCheck = readStation.getDataCheck();

            sendReaderStatus();

            //  Send the card image.

            udpOutputSemaphore.Wait();
            udpClient.Send(message, n);
            udpOutputSemaphore.Release();

            //  Consider setting readStation to null here...

        }
    }
}
