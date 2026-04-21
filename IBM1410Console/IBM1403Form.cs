using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBM1410Console

    /*
    * Printer FPGA <-> PC Support Program protocols:
    * 
    * For PC => FPGA:
    *    Channel Character [CR]:            0x85 (Both Channels)
    *    Unit Record Device Char [UD]:      0x02 (Printer Ch1)
    *    Status Operation Code Char [SO]:   0x01
    *    Status from PC to FPGA:            [CR] [UD] [SO] [Status]
    * 
    * For FPGA => PC
    *    Channel Character [CW]:            0x83 (Both channels)
    *    Unit Record Device Char [UD]:      0x02 (Printer Ch1)
    *    Unt Operation Char [OP]:           0x20 (print) or 0x2F (Carriage Control)
    *    Message from FPGA to PC:           [CW] [UD] [OP] [data bytes - print line or CC char] [0x00]
    * 
    */

    /*
     * Carriage Tape INTERNAL format:  
     * The carriage tape is an array with one member per line, 
     * The default is 1-66 (11 inches, 6 lines/inch).
     * Each array entry is a bitmap: channel 1 is 1, channel 2 is 2,
     * channel 3 is 4 ... channel 12 is 1024.
     * 
     * There is a default carriage tape, with:
     * Line 1 punched for channel 1,
     * Line 4 punched for channels 2,3,4,5,6,7,8,10 and 11
     * Line 61 punched for channel 9
     * Line 63 punched for channel 12
     * 
     * Carriage Tape FILE Format:  We use the same format as used
     * by Joseph Newcomer in his 1401 emulator:
     * 
     *      LENGTH n
     *      CHAN c = l [[+]l]...
     *      CHAN ...
     *      (Where c is a number from 1 to 12 - channel number, and l
     *      is a page line number from 1 to n (from the LENGTH line)
     *      (A + in the first channel list entry is silently ignored)
     */
     
