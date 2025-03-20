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
using System.Threading;
using System.IO.Pipes;
using System.Net.Sockets;
using System.Net;


namespace IBM1410Console
{
    public partial class IBM1410Form : Form
    {


        IBM1415ConsoleForm IBM1415ConsoleForm = null;
        UI1415LForm UI1415LForm = null;
        IBM1410SwitchForm IBM1410SwitchForm = null;
        IBM1410TapesForm IBM1410TapesForm = null;

        SerialPort serialPort;
        SerialDataPublisher serialDataPublisher;
        SemaphoreSlim serialOuputSemaphore;

        public struct udpStateStruct
        {
            public UdpClient udpClient;
            public IPEndPoint ipEndPoint;
        }

        udpStateStruct udpState;
        UDPDataPublisher udpDataPublisher;
        SemaphoreSlim udpOutputSemaphore;

        // string[] comPortNames = SerialPort.GetPortNames();
        int[] serialPortSpeeds = { 9600, 19200, 28800, 57600, 115200 };
        List<string> comPorts;

        const byte loaderStreamFlag = 0x82;
        const byte addrMark = 0x40;
        const byte endMark = 0x70;
        const byte data0Mark = 0x20;
        const byte data1Mark = 0x10;

        // static public long coreSize = 40000;

        IPAddress fpgaIPAddress = IPAddress.Parse("192.168.42.254");
        IPEndPoint fpgaEndPoint;

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

            udpState.ipEndPoint = new IPEndPoint(IPAddress.Any, 1024);
            udpState.udpClient = new UdpClient(udpState.ipEndPoint);
            fpgaEndPoint = new IPEndPoint(fpgaIPAddress, 1024);
            udpState.udpClient.Connect(fpgaEndPoint);
            udpDataPublisher = new UDPDataPublisher(udpState,fpgaIPAddress);

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

            //  For now, we are using a simple semaphore to control access to serial output.
            //  If writing a large amount of data, consider splitting it up and giving up
            //  control at times!

            serialOuputSemaphore = new SemaphoreSlim(1);
            udpOutputSemaphore = new SemaphoreSlim(1);

            IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher, serialPort, serialOuputSemaphore);

            // Need this form during setup of lamp form...

            IBM1410SwitchForm = new IBM1410SwitchForm(serialPort, serialOuputSemaphore,
                udpState.udpClient, udpOutputSemaphore);

            //  Warn the user if there were no suitable serial ports found...

            if (comPorts.Count == 0) {
                MessageBox.Show("There are no available suitable USB COM ports",
                    "No USB COM Ports");
            }

            Console.WriteLine("Starting up...");
            Debug.WriteLine("Debug: Starting up...");

            //  Come up with Switches showing...

            if (IBM1410SwitchForm == null) {
                IBM1410SwitchForm = new IBM1410SwitchForm(serialPort, serialOuputSemaphore,
                    udpState.udpClient, udpOutputSemaphore);
            }
            IBM1410SwitchForm.Show();

            //  And the tape drive panel showing...

            if (IBM1410TapesForm == null) {
                IBM1410TapesForm = new IBM1410TapesForm(serialDataPublisher, udpDataPublisher,
                    serialPort, serialOuputSemaphore,
                    udpState.udpClient, udpOutputSemaphore);
            }
            IBM1410TapesForm.Show();

            //  We need the lamps form now, too, so it can learn about resets

            UI1415LForm UI1415LForm = new UI1415LForm(serialDataPublisher, udpDataPublisher, IBM1410SwitchForm);

            //  Next, tell the switch form about other forms that need to know about
            //  Computer and Program resets

            IBM1410SwitchForm.setForms(UI1415LForm, IBM1410TapesForm);

            //  And the console typewriter...  put in front.

