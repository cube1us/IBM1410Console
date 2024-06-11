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
using System.Text;
using System.IO.Ports;
using System.Diagnostics;

namespace IBM1410Console
{

    public class SerialDataEventArgs: EventArgs
    {

        public int DispatchCode { get; set; }
        public int SerialByte { get; set; }
        public SerialDataEventArgs(int dispatchCode, int serialByte)
        {
            SerialByte = serialByte;
            DispatchCode = dispatchCode;
        }

    }

    // The following is the same as above, but for the light data stream.
    // This way, all the other subscribers don't have to ignore it.

    public class SerialLightDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int SerialByte { get; set; }
        public SerialLightDataEventArgs(int dispatchCode, int serialByte) {
            SerialByte = serialByte;
            DispatchCode = dispatchCode;
        }

    }

    // And for a change in console lock status

    public class ConsoleLockDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int SerialByte { get; set; }
        public ConsoleLockDataEventArgs(int dispatchCode, int serialByte) {
            SerialByte = serialByte;
            DispatchCode = dispatchCode;
        }

    }


    public class SerialDataPublisher
    {

        //  The following event is raised to subscribers as appropriate

        public event EventHandler<SerialDataEventArgs> SerialOutputEvent;
        public event EventHandler<SerialLightDataEventArgs> SerialLightOutputEvent;
        public event EventHandler<ConsoleLockDataEventArgs> ConsoleLockOutputEvent;

        //  Last received serial ID code byte

        private int lastCodeByte = 0x00;
        private const int lightCodeByte = 0x81;
        private const int lockCodeByte = 0x82;

        public SerialDataPublisher(SerialPort serialPort) {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            // TODO:  This open can fail if specified serial port not found.
            serialPort.Open();
            Debug.WriteLine("Received Data Handler subscribed");
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            SerialPort sp = (SerialPort)sender;
            // string inputData = sp.ReadExisting();
            int numBytes = sp.BytesToRead;
            int readByte = 0;

            Debug.WriteLine("Received " + numBytes.ToString() + " bytes from 1410.");

            for(int i = 0; i < numBytes; ++i) {
                readByte = sp.ReadByte();
                // Debug.WriteLine("Read byte " + readByte.ToString("X2"));

                if (readByte >= 0x80) {
                    lastCodeByte = readByte;
                    if (lastCodeByte != lightCodeByte) { 
                        Debug.WriteLine("Changed input stream: code byte: " + readByte.ToString("X2"));
                    }
                }
                else if(lastCodeByte == lightCodeByte ) {
                    SerialLightDataEventArgs serialLightDataEventArgs = new SerialLightDataEventArgs(lastCodeByte, readByte);
                    OnRaiseSerialLightOutputEvent(serialLightDataEventArgs);
                }
                else if(lastCodeByte == lockCodeByte) {
                    ConsoleLockDataEventArgs consoleLockDataEventArgs = new ConsoleLockDataEventArgs(lastCodeByte, readByte);
                    OnRaiseConsoleLockOutputEvent(consoleLockDataEventArgs);
                }
                else {
                    SerialDataEventArgs serialDataEventArgs = new SerialDataEventArgs(lastCodeByte, readByte);
                    OnRaiseSerialOutputEvent(serialDataEventArgs);
                }

            }

            // SerialDataEventArgs serialDataEventArgs = new SerialDataEventArgs(0, inputData);

            // Debug.WriteLine("Data received: /" + inputData + "/");

            // OnRaiseSerialOutputEvent(serialDataEventArgs);
        }

        protected void OnRaiseSerialOutputEvent(SerialDataEventArgs e) {
            EventHandler<SerialDataEventArgs> raiseEvent = SerialOutputEvent;
            // Debug.WriteLine("Signaling event with code " + e.DispatchCode + " and character " + e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseSerialLightOutputEvent(SerialLightDataEventArgs e) {
            EventHandler<SerialLightDataEventArgs> raiseEvent = SerialLightOutputEvent;
            // Debug.WriteLine("Signaling light event with code " + e.DispatchCode + " and character " + e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseConsoleLockOutputEvent(ConsoleLockDataEventArgs e) {
            EventHandler<ConsoleLockDataEventArgs> raiseEvent = ConsoleLockOutputEvent;
            Debug.WriteLine("Signaling console lock event with code " + e.DispatchCode + " and character " + e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }


    }
}
