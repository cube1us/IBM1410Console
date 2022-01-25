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

    public class SerialDataPublisher
    {

        //  The following event is raised to subscribers as appropriate

        public event EventHandler<SerialDataEventArgs> SerialOutputEvent;

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
                Debug.WriteLine("Read byte " + readByte.ToString("X2"));
                SerialDataEventArgs serialDataEventArgs = new SerialDataEventArgs(0, readByte);
                OnRaiseSerialOutputEvent(serialDataEventArgs);
            }

            // SerialDataEventArgs serialDataEventArgs = new SerialDataEventArgs(0, inputData);

            // Debug.WriteLine("Data received: /" + inputData + "/");

            // OnRaiseSerialOutputEvent(serialDataEventArgs);
        }

        protected void OnRaiseSerialOutputEvent(SerialDataEventArgs e) {
            EventHandler<SerialDataEventArgs> raiseEvent = SerialOutputEvent;
            Debug.WriteLine("Signaling event with code " + e.DispatchCode + " and character " + e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

    }
}
