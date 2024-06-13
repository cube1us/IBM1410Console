using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBM1410Console
{
    public partial class IBM1410TapesForm : Form {

        private int currentChannel;
        private int currentUnit;

        private IBM1410TapeUnit channel1SelectedUnit = null;
        private IBM1410TapeUnit channel2SelectedUnit = null;

        private IBM1410TapeUnit[,] TapeUnits = null;
        private IBM1410TapeUnit tapeUnit = null;

        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;
        private SerialDataPublisher serialDataPublisher;

        private enum ChanneReceiveState { receiveIdle, receivingOperation, receivingData };
        ChanneReceiveState channel1ReceiveState = ChanneReceiveState.receiveIdle;
        ChanneReceiveState channel2ReceiveState = ChanneReceiveState.receiveIdle;

        const byte READDATAFLAG = 0x40;
        
        const byte CHANNEL1TOFPGAFLAG = 0x84;
        const byte CHANNEL2TOFPGAFLAG = 0x83;

        public const byte TAPEOPERRESETTI = 0x3f;
        public const byte TAPEOPERREWIND = 0x40;
        public const byte TAPEOPERUNLOAD = 0x20;
        public const byte TAPEOPERWTM = 0x10;
        public const byte TAPEOPERERASE = 0x08;
        public const byte TAPEOPERBACKSPACE = 0x04;
        public const byte TAPEOPERWRITE = 0x02;
        public const byte TAPEOPERREAD = 0x01;

        public const byte TAPEENDOFRECORD = 0x00;

        //  Constructor

        public IBM1410TapesForm(SerialDataPublisher serialDataPublisher, 
            SerialPort serialPort, SemaphoreSlim serialOutputSemaphore) {

            int c, u;

            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;  
            this.serialDataPublisher = serialDataPublisher;

            InitializeComponent();
            this.CreateHandle();        // Ensures controls created before we get data from FPGA

            //  Instantiate the tape units

            TapeUnits = new IBM1410TapeUnit[3, 10];

            for (c = 1; c < 2; ++c) {
                for (u = 0; u < 10; ++u) {
                    TapeUnits[c,u] = new IBM1410TapeUnit(serialPort, serialOutputSemaphore, c, u);
                    TapeUnits[0, u] = null; 
                }
            }

            currentChannel = 1;
            currentUnit = 0;
            tapeUnit = TapeUnits[currentChannel,currentUnit];

            unitDial.Value = currentUnit;
            unitDial.Maximum = 9;
            unitDial.Minimum = 0;

            loadButton.Enabled = false; 
            startButton.Enabled = false;
            unloadButton.Enabled = false;

            serialDataPublisher.TapeChannel1OutputEvent +=
                new EventHandler<TapeChannelEventArgs>(tapeChannel1OutputAvailable);

            serialDataPublisher.TapeChannel2OutputEvent +=
                new EventHandler<TapeChannelEventArgs>(tapeChannel1OutputAvailable);

            Debug.WriteLine("Event Handlers for SerialDataPublisher (Tapes) Registered.");
        }

        void tapeChannel1OutputAvailable(object sender, TapeChannelEventArgs e) {

            //  TODO:  Move most of this code into another method, with channel as a parameter.

            byte c = (byte) e.SerialByte;

            Debug.WriteLine("Entered serial dispatch for tape channel 1, code " + e.DispatchCode.ToString());

            //  Is this data really for me?

            if (e.DispatchCode != SerialDataPublisher.tapeChannel1FromTAUCodeByte) {
                return;
            }

            Debug.WriteLine("Channel 1 Tape input from serial port: " + c.ToString("X2"));

            switch (channel1ReceiveState) {

                //  In the Idle state, we expect to receive a unit number

                case ChanneReceiveState.receiveIdle:
                
                    // Received a unit, perhaps with an X'40' flag for reading data.
                    
                    if((c & 0x0f) > 10) {
                        Debug.WriteLine("Channel 1 INVALID tape unit " + c.ToString("X2"));
                        return;
                    }

                    //  Did the selected unit change?  If so, deselect the old one,
                    //  before selecting the new one.

                    if(channel1SelectedUnit != null) {
                        if(channel1SelectedUnit.UnitNumber != (c & 0x0f)) {
                            channel1SelectedUnit.Select(false);
                        }
                    }

                    channel1SelectedUnit = TapeUnits[1, c & 0x0f];
                    channel1SelectedUnit.Select(true);
                    channel1ReceiveState = ChanneReceiveState.receivingOperation;
                    break;

                //  In the receiving Operation state, we expect to get a valid tape operation.

                case ChanneReceiveState.receivingOperation:

                    switch (c) {
                        case TAPEOPERREAD:
                            ReadTapeRecord(channel1SelectedUnit);
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        case TAPEOPERWRITE:
                            channel1ReceiveState = ChanneReceiveState.receivingData;
                            break;
                        case TAPEOPERBACKSPACE:
                            channel1SelectedUnit.Backspace();
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        case TAPEOPERERASE:
                            channel1SelectedUnit.Skip();
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        case TAPEOPERWTM:
                            channel1SelectedUnit.WriteTM();
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        case TAPEOPERUNLOAD:
                            channel1SelectedUnit.RewindUnload();
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        case TAPEOPERREWIND:
                            channel1SelectedUnit.Rewind();
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        case TAPEOPERRESETTI:
                            channel1SelectedUnit.ResetTapeIndicate();
                            channel1ReceiveState = ChanneReceiveState.receiveIdle;
                            break;
                        default:
                            Debug.WriteLine("Channel 1 INVALID tape operation " + c.ToString("X2"));
                            return;
                    }
                    break;
                
                //  State for receing data (Write to tape).  X'40' marks the end of the record

                case ChanneReceiveState.receivingData:
                    if(c == TAPEENDOFRECORD) {
                        channel1SelectedUnit.WriteIRG();
                        Debug.WriteLine("Channel 1 Write tape end of record." + c.ToString("X2"));
                        channel1ReceiveState = ChanneReceiveState.receiveIdle;
                    }
                    else {
                        channel1SelectedUnit.Write(c);
                        channel1ReceiveState = ChanneReceiveState.receivingData;
                        Debug.WriteLine("Channel 1 write tape wrote the byte");
                    }
                    break;

                default:
                    channel1ReceiveState = ChanneReceiveState.receiveIdle;
                    Debug.WriteLine("Channel 1 Tape state machine, INVALID state.");
                    break;

            }

            Debug.WriteLine("Tape Channel 1 leaving output available routine...");

            //  If the current tape unit on the GUI is the same as this one, 
            //  Update the info displayed.

            if (channel1SelectedUnit != null && tapeUnit != null &&
                tapeUnit.ChannelNumber == channel1SelectedUnit.ChannelNumber &&
                tapeUnit.UnitNumber == channel1SelectedUnit.UnitNumber) {
                Display();
            }

        }

        void tapeChannel2OutputAvailable(object sender, TapeChannelEventArgs e) {
            return;
        }

        
        //  Method to read a tape record and send it off to the FPGA.  Ideally, this thing
        //  would send it in pieces, but for now, it holds the semaphore for the entire block.

        private void ReadTapeRecord(IBM1410TapeUnit tapeUnit) {

            int c;
            byte[] bytes = new byte[1];

            byte[] tapeTestData = {
                0x10, 0x01, 0x02, 0x43, 0x04, 0x45, 0x46, 0x07,
                0x08, 0x49, 0x4a, 0x0b, 0x4c, 0x0d, 0x0e, 0x4f,
                0x10, 0x51, 0x52, 0x13
             };


            Debug.WriteLine("Begin Tape read, unit " + tapeUnit.ChannelNumber.ToString() +
                tapeUnit.UnitNumber.ToString());

            //  Obtain access to the serial port for access.

            serialOutputSemaphore.Wait();

            //  Send the channel 1 flag to the FPGA

            bytes[0] = CHANNEL1TOFPGAFLAG;
            serialPort.Write(bytes, 0, 1);

            //  Send the unit number + 0x40 to the FPGA to signal input data

            bytes[0] = (byte)(tapeUnit.UnitNumber | READDATAFLAG);  
            serialPort.Write(bytes, 0, 1);
            
            for (int i = 0; i < tapeTestData.Length; i++) {
                serialPort.Write(tapeTestData, i, 1);
            }

            bytes[0] = TAPEENDOFRECORD;
            serialPort.Write(bytes, 0, 1);


                /*
                while (true) {
                    c = tapeUnit.Read();
                    if (c == IBM1410TapeUnit.TAPEUNITNOTREADY || c == IBM1410TapeUnit.TAPEUNITIRG) {
                        //  Unit went not ready, or end of record -- return IRG
                        bytes[0] = TAPEENDOFRECORD;
                    }
                    else {
                        bytes[0] = (byte)(c & 0x3f);
                    }

                    serialPort.Write(bytes, 0, 1);
                    if (bytes[0] == TAPEENDOFRECORD) { 
                        break;
                    }
                }
                */

            //  Release the lock on the serial port.

            serialOutputSemaphore.Release();

            Debug.WriteLine("Ending Channel 1 tape read");
        }


        //  Click on the unit number
        private void unitDial_ValueChanged(object sender, EventArgs e) {
            currentUnit = (int)unitDial.Value;
            tapeUnit = TapeUnits[currentChannel,currentUnit];
            Display();
        }


        //  Click on the channel number

        private void channelButton_Click(object sender, EventArgs e) {
            if (currentChannel == 1) {
                currentChannel = 2;
            }
            else {
                currentChannel = 1;
            }
            channelButton.Text = currentChannel.ToString();
            tapeUnit = TapeUnits[currentChannel,currentUnit];
            Display();
        }


        //  Click on the Load/Rewind button.
        private void loadButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                tapeUnit.LoadRewind();
                Display();
            }
        }


        //  Start button click
        private void startButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                tapeUnit.Start();
                Display();
            }
        }


        //  Density Change
        private void densityButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                tapeUnit.ChangeDensity();
                Display();
            }
        }


        //  Unload
        private void unloadButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                tapeUnit.Unload();
                Display();
            }
        }


        //  Reset
        private void resetButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                tapeUnit.Reset();
                Display();
            }
        }


        //  Mount a tape (file)

        private void mountButton_Click(object sender, EventArgs e) { 
            if(tapeUnit != null && openFileDialog.ShowDialog() == DialogResult.OK) {
                fileNameLabel.Text = openFileDialog.FileName;
                tapeUnit.Mount(fileNameLabel.Text);
                Display();
            }
        }

        //  Update the display...

        void Display() {
            if (tapeUnit == null) {
                return;
            }

            //  Because this method may be called from the serial data publisher thread,
            //  the various updates need to be thread-safe.

            Action safeDisplay = delegate
            {

                readyLabel.ForeColor = tapeUnit.Ready ? Color.White : Color.DarkGray;
                selectLabel.ForeColor = tapeUnit.Selected ? Color.White : Color.DarkGray;
                protectLabel.ForeColor = tapeUnit.FileProtect ? Color.White : Color.DarkGray;
                tapeIndicateLabel.ForeColor = tapeUnit.TapeIndicate ? Color.White : Color.DarkGray;
                densityLabel.ForeColor = tapeUnit.HighDensity ? Color.White : Color.DarkGray;
                fileNameLabel.Text = tapeUnit.FileName;
                recordNumberLabel.Text = tapeUnit.RecordNumber.ToString();

            };

            this.Invoke(safeDisplay);

            //  Enable or disable buttons appropriate to the status of the drive.
            //  Again, these need to be thread-safe.

            Action safeButtonsDisplay = null;

            if (tapeUnit.Ready) {
                safeButtonsDisplay = delegate
                {
                    mountButton.Enabled = false;
                    loadButton.Enabled = false;
                    startButton.Enabled = false;
                    unloadButton.Enabled = false;
                    resetButton.Enabled = true;
                };
            }
            else if (tapeUnit.Loaded) {
                safeButtonsDisplay = delegate
                {
                    mountButton.Enabled = false;
                    loadButton.Enabled = false;
                    startButton.Enabled = true;
                    unloadButton.Enabled = true;
                    resetButton.Enabled = true;
                };
            }
            else if (tapeUnit.FileName != null && tapeUnit.FileName.Length > 0) {
                safeButtonsDisplay = delegate
                {
                    mountButton.Enabled = true;
                    loadButton.Enabled = true;
                    startButton.Enabled = false;
                    unloadButton.Enabled = false;
                    resetButton.Enabled = true;
                };
            }
            else {
                safeButtonsDisplay = delegate
                {
                    mountButton.Enabled = true;
                    loadButton.Enabled = false;
                    startButton.Enabled = false;
                    unloadButton.Enabled = false;
                    resetButton.Enabled = true;
                };
            }

            this.Invoke(safeButtonsDisplay);

        }
    }
}
