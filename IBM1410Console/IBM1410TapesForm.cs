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
using System.Net.Sockets;
using System.Windows.Forms.VisualStyles;

namespace IBM1410Console
{
    public partial class IBM1410TapesForm : Form
    {

        private int currentChannel;
        private int currentUnit;

        private IBM1410TapeUnit channel1SelectedUnit = null;
        private IBM1410TapeUnit channel2SelectedUnit = null;

        private IBM1410TapeUnit[,] TapeUnits = null;
        private IBM1410TapeUnit tapeUnit = null;

        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;
        private SerialDataPublisher serialDataPublisher;
        private UDPDataPublisher udpDataPublisher;

        private UdpClient udpClient = null;
        private SemaphoreSlim udpOutputSemaphore = null;

        private int[] recordSize = { 0, 0, 0 };

        private enum ChannelReceiveState { receiveIdle, receivingOperation, receivingData };
        ChannelReceiveState channel1ReceiveState = ChannelReceiveState.receiveIdle;
        ChannelReceiveState channel2ReceiveState = ChannelReceiveState.receiveIdle;

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

        // Sleep this amount for each tape packet sent so that we don't
        // overrun the 1410 channel at 9us per character.

        const int TAPEPACKETSLEEPTIME = 10;     

        //  Constructor

        public IBM1410TapesForm(SerialDataPublisher serialDataPublisher,
            UDPDataPublisher udpDataPublisher,
            SerialPort serialPort, SemaphoreSlim serialOutputSemaphore,
            UdpClient udpClient, SemaphoreSlim udpOutputSemaphore) {

            int c, u;

            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;
            this.serialDataPublisher = serialDataPublisher;
            this.udpDataPublisher = udpDataPublisher;
            this.udpClient = udpClient;
            this.udpOutputSemaphore = udpOutputSemaphore;

            InitializeComponent();
            this.CreateHandle();        // Ensures controls created before we get data from FPGA

            //  Instantiate the tape units

            TapeUnits = new IBM1410TapeUnit[3, 10];

            for (c = 1; c < 3; ++c) {
                for (u = 0; u < 10; ++u) {
                    TapeUnits[c, u] = new IBM1410TapeUnit(serialPort, serialOutputSemaphore,
                        udpClient, udpOutputSemaphore, c, u);
                    TapeUnits[0, u] = null;
                }
            }

            currentChannel = 1;
            currentUnit = 0;
            tapeUnit = TapeUnits[currentChannel, currentUnit];

            unitDial.Value = currentUnit;
            unitDial.Maximum = 9;
            unitDial.Minimum = 0;

            loadButton.Enabled = false;
            startButton.Enabled = false;
            unloadButton.Enabled = false;

            serialDataPublisher.TapeChannel1OutputEvent +=
                new EventHandler<TapeChannelEventArgs>(tapeChannel1OutputAvailable);

            serialDataPublisher.TapeChannel2OutputEvent +=
                new EventHandler<TapeChannelEventArgs>(tapeChannel2OutputAvailable);

            udpDataPublisher.UDPTapeChannel1OutputEvent +=
                new EventHandler<UDPTapeChannelEventArgs>(tapeChannel1UDPOutputAvailable);

            udpDataPublisher.UDPTapeChannel2OutputEvent +=
                new EventHandler<UDPTapeChannelEventArgs>(tapeChannel2UDPOutputAvailable);

            Debug.WriteLine("Event Handlers for Serial and UDP Data Publishers (Tapes) Registered.");
        }

        //  Methods that get called when serial data is available from the FPGA...

        void tapeChannel1OutputAvailable(object sender, TapeChannelEventArgs e) {

            //  Is this data really for me?

            if (e.DispatchCode != SerialDataPublisher.tapeChannel1FromTAUCodeByte) {
                return;
            }

            tapeSerialInputAvailable(1, (byte)e.SerialByte);
        }

        void tapeChannel2OutputAvailable(object sender, TapeChannelEventArgs e) {

            //  Is this data really for me?

            if (e.DispatchCode != SerialDataPublisher.tapeChannel2FromTAUCodeByte) {
                return;
            }

            tapeSerialInputAvailable(2, (byte)e.SerialByte);
        }

