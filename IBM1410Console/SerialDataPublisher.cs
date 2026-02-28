/* 
 *  COPYRIGHT 2020, 2021, 2022, 2025, 2026 Jay R. Jaeger
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

    public class SerialDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int SerialByte { get; set; }
        public SerialDataEventArgs(int dispatchCode, int serialByte) {
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


    //  Tape channel data stream, used for events to both tape channels

    public class TapeChannelEventArgs : EventArgs
    {
        public int DispatchCode { get; set; }
        public int SerialByte { get; set; }
        public TapeChannelEventArgs(int dispatchCode, int serialByte) {
            SerialByte = serialByte;
            DispatchCode = dispatchCode;
        }
    }

    public class UnitRecordChannelEventArgs : EventArgs
    {
        public int DispatchCode { get; set; }
        public int SerialByte { get; set; }
        public UnitRecordChannelEventArgs(int dispatchCode, int serialByte) {
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
        public event EventHandler<TapeChannelEventArgs> TapeChannel1OutputEvent;
        public event EventHandler<TapeChannelEventArgs> TapeChannel2OutputEvent;
        public event EventHandler<UnitRecordChannelEventArgs> UnitChannel1OutputEvent;
        // public event EventHandler<UnitRecordChannelEventArgs> PunchChannel1OutputEvent;
        // public event EventHandler<UnitRecordChannelEventArgs> PrinterChannel1OutputEvent;


        //  Last received serial ID code byte

        //  NOTE:  For the unit record (1414) devices, the *second* byte identifies the
        //  channel and particular device.  For this reason, this module (and its UDP 
        //  counterpart) dispatch events to each particular device (reader, punch,
        //  printer, paper tape, telegraph, etc).  And for this reason, this program
        //  and the FPGA implementation must ensure that the streams for these devices
        //  are transmitted without a message from a second unit record device -
        //  even on other channels.  CURRENTLY, only the channel 1 1414 is implemented.
        //  In addition, to simplify things, THIS module keeps track of which unit 
        //  record device (including the channel number) is active.

        private int lastCodeByte = 0x00;
        private int lastUnitRecordDevice = 0x00;
        private int lastUnitRecordOperation = 0x00;
        private int readerChannel1Device = 0x01;
        private int punchChannel1Device = 0x02;
        private int printerChannel1Device = 0x03;
        
        private const int lightCodeByte = 0x81;
        private const int lockCodeByte = 0x82;
        public const int deviceFrom1414CodeByte = 0x83;
        public const int tapeChannel1FromTAUCodeByte = 0x85;
        public const int tapeChannel2FromTAUCodeByte = 0x84;

        public const int tapeChannel2ToTAUCodeByte = 0x83;
        public const int tapeChannel1ToTAUCodeByte = 0x84;
        public const int deviceTo1414CodeByte = 0x85;


        public SerialDataPublisher(SerialPort serialPort) {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            // TODO:  This open can fail if specified serial port not found.
            try {
                serialPort.Open();
                Debug.WriteLine("Received Data Handler subscribed");
            }
            catch(Exception e) {

            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            SerialPort sp = (SerialPort)sender;
            // string inputData = sp.ReadExisting();
            int numBytes = sp.BytesToRead;
            int readByte = 0;

            // Debug.WriteLine("Received " + numBytes.ToString() + " bytes from 1410.");

            for (int i = 0; i < numBytes; ++i) {
                readByte = sp.ReadByte();
                if (lastCodeByte != lightCodeByte) {
                    // Debug.WriteLine("Read byte " + readByte.ToString("X2"));
                }

                if (readByte >= 0x80) {
                    if (lastCodeByte != readByte) {
                        // Debug.WriteLine("Changed input stream: code byte: " + readByte.ToString("X2"));
                    }
                    lastCodeByte = readByte;
                }
                else if (lastCodeByte == lightCodeByte) {
                    SerialLightDataEventArgs serialLightDataEventArgs = new SerialLightDataEventArgs(lastCodeByte, readByte);
                    OnRaiseSerialLightOutputEvent(serialLightDataEventArgs);
                }
                else if (lastCodeByte == lockCodeByte) {
                    ConsoleLockDataEventArgs consoleLockDataEventArgs = new ConsoleLockDataEventArgs(lastCodeByte, readByte);
                    OnRaiseConsoleLockOutputEvent(consoleLockDataEventArgs);
                }
                else if (lastCodeByte == deviceFrom1414CodeByte) {
                    Debug.WriteLine("Received byte for Unit Record: " + readByte.ToString("X2"));
                    // UnitRecordChannelEventArgs unitRecordChannelEventArgs = new UnitRecordChannelEventArgs(lastCodeByte, readByte);

                    //  Have we received the device number yet?  If not, then this must be the device number (which
                    //  also includes the channel number in it.) 
                    //  If we have that, but not the operation, then this must be the operation.
                    //  Otherwise we know both, and this must be data (i.e. for punch, printer, paper tape or telegraph)

                    if (lastUnitRecordDevice == 0x00) {
                        lastUnitRecordDevice = readByte;
                        //  Note: We do NOT dispatch the unit record device code, we just remember it.
                        Debug.WriteLine("Receiving request for unit record device " + readByte.ToString("X2"));
                    }
                    else if (lastUnitRecordOperation == 0x00) {
                        lastUnitRecordOperation = readByte;
                        Debug.WriteLine("Received request for operation " + readByte.ToString("X2") + " for unit record device " + lastUnitRecordDevice.ToString("X2"));

                        //  We DO Dispatch the unit record operation code, however.
                        UnitRecordChannelEventArgs unitRecordChannelEventArgs = new UnitRecordChannelEventArgs(lastCodeByte, readByte);
                        OnRaiseUnitChannel1OutputEvent(unitRecordChannelEventArgs);

                        //  If we are receiving data from the FPGA for the reader, then this is the end of the message

                        if (lastUnitRecordDevice == readerChannel1Device) {
                            Debug.WriteLine("Dispatced Reader Channel 1 operation of " + readByte.ToString("X2"));
                            lastUnitRecordDevice = 0x00;
                            lastUnitRecordOperation = 0x00;
                        }
                    }
                    else if (lastUnitRecordDevice == punchChannel1Device) {
                        Debug.WriteLine("Dispatching data byte to Channel 1 punch: " + readByte.ToString("X2"));
                        
                        UnitRecordChannelEventArgs unitRecordChannelEventArgs = new UnitRecordChannelEventArgs(lastCodeByte, readByte);
                        OnRaiseUnitChannel1OutputEvent(unitRecordChannelEventArgs);
                        
                        //  If this byte is 0, then reset (the FPGA should never send an actual 0 ** DATA ** byte to the punch 
                        //  (It would be 0x40 for a blank)

                        if (readByte == 0x00) {
                            lastUnitRecordDevice = 0x00;
                            lastUnitRecordOperation = 0x00;
                        }
                    }

                    else {
                        // Just ignore any other unit record device for now.
                    }
                }
                else if (lastCodeByte == tapeChannel1FromTAUCodeByte) {
                    // Debug.WriteLine("Dispatch byte to Channel 1 tape: " + readByte.ToString("X2"));
                    TapeChannelEventArgs tapeChannel1DataEventArgs = new TapeChannelEventArgs(lastCodeByte, readByte);
                    // Debug.WriteLine("Tape Channel 1 Event Args Created");
                    OnRaiseTapeChannel1OutputEvent(tapeChannel1DataEventArgs);
                    // Debug.WriteLine("Tape Channel 1 Back from the raised event.");
                }
                else if (lastCodeByte == tapeChannel2FromTAUCodeByte) {
                    TapeChannelEventArgs tapeChannel2DataEventArgs = new TapeChannelEventArgs(lastCodeByte, readByte);
                    OnRaiseTapeChannel2OutputEvent(tapeChannel2DataEventArgs);
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
            // Debug.WriteLine("Signaling event with code " + e.DispatchCode + " and character " +
            //  e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseSerialLightOutputEvent(SerialLightDataEventArgs e) {
            EventHandler<SerialLightDataEventArgs> raiseEvent = SerialLightOutputEvent;
            // Debug.WriteLine("Signaling light event with code " + e.DispatchCode + " and character " +
            //  e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseConsoleLockOutputEvent(ConsoleLockDataEventArgs e) {
            EventHandler<ConsoleLockDataEventArgs> raiseEvent = ConsoleLockOutputEvent;
            Debug.WriteLine("Signaling console lock event with code " + e.DispatchCode + " and character " 
                + e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseTapeChannel1OutputEvent(TapeChannelEventArgs e) {
            EventHandler<TapeChannelEventArgs> raiseEvent = TapeChannel1OutputEvent;
            // Debug.WriteLine("Signaling Tape Channel 1 event with code " + e.DispatchCode + " and character " + 
            //    e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                // Debug.WriteLine("Tape Channel 1 raising event");
                raiseEvent(this, e);
            }
            // Debug.WriteLine("Tape Channel 1 Back from raised event.");
        }

        protected void OnRaiseTapeChannel2OutputEvent(TapeChannelEventArgs e) {
            EventHandler<TapeChannelEventArgs> raiseEvent = TapeChannel2OutputEvent;
            Debug.WriteLine("Signaling Tape Channel 2 event with code " + e.DispatchCode + " and character " + 
                e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseUnitChannel1OutputEvent(UnitRecordChannelEventArgs e) {
            EventHandler<UnitRecordChannelEventArgs> raiseEvent = UnitChannel1OutputEvent;
            Debug.WriteLine("Signaling Unit Record event with code " + e.DispatchCode + " and character " +
                e.SerialByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }
    }
}