/* 
 *  COPYRIGHT 2020, 2021, 2022 Jay R. Jaeger
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;

namespace IBM1410Console
{
    public partial class IBM1410Form : Form
    {


        IBM1415ConsoleForm IBM1415ConsoleForm = null;
        UI1415LForm UI1415LForm = null;
        IBM1410SwitchForm IBM1410SwitchForm = null;

        SerialPort serialPort;
        SerialDataPublisher serialDataPublisher;

        // string[] comPortNames = SerialPort.GetPortNames();
        int[] serialPortSpeeds = { 9600, 19200, 28800, 57600, 115200 };
        List<string> comPorts;

        static public long coreSize = 40000;

        public IBM1410Form() {
            string portName = null;

            InitializeComponent();

            Debug.WriteLine("Enumerating Serial Ports...");

            //  Try and find the correct serial port (one that is USB)

            comPorts = Helpers.getComPorts();

            serialPort = new SerialPort();
            serialPort.BaudRate = serialPortSpeeds[4];
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;

            //  See if there is a remembered setting that is in the list.  If so, use
            //  that.  Otherwise, use the first one in the list.  If the list is emppy,
            //  set arbitrarily to COM1

            foreach (string comPort in comPorts) {
                if (comPort.Equals(Properties.Settings.Default.ComPort)) {
                    portName = comPort;
                    break;
                }
            }

            //  If we didn't find one and if none were saved save this one...

            if (portName == null) {
                portName = comPorts.Count > 0 ? comPorts[0] : "COM1";
                if (Properties.Settings.Default.ComPort.Length == 0) {
                    Properties.Settings.Default.ComPort = portName;
                    Properties.Settings.Default.Save();
                    Debug.WriteLine("Initialzied ComPort setting to " + portName);
                }
            }

            serialPort.PortName = portName;
            Debug.WriteLine("Serial port is " + serialPort.PortName);
            serialPort.Handshake = Handshake.None;

            serialDataPublisher = new SerialDataPublisher(serialPort);

            IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher, serialPort);
            IBM1410SwitchForm = new IBM1410SwitchForm(serialPort);  // Need this form during setup of lamp form...

            //  Warn the user if there were no suitable serial ports found...

            if (comPorts.Count == 0) {
                MessageBox.Show("There are no available suitable USB COM ports",
                    "No USB COM Ports");
            }

            Console.WriteLine("Starting up...");
            Debug.WriteLine("Debug: Starting up...");

            //  Come up with Switches showing...

            if (IBM1410SwitchForm == null) {
                IBM1410SwitchForm = new IBM1410SwitchForm(serialPort);
            }
            IBM1410SwitchForm.Show();

            //  And the console typewriter...  put in front.

            if (IBM1415ConsoleForm == null) {
                IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher, serialPort);
            }
            IBM1415ConsoleForm.Show();
            IBM1415ConsoleForm.BringToFront();

            //  And back this main form out of the way...

            this.SendToBack();
        }

        private void comPortsSettings_Click(object sender, EventArgs e) {

            //  Repopulate the COM ports list...

            comPorts = Helpers.getComPorts();

            if (comPorts.Count == 0) {
                MessageBox.Show("There are no available suitable USB COM ports",
                    "No USB COM Ports");
                return;
            }

            ComPortSettingsForm comPortSettingsForm = new ComPortSettingsForm(serialPort, comPorts, serialPortSpeeds);
            comPortSettingsForm.ShowDialog();
        }

        private void consoleStripMenuItem_Click(object sender, EventArgs e) {
            if (IBM1415ConsoleForm == null) {
                IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher, serialPort);
            }
            IBM1415ConsoleForm.Show();
        }

        private void windowsStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void lightStripMenuItem_Click(object sender, EventArgs e) {
            if (UI1415LForm == null) {
                UI1415LForm = new UI1415LForm(serialDataPublisher, IBM1410SwitchForm);
            }
            UI1415LForm.Show();

        }

        private void switchesStripMenuItem_Click(object sender, EventArgs e) {
            if (IBM1410SwitchForm == null) {
                IBM1410SwitchForm = new IBM1410SwitchForm(serialPort);
            }
            IBM1410SwitchForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Form AboutBox = new AboutBox();
            AboutBox.ShowDialog();
        }

        private void IBM1410Form_Load(object sender, EventArgs e) {

            //  If we have saved settings for this window, use them.

            if (Properties.Settings.Default.MainSize.Width != 0 &&
                Properties.Settings.Default.MainSize.Height != 0) {
                this.Size = Properties.Settings.Default.MainSize;
                this.Location = Properties.Settings.Default.MainLoc;
            }

            this.SendToBack();
        }

        private void IBM1410Form_FormClosing(object sender, FormClosingEventArgs e) {

            //  First, remember the size and location of the window...

            if (this.WindowState == FormWindowState.Normal) {
                // save location and size if the state is normal
                Properties.Settings.Default.MainLoc = this.Location;
                Properties.Settings.Default.MainSize = this.Size;
            }
            else {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.MainLoc = this.RestoreBounds.Location;
                Properties.Settings.Default.MainSize = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();

        }

        private void LoadCoreImageToolStripMenuItem_Click(object sender, EventArgs e) {
            char[] coreSizeChars = new char[6];
            long fileCoreSize = 0;
            long coresize = 0;

            OpenFileDialog LoadCoreImageOpenDialog = new OpenFileDialog();
            LoadCoreImageOpenDialog.AddExtension = true;
            LoadCoreImageOpenDialog.DefaultExt = "cor";
            LoadCoreImageOpenDialog.Filter = "Core Images (*.cor;*.img;*.bin)|*.cor;*.img;*.bin|All Files (*.*)|*.*";
            LoadCoreImageOpenDialog.CheckFileExists = true;
            LoadCoreImageOpenDialog.CheckPathExists = true;

            if (LoadCoreImageOpenDialog.ShowDialog() == DialogResult.OK) {
                Stream fileStream = File.Open(LoadCoreImageOpenDialog.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fileStream);

                //  The first five characters are the core size, in decimal, ascii characters

                reader.Read(coreSizeChars, 0, 5);
                coreSizeChars[5] = '\0';
                fileCoreSize = Int32.Parse(coreSizeChars);
                Debug.WriteLine("File Core size: " + fileCoreSize);
                if (fileCoreSize > Properties.Settings.Default.CoreSize) {
                    DialogResult result = MessageBox.Show(
                        "Core size in file of " + fileCoreSize +
                        " is greater than selected FPGA core size of " +
                        Properties.Settings.Default.CoreSize,
                        "Core Size Warning",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Cancel) {
                        reader.Close();
                        fileStream.Close();
                        return;
                    }
                }

                //  The amount we will send is the smaller of the FPGA core size
                //  and the file core size.

                coreSize = fileCoreSize > Properties.Settings.Default.CoreSize ?
                    Properties.Settings.Default.CoreSize : fileCoreSize;
                Debug.Write("Sending Core image size of " + coreSize);

                //  Read the file and send the data...

                reader.Close();
                fileStream.Close();
            }

        }

        private void fPGACoreSizeToolStripMenuItem_Click(object sender, EventArgs e) {

            CoreSizeSettingsForm coreSizeSettingsForm = new CoreSizeSettingsForm();
            coreSizeSettingsForm.setCoreSize(Properties.Settings.Default.CoreSize.ToString());
            coreSizeSettingsForm.ShowDialog();
        }
    }
}