        //  Methods that get called when Ethernet UDP data is available from the FPGA...

        void tapeChannel1UDPOutputAvailable(object sender, UDPTapeChannelEventArgs e) {

            if(e.DispatchCode != UDPDataPublisher.tapeChannel1FromTAUCodeByte) {
                return;
            }

            // tapeSerialInputAvailable(1, (byte)e.UDPByte);

            for(int i = 0; i < e.UDPLen; ++i) {
                tapeSerialInputAvailable(1, (byte) e.UDPBytes[i]);
            }
        }

        void tapeChannel2UDPOutputAvailable(object sender, UDPTapeChannelEventArgs e) {

            if (e.DispatchCode != UDPDataPublisher.tapeChannel2FromTAUCodeByte) {
                return;
            }

            // tapeSerialInputAvailable(2, (byte)e.UDPByte);

            for (int i = 0; i < e.UDPLen; ++i) {
                tapeSerialInputAvailable(2, (byte)e.UDPBytes[i]);
            }

            // Debug.WriteLine("Dispatching bytes to TAU Channel 2");
        }


        //  Method to reset the tape receive state during a computer or program reset,
        //  for example

        public void tapeSerialStateReset() {
            Debug.WriteLine("IBM1410TapesForm: tapSerialStateReset()");
            channel1ReceiveState = ChannelReceiveState.receiveIdle;
            channel2ReceiveState = ChannelReceiveState.receiveIdle;
        }

        //  Method to actually handle a byte of data from the USB serial port
        //  for either channel

