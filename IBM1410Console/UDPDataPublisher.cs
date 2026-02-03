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

//  There are a couple of warnings that I really don't care for, so suppress them.

#pragma warning disable IDE0090
#pragma warning disable IDE1005

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace IBM1410Console
{

    public class UDPDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int[] UDPBytes { get; set; }
        public int UDPLen { get; set; }
        public UDPDataEventArgs(int dispatchCode, int[] udpBytes, int udpLen) {
            UDPBytes = udpBytes;
            DispatchCode = dispatchCode;
            UDPLen = udpLen;
        }

    }

    // The following is the same as above, but for the light data stream.
    // This way, all the other subscribers don't have to ignore it.

    public class UDPLightDataEventArgs : EventArgs
    {

        public int DispatchCode { get; set; }
        public int[] UDPBytes { get; set; }
        public int UDPLen { get; set; }
        public UDPLightDataEventArgs(int dispatchCode, int[] udpBytes, int uDPLen) {
            UDPBytes = udpBytes;
            DispatchCode = dispatchCode;
            UDPLen = uDPLen;
        }

    }

    
    //  Tape channel data stream, used for events to both tape channels

    public class UDPTapeChannelEventArgs : EventArgs
    {
        public int DispatchCode { get; set; }
        public int[] UDPBytes { get; set; }
        public int UDPLen { get; set; }
        public UDPTapeChannelEventArgs(int dispatchCode, int[] udpBytes, int udpLen) {
            UDPBytes = udpBytes;
            UDPLen = udpLen;
            DispatchCode = dispatchCode;
        }
    }

    public class UDPUnitRecordChannelEventArgs : EventArgs
    {
        public int DispatchCode { get; set; }
        public int[] UDPBytes { get; set; }
        public int UDPLen { get; set; }
        public UDPUnitRecordChannelEventArgs(int dispatchCode, int[] udpBytes, int udpLen) {
            UDPBytes = udpBytes;
            UDPLen = udpLen;
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
        public event EventHandler<UDPUnitRecordChannelEventArgs> UDPReaderChannel1OutputEvent;
        public event EventHandler<UDPUnitRecordChannelEventArgs> UDPPunchChannel1OutputEvent;
        public event EventHandler<UDPUnitRecordChannelEventArgs> UDPPrinterChannel1OutputEvent;


        //  Last received UDP ID code byte coming FROM the FPGA

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
        private const int lockCodeByte = 0x82;   // Currently handled by UART Serial
        public const int tapeChannel1FromTAUCodeByte = 0x85;
        public const int tapeChannel2FromTAUCodeByte = 0x84;
        public const int deviceFrom1414CodeByte = 0x83;

        //  The following are not actually used here - they are used with UDP data sent TO the FPGA

        public const int tapeChannel1ToTAUCodeByte = 0x84;
        public const int tapeChannel2ToTAUCodeByte = 0x83;
        public const int deviceTo1414CodeByte  = 0x85;


        IBM1410Form.udpStateStruct udpState;
        IPAddress fpgaIPAddress;

        public UDPDataPublisher(IBM1410Console.IBM1410Form.udpStateStruct udpState,
            IPAddress fpgaAddress) {  
            this.udpState = udpState;
            this.fpgaIPAddress = fpgaAddress;

            //  Start up the recieve - this is just the FIRST receive.
            udpState.udpClient.BeginReceive(new AsyncCallback(UDPDataReceivedHandler), udpState);

            Debug.WriteLine("UDP BeginReceive called.");
        }

        private void UDPDataReceivedHandler(IAsyncResult ar) { 

            Byte[] rxBytes = udpState.udpClient.EndReceive(ar, ref udpState.ipEndPoint);
            int numBytes = rxBytes.Length;
            int readByte = 0;
            int dispatchLen = 0;
            int[] dispatchBytes = new int[2048];

            //  Verify it is coming from the right place.  Ignore if not.

            if (!IPAddress.Equals(udpState.ipEndPoint.Address, fpgaIPAddress)) {
                Debug.WriteLine("UDP Packet from unexpected address.");
                return;
            }

            // Debug.WriteLine("UDP Received " + rxBytes.Length.ToString() + " bytes from " +
            //    "1410 IP Address " + udpState.ipEndPoint.Address.ToString());



            //  Process the data

            dispatchLen = 0;

            //  The following loop looks like it could go one too far, but it really doesn't.

            for (int i = 0; i <= numBytes; ++i) {
                if(i < numBytes) {
                    readByte = rxBytes[i];
                }

                // if (lastCodeByte != lightCodeByte && i < numBytes) {
                //     Debug.WriteLine("Read byte " + readByte.ToString("X2"));
                // }

                // Debug.WriteLine("Read byte " + readByte.ToString("X2"));

                if (readByte >= 0x80 || i == numBytes) {

                    //  If this is a new device code, OR, if the previous
                    //  byte was the last byte of the packet (i == numBytes), we need to dispatch the
                    //  data we already grabbed, then reset the dispatchLen variable.

                    if (i > 0) {
                        // Debug.WriteLine("Dispatching " + dispatchLen + " bytes...");
                        if (lastCodeByte == lightCodeByte) {
                            UDPLightDataEventArgs udpLightDataEventArgs =
                                new UDPLightDataEventArgs(lastCodeByte, dispatchBytes, dispatchLen);
                            OnRaiseUDPLightOutputEvent(udpLightDataEventArgs);
                            dispatchLen = 0;
                        }
                        /*
                        else if (lastCodeByte == lockCodeByte) {
                            ConsoleLockDataEventArgs consoleLockDataEventArgs = new ConsoleLockDataEventArgs(lastCodeByte, readByte);
                            OnRaiseConsoleLockOutputEvent(consoleLockDataEventArgs);
                        }
                        */
                        else if (lastCodeByte == deviceFrom1414CodeByte) {
                            Debug.WriteLine("Dispatching " + dispatchLen + " bytes for unit record");

                            //  At this point we *must* have received at least one byte, so the device should not be 00
                            //  Have we received the device number yet?  If not, then just ignore

                            if (lastUnitRecordDevice == 0x00) {
                                Debug.WriteLine("UDPDataPublisher: No unit record device found as expected.");
                                MessageBox.Show("UDPDataPublisher: No unit record device found as expected.");
                            }
                            else if (lastUnitRecordOperation == 0x00 || dispatchLen == 0) {
                                Debug.WriteLine("UDPDataPublisher: No unit record operation available yet - no Dispatch");
                            }
                            //  For a card reader, nothing follows the operation
                            else if (lastUnitRecordDevice == readerChannel1Device) {
                                if(dispatchLen != 1) {
                                    Debug.WriteLine("UDPDataPublisher: Reader Channel 1 Dispatch Length not 1 " + 
                                        dispatchLen.ToString());
                                    MessageBox.Show("UDPDataPublisher: Reader Channel 1 Dispatch Length not 1 " +
                                        dispatchLen.ToString());
                                }
                                Debug.WriteLine("Dispatching Reader Channel 1 operation of " + 
                                    dispatchBytes[0].ToString("X2"));
                                UDPUnitRecordChannelEventArgs unitRecordChannelEventArgs = 
                                    new UDPUnitRecordChannelEventArgs(lastCodeByte, dispatchBytes, dispatchLen);
                                OnRaiseUDPReaderChannel1OutputEvent(unitRecordChannelEventArgs);
                                //  And then reset...
                                lastUnitRecordDevice = 0x00;
                                lastUnitRecordOperation = 0x00;
                            }
                            else {
                                //  For a unit record output device, we are receiving data until we get a 0 byte.
                                //  TODO

                                // UnitRecordChannelEventArgs unitRecordChannelEventArgs = new UnitRecordChannelEventArgs(lastCodeByte, readByte);

                                //  Decide which device we are going to dispatch to...

                                //  If this is a 0 byte, it is the end of the data, so reset our state information.

                                if (readByte == 0x00) {
                                    lastUnitRecordDevice = 0x00;
                                    lastUnitRecordOperation = 0x00;
                                }
                            }
                        }

                        else if (lastCodeByte == tapeChannel1FromTAUCodeByte) {
                            // Debug.WriteLine("Dispatch byte to Channel 1 tape: " + readByte.ToString("X2"));
                            UDPTapeChannelEventArgs tapeChannel1DataEventArgs =
                                new UDPTapeChannelEventArgs(lastCodeByte, dispatchBytes, dispatchLen);
                            // Debug.WriteLine("Tape Channel 1 Event Args Created");
                            OnRaiseUDPTapeChannel1OutputEvent(tapeChannel1DataEventArgs);
                            // Debug.WriteLine("Tape Channel 1 Back from the raised event.");
                            dispatchLen = 0;
                        }
                        else if (lastCodeByte == tapeChannel2FromTAUCodeByte) {
                            UDPTapeChannelEventArgs tapeChannel2DataEventArgs =
                                new UDPTapeChannelEventArgs(lastCodeByte, dispatchBytes, dispatchLen);
                            OnRaiseUDPTapeChannel2OutputEvent(tapeChannel2DataEventArgs);
                            dispatchLen = 0;
                        }
                        else {
                            UDPDataEventArgs udpDataEventArgs = new UDPDataEventArgs(lastCodeByte, dispatchBytes, dispatchLen);
                            OnRaiseUDPOutputEvent(udpDataEventArgs);
                            dispatchLen = 0;
                        }
                    }

                    if (i != numBytes) {
                        if (lastCodeByte != readByte) {
                            Debug.WriteLine("Changed input stream: code byte: " + readByte.ToString("X2"));
                        }
                        lastCodeByte = readByte;
                    }
                }

                else {

                    //  NOT the last byte for a device or end of packet

                    //  For unit record devices, capture the first byte as the device,
                    //  and the second byte as the operation.

                    if (lastCodeByte == deviceFrom1414CodeByte) {
                        if (lastUnitRecordDevice == 0) {
                            //  Do NOT increment the dispatchLen for the device code,
                            //  and do NOT put it in the dispatchBytes vector.
                            lastUnitRecordDevice = readByte;
                        }
                        else if (lastUnitRecordDevice != 0 && lastUnitRecordOperation == 0) {
                            lastUnitRecordOperation = readByte;
                            dispatchBytes[dispatchLen++] = readByte;
                        }
                        else {
                            dispatchBytes[dispatchLen++] = readByte;
                        }
                    }

                    else {
                        //  Normal byte: not code byte and previous byte was not the last byte
                        //  Stuff it into the dispatch array.

                        dispatchBytes[dispatchLen++] = readByte;
                    }
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
            // Debug.WriteLine("Signaling Tape Channel 2 event with code " + e.DispatchCode + " and character " + 
            //     e.UDPByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

        protected void OnRaiseUDPReaderChannel1OutputEvent(UDPUnitRecordChannelEventArgs e) {
            EventHandler<UDPUnitRecordChannelEventArgs> raiseEvent = UDPReaderChannel1OutputEvent;
            // Debug.WriteLine("Signaling Reader Channel 1 event with code " + e.DispatchCode + " and character " + 
            //     e.UDPByte.ToString("X2"));
            if (raiseEvent != null) {
                raiseEvent(this, e);
            }
        }

    }
}