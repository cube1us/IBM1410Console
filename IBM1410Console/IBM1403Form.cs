using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBM1410Console

    /*
    * Printer FPGA <-> PC Support Program protocols:
    * 
    * For PC => FPGA:
    *    Channel Character [CR]:            0x85 (Both Channels)
    *    Unit Record Device Char [UD]:      0x02 (Printer Ch1)
    *    Status Operation Code Char [SO]:   0x01
    *    Status from PC to FPGA:            [CR] [UD] [SO] [Status]
    * 
    * For FPGA => PC
    *    Channel Character [CW]:            0x83 (Both channels)
    *    Unit Record Device Char [UD]:      0x02 (Printer Ch1)
    *    Unt Operation Char [OP]:           0x20 (print) or 0x2F (Carriage Control)
    *    Message from FPGA to PC:           [CW] [UD] [OP] [data bytes - print line or CC char] [0x00]
    * 
    */

{
    public partial class IBM1403Form : Form
    {

        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;
        private SerialDataPublisher serialDataPublisher;
        private UDPDataPublisher udpDataPublisher;
        private UdpClient udpClient = null;
        private SemaphoreSlim udpOutputSemaphore = null;
        private byte[] printLine;

        private Boolean printerReady = false;
        private Boolean printerBusy = false;

        public const int printerIsReady = 0x01;
        public const int printerIsBusy = 0x02;

        private int currentUnitRecordDevice = 0;
        private int currentPrinterOperation = 0;
        private int currentPrinterColumn = 0;
        private byte currentCarriageControlCharacter = 0;

        public const byte UNITRECORDFLAG = 0x85;
        public const byte READERCH1FLAG = 0x01;
        public const byte PRINTERCH1FLAG = 0x02;
        public const byte PRINTERCH2FLAG = 0x42;

        public const byte STATUSUPDATEOPERATION = 0x01;
        public const byte PRINTEROPERATION = 0x20;
        public const byte FORMSOPERATION = 0x2F;
        public const int PRINTERLINELENGTH = 132;

        private byte printerStatus = 0;               // Not Ready by default

        public IBM1403Form(SerialDataPublisher serialDataPublisher,
            UDPDataPublisher udpDataPublisher,
            SerialPort serialPort, SemaphoreSlim serialOutputSemaphore,
            UdpClient udpClient, SemaphoreSlim udpOutputSemaphore) {

            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;
            this.udpDataPublisher = udpDataPublisher;
            this.udpClient = udpClient;
            this.udpOutputSemaphore = udpOutputSemaphore;
            printLine = null;

            InitializeComponent();      // Create the buttons, etc.
            this.CreateHandle();        // Ensure controls are created before we get FPGA data

            printerStartButton.Enabled = true;
            printerStopButton.Enabled = true;

            serialDataPublisher.UnitChannel1OutputEvent +=
                new EventHandler<UnitRecordChannelEventArgs>(unitChannel1OperationAvailable);

            udpDataPublisher.UDPUnitChannel1OutputEvent +=
                new EventHandler<UDPUnitRecordChannelEventArgs>(unitChannel1UDPOperationAvailable);

            Debug.WriteLine("Event Handlers for Serial and UDP Data Publishers (Printer) Registered.");

        }

        //  Right now, the unit record devices are just UDP, so ignore serial requests
        void unitChannel1OperationAvailable(object sender, UnitRecordChannelEventArgs e) {
            //  Right now, just using UDP, so ignore serial port requests.
        }

        //  Method that receives subscribed-to events for unit record messages.
        //  (There are to such subscribers right now, the other being the reader/punch)
        void unitChannel1UDPOperationAvailable(object sender, UDPUnitRecordChannelEventArgs e) {

            //  The CPU has asked the 1414 to have a unit record device do something...
            //  It might or might NOT be the reader...

            //  If this really isn't for us, ignore it.

            if (e.DispatchCode != UNITRECORDFLAG) {
                return;
            }

            //  Loop through the bytes (hopefully / typically, the entire packet)

            for (int i = 0; i < e.UDPLen; i++) {
                //  TODO: Make sure the other unit record devices aren't active
                if (currentUnitRecordDevice == 0) {
                    //  If we are not currently processing a device, this byte is
                    //  the device code.
                    currentUnitRecordDevice = e.UDPBytes[i];
                    currentPrinterOperation = 0;
                }
                else if (currentUnitRecordDevice == READERCH1FLAG) {
                    //  The current unit record device is the reader, so ignore it.
                    //  But this needs to be here because the reader message does NOT have
                    //  a 0x00 terminator - so we need to reset the device code.
                    currentPrinterOperation = 0;
                    currentCarriageControlCharacter = 0;
                    currentUnitRecordDevice = 0;
                }
                else if (currentUnitRecordDevice == PRINTERCH1FLAG) {
                    //  The current unit record device is the printer, so process it.
                    printerMessageInputAvailable((byte)e.UDPBytes[i]);
                }
                else if (e.UDPBytes[i] == 0) {
                    //  For any other device (e.g., the punch, for now), just ignore the data until we see a 0x00
                    currentUnitRecordDevice = 0;
                }
            }
        }

        //  Method to actually handle a byte of data from the FPGA (the IBM 1414, if you will)
        //  that is destined for the printer.

        void printerMessageInputAvailable(byte c) {

            //  0 Terminates the printer request when receiving data, whether a print line or a carriage control request

            if (c == 0) {
                currentPrinterOperation = 0;
                currentUnitRecordDevice = 0;
                return;
            }

            //  The first byte should be an operation code.

            if (currentPrinterOperation == 0) {
                if ((c & PRINTEROPERATION) == PRINTEROPERATION) {
                    currentPrinterOperation = c;
                    if (currentPrinterOperation == PRINTEROPERATION) {
                        printLine = new byte[PRINTERLINELENGTH];
                        currentPrinterColumn = 0;
                    }
                    else if (currentPrinterOperation == FORMSOPERATION) {
                        printLine = null;
                    }
                }
                else {
                    Debug.WriteLine("IBM1402Form.printerMessageInputAvailable: Invalid printer operation code: " + c.ToString("X2"));
                    MessageBox.Show("IBM1402Form.printerMessageInputAvailable: Invalid printer operation code: " + c.ToString("X2"));
                }
                currentPrinterOperation = 0;
                currentUnitRecordDevice = 0;
            }


            else {
                if (c == 0) {
                    if (currentPrinterOperation == PRINTEROPERATION) {
                        if (currentPrinterColumn != PRINTERLINELENGTH) {
                            Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Print line data image < 132 characters.");
                            MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Print line data image < 132 characters.");
                        }
                        printerRichTextBox1.AppendText(System.Text.Encoding.ASCII.GetString(printLine) + "\n");
                        printLine = null;
                        currentPrinterOperation = 0;
                        currentUnitRecordDevice = 0;
                    }
                    else if (currentPrinterOperation == FORMSOPERATION) {
                        if (currentCarriageControlCharacter == 0) {
                            Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Empty carriage control message received.");
                            MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Empty carriage control message received.");
                        }
                        else {
                            //  TODO:  Actually do the carriage control operation.
                        }
                    }
                }
                else if (currentPrinterOperation == FORMSOPERATION) {
                    if (currentCarriageControlCharacter != 0) {
                        Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Multiple byte carriage control message received.");
                        MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Multiple byte carriage control message received.");
                    }
                    else {
                        currentCarriageControlCharacter = c;
                    }
                }
                else if (currentPrinterOperation == PRINTEROPERATION && currentPrinterColumn < PRINTERLINELENGTH) {
                    //  Strip the character's 0x40 parity bit, convert to ASCII, and append to the print line.
                    printLine.Append((byte)IBM1410BCD.BCDtoASCII((byte)(c & 0x3f)));
                    ++currentPrinterColumn;
                }
                else {
                    Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Print line data image > 132 characters.");
                    MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Print line data image > 132 characters.");
                }
            }

        }

        //  Method to send status of the punch.  For now, just the stop and start
        //  buttons.  In theory, it should also deal with a full stacker.

        private void sendPrinterStatus() {
            byte[] statusBuffer = new byte[4];

            printerStatus = 0;
            if (printerReady) {
                printerStatus |= printerIsReady;
            }
            if (printerBusy) {
                printerStatus |= printerIsBusy;
            }

            //  For now, serial port version NOT implemented.

            //  Send the updated status to the FPGA...

            udpOutputSemaphore.Wait();
            statusBuffer[0] = UNITRECORDFLAG;
            statusBuffer[1] = PRINTERCH1FLAG;
            statusBuffer[2] = STATUSUPDATEOPERATION;
            statusBuffer[3] = printerStatus;
            udpClient.Send(statusBuffer, statusBuffer.Length);
            udpOutputSemaphore.Release();

        }

        private void printerStartButton_Click(object sender, EventArgs e) {
            printerReady = true;
            printerBusy = false;
            sendPrinterStatus();
        }

        private void printerStopButton_Click(object sender, EventArgs e) {
            printerReady = false;
            printerBusy = false;
            sendPrinterStatus();
        }

        private void carriageStopButton_Click(object sender, EventArgs e) {
            printerStopButton_Click(sender,e);
        }
    }
}
