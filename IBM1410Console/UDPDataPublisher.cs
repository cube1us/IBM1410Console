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
using System.Net;

namespace IBM1410Console
{

    public class UDPDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int UDPByte { get; set; }
        public UDPDataEventArgs(int dispatchCode, int udpByte) {
            UDPByte = udpByte;
            DispatchCode = dispatchCode;
        }

    }

    // The following is the same as above, but for the light data stream.
    // This way, all the other subscribers don't have to ignore it.

    public class UDPLightDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int UDPByte { get; set; }
        public UDPLightDataEventArgs(int dispatchCode, int udpByte) {
            UDPByte = udpByte;
            DispatchCode = dispatchCode;
        }

    }

    
    //  Tape channel data stream, used for events to both tape channels

    public class UDPTapeChannelEventArgs : EventArgs
    {
        public int DispatchCode { get; set; }
        public int UDPByte { get; set; }
        public UDPTapeChannelEventArgs(int dispatchCode, int udpByte) {
            UDPByte = udpByte;
            DispatchCode = dispatchCode;
        }
    }


    public class UDPDataPublisher
    {

        //  The following event is raised to subscribers as appropriate

        public event EventHandler<UDPDataEventArgs> UDPOutputEvent;
        public event EventHandler<UDPLightDataEventArgs> UDPLightOutputEvent;
        public event EventHandler<UDPTapeChannelEventArgs> UDPTapeChannel1OutputEvent;
        public event EventHandler<UDPTapeChannelEventArgs> UDPTapeChannel2OutputEvent;

        //  Last received UDP ID code byte

        private int lastCodeByte = 0x00;
        private const int lightCodeByte = 0x81;
        private const int lockCodeByte = 0x82;
        public const int tapeChannel1ToTAUCodeByte = 0x84;
        public const int tapeChannel2ToTAUCodeByte = 0x83;
        public const int tapeChannel1FromTAUCodeByte = 0x85;
        public const int tapeChannel2FromTAUCodeByte = 0x84;

        IBM1410Form.udpStateStruct udpState;
        IPAddress fpgaIPAddress;

        public UDPDataPublisher(IBM1410Console.IBM1410Form.udpStateStruct udpState,
            IPAddress fpgaAddress) {  
            this.udpState = udpState;
            this.fpgaIPAddress = fpgaAddress;

            //  Start up the recieve - this is just the FIRST receive.
            udpState.udpClient.BeginReceive(new AsyncCallback(UDPDataReceivedHandler), udpState);

            Debug.WriteLine("UDP BeginREceive called.");
        }

        private void UDPDataReceivedHandler(IAsyncResult ar) { 

            Byte[] rxBytes = udpState.udpClient.EndReceive(ar, ref udpState.ipEndPoint);
            int numBytes = rxBytes.Length;
            int readByte = 0;

            //  Verify it is coming from the right place.  Ignore if not.

            if (!IPAddress.Equals(udpState.ipEndPoint.Address, fpgaIPAddress)) {
                Debug.WriteLine("UDP Packet from unexpected address.");
                return;
            }

            Debug.WriteLine("UDP Received " + rxBytes.Length.ToString() + " bytes from " +
                "1410 IP Address " + udpState.ipEndPoint.Address.ToString());



            //  Process the data

            for (int i = 0; i < numBytes; ++i) {
                readByte = rxBytes[i];
                if (lastCodeByte != lightCodeByte) {
                    Debug.WriteLine("Read byte " + readByte.ToString("X2"));
                }

                if (readByte >= 0x80) {
                    lastCodeByte = readByte;
                    if (lastCodeByte != lightCodeByte) {
                        Debug.WriteLine("Changed input stream: code byte: " + readByte.ToString("X2"));
                    }
                }
                else if (lastCodeByte == lightCodeByte) {
                    UDPLightDataEventArgs udpLightDataEventArgs = new UDPLightDataEventArgs(lastCodeByte, readByte);
                    OnRaiseUDPLightOutputEvent(udpLightDataEventArgs);
                }
                /*
                else if (lastCodeByte == lockCodeByte) {
                    ConsoleLockDataEventArgs consoleLockDataEventArgs = new ConsoleLockDataEventArgs(lastCodeByte, readByte);
                    OnRaiseConsoleLockOutputEvent(consoleLockDataEventArgs);
                }
                */
                else if (lastCodeByte == tapeChannel1FromTAUCodeByte) {
                    // Debug.WriteLine("Dispatch byte to Channel 1 tape: " + readByte.ToString("X2"));
                    UDPTapeChannelEventArgs tapeChannel1DataEventArgs = 
                        new UDPTapeChannelEventArgs(lastCodeByte, readByte);
                    // Debug.WriteLine("Tape Channel 1 Event Args Created");
                    OnRaiseUDPTapeChannel1OutputEvent(tapeChannel1DataEventArgs);
                    // Debug.WriteLine("Tape Channel 1 Back from the raised event.");
                }
                else if (lastCodeByte == tapeChannel2FromTAUCodeByte) {
                    UDPTapeChannelEventArgs tapeChannel2DataEventArgs = 
                        new UDPTapeChannelEventArgs(lastCodeByte, readByte);
                    OnRaiseUDPTapeChannel2OutputEvent(tapeChannel2DataEventArgs);
                }
                else {
                    UDPDataEventArgs udpDataEventArgs = new UDPDataEventArgs(lastCodeByte, readByte);
                    OnRaiseUDPOutputEvent(udpDataEventArgs);
                }

            }

            // UDPDataEventArgs udpDataEventArgs = new udpDataEventArgs(0, inputData);

            // Debug.WriteLine("Data received: /" + inputData + "/");

            // OnRaiseUDPOutputEvent(udpDataEventArgs);

            //  Start up the next receive right away...

            udpState.udpClient.BeginReceive(new AsyncCallback(UDPDataReceivedHandler), udpState);

        }

        protected void OnRaiseUDPOutputEvent(UDPDataEventArgs e) {
            EventHandler<UDPDataEventArgs> raiseEvent = UDPOutputEvent;
            // Debug.WriteLine("Signaling event with code " + e.DispatchCode + " and character " +
            //  e.UDPByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseUDPLightOutputEvent(UDPLightDataEventArgs e) {
            EventHandler<UDPLightDataEventArgs> raiseEvent = UDPLightOutputEvent;
            // Debug.WriteLine("Signaling light event with code " + e.DispatchCode + " and character " +
            //  e.UDPByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseUDPTapeChannel1OutputEvent(UDPTapeChannelEventArgs e) {
            EventHandler<UDPTapeChannelEventArgs> raiseEvent = UDPTapeChannel1OutputEvent;
            // Debug.WriteLine("Signaling Tape Channel 1 event with code " + e.DispatchCode + " and character " + 
            //    e.UDPByte.ToString("X2"));
            if (raiseEvent != null) {
                // Debug.WriteLine("Tape Channel 1 raising event");
                raiseEvent(this, e);
            }
            // Debug.WriteLine("Tape Channel 1 Back from raised event.");
        }

        protected void OnRaiseUDPTapeChannel2OutputEvent(UDPTapeChannelEventArgs e) {
            EventHandler<UDPTapeChannelEventArgs> raiseEvent = UDPTapeChannel2OutputEvent;
            Debug.WriteLine("Signaling Tape Channel 2 event with code " + e.DispatchCode + " and character " + 
                e.UDPByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }
    }
}