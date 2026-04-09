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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace IBM1410Console

/*
* Card Reader/Punch FPGA <-> PC Support Program protocols:
* 
* For PC => FPGA:
* 
*    Channel Character [CR]:            0x85 (Both Channels)
*    Unit Record Device Char [UD]:      0x01 (Reader Ch1) or 0x04 (Punch Ch1)
*    Status Operation Code Char [SO]:   0x01
*    Status from PC to FPGA:            [CR] [UD] [SO] [Status]
* 
*    Channel Character [CR]:            0x85 (Both Channels)
*    Unit Record Device Char [UD]:      0x01 (Reader Ch1)
*    Status Operation Code Char [SO]:   0x02 (Reader Data to Buffer)
*    Card Image from PC to FPGA:        [CR] [UD] [SO] [Card Read Data] [0x00]
*    
* For FPGA => PC
* 
*    Channel Character [CW]:            0x83 (Both channels)
*    Unit Record Device Char [UD]:      0x01 (Reader Ch1)
*    Unt Operation Char [OP]:           0x1x (Reader Stack and Feed)
*    Message from FPGA to PC:           [CW] [UD] [OP] <Note: NO Trailing 0x00>
* 
*    Channel Character [CW]:            0x83 (Both channels)
*    Unit Record Device Char [UD]:      0x04 (Punch Ch1)
*    Unt Operation Char [OP]:           0x4x (Punch Data, Stack and Feed)
*    Message from FPGA to PC:           [CW] [UD] [OP] [Card Punch Data] [0x00]
* 
*/