        void tapeSerialInputAvailable(int channel, byte c) {

            ChannelReceiveState channelReceiveState = channel == 1 ? channel1ReceiveState :
                channel2ReceiveState;
            IBM1410TapeUnit tapeUnit = channel == 1 ? channel1SelectedUnit :
                channel2SelectedUnit;

            String tapeUnitString = "";

            if (tapeUnit != null) {
                tapeUnitString = tapeUnit.ChannelNumber.ToString() + tapeUnit.UnitNumber.ToString();
            }

            // Debug.WriteLine("Entered serial dispatch for tape channel " + channel.ToString() +
            //    " data: " + c.ToString("X2"));

            switch (channelReceiveState) {

                //  In the Idle state, we expect to receive a unit number

                case ChannelReceiveState.receiveIdle:

                    // Received a unit, perhaps with an X'40' flag for reading data.

                    if ((c & 0x0f) > 10) {
                        Debug.WriteLine("Tape Channel " + channel.ToString() + " INVALID tape unit " +
                            c.ToString("X2"));
                        return;
                    }

                    //  Did the selected unit change?  If so, deselect the old one,
                    //  before selecting the new one.

                    if (tapeUnit != null) {
                        if (tapeUnit.UnitNumber != (c & 0x0f)) {
                            tapeUnit.Select(false);
                        }
                    }

                    tapeUnit = TapeUnits[channel, c & 0x0f];
                    if (channel == 1) {
                        channel1SelectedUnit = tapeUnit;
                    }
                    else {
                        channel2SelectedUnit = tapeUnit;
                    }

                    tapeUnit.Select(true);

                    //  Now that we know the unit number, we can also compose the string for
                    //  debug messages.  Hmmm: maybe TapeUnit should just have a method for this.

                    tapeUnitString = tapeUnit.ChannelNumber.ToString() + tapeUnit.UnitNumber.ToString();

                    //  New state is assigned to the internal variable - and then
                    //  copied to appropriate channel related variable later.

                    channelReceiveState = ChannelReceiveState.receivingOperation;

                    break;

                //  In the receiving Operation state, we expect to get a valid tape operation.

                case ChannelReceiveState.receivingOperation:

                    switch (c) {
                        case TAPEOPERREAD:
                            ReadTapeRecord(tapeUnit);
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        case TAPEOPERWRITE:
                            channelReceiveState = ChannelReceiveState.receivingData;
                            recordSize[channel] = 0;
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " begin write");
                            break;
                        case TAPEOPERBACKSPACE:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " Backspace");
                            tapeUnit.Backspace();
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        case TAPEOPERERASE:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " Erase");
                            tapeUnit.Skip();
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        case TAPEOPERWTM:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " WTM");
                            tapeUnit.WriteTM();
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        case TAPEOPERUNLOAD:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " Rewind Unload");
                            tapeUnit.RewindUnload();
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        case TAPEOPERREWIND:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " Rewind");
                            tapeUnit.Rewind();
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        case TAPEOPERRESETTI:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString + " Reset T.I. Request from FPGA");
                            tapeUnit.ResetTapeIndicate();
                            channelReceiveState = ChannelReceiveState.receiveIdle;
                            break;
                        default:
                            Debug.WriteLine("*** Tape Unit " + tapeUnitString +
                                " INVALID tape operation " + c.ToString("X2"));
                            //  In this case do NOT update the state variable for the affected channel.
                            return;
                    }
                    break;

                //  State for receivng data (Write to tape).  X'00' marks the end of the record

                case ChannelReceiveState.receivingData:
                    if (c == TAPEENDOFRECORD) {
                        tapeUnit.WriteIRG();
                        Debug.WriteLine("Tape Write " + tapeUnitString + " end of record, size=" +
                            recordSize[channel]);
                        channelReceiveState = ChannelReceiveState.receiveIdle;
                    }
                    else {
                        tapeUnit.Write(c, false);
                        channelReceiveState = ChannelReceiveState.receivingData;
                        ++recordSize[channel];
                        // Debug.WriteLine("Tape Write " + tapeUnitString + " wrote byte: " + c.ToString("X2"));
                    }
                    break;

                default:
                    channel1ReceiveState = ChannelReceiveState.receiveIdle;
                    Debug.WriteLine("Channel " + tapeUnit.ChannelNumber.ToString() + "" +
                        " Tape state machine, INVALID state.");
                    break;
            }


            //  NOW update the state variable as appropriate.

            if (channel == 1) {
                channel1ReceiveState = channelReceiveState;
            }
            else {
                channel2ReceiveState = channelReceiveState;
            }

            // Debug.WriteLine("Tape " + tapeUnitString + " leaving output available routine...");

            //  If the current tape unit on the GUI is the same as this one, 
            //  Update the info displayed.

            if (tapeUnit != null &&
                tapeUnit.ChannelNumber == currentChannel &&
                tapeUnit.UnitNumber == currentUnit) {
                Display();
            }

        }


        //  Method to read a tape record and send it off to the FPGA.  Ideally, this thing
        //  would send it in pieces, but for now, it holds the semaphore for the entire block.

        private void ReadTapeRecord(IBM1410TapeUnit tapeUnit) {

            int c;
            byte[] bytes = new byte[1];
            byte[] packet = new byte[512];
            int packetIx = 0;

            byte[] tapeTestData = {
                0x10, 0x01, 0x02, 0x43, 0x04, 0x45, 0x46, 0x07,
                0x08, 0x49, 0x4a, 0x0b, 0x4c, 0x0d, 0x0e, 0x4f,
                0x10, 0x51, 0x52, 0x13
             };

            String tapeUnitString = tapeUnit.ChannelNumber.ToString() +
                tapeUnit.UnitNumber.ToString();

            Debug.WriteLine("*** Begin Tape read, unit " + tapeUnitString);
            recordSize[tapeUnit.ChannelNumber] = 0;

            //  Obtain access to the serial port for access.

            serialOutputSemaphore.Wait();
            udpOutputSemaphore.Wait();
            packetIx = 0;

            //  Send the channel flag to the FPGA

            bytes[0] = (tapeUnit.ChannelNumber == 1) ? CHANNEL1TOFPGAFLAG : CHANNEL2TOFPGAFLAG;
            // serialPort.Write(bytes, 0, 1);
            packet[packetIx++] = (tapeUnit.ChannelNumber == 1) ? CHANNEL1TOFPGAFLAG : CHANNEL2TOFPGAFLAG;

            //  Send the unit number + 0x40 to the FPGA to signal input data

            bytes[0] = (byte)(tapeUnit.UnitNumber | READDATAFLAG);
            // serialPort.Write(bytes, 0, 1);
            packet[packetIx++] = (byte)(tapeUnit.UnitNumber | READDATAFLAG);

            /*
            for (int i = 0; i < tapeTestData.Length; i++) {
                serialPort.Write(tapeTestData, i, 1);
            }

            bytes[0] = TAPEENDOFRECORD;
            serialPort.Write(bytes, 0, 1);
            */


            while (true) {
                c = tapeUnit.Read();
                if (c == IBM1410TapeUnit.TAPEUNITNOTREADY || c == IBM1410TapeUnit.TAPEUNITIRG) {
                    //  Unit went not ready, or end of record -- return IRG
                    bytes[0] = TAPEENDOFRECORD;
                    packet[packetIx++] = TAPEENDOFRECORD;
                }
                else {
                    bytes[0] = (byte)(c & 0x7f);
                    packet[packetIx++] = (byte)(c & 0x7f);
                    ++recordSize[tapeUnit.ChannelNumber];
                }

                // Debug.WriteLine("Read on tape unit " + tapeUnitString + " sending " + 
                //    bytes[0].ToString("X2"));

                // serialPort.Write(bytes, 0, 1);

                //  If the UDP packet is almost full, send it.

                if (packetIx > packet.Length -4) {
                    udpClient.Send(packet, packetIx);
                    //  Sleep so that we don't overrun the IBM 1410 channel at 9us / char
                    System.Threading.Thread.Sleep(10);  // TAPEPACKETSLEEPTIME
                    /*
                    Debug.WriteLine("Sent UDP Tape Read packet: ");
                    for (int i = 0; i < packetIx; ++i) {
                        Debug.Write(packet[i].ToString("X2") + " ");
                        if (i % 16 == 15) {
                            Debug.WriteLine("");
                        }
                    }

                    Debug.WriteLine("/");
                    */

                    packetIx = 0;
                    packet[packetIx++] = (tapeUnit.ChannelNumber == 1) ? CHANNEL1TOFPGAFLAG : CHANNEL2TOFPGAFLAG;
                }

                if (bytes[0] == TAPEENDOFRECORD) {
                    break;
                }
            }

            //  If we have data still in the UDP packet, send it.
            if(packetIx > 0) {
                udpClient.Send(packet, packetIx);
            }

            /*
            Debug.WriteLine("Sent last UDP Tape Read packet: ");
            for(int i = 0; i < packetIx; ++i) {
                Debug.Write(packet[i].ToString("X2") + " ");
                if (i % 16 == 15) {
                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine("/");
            */


            //  Release the lock on the serial port.

            udpOutputSemaphore.Release();
            serialOutputSemaphore.Release();
            // Update FPGA unit status, particularly BUT DONT!!!
            //  tapeUnit.UpdateFPGATape("Read after Semaphore Release);  
            Debug.WriteLine("Ending tape read on unit " + tapeUnitString + " record size=" +
                recordSize[tapeUnit.ChannelNumber]);

        }


        //  Click on the unit number
        private void unitDial_ValueChanged(object sender, EventArgs e) {
            currentUnit = (int)unitDial.Value;
            tapeUnit = TapeUnits[currentChannel, currentUnit];
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
            tapeUnit = TapeUnits[currentChannel, currentUnit];
            Display();
        }


        //  Click on the Load/Rewind button.
        private void loadButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                if (tapeUnit.LoadRewind()) {
                    loadButton.Text = "Rwd";
                }
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
                loadButton.Text = "Load";
                Display();
            }
        }


        //  Reset
        private void resetButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null) {
                loadButton.Text = tapeUnit.Loaded ? "Rwd" : "Load";
                tapeUnit.Reset();
                Display();
            }
        }


        //  Mount a tape (file)

        private void mountButton_Click(object sender, EventArgs e) {
            if (tapeUnit != null && openFileDialog.ShowDialog() == DialogResult.OK) {
                fileNameLabel.Text = openFileDialog.FileName;
                tapeUnit.Mount(fileNameLabel.Text);
                loadButton.Text = "Load";
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
                    loadButton.Enabled = true;   // Actually it is a Load/Rewind button.  ;)
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

        //  If the user tries to close the tapes form, just hide it.
        private void IBM1410TapesForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
