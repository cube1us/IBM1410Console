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

        private IBM1410TapeUnit[,] TapeUnits = null;
        private IBM1410TapeUnit TapeUnit = null;

        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;
        private SerialDataPublisher serialDataPublisher;

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

            for (c = 0; c < 2; ++c) {
                for (u = 0; u < 10; ++u) {
                    TapeUnits[c,u] = new IBM1410TapeUnit(serialPort, serialOutputSemaphore, c, u);
                }
            }

            currentChannel = 1;
            currentUnit = 0;
            TapeUnit = TapeUnits[currentChannel,currentUnit];

            unitDial.Value = currentUnit;
            unitDial.Maximum = 9;
            unitDial.Minimum = 0;

            loadButton.Enabled = false; 
            startButton.Enabled = false;
            unloadButton.Enabled = false;

            serialDataPublisher.TapeChannel1OutputEvent +=
                new EventHandler<TapeChannelEventArgs>(tapeChannel1OutputAvailable);

            serialDataPublisher.TapeChannel1OutputEvent +=
                new EventHandler<TapeChannelEventArgs>(tapeChannel1OutputAvailable);

            Debug.WriteLine("Event Handlers for SerialDataPublisher (Tapes) Registered.");
        }

        void tapeChannel1OutputAvailable(object sender, TapeChannelEventArgs e) {
            return;
        }

        void tapeChannel2OutputAvailable(object sender, TapeChannelEventArgs e) {
            return;
        }


        //  Click on the unit number
        private void unitDial_ValueChanged(object sender, EventArgs e) {
            currentUnit = (int)unitDial.Value;
            TapeUnit = TapeUnits[currentChannel,currentUnit];
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
            TapeUnit = TapeUnits[currentChannel,currentUnit];
        }


        //  Click on the Load/Rewind button.
        private void loadButton_Click(object sender, EventArgs e) {
            if (TapeUnit != null) {
                TapeUnit.LoadRewind();
                Display();
            }
        }


        //  Start button click
        private void startButton_Click(object sender, EventArgs e) {
            if (TapeUnit != null) {
                TapeUnit.Start();
                Display();
            }
        }


        //  Density Change
        private void densityButton_Click(object sender, EventArgs e) {
            if (TapeUnit != null) {
                TapeUnit.ChangeDensity();
                Display();
            }
        }


        //  Unload
        private void unloadButton_Click(object sender, EventArgs e) {
            if (TapeUnit != null) {
                TapeUnit.Unload();
                Display();
            }
        }


        //  Reset
        private void resetButton_Click(object sender, EventArgs e) {
            if (TapeUnit != null) {
                TapeUnit.Reset();
                Display();
            }
        }


        //  Mount a tape (file)

        private void mountButton_Click(object sender, EventArgs e) { 
            if(TapeUnit != null && openFileDialog.ShowDialog() == DialogResult.OK) {
                fileNameLabel.Text = openFileDialog.FileName;
                TapeUnit.Mount(fileNameLabel.Text);
                Display();
            }
        }

        //  Update the display...

        void Display() {
            if (TapeUnit == null) {
                return;
            }

            readyLabel.ForeColor = TapeUnit.Ready ? Color.White : Color.DarkGray;
            selectLabel.ForeColor = TapeUnit.Selected ? Color.White : Color.DarkGray;
            protectLabel.ForeColor = TapeUnit.FileProtect ? Color.White : Color.DarkGray;
            tapeIndicateLabel.ForeColor = TapeUnit.TapeIndicate ? Color.White : Color.DarkGray;
            densityLabel.ForeColor = TapeUnit.HighDensity ? Color.White : Color.DarkGray;
            fileNameLabel.Text = TapeUnit.FileName;
            recordNumberLabel.Text = TapeUnit.RecordNumber.ToString();

            //  Enable or disable buttons appropriate to the status of the drive.

            if (TapeUnit.Ready) {
                mountButton.Enabled = false;
                loadButton.Enabled = false;
                startButton.Enabled = false;
                unloadButton.Enabled = false;
                resetButton.Enabled = true;
            }
            else if (TapeUnit.Loaded) {
                mountButton.Enabled = false;
                loadButton.Enabled = false;
                startButton.Enabled = true;
                unloadButton.Enabled = true;
                resetButton.Enabled = true;
            }
            else if (TapeUnit.FileName != null && TapeUnit.FileName.Length > 0) {
                mountButton.Enabled = true;
                loadButton.Enabled = true;
                startButton.Enabled = false;
                unloadButton.Enabled = false;
                resetButton.Enabled = true;
            }
            else {
                mountButton.Enabled = true;
                loadButton.Enabled = false;
                startButton.Enabled = false;
                unloadButton.Enabled = false;
                resetButton.Enabled = true;
            }

        }
    }
}