{
    public partial class IBM1402Form : Form
    {
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

        private Boolean punchReady = false;
        private Boolean punchBusy = false;

        private int currentUnitRecordDevice = 0;
        private int currentReaderOperation = 0;
        private int currentPunchOperation = 0;

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

        public const int punchIsReady = 0x01;
        public const int punchIsBusy = 0x02;

        public const byte UNITRECORDTO1414FLAG = 0x85;
        public const byte UNITRECORDFROM1414FLAG = 0x83;
        public const byte READERCH1FLAG = 0x01;
        public const byte PUNCHCH1FLAG = 0x04;
        public const byte READERCH2FLAG = 0x41;
        public const byte PUNCHCH2FLAG = 0x44;

        public const byte STATUSUPDATEOPERATION = 0x01;
        public const byte SENDCARDOPERATION = 0x02;

        public const byte READERFEEDOPERATION = 0x10;
        // public const byte STACKER1 = 0x1;
        // public const byte STACKER2 = 0x2;

        public const byte PUNCHOPERATION = 0x40;

        private byte readerStatus = 0;              // Not ready by default.
        private byte punchStatus = 0;               // Not Ready by default

        IBM1410Card punchedCard = null;

        private int readerNestCount = 0;
        private int statusNestCount = 0;

        public IBM1402Form(SerialDataPublisher serialDataPublisher,
            UDPDataPublisher udpDataPublisher,
            SerialPort serialPort, SemaphoreSlim serialOutputSemaphore,
            UdpClient udpClient, SemaphoreSlim udpOutputSemaphore) {

            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;
            this.udpDataPublisher = udpDataPublisher;
            this.udpClient = udpClient;
            this.udpOutputSemaphore = udpOutputSemaphore;

            InitializeComponent();  // Create the buttons before we create the stackers.
            this.CreateHandle();    // Ensures controls are created before we get FPGA data

            //  Create the various stackers.

            readerStacker0 = new IBM1402Stacker("Reader Stacker 0", "0", reader0StackerButton);
            readerStacker1 = new IBM1402Stacker("Reader Stacker 1", "1", reader1StackerButton);
            readerStacker2 = new IBM1402Stacker("Reader Stacker 2 / Punch Stacker 8", "2/8", middleStackerButton);
            punchStacker0 = new IBM1402Stacker("Punch Stacker 0", "0", punch0StackerButton);
            punchStacker4 = new IBM1402Stacker("Punch Stacker 4", "4", punch4StackerButton);
            punchStacker8 = readerStacker2;

            readerStartButton.Enabled = false;
            readerStopButton.Enabled = false;
            readerEOFButton.Enabled = true;
            readStation = checkStation = null;
            readerReady = readerLastCard = false;
            readerFileStream = null;

            //  We unsubscribe first, becuase sometimes we ended up with two subscriptions.
            //  Not sure why that happeneds, but unsubscribing when not subscribed is harmless.

            serialDataPublisher.UnitChannel1OutputEvent -=
                new EventHandler<UnitRecordChannelEventArgs>(unitChannel1OperationAvailable);

            udpDataPublisher.UDPUnitChannel1OutputEvent -=
                new EventHandler<UDPUnitRecordChannelEventArgs>(unitChannel1UDPOperationAvailable);

            Debug.WriteLine("IBM1402Form: Unsubscribed from unit record events.");

            serialDataPublisher.UnitChannel1OutputEvent +=
                new EventHandler<UnitRecordChannelEventArgs>(unitChannel1OperationAvailable);

            udpDataPublisher.UDPUnitChannel1OutputEvent +=
                new EventHandler<UDPUnitRecordChannelEventArgs>(unitChannel1UDPOperationAvailable);

            Debug.WriteLine("IBM1402Form: Subscribed to unit record events.");
        }

        //  Right now, the unit record devices are just UDP, so ignore serial requests
        void unitChannel1OperationAvailable(object sender, UnitRecordChannelEventArgs e) {
            //  Right now, just using UDP, so ignore serial port requests.
        }

        void unitChannel1UDPOperationAvailable(object sender, UDPUnitRecordChannelEventArgs e) {

            //  The CPU has asked the 1414 to have a unit record device do something...
            //  It might or might NOT be the reader...

            //  If this really isn't for us, ignore it.

            if (e.DispatchCode != UNITRECORDFROM1414FLAG) {
                return;
            }

            Debug.WriteLine("IBM1402Form: Processing UDP Input.");

            //  Loop through the bytes (hopefully / typically, the entire packet)

            for (int i = 0; i < e.UDPLen; i++) {
                //  TODO: Make sure the other unit record devices aren't active
                if (currentUnitRecordDevice == 0) {
                    //  If we are not currently processing a device, this byte is
                    //  the device code.
                    currentUnitRecordDevice = e.UDPBytes[i];
                    // Debug.WriteLine("IBM1402Form: Current Unit Record Device is " + currentUnitRecordDevice.ToString("X2"));
                    currentReaderOperation = 0;
                    currentPunchOperation = 0;
                }
                else if (currentUnitRecordDevice == READERCH1FLAG) {
                    //  The current unit record device is the reader, so process it.
                    readerMessageInputAvailable((byte)e.UDPBytes[i]);
                }
                else if (currentUnitRecordDevice == PUNCHCH1FLAG) {
                    punchMessageInputAvailable((byte)e.UDPBytes[i]);
                }
                else if (e.UDPBytes[i] == 0) {
                    //  For any other device (e.g., printer, for now), just ignore the data until we see a 0x00
                    //  This means that even the printer forms control message must have a 0x00 terminator.
                    currentUnitRecordDevice = 0;
                }
            }
        }

        //  Method to actually handle a byte of data from the FPGA (IBM 1414, if you will)

        void readerMessageInputAvailable(byte c) {

            Helpers.checkNesting("UDP Reader", ++readerNestCount);

            //  0 Terminates the reader request when receiving data, though this should
            //  never actually occur, for a reader...

            if (c == 0) {
                currentReaderOperation = 0;
                currentUnitRecordDevice = 0;
                --readerNestCount;
                return;
            }

            //  The first byte should be an operation code.  And for the reader,
            //  That is ALL we expect - we do not expect a trailing 00.

            if (currentReaderOperation == 0) {
                if ((c & READERFEEDOPERATION) == READERFEEDOPERATION) {
                    currentReaderOperation = c;
                    doSelectStackerFeed();
                }
                else {
                    Debug.WriteLine("IBM1402Form.readerMessageInputAvailable: Invalid reader operation code: " + c.ToString("X2"));
                    MessageBox.Show("IBM1402Form.readerMessageInputAvailable: Invalid reader operation code: " + c.ToString("X2"));
                }
                currentReaderOperation = 0;
                currentUnitRecordDevice = 0;
            }

            --readerNestCount;
        }

        void punchMessageInputAvailable(byte c) {

            if (c == 0) {

                //  A 0 byte terminates the card image.

                IBM1402Stacker stacker = null;
                switch (currentPunchOperation) {
                    case 0x40: stacker = punchStacker0; break;
                    case 0x44: stacker = punchStacker4; break;
                    case 0x48: stacker = punchStacker8; break;
                    default: stacker = null; break;
                }
                if (stacker == null) {
                    Debug.WriteLine("IBM1402Form.punchMessageInputAvailable: Unexpected punch operation received from FPGA: " + currentPunchOperation.ToString("X2"));
                    MessageBox.Show("IBM1402Form.punchMessageInputAvailable: Unexpected punch operation received from FPGA: " + currentPunchOperation.ToString("X2"));
                }
                else {
                    // Debug.WriteLine("IBM1402Form: Stacking punched card.");
                    stacker.Stack(this, punchedCard);
                }
                punchedCard = null;
                currentUnitRecordDevice = 0;
                currentPunchOperation = 0;
                return;
            }

            if (currentPunchOperation == 0) {
                if ((c & PUNCHOPERATION) == PUNCHOPERATION) {
                    currentPunchOperation = c;
                    // Debug.WriteLine("IBM1402Form: Current Punch Operation is " + currentPunchOperation.ToString("X2"));
                    punchedCard = new IBM1410Card();
                }
                else {
                    Debug.WriteLine("IBM1402Form.punchMessageInputAvailable: Invalid punch operation code: " + c.ToString("X2"));
                    MessageBox.Show("IBM1402Form.punchMessageInputAvailable: Invalid punch operation code: " + c.ToString("X2"));
                }
            }

            else {
                //  Add the character, stripping the 0x40 parity bit, and translating to ASCII.
                Debug.WriteLine("IBM1402Form: Adding byte to card: " + (c & 0x3f).ToString("X2"));
                Debug.WriteLine("IBM1402Form: BCD to ASCII is:     " + ((byte)IBM1410BCD.BCDtoASCII((byte)(c & 0x3f))).ToString("X2"));

                if (punchedCard.addByte((byte)IBM1410BCD.BCDtoASCII((byte)(c & 0x3f))) == false) {
                    Debug.WriteLine("IBM1402Form.punchMessageInputAvailable: Punched card data image > 80 characters.");
                    MessageBox.Show("IBM1402Form.punchMessageInputAvailable: Punched card data image > 80 characters.");
                }
            }
        }

        //  Method to stack the card in the raed station, if any, and feed the next card

        private void doSelectStackerFeed() {

            IBM1402Stacker stacker = null;

            //  If the reader is currently busy or not ready, report that.

            if (readerBusy || !readerReady) {
                Debug.WriteLine("IBM1402Form: Sending busy [which isn't done here anyway] or [so must be] not ready...");
                sendReaderStatus();
                return;
            }

            //  If there is a card at the read station, stack it.

            if (readStation != null) {
                switch (currentReaderOperation) {
                    case 0x10: stacker = readerStacker0; break;
                    case 0x11: stacker = readerStacker1; break;
                    case 0x12: stacker = readerStacker2; break;
                    default: stacker = null; break;
                }
                if (stacker == null) {
                    Debug.WriteLine("IBM1402Form.doSelectStackerFeed: Unexpected reader operation received from FPGA: " + currentReaderOperation.ToString("X2"));
                    MessageBox.Show("IBM1402Form.doSelectStackerFeed: Unexpected reader operation received from FPGA: " + currentReaderOperation.ToString("X2"));
                }
                else {
                    stacker.Stack(this, readStation);
                }
                readStation = null;
            }

            //  If there is no card presently at the check station, we are done, and
            //  are now net ready.

            if (checkStation == null) {
                readerReady = false;
                Debug.WriteLine("IBM1402Form: Reader out of cards.");
                sendReaderStatus();
                return;
            }

            //  At this point, the readStation is gauranteed to be empty, and
            //  and check station is guaranteed to NOT be empty.

            readStation = checkStation;
            checkStation = FeedCard();

            //  If there is no new card, and there has been a card read and it is at 
            //  the read station, and the EOF button was pressed that is the last card.

            if (checkStation == null && readStation != null && readerEOF) {
                Debug.WriteLine("IBM1402Form: Setting readerEOF to true - no more cards.");
                readStation.setLastCard(true);
            }

            //  If there is a card at the check station, or, if EOF is pressed, 
            //  there is at least a card at the read station, all is OK.  If so,
            //  Then send the card image to the buffer on the 1414 (i.e., the FPGA)

            if (checkStation != null || (readStation != null && readStation.getLastCard())) {
                readerReady = true;
                if (readStation.getLastCard() == true) {
                    Debug.WriteLine("IBM1402Form: Reader still ready for last card.");
                }
            }
            else {
                readerReady = false;
                Debug.WriteLine("IBM1402Form: Reader Not Ready after last card.");
            }

            //  TODO: The following code is identical to the startButton code, and should be
            //  factored out some day

            //  Set the ready light to the correct state

            labelReaderReady.ForeColor = readerReady ? Color.SeaGreen : Color.DimGray;
            labelReaderStop.ForeColor = Color.DimGray;
            readerStartButton.Enabled = !readerReady;
            readerStopButton.Enabled = readerReady;

            //  If there is data at the read station, send that off to the 1414 (FPGA)

            if (readStation != null) {
                sendReadStation();

                //  If we just sent the last card, reset the EOF status

                if (readStation.lastCard) {
                    readerEOF = false;
                    readerLastCard = false;
                }
            }
            else {
                //  Send the reader status to the FPGA (1414) if we didn't just send it.
                sendReaderStatus();
            }
        }

        //  Method to set the status bits for the reader, and send them off to the FPGA

        private void sendReaderStatus() {

            byte[] statusBuffer = new byte[4];

            readerStatus = 0;
            if (readerReady) {
                readerStatus |= readerIsReady;
            }
            if (readerBusy) {
                readerStatus |= readerIsBusy;
            }
            if (readerDataCheck) {
                readerStatus |= readerIsDataCheck;
            }
            if (readerLastCard) {
                readerStatus |= readerIsLastCard;
                Debug.WriteLine("IBM1402Form: Sending last card status.");
            }
            if (readerWLR) {
                readerStatus |= readerIsWLR;
            }

            //  For now, serial port version NOT implemented.

            //  Send the updated status to the FPGA...

            Helpers.checkNesting("Reader Status Semaphore: ", ++statusNestCount);
            udpOutputSemaphore.Wait();
            statusBuffer[0] = UNITRECORDTO1414FLAG;
            statusBuffer[1] = READERCH1FLAG;
            statusBuffer[2] = STATUSUPDATEOPERATION;
            statusBuffer[3] = readerStatus;
            udpClient.Send(statusBuffer, statusBuffer.Length);
            udpOutputSemaphore.Release();

            Debug.WriteLine("IBM1402Form: Updated reader status to " + statusBuffer[3].ToString("X2"));
            --statusNestCount;
        }

        //  Method to send status of the punch.  For now, just the stop and start
        //  buttons.  In theory, it should also deal with a full stacker.

        private void sendPunchStatus() {
            byte[] statusBuffer = new byte[4];

            punchStatus = 0;
            if (punchReady) {
                punchStatus |= punchIsReady;
            }
            if (punchBusy) {
                punchStatus |= punchIsBusy;
            }

            //  For now, serial port version NOT implemented.

            //  Send the updated status to the FPGA...

            udpOutputSemaphore.Wait();
            statusBuffer[0] = UNITRECORDTO1414FLAG;
            statusBuffer[1] = PUNCHCH1FLAG;
            statusBuffer[2] = STATUSUPDATEOPERATION;
            statusBuffer[3] = punchStatus;
            udpClient.Send(statusBuffer, statusBuffer.Length);
            udpOutputSemaphore.Release();

        }

        //  Method to process the 1402 Reader Load Button - as though we just
        //  loaded in some cards.  It does not actually feed the cards, though.

        private void loadButton_Click(object sender, EventArgs e) {
            if (readerOpenFileDialog.ShowDialog() == DialogResult.OK) {
                if (readerFileStream != null) {
                    readerFileStream.Close();
                    readerFileStream = null;

                    //  TODO: For now, just clear the read a check station as though the operator
                    //  ran out the cards.  Later, maybe add an option/check box for that.

                    readStation = null;
                    checkStation = null;
                }
                try {
                    readerFileStream = new FileStream(readerOpenFileDialog.FileName,
                        FileMode.Open, FileAccess.Read);
                    loadButton.Enabled = false;
                    // labelReaderReady.ForeColor = Color.SeaGreen;
                    // readerReady = true;
                    readerReady = false;
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

            // if (readerFileStream == null || readerReady == false) {
            if (readerFileStream == null) {
                MessageBox.Show("ERROR: Unexpected Reader Start when no file loaded");
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

            labelReaderReady.ForeColor = readerReady ? Color.SeaGreen : Color.DimGray;
            labelReaderStop.ForeColor = Color.DimGray;
            readerStartButton.Enabled = !readerReady;
            readerStopButton.Enabled = readerReady;

            //  Send the reader status to the FPGA (1414)

            sendReaderStatus();

            //  If there is data at the read station, send that off to the FPGA

            if (readStation != null) {
                sendReadStation();

                //  If we just sent the last card, reset the EOF status

                if (readStation.lastCard) {
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
            readerStopButton.Enabled = false; // Consider leaving it enabled?
            labelReaderReady.ForeColor = Color.DimGray;
            loadButton.Enabled = true;
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

            if (readerFileStream == null || card == null) {
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

            // Debug.WriteLine("Exit card read loop with i of " + i.ToString());

            //  The last character we saw should be the newline.

            if (c != '\n') {
                Debug.WriteLine("Warning: IBM1402Form.Feed: No newline found within 82 characters of card image.");
                MessageBox.Show("Warning: IBM1402Form.Feed: No newline found within 82 characters of card image.");
                card.setWrongLengthRecord(true);
            }

            if (i > 0 && temp[i - 1] == '\r') {
                temp[i - 1] = (byte)' ';
                // Debug.WriteLine("Changing carriage return at loction " + (i-1).ToString());
            }

            //  Change the newline and any trailing garbage to spaces

            for (; i < 80; ++i) {
                temp[i] = (byte)' ';
                // Debug.WriteLine("Adding padding at i of " + i.ToString());
            }

            //  Assign the data to the card image.

            card.image = temp[0..80];

            return (card);
        }

        //  Method to send a card image to the FPGA (1414 IO Synchronizer)

        private void sendReadStation() {
            int i, n;
            byte[] card = readStation.image;
            byte[] message = new byte[readStation.image.Length + 4];
            byte bcdChar;
            string debugMsg;

            readerDataCheck = false;
            message[0] = UNITRECORDTO1414FLAG;
            message[1] = READERCH1FLAG;
            message[2] = SENDCARDOPERATION;
            n = 3;

            //  Convert the data from ASCII to BCD, filling in the message along the way.
            //  If invalid data is found, set that status too...

            readStation.setDataCheck(false);

            Debug.WriteLine("IBM1402Form: Card image length is " + card.Length.ToString());
            for (i = 0; i < card.Length; ++i) {
                bcdChar = IBM1410BCD.ASCIItoBCD((char)(card[i]));
                if (bcdChar == 0xff) {
                    readStation.setDataCheck(true);
                    //  This messed up diagnostic... bcdChar = IBM1410BCD.BCD_ASTERISK; // Asterisk insert.  ;)
                    message[n++] = (byte)(0x3f);    // Make this one even parity to cause an error
                }
                else {
                    //  Calculate odd parity, and put it in bit SIX (because message data can't
                    //  set bit 7!).  We are sending odd parity - but it may have made more sense
                    //  to send even parity.  Oh well....

                    message[n++] = (byte)(bcdChar | (IBM1410BCD.CalculateOddParity(bcdChar) << 6));
                    // Debug.WriteLine("Put character in reader buffer: " +
                    //  ((bcdChar | (IBM1410BCD.CalculateOddParity(bcdChar) << 6)).ToString("X2")) );
                }
            }

            message[n++] = 0;  //  Trailing 0 on the card image in the message by convention.

            //  Update the reader status first.  That will either set or clear the WLR and data check in the FPGA
            //  It also updates the last card status in the 1414.

            readerWLR = readStation.getWrongLengthRecord();
            readerDataCheck = readStation.getDataCheck();
            readerLastCard = readStation.getLastCard();

            sendReaderStatus();

            //  Send the card image.


            Debug.WriteLine("IBM1402Form: Sending BCD Card image: ");
            debugMsg = "IBM1402Form: ";
            for(int c = 0; c <= n && c < message.Length-1; ++c) {
                debugMsg = debugMsg + message[c].ToString("X2") + " ";
            }
            Debug.WriteLine(debugMsg);

            udpOutputSemaphore.Wait();
            udpClient.Send(message, n);
            udpOutputSemaphore.Release();

            //  Consider setting readStation to null here...

        }

        //  Handler methods for all of the stacker buttons - opens a dialog

        private void punch0StackerButton_Click(object sender, EventArgs e) {
            IBM1402StackerForm form = new IBM1402StackerForm(punchStacker0);
            form.ShowDialog();
            form = null;
        }

        private void punch4StackerButton_Click(object sender, EventArgs e) {
            IBM1402StackerForm form = new IBM1402StackerForm(punchStacker4);
            form.ShowDialog();
            form = null;
        }

        private void middleStackerButton_Click(object sender, EventArgs e) {
            IBM1402StackerForm form = new IBM1402StackerForm(readerStacker2);
            form.ShowDialog();
            form = null;
        }

        private void reader1StackerButton_Click(object sender, EventArgs e) {
            IBM1402StackerForm form = new IBM1402StackerForm(readerStacker1);
            form.ShowDialog();
            form = null;
        }

        private void reader0StackerButton_Click(object sender, EventArgs e) {
            IBM1402StackerForm form = new IBM1402StackerForm(readerStacker0);
            form.ShowDialog();
            form = null;
        }

        private void testButton_Click(object sender, EventArgs e) {
            IBM1410Card card = new IBM1410Card();
            card.image = Encoding.ASCII.GetBytes("Test Card Image ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789 @#$%+-()*");
            card.selectStacker(readerStacker2);
            card.Stack(this);
        }

        private void punchStartButton_Click(object sender, EventArgs e) {
            punchReady = true;
            punchBusy = false;
            labelPunchReady.ForeColor = Color.SeaGreen;
            sendPunchStatus();
        }

        private void punchStopButton_Click(object sender, EventArgs e) {
            punchReady = false;
            punchBusy = false;
            labelPunchReady.ForeColor = Color.DimGray;
            sendPunchStatus();
        }

        private void IBM1402Form_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