            if (IBM1415ConsoleForm == null) {
                IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher, serialPort, serialOuputSemaphore);
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
                IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher, serialPort, serialOuputSemaphore);
            }
            IBM1415ConsoleForm.Show();
        }

        private void windowsStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void lightStripMenuItem_Click(object sender, EventArgs e) {
            if (UI1415LForm == null) {
                UI1415LForm = new UI1415LForm(serialDataPublisher, udpDataPublisher, IBM1410SwitchForm);
            }
            UI1415LForm.Show();

        }

        private void switchesStripMenuItem_Click(object sender, EventArgs e) {
            if (IBM1410SwitchForm == null) {
                IBM1410SwitchForm = new IBM1410SwitchForm(serialPort, serialOuputSemaphore,
                    udpState.udpClient, udpOutputSemaphore);
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
            int bytesPerCharacter = 0;
            byte[] buffer = new byte[6];  //    Enough for start mark, bank and address bytes
            byte[] packet = new byte[1024];
            int packetIx = 0;
            Stream fileStream;

            OpenFileDialog LoadCoreImageOpenDialog = new OpenFileDialog();
            LoadCoreImageOpenDialog.AddExtension = true;
            LoadCoreImageOpenDialog.DefaultExt = "cor";
            LoadCoreImageOpenDialog.Filter = "Core Images (*.cor;*.img;*.bin)|*.cor;*.img;*.bin|All Files (*.*)|*.*";
            LoadCoreImageOpenDialog.CheckFileExists = true;
            LoadCoreImageOpenDialog.CheckPathExists = true;

            if (LoadCoreImageOpenDialog.ShowDialog() == DialogResult.OK) {
                try {
                   fileStream = File.Open(LoadCoreImageOpenDialog.FileName, FileMode.Open, FileAccess.Read);
                }
                catch(Exception e2) {
                    MessageBox.Show("Core Image File open failed.", "File open failed.");
                    return;
                }
                BinaryReader reader = new BinaryReader(fileStream);

                //  The first five characters are the core size, in decimal, ascii characters

                reader.Read(coreSizeChars, 0, 5);
                coreSizeChars[5] = '\0';
                try {
                    fileCoreSize = Int32.Parse(coreSizeChars);
                }
                catch (Exception) {
                    MessageBox.Show("First five bytes - size - not numeric.  Load aborted",
                        "Load Aborted");
                    reader.Close();
                    fileStream.Close();
                    return;
                }
                Debug.WriteLine("File Core size: " + fileCoreSize);

                //  See if file size matches up with size in first 5 bytes...
                //  It should be either 2*size+5 or 4*size+5

                if (fileStream.Length == fileCoreSize * 2 + 5) {
                    bytesPerCharacter = 2;
                }
                else if (fileStream.Length == fileCoreSize * 4 + 5) {
                    bytesPerCharacter = 4;
                }
                else {
                    DialogResult result = MessageBox.Show(
                        "Actual size of file of " + fileStream.Length +
                        " bytes is not 2x+5 or 4x+5 of core size in header of " +
                        fileCoreSize,
                        "File Size Warning",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Cancel) {
                        reader.Close();
                        fileStream.Close();
                        return;
                    }
                }

                if (fileCoreSize > Properties.Settings.Default.CoreSize) {
                    DialogResult result = MessageBox.Show(
                        "Core size in file of " + fileCoreSize +
                        " is greater than selected FPGA core size of " +
                        Properties.Settings.Default.CoreSize +
                        " -- Will only send " + Properties.Settings.Default.CoreSize,
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

                coresize = fileCoreSize > Properties.Settings.Default.CoreSize ?
                    Properties.Settings.Default.CoreSize : fileCoreSize;
                Debug.WriteLine("Sending Core image size of " + coresize);

                //  Acquire access to the serial port

                serialOuputSemaphore.Wait();
                udpOutputSemaphore.Wait();

                //  Send the address, which, for now, is always 0 in bank 0.

                buffer[0] = loaderStreamFlag;
                buffer[1] = addrMark | 0x01;    // Bank 1 - 0-9999 start address
                buffer[2] = addrMark | 0x00;
                buffer[3] = addrMark | 0x00;
                buffer[4] = addrMark | 0x00;
                buffer[5] = addrMark | 0x00;

                packetIx = 0;
                packet[0] = loaderStreamFlag;
                packet[1] = addrMark | 0x01;    // Bank 1 - 0-9999 start address
                packet[2] = addrMark | 0x00;
                packet[3] = addrMark | 0x00;
                packet[4] = addrMark | 0x00;
                packet[5] = addrMark | 0x00;
                packetIx = 6;

                // serialPort.Write(buffer, 0, 6);

                //  Read the file and send the data...

                for (int addr = 0; addr < coresize; addr++) {
                    long c, t;

                    try {
                        c = bytesPerCharacter == 2 ? reader.ReadInt16() :
                            reader.ReadInt32();
                    }
                    catch (EndOfStreamException) {
                        MessageBox.Show("Unexpected EOF on core image file.",
                            "Unexpected EOF");
                        break;
                    }
                    catch (Exception ex) {
                        MessageBox.Show("ERROR reading core image file: " +
                            ex.Message, "Unexpected I/O Error");
                        break;
                    }

                    //  Exchange the top two bits to convert file format (WM C ...)
                    //  to FPGA format (C WM ...)

                    t = c;
                    c = c & 0x3f;
                    if ((t & 0x80) == 0x80) {
                        c = c | 0x40;
                    }
                    if ((t & 0x40) == 0x40) {
                        c = c | 0x80;
                    }

                    //  Fix bad parity on zeroes (kludge)

                    if (c == 0) {
                        c = 0x80;
                    }

                    //  Temporary debug...
                    /*
                    if (addr < 10) {
                        Debug.WriteLine("Read in " + t.ToString("X4") +
                            " Converted to " + c.ToString("X4"));
                    }
                    */

                    // If packet buffer is almsot full, send it.
                    // The -4 gives us 2 extra bytes left for the end mark

                    if (packetIx > packet.Length - 4) {   
                        udpState.udpClient.Send(packet, packetIx);
                        // Debug.WriteLine("Sent UDP packet length " + packetIx.ToString());
                        /*
                        Debug.Write("/");
                        for (int i = 0; i < packetIx; ++i) {
                            Debug.Write(packet[i].ToString("X2") + " ");
                        }
                        Debug.WriteLine("/");
                        */

                        packetIx = 0;
                        // System.Threading.Thread.Sleep(100);
                    }

                    //  Data is sent HIGH four bits first, with appropriate marks.

                    buffer[0] = (byte)(((c & 0xf0) >> 4) | data0Mark);
                    buffer[1] = (byte)((c & 0x0f) | data1Mark);
                    // serialPort.Write(buffer, 0, 2);

                    packet[packetIx++] = (byte)(((c & 0xf0) >> 4) | data0Mark);
                    packet[packetIx++] = (byte)((c & 0x0f) | data1Mark);
                }

                //  Send the end of load marker.

                buffer[0] = endMark;
                // serialPort.Write(buffer, 0, 1);

                packet[packetIx++] = endMark;
                udpState.udpClient.Send(packet, packetIx);
                Debug.WriteLine("Sent final packet of length " + packetIx.ToString());

                //  Release the kraken, I mean semaphore...

                udpOutputSemaphore.Release();
                serialOuputSemaphore.Release();

                reader.Close();
                fileStream.Close();

                MessageBox.Show("Core File Image Load Complete", "Core Image Load Complete");
            }

        }

        private void fPGACoreSizeToolStripMenuItem_Click(object sender, EventArgs e) {

            CoreSizeSettingsForm coreSizeSettingsForm = new CoreSizeSettingsForm();
            coreSizeSettingsForm.setCoreSize(Properties.Settings.Default.CoreSize.ToString());
            coreSizeSettingsForm.ShowDialog();
        }

        private void tapesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (IBM1410TapesForm == null) {
                IBM1410TapesForm = new IBM1410TapesForm(serialDataPublisher, udpDataPublisher,
                    serialPort, serialOuputSemaphore,
                    udpState.udpClient, udpOutputSemaphore);
            }
            IBM1410TapesForm.Show();
        }

        private void clearCoreToolStripMenuItem_Click(object sender, EventArgs e) {
            byte[] buffer = new byte[6];

            //  Gain access to the serial port...

            serialOuputSemaphore.Wait();
            udpOutputSemaphore.Wait();

            //  Send the flag byte fgor core load, and the start address.

            buffer[0] = loaderStreamFlag;
            buffer[1] = addrMark | 0x01;    // Bank 1 - 0-9999 start address
            buffer[2] = addrMark | 0x00;
            buffer[3] = addrMark | 0x00;
            buffer[4] = addrMark | 0x00;
            buffer[5] = addrMark | 0x00;
            // serialPort.Write(buffer, 0, 6);
            udpState.udpClient.Send(buffer, 6);


            for (int addr = 0; addr < Properties.Settings.Default.CoreSize; addr++) {

                //  Send a blank (0x80)

                buffer[0] = (0x08 | data0Mark);
                buffer[1] = data1Mark;
                // serialPort.Write(buffer, 0, 2);
                udpState.udpClient.Send(buffer, 2);
            }

            //  Send the end of load marker.

            buffer[0] = endMark;
            // serialPort.Write(buffer, 0, 1);
            udpState.udpClient.Send(buffer, 1);

            udpOutputSemaphore.Release();
            serialOuputSemaphore.Release();

            MessageBox.Show("Core Clear Complete", "Core Clear Complete");
        }

    }
}

