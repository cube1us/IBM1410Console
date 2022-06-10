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
    public partial class IBM1415ConsoleForm : Form
    {

        private enum state { ordinary, wordmark, backspace};
        state printerState = state.ordinary;
        bool wmInProgress = false;

        const int CR = 0x0d;
        const int BSP = 0x08;
        const int WM = 0x76;
        const int UNDERSCORE = 0x5f;

        public const int SLEEPTIME = 100;

        const int consoleControlUpperCase = 0x01;
        const int consoleInquiryRequest = 0x02;
        const int consoleInquiryRelease = 0x04;
        const int consoleInquiryCancel = 0x08;
        const int consoleControlSpace = 0x10;
        const int consoleControlWM = 0x20;
        const int consoleControlFlag = 0x40;
        const int consoleControlIndex = 0x7f;
        const int consoleInputFlag = 0x81;

        protected byte[] consoleInputFlagByte = new byte[] { 0x81 };
        SerialPort serialPort = null;

        Font consoleFont = new Font("IBM1415", 12.0f, FontStyle.Regular);  // IBM 1410 1415
        Font consoleUnderlineFont = new Font("IBM1415", 12.0f, FontStyle.Underline);  // Underline (bad parity)

        public IBM1415ConsoleForm(SerialDataPublisher serialPublisher, SerialPort serialPort)
        {
            InitializeComponent();
            this.CreateHandle();    // This ensures controls are created before posting data from FPGA!

            if (consoleFont == null ) {
                ConsoleOutput.Text = "Unable to set font.";
            }
            else {
                ConsoleOutput.Font = consoleFont;
                ConsoleOutput.Text = "This is a test abcdef";
            }

            //            foreach(FontFamily ff in FontFamily.Families) {
            //               ConsoleOutput.Text = ConsoleOutput.Text + Environment.NewLine;
            //                ConsoleOutput.Text = ConsoleOutput.Text + ff.Name;
            //            }

            this.serialPort = serialPort;

            serialPublisher.SerialOutputEvent += new EventHandler<SerialDataEventArgs>(consoleOutputAvailable);
            serialPublisher.ConsoleLockOutputEvent += new EventHandler<ConsoleLockDataEventArgs>(consoleLockDataAvailable);
            Debug.WriteLine("Event Handler for SerialDataPublisher Registered.");
        }

        void consoleLockDataAvailable(object sender, ConsoleLockDataEventArgs e) {

            const int consoleLockCodeByte = 0x82;

            if (e.DispatchCode != consoleLockCodeByte) {
                return;
            }

            Debug.WriteLine("Data received by 1415 Console Keyboard Lock: " + e.SerialByte.ToString("X2"));

            if((e.SerialByte & 0x01) != 0) {
                Action safeLockChange = delegate {
                    keyboardLockLabel.ForeColor = Color.ForestGreen;
                    keyboardLockLabel.Text = "UNLOCKED";
                    ConsoleOutput.ScrollToCaret();
                };
                ConsoleOutput.Invoke(safeLockChange);
            }
            else {
                Action safeLockChange = delegate {
                    keyboardLockLabel.ForeColor = Color.Crimson;
                    keyboardLockLabel.Text = "LOCKED";
                };
                ConsoleOutput.Invoke(safeLockChange);
            }
        }

        void consoleOutputAvailable(object sender, SerialDataEventArgs e) {
            int c = e.SerialByte;

            const int consoleCodeByte = 0x88;

            if(e.DispatchCode != consoleCodeByte) {
                return;
            }

            string s = Char.ToString((char)e.SerialByte);
            Debug.WriteLine("Data received by 1415 Console Data: " + e.SerialByte.ToString("X2") + " /" + s + "/");


            switch (printerState) {
                case state.ordinary:
                    if (c == WM) {
                        printerState = state.wordmark;
                        // Print a naked wordmark.  Later, back up and overwrite
                        Debug.WriteLine("Printing WM character before backspace...");
                        s = char.ToString((char) 0xFF);
                        doAppend(s,false);
                    }
                    else if (c == BSP) {
                        printerState = state.backspace;
                    }
                    else if (wmInProgress) {
                        c |= 0x80;
                        s = Char.ToString((char)c);
                        doAppend(s,true); // This should replace the "naked" WM 
                        wmInProgress = false;
                    }
                    else {
                        doAppend(s,false);
                    }
                    break;
                case state.wordmark:
                    if(c == BSP) {
                        wmInProgress = true;
                        printerState = state.ordinary;
                    }
                    else {
                        s = "<naked WM>";
                        doAppend(s,false);
                        s = Char.ToString((char)c);
                        doAppend(s,false);
                        printerState = state.ordinary;
                    }
                    break;
                case state.backspace:
                    if(c == UNDERSCORE) {
                        Debug.WriteLine("received underline character...");
                        doUnderline();
                    }
                    else {
                        s = "<overprint?>" + s;
                        doAppend(s,false);
                    }
                    printerState = state.ordinary;
                    break;
            }
        }

        void doUnderline() {
            if (ConsoleOutput.InvokeRequired) {
                Action safeUnderline = delegate {
                    // Debug.WriteLine("Doing underline at " + (ConsoleOutput.Text.Length - 1).ToString());
                    ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length - 1;
                    ConsoleOutput.SelectionLength = 1;
                    ConsoleOutput.SelectionFont = consoleUnderlineFont;
                    ConsoleOutput.SelectionLength = 0;
                    ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length;
                    ConsoleOutput.SelectionFont = consoleFont;
                };
                ConsoleOutput.Invoke(safeUnderline);
            }
            else {
                ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length - 1;
                ConsoleOutput.SelectionLength = 1;
                ConsoleOutput.SelectionFont = consoleUnderlineFont;
                ConsoleOutput.SelectionLength = 0;
                ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length;
                ConsoleOutput.SelectionFont = consoleFont;
            }
        }


        void doAppend(string s, bool replace) { 
            if (ConsoleOutput.InvokeRequired) {
                Debug.WriteLine("Console Output event: Delegating append of text.");
                Action safeAppend = delegate { 
                    if(replace) {
                        ConsoleOutput.Text = ConsoleOutput.Text.Substring(0, ConsoleOutput.Text.Length - 1);
                        ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length;
                    }
                    ConsoleOutput.AppendText(s); 
                    if(s.Contains("\r")) {
                        ConsoleOutput.ScrollToCaret();
                    }
                };
                ConsoleOutput.Invoke(safeAppend);
            }
            else {
                if (replace) {
                    ConsoleOutput.Text = ConsoleOutput.Text.Substring(0,ConsoleOutput.Text.Length - 1);
                    ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length;
                }
                ConsoleOutput.AppendText(s);
                if (s.Contains("\r")) {
                    ConsoleOutput.ScrollToCaret();
                }
                Debug.WriteLine("Console Output Event: Writing text directly.");
            }
        }

        private void IBM1415ConsoleForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void ConsoleOutput_KeyPress(object sender, KeyPressEventArgs e) {
            Debug.WriteLine("Console input character /" + e.KeyChar + "/");
            byte[] consoleByte = new byte[1];
            byte[] consoleControlByte = new byte[1];
            byte inputBCDCharacter;
            bool controlKey = false;

            //  If the keyboard is locked, ignore the input

            if (e.KeyChar != (char)Keys.Back && !keyboardLockLabel.Text.Contains("UNLOCKED")) {
                Debug.WriteLine("Keyboard locked - input ignored.");
                e.Handled = true;
                return;
            }

            //  Life is easier if, for keyboard, we swap b (alt. blank) and B ("B")

            if (e.KeyChar == 'B') {
                inputBCDCharacter = IBM1410BCD.ASCIItoBCD('b');
            }
            else if (e.KeyChar == 'b') {
                inputBCDCharacter = IBM1410BCD.ASCIItoBCD('B');
            }
            else {
                inputBCDCharacter = IBM1410BCD.ASCIItoBCD(e.KeyChar);
            }

            consoleByte[0] = inputBCDCharacter;

            //  Ignore illegal input characters.

            if (inputBCDCharacter == 0xff) {
                Debug.WriteLine("Unknown input character ignored...");
                e.Handled = true;
                return;
            }

            //  Send the flag byte telling 1410 we are doing console input

            serialPort.Write(consoleInputFlagByte, 0, consoleInputFlagByte.Length);

            //  For special keys, send their control code 

            //  Otherwise, because we don't know what case the console typewriter is
            //  currently in, send a shift control byte to be sure.

            if (e.KeyChar == 0x17 || e.KeyChar == WM || e.KeyChar == 0x09) {
                //  Word Mark options
                Debug.WriteLine("Word Mark...");
                consoleControlByte[0] = consoleControlFlag | consoleControlWM;
                controlKey = true;
            }
            else if(e.KeyChar == (char) Keys.Back) {
                //  Backspace serves as the "Index" key
                Debug.WriteLine("Index Key...");
                consoleControlByte[0] = consoleControlFlag | consoleControlIndex;
                controlKey = true;
            }
            else if(e.KeyChar == 0x20) {
                //  Space
                Debug.WriteLine("Space Bar...");
                consoleControlByte[0] = consoleControlFlag | consoleControlSpace;
                controlKey = true;
            }
            else if (IBM1410BCD.BCDShifted(inputBCDCharacter)) {
                consoleControlByte[0] = consoleControlFlag | consoleControlUpperCase;
                Debug.WriteLine("Shifting to Upper case");
            }
            else {
                consoleControlByte[0] = consoleControlFlag;  // Lower case
                Debug.WriteLine("Shifting to Lower case");
            }

            serialPort.Write(consoleControlByte, 0, 1);

            //  Give time for the shift or control character to register

            System.Threading.Thread.Sleep(SLEEPTIME);

            //  If this was a control key, now turn the control bits off now.
            //  Otherwise, send the actual character.

            if (controlKey) {
                consoleControlByte[0] = consoleControlFlag;
                serialPort.Write(consoleControlByte, 0, 1);
            }
            else { 
                Debug.WriteLine("Console Input Sending BCD character");
                serialPort.Write(consoleByte, 0, 1);
            }

            //  Then, if we shifted to UC, shift back (as normally the operator would 
            //  take his finger of the shift key...

            // if (IBM1410BCD.BCDShifted(inputBCDCharacter)) {
            //    consoleControlByte[0] = consoleControlFlag;
            //    Debug.WriteLine("Shifting to lower case after upper case character");
            //    serialPort.Write(consoleControlByte, 0, 1);
            // }

            e.Handled = true;
        }
    }
}
