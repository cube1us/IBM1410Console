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
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace IBM1410Console
{
    public partial class ComPortSettingsForm : Form
    {

        SerialPort serialPort;
        int[] serialPortSpeeds;

        public ComPortSettingsForm(SerialPort serialPort, List<string> comPorts, int[] serialPortSpeeds)
        {
            InitializeComponent();

            this.serialPort = serialPort;
            this.serialPortSpeeds = serialPortSpeeds;

            //  Note that the assignments below change the items inside the passed serialPort Object.

            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;

            //  If we get here, we know that there is at least one port...

            foreach (string comPort in comPorts) {
                portsComboBox.Items.Add(comPort);
            }

            portsComboBox.SelectedIndex = 0;
            serialPort.Close();
            serialPort.PortName = (string) portsComboBox.SelectedItem;

            foreach (int speed in serialPortSpeeds) {
                speedComboBox.Items.Add(speed.ToString());
            }

            speedComboBox.SelectedIndex = 4;
            serialPort.BaudRate = serialPortSpeeds[4];
            serialPort.Open();
        }

        private void portsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (portsComboBox.SelectedItem != null) {
                serialPort.Close();
                serialPort.PortName = (string)portsComboBox.SelectedItem;
                Properties.Settings.Default.ComPort = serialPort.PortName;
                Properties.Settings.Default.Save();
                Debug.WriteLine("COM port set to " + serialPort.PortName + " and saved.");
                serialPort.Open();
            }
        }

        private void speedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(speedComboBox.SelectedIndex >= 0) {
                serialPort.BaudRate = serialPortSpeeds[speedComboBox.SelectedIndex];
                Debug.WriteLine("Com port set to speed " + serialPort.BaudRate.ToString());
            }
        }
    }
}