{
    public partial class IBM1403Form : Form
    {
        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;
        private SerialDataPublisher serialDataPublisher;
        private UDPDataPublisher udpDataPublisher;
        private UdpClient udpClient = null;
        private SemaphoreSlim udpOutputSemaphore = null;
        private byte[] printLine;
        private int[] carriageTape = null;
        private int formLength = 0;
        private int currentPrintLine = 1;

        private Boolean printerReady = false;
        private Boolean printerBusy = false;
        private Boolean carriageChannel9 = false;
        private Boolean carriageChannel12 = false;

        public const int printerIsReady = 0x01;
        public const int printerIsBusy = 0x02;
        public const int carriageIsChannel9 = 0x20;
        public const int carriageIsChannel12 = 0x40;
        public const int carriageChannel9Bit = 0x01 << 8;
        public const int carriageChannel12Bit = 0x01 << 11;

        private int currentUnitRecordDevice = 0;
        private int currentPrinterOperation = 0;
        private int currentPrinterColumn = 0;
        private byte currentCarriageControlCharacter = 0;
        private int printerDeferredSpace = 0;
        private int printerDeferredSkip = 0;
        private Boolean printerRequiresSpace = false;
        private Boolean printerSuppressSpace = false;
        private Boolean rtfInserted = false;

        public const byte UNITRECORDTO1414FLAG = 0x85;
        public const byte UNITRECORDFROM1414FLAG = 0x83;
        public const byte READERCH1FLAG = 0x01;
        public const byte PUNCHCH1FLAG = 0x04;
        public const byte PRINTERCH1FLAG = 0x02;
        public const byte PRINTERCH2FLAG = 0x42;

        public const byte STATUSUPDATEOPERATION = 0x01;
        public const byte PRINTEROPERATION = 0x20;
        public const byte FORMSOPERATION = 0x2F;
        public const int PRINTERLINELENGTH = 132;

        private byte printerStatus = 0;               // Not Ready by default

        //  Translate numerics to carriage channel.  0 is invalid.

        private int[] BCDToCarriageChannel = {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 0, 0 };

        Font printerFont = new Font("IBM 1410 1403", 10, FontStyle.Regular);  // IBM 1410 1403 printer font

        public IBM1403Form(SerialDataPublisher serialDataPublisher,
            UDPDataPublisher udpDataPublisher,
            SerialPort serialPort, SemaphoreSlim serialOutputSemaphore,
            UdpClient udpClient, SemaphoreSlim udpOutputSemaphore) {

            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;
            this.udpDataPublisher = udpDataPublisher;
            this.udpClient = udpClient;
            this.udpOutputSemaphore = udpOutputSemaphore;
            printLine = null;

            InitializeComponent();      // Create the buttons, etc.
            this.CreateHandle();        // Ensure controls are created before we get FPGA data

            printerStartButton.Enabled = true;
            printerStopButton.Enabled = true;

            if (printerFont != null) {
                printerRichTextBox1.Font = printerFont;
            }
            else {
                Debug.WriteLine("Can't initialize 1403 font for printer.");
            }

            //  Set up default carriage tape

            setCarriageDefault();

            //  We unsubscribe first, becuase sometimes we ended up with two subscriptions.
            //  Not sure why that happeneds, but unsubscribing when not subscribed is harmless.

            serialDataPublisher.UnitChannel1OutputEvent -=
                new EventHandler<UnitRecordChannelEventArgs>(unitChannel1OperationAvailable);

            udpDataPublisher.UDPUnitChannel1OutputEvent -=
                new EventHandler<UDPUnitRecordChannelEventArgs>(unitChannel1UDPOperationAvailable);

            Debug.WriteLine("IBM1403Form: Event Handlers for Serial and UDP Data Publishers (Printer) Registered.");
            serialDataPublisher.UnitChannel1OutputEvent +=
                new EventHandler<UnitRecordChannelEventArgs>(unitChannel1OperationAvailable);

            udpDataPublisher.UDPUnitChannel1OutputEvent +=
                new EventHandler<UDPUnitRecordChannelEventArgs>(unitChannel1UDPOperationAvailable);

            Debug.WriteLine("IBM1403Form: Event Handlers for Serial and UDP Data Publishers (Printer) Registered.");

        }

        //  Right now, the unit record devices are just UDP, so ignore serial requests
        void unitChannel1OperationAvailable(object sender, UnitRecordChannelEventArgs e) {
            //  Right now, just using UDP, so ignore serial port requests.
        }

        //  Method that receives subscribed-to events for unit record messages.
        //  (There are to such subscribers right now, the other being the reader/punch)
        void unitChannel1UDPOperationAvailable(object sender, UDPUnitRecordChannelEventArgs e) {

            //  The CPU has asked the 1414 to have a unit record device do something...
            //  It might or might NOT be the reader...

            //  If this really isn't for us, ignore it.

            if (e.DispatchCode != UNITRECORDFROM1414FLAG) {
                return;
            }

            // Debug.WriteLine("IBM1403Form: Processing UDP Input");

            //  Loop through the bytes (hopefully / typically, the entire packet)

            for (int i = 0; i < e.UDPLen; i++) {
                //  TODO: Make sure the other unit record devices aren't active
                if (currentUnitRecordDevice == 0) {
                    //  If we are not currently processing a device, this byte is
                    //  the device code.
                    currentUnitRecordDevice = e.UDPBytes[i];
                    // Debug.WriteLine("IBM1403Form: Current Unit Record Device is " + currentUnitRecordDevice.ToString("X2"));
                    currentPrinterOperation = 0;
                }
                else if (currentUnitRecordDevice == READERCH1FLAG) {
                    //  The current unit record device is the reader, so ignore it.
                    //  But this needs to be here because the reader message does NOT have
                    //  a 0x00 terminator and just has the operation code,
                    //  so we need to (and can) reset the device code.
                    currentPrinterOperation = 0;
                    currentCarriageControlCharacter = 0;
                    currentUnitRecordDevice = 0;
                }
                else if (currentUnitRecordDevice == PRINTERCH1FLAG) {
                    //  The current unit record device is the printer, so process it.
                    printerMessageInputAvailable((byte)e.UDPBytes[i]);
                }
                else if (e.UDPBytes[i] == 0) {
                    //  For any other device (e.g., the punch, for now), just ignore the data until we see a 0x00
                    currentUnitRecordDevice = 0;
                }
            }
        }

        //  Method to actually handle a byte of data from the FPGA (the IBM 1414, if you will)
        //  that is destined for the printer.

        void printerMessageInputAvailable(byte c) {

            Action safePrinterTextBoxUpdate;

            //  0 Terminates the printer request when receiving data, whether a print line or a carriage control request

            if (c == 0) {
                if (currentPrinterOperation == PRINTEROPERATION) {
                    if (currentPrinterColumn != PRINTERLINELENGTH) {
                        Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Print line data image < 132 characters.");
                        MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Print line data image < 132 characters.");
                    }

                    //  Because this code is running on the UDP publisher thread, to update the UI we need to use Invoke.

                    // Debug.WriteLine("IBM1403Form: Printing line of length " + printLine.Length.ToString());
                    // for (int i = 0; i < printLine.Length; i++) {
                    //     Debug.Write(printLine[i].ToString("X2") + " ");
                    // }
                    // Debug.WriteLine("");

                    //  If we did not advance or suppress spacing after the last print, then advance it now.
                    //  But if we suppressed it, add a carriage return in front of the print line.

                    if(printerRequiresSpace) {
                        advanceCarriage();
                    }

                    safePrinterTextBoxUpdate = delegate
                    {
                        printerRichTextBox1.AppendText((printerSuppressSpace ? "\r" : "") + System.Text.Encoding.UTF8.GetString(printLine));
                        printerRichTextBox1.Update();
                    };
                    this.Invoke(safePrinterTextBoxUpdate);
                    Debug.WriteLine("IBM1403Form: Print /" + System.Text.Encoding.UTF8.GetString(printLine) + "/");

                    printLine = null;
                    printerRequiresSpace = true;   // Must have CC advance/suppress or we will advance before next line.

                    if (printerDeferredSpace != 0) {
                        for (int i = 0; i < printerDeferredSpace; i++) {
                            advanceCarriage();
                        }
                    }

                    if (printerDeferredSkip != 0) {
                        skipCarriage(printerDeferredSkip);
                    }

                    printerDeferredSpace = 0;
                    printerDeferredSkip = 0;
                    printerSuppressSpace = false;

                    //  Need to send the printer status in part so that it turns off the busy flag in the FPGA

                    sendPrinterStatus();
                }

                else if (currentPrinterOperation == FORMSOPERATION) {
                    if (currentCarriageControlCharacter == 0) {
                        Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Empty carriage control message received.");
                        MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Empty carriage control message received.");
                    }
                    else {
                        //  TODO:  Actually do the carriage control operation.
                        Debug.WriteLine("IBM1403Form: Carriage Control Operation character = " + currentCarriageControlCharacter.ToString("X2"));

                        switch (currentCarriageControlCharacter & (IBM1410BCD.BITA | IBM1410BCD.BITB)) {
                            case 0:
                                //  Immediate Skip
                                skipCarriage(BCDToCarriageChannel[currentCarriageControlCharacter & 0x0f]);
                                break;
                            case IBM1410BCD.BITA:
                                // Space after print
                                printerDeferredSpace = BCDToCarriageChannel[currentCarriageControlCharacter & 0x0f];
                                // if (printerDeferredSpace == 0) {
                                //     printerRequiresSpace = false;
                                // }
                                break;
                            case IBM1410BCD.BITB:
                                //  Immediate Space
                                int i;
                                for (i = 0; i < BCDToCarriageChannel[currentCarriageControlCharacter & 0x0f]; ++i) {
                                    advanceCarriage();
                                }
                                //  If the numeric part is 0, suppress the next space...
                                if (i == 0) {
                                    printerRequiresSpace = false;
                                    printerSuppressSpace = true;
                                }
                                break;
                            case IBM1410BCD.BITA | IBM1410BCD.BITB:
                                // Skip after print
                                printerDeferredSkip = BCDToCarriageChannel[currentCarriageControlCharacter & 0x0f];
                                break;
                        }

                        // Sending status will turn off carriage busy in CPU -- even for deferred skipping - may not be correct.

                        sendPrinterStatus();
                        currentCarriageControlCharacter = 0;
                    }
                }

                currentPrinterOperation = 0;
                currentUnitRecordDevice = 0;
                return;
            }

            //  The first byte should be an operation code.

            if (currentPrinterOperation == 0) {
                if ((c & PRINTEROPERATION) == PRINTEROPERATION) {
                    currentPrinterOperation = c;
                    // Debug.WriteLine("IBM1403Form: Current Print Operation is " + currentPrinterOperation.ToString("X2"));
                    if (currentPrinterOperation == PRINTEROPERATION) {
                        printLine = new byte[PRINTERLINELENGTH];
                        currentPrinterColumn = 0;
                    }
                    else if (currentPrinterOperation == FORMSOPERATION) {
                        printLine = null;
                    }
                }
                else {
                    Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Invalid printer operation code: " + c.ToString("X2"));
                    MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Invalid printer operation code: " + c.ToString("X2"));
                    currentPrinterOperation = 0;
                    currentUnitRecordDevice = 0;
                }
            }

            else {

                if (currentPrinterOperation == FORMSOPERATION) {
                    if (currentCarriageControlCharacter != 0) {
                        Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Multiple byte carriage control message received.");
                        MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Multiple byte carriage control message received.");
                    }
                    else {
                        currentCarriageControlCharacter = c;
                    }
                }
                else if (currentPrinterOperation == PRINTEROPERATION && currentPrinterColumn < PRINTERLINELENGTH) {
                    //  Strip the character's 0x40 parity bit, convert to ASCII, and append to the print line.
                    printLine[currentPrinterColumn] = ((byte)IBM1410BCD.BCDtoASCII((byte)(c & 0x3f)));
                    ++currentPrinterColumn;
                }
                else {
                    Debug.WriteLine("IBM1403Form.printerMessageInputAvailable: Print line data image > 132 characters.");
                    MessageBox.Show("IBM1403Form.printerMessageInputAvailable: Print line data image > 132 characters.");
                }
            }

        }

        //  Method to do a carriage skip.  It has a built in carriage stop as well.

        private void skipCarriage(int channel) {
            int skipped = 0;

            Debug.WriteLine("Skipping carriage to channel " + channel.ToString());

            if (channel == 0) {
                return;
            }

            for (skipped = 0; skipped < formLength + 2; ++skipped) {
                if ((carriageTape[currentPrintLine] & (1 << channel - 1)) != 0) {
                    break;
                }
                advanceCarriage();
            }

            Debug.WriteLine("Skipped " + skipped.ToString() + " lines...");

            //  Force a carriage stop in extreme circumstances...

            if (skipped >= formLength + 1) {
                stopPrinter();
            }
        }

        //  Method to advance the carriage and check for holes in the carriage tape
        //  and set appropriate status.

        private void advanceCarriage() {

            if (++currentPrintLine > formLength) {
                currentPrintLine = 1;
            }

            Action safePrinterTextBoxUpdate = delegate
            {
                printerRichTextBox1.AppendText("\n");
                printerRichTextBox1.Update();
            };

            printerRequiresSpace = false;

            this.Invoke(safePrinterTextBoxUpdate);

            //  The carriage channel signals are latched.  Once set, they stay
            //  that way until the next hole is sensed.  Note than if just channel
            //  9 is punched, it will reset 12, and vice-versa.

            if ((carriageTape[currentPrintLine] & carriageChannel9Bit) != 0) {
                carriageChannel9 = true;
                carriageChannel12 = (carriageTape[currentPrintLine] & carriageChannel12Bit) != 0;
            }
            else if ((carriageTape[currentPrintLine] & carriageChannel12Bit) != 0) {
                carriageChannel12 = true;
                carriageChannel9 = (carriageTape[currentPrintLine] & carriageChannel9Bit) != 0;
            }
            else if (carriageTape[currentPrintLine] != 0) {
                carriageChannel9 = false;
                carriageChannel12 = false;
            }
        }


        //  Method to stop the printer (Stop or carriage stop)

        private void stopPrinter() {
            printerReady = false;
            printerBusy = false;
            labelPrintReady.ForeColor = Color.DimGray;  // Might need a delegate?
            sendPrinterStatus();
        }

        //  Method to send status of the Printer to the FPGA.

        private void sendPrinterStatus() {
            byte[] statusBuffer = new byte[4];

            printerStatus = 0;
            if (printerReady) {
                printerStatus |= printerIsReady;
            }
            if (printerBusy) {
                printerStatus |= printerIsBusy;
            }
            if (carriageChannel9) {
                printerStatus |= carriageIsChannel9;
                Debug.WriteLine("IBM1403Form: Sending Carriage Channel 9 Status.");
            }
            if (carriageChannel12) {
                printerStatus |= carriageIsChannel12;
                Debug.WriteLine("IBM1403Form: Sending Carriage Channel 12 Status.");
            }

            Debug.WriteLine("Sending status byte of " + printerStatus.ToString("X2"));

            //  For now, serial port version NOT implemented.

            //  Send the updated status to the FPGA...

            udpOutputSemaphore.Wait();
            statusBuffer[0] = UNITRECORDTO1414FLAG;
            statusBuffer[1] = PRINTERCH1FLAG;
            statusBuffer[2] = STATUSUPDATEOPERATION;
            statusBuffer[3] = printerStatus;
            udpClient.Send(statusBuffer, statusBuffer.Length);
            udpOutputSemaphore.Release();
        }

        //  Method to set up a default carriage tape

        private void setCarriageDefault() {
            formLength = 66;
            carriageTape = new int[formLength + 1];   // 1-66 (C# inits to 0!)

            carriageTape[1] = 1;
            carriageTape[4] = 2 | 4 | 8 | 16 | 32 | 64 | 128 | 512 | 1024;
            carriageTape[61] = 256;         // Channel 9
            carriageTape[63] = 2048;        // Channel 12 
        }

        private void printerStartButton_Click(object sender, EventArgs e) {
            printerReady = true;
            printerBusy = false;
            labelPrintReady.ForeColor = Color.SeaGreen;
            sendPrinterStatus();
        }

        private void printerStopButton_Click(object sender, EventArgs e) {
            stopPrinter();
        }

        private void carriageStopButton_Click(object sender, EventArgs e) {
            stopPrinter();
        }

        //  Method to clear out the print display area
        private void printerClearButton_Click(object sender, EventArgs e) {
            printerRichTextBox1.Clear();
            rtfInserted = false;
        }

        private void printerSaveButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (printerRTFCheckBox.Checked) {
                // The following did not work - the Rich Text Box just threw it away.
                // if (!rtfInserted) {
                //    printerRichTextBox1.SelectionStart = 0;
                //    printerRichTextBox1.SelectionLength = 0;
                //    printerRichTextBox1.SelectedText =
                //       @"{\rtf1\ansi \paperw18000 \paperh15840 \margl1440 \margr1440 \margt720 \marg720}";
                //    rtfInserted = true;
                // }
                saveFileDialog.Filter = "RTF file (*.rtf)|*.rtf|Text file (*.txt)|*.txt|All Files (*.*)|*.*";
            }
            else {
                saveFileDialog.Filter = "Text file (*.txt)|*.txt|All Files (*.*)|*.*";
            }
            
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save Printer Output" + this.Text + " to a file";
            saveFileDialog.DefaultExt = printerRTFCheckBox.Checked ? "rtf" : "txt";
            saveFileDialog.AddExtension = true;

            //  Display the save file dialog and check if the users clicked OK

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = saveFileDialog.FileName;
                try {
                    if (printerRTFCheckBox.Checked) {
                        printerRichTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
                    }
                    else {
                        System.IO.File.WriteAllText(fileName, printerRichTextBox1.Text);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error saving print to file {fileName} {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IBM1403Form_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        //  Method to load a carriage tape from a file.  If the file cannot be
        //  accessed, the existing carriageTape used.  If the file has an error,
        //  erroneous lines are ignored.  If the LENGTH lineis missing, 66 is
        //  assumed.

        private void carriageTapeButton_Click(object sender, EventArgs e) {
            FileStream carriageFileStream = null;
            StreamReader carriageStreamReader = null;
            String carriageLine = null;
            int lineno = 1;

            if (openCarriageFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    carriageFileStream = new FileStream(openCarriageFileDialog.FileName,
                        FileMode.Open, FileAccess.Read);
                    carriageStreamReader = new StreamReader(carriageFileStream);
                }
                catch (Exception eCarriage) {
                    Debug.WriteLine("IBM1403Form: ERROR: Cannot open carriage tape file " +
                        openCarriageFileDialog.FileName);
                    Debug.WriteLine("IBM1403Form:   " + eCarriage.Message);
                    MessageBox.Show("IBM1403Form: Open of carriage tape file " +
                        openCarriageFileDialog.FileName + " failed.");
                    return;
                }
            }
            else {
                return;
            }

            //  Process the lines in the carriage control file one a a time.

            while ((carriageLine = carriageStreamReader.ReadLine()) != null) {
                Int32 temp;
                int channelLine = 0;
                int channel;
                string s;

                String[] tokens = carriageLine.Split(
                    (char[])null, StringSplitOptions.RemoveEmptyEntries |
                    StringSplitOptions.TrimEntries);

                for (int i = 0; i < tokens.Length; ++i) {
                    Debug.Write(tokens[i] + " ");
                }
                Debug.WriteLine("");

                if (lineno == 1) {
                    //  Validate first line is LENGTH nnn
                    formLength = 66;
                    if (tokens.Length != 2 || !tokens[0].ToUpper().Equals("LENGTH")) {
                        MessageBox.Show("IBM1403Form: First Line of Carriage Tape File must start with LENGTH nnn");
                    }
                    else {
                        if (Int32.TryParse(tokens[1], out temp)) {
                            formLength = temp;
                        }
                        else {
                            MessageBox.Show("IBM1403Form: First Line of Carriage Tape File must start with LENGTH nnn");
                        }
                    }

                    carriageTape = new int[formLength + 1];
                }

                else {
                    //  Validate Channel line CHAN c = n [[+]n]...
                    if (tokens.Length < 4 || !tokens[0].ToUpper().Equals("CHAN") ||
                        !tokens[2].Equals("=")) {
                        MessageBox.Show("IBM1403Form: Line " + lineno.ToString() + " CHAN improper format - missing CHAN or =.");
                        continue;
                    }
                    if (Int32.TryParse(tokens[1], out temp) && temp > 0 || temp <= 12) {
                        channel = temp;
                    }
                    else {
                        MessageBox.Show("IBM1403Form: Line " + lineno.ToString() + " CHAN improper format or invalid channel.");
                        continue;
                    }

                    channelLine = 0;
                    for (int i = 3; i < tokens.Length; i++) {
                        if (tokens[i].Substring(0, 1).Equals("+")) {        // So, this one is +n
                            if (tokens[i].Length >= 2 && Int32.TryParse(tokens[i].Substring(1), out temp) && temp > 0) {
                                if (channelLine + temp <= formLength) {
                                    channelLine = channelLine + temp;
                                }
                                else {
                                    MessageBox.Show("IBM1403Form: Line " + lineno.ToString() + " CHAN: line # is > LENGTH");
                                    break;
                                }
                            }
                            else {
                                MessageBox.Show("IBM1403Form: Line " + lineno.ToString() + " CHAN: Missing or invalid +#");
                                break;
                            }
                        }
                        else {
                            if (Int32.TryParse(tokens[i], out temp) && temp >= 1 && temp <= formLength) {
                                channelLine = temp;
                            }
                            else {
                                MessageBox.Show("IBM1403Form: Line " + lineno.ToString() + " CHAN: invalid line #");
                                break;
                            }
                        }

                        //  If we get here, we had a valid CHAN = Line # entry.  Enter it, and move on to the
                        //  next entry in the line.

                        carriageTape[channelLine] |= (1 << (channel - 1));
                    }
                }

                //  Move on to the next line

                ++lineno;

            }

            carriageStreamReader.Close();
            carriageFileStream.Close();

            //  Debugging

            for (int i = 1; i <= formLength; ++i) {
                if (carriageTape[i] != 0) {
                    Debug.Write("IBM1403Form: Carriage Tape Line " + i.ToString() + ", Channels: ");
                    int temp = carriageTape[i];
                    for (int c = 1; c <= 12; ++c) {
                        if ((temp & 1) == 1) {
                            Debug.Write(c.ToString());
                        }
                        temp = temp >> 1;
                    }
                    Debug.WriteLine("");
                }
            }

        }

        private void printerRTFCheckBox_CheckedChanged(object sender, EventArgs e) {
            //  Don't really need to do anything, it just toggles.
        }
    }
}
