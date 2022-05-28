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
                    }
                    else if (c == BSP) {
                        printerState = state.backspace;
                    }
                    else if (wmInProgress) {
                        c |= 0x80;
                        s = Char.ToString((char)c);
                        doAppend(s);
                        wmInProgress = false;
                    }
                    else {
                        doAppend(s);
                    }
                    break;
                case state.wordmark:
                    if(c == BSP) {
                        wmInProgress = true;
                        printerState = state.ordinary;
                    }
                    else {
                        s = "<naked WM>";
                        doAppend(s);
                        s = Char.ToString((char)c);
                        doAppend(s);
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
                        doAppend(s);
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


        void doAppend(string s) { 
            if (ConsoleOutput.InvokeRequired) {
                Debug.WriteLine("Console Output event: Delegating append of text.");
                Action safeAppend = delegate { 
                    ConsoleOutput.AppendText(s); 
                    if(s.Contains("\r")) {
                        ConsoleOutput.ScrollToCaret();
                    }
                };
                ConsoleOutput.Invoke(safeAppend);
            }
            else {
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

            // TODO:  Handle upper vs. lower case

            //	First, we send the special flag byte...

            serialPort.Write(consoleInputFlagByte, 0, consoleInputFlagByte.Length);

            //  Then the actual character -- in BCD -- for testing, just sending a zero for now

            byte[] testByte = new byte[] { 0x0a };  // BCD '0'

            serialPort.Write(testByte, 0, testByte.Length);

            e.Handled = true;
        }
    }
}
