using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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

        Font consoleFont = new Font("IBM1415", 12.0f, FontStyle.Regular);  // IBM 1410 1415
        Font consoleUnderlineFont = new Font("IBM1415", 12.0f, FontStyle.Underline);  // Underline (bad parity)

        public IBM1415ConsoleForm(SerialDataPublisher consoleOutputPublisher)
        {
            InitializeComponent();

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

            consoleOutputPublisher.SerialOutputEvent += new EventHandler<SerialDataEventArgs>(consoleOutputAvailable);
            // Debug.WriteLine("Event Handler for SerialDataPublisher Registered.");
        }

        void consoleOutputAvailable(object sender, SerialDataEventArgs e) {
            int c = e.SerialByte;
            string s = Char.ToString((char)e.SerialByte);
            // Debug.WriteLine("Data received by 1415 form: " + e.SerialByte.ToString("X2") + " /" + s + "/");

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
                };
                ConsoleOutput.Invoke(safeUnderline);
            }
            else {
                ConsoleOutput.SelectionStart = ConsoleOutput.Text.Length - 1;
                ConsoleOutput.SelectionLength = 1;
                ConsoleOutput.SelectionFont = consoleUnderlineFont;
                ConsoleOutput.SelectionLength = 0;
            }
        }


        void doAppend(string s) { 
            if (ConsoleOutput.InvokeRequired) {
                // Debug.WriteLine("Console Output event: Delegating append of text.");
                Action safeAppend = delegate { ConsoleOutput.AppendText(s); };
                ConsoleOutput.Invoke(safeAppend);
            }
            else {
                ConsoleOutput.AppendText(s);
                // Debug.WriteLine("Console Output Event: Writing text directly.");
            }
        }
    }
}
