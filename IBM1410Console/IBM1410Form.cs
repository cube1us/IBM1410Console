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

namespace IBM1410Console
{
    public partial class IBM1410Form : Form
    {

        
        IBM1415ConsoleForm IBM1415ConsoleForm = null;
        UI1415LForm UI1415LForm = null;
        IBM1410SwitchForm IBM1410SwitchForm = null;

        SerialPort serialPort;
        SerialDataPublisher serialDataPublisher;

        string[] comPorts = SerialPort.GetPortNames();
        int[] serialPortSpeeds = { 9600, 19200, 28800, 57600, 115200 };


        public IBM1410Form()
        {
            InitializeComponent();

            serialPort = new SerialPort();

            //  TODO: This stuff should really come from remembered settings, but for now...

            serialPort.BaudRate = serialPortSpeeds[4];
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.PortName = "COM10";
            serialPort.Handshake = Handshake.None;

            serialDataPublisher = new SerialDataPublisher(serialPort);

            IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher);
            IBM1410SwitchForm = new IBM1410SwitchForm(serialPort);  // Need this form during setup of lamp form...

            Console.WriteLine("Starting up...");
            Debug.WriteLine("Debug: Starting up...");
        }

        private void comPortsSettings_Click(object sender, EventArgs e)
        {
            ComPortSettingsForm comPortSettingsForm = new ComPortSettingsForm(serialPort, comPorts, serialPortSpeeds);
            comPortSettingsForm.ShowDialog();

        }

        private void consoleStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IBM1415ConsoleForm == null) {
                IBM1415ConsoleForm = new IBM1415ConsoleForm(serialDataPublisher);
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
            if(IBM1410SwitchForm == null) {
                IBM1410SwitchForm = new IBM1410SwitchForm();
            }
            IBM1410SwitchForm.Show();
        }
    }
}
