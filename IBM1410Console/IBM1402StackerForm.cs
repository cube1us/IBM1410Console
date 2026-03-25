using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBM1410Console
{
    public partial class IBM1402StackerForm : Form


    {
        private IBM1402Stacker stacker;
        
        Font cardFont = new Font("IBM 1410 1403", 12, FontStyle.Regular);  // IBM 1410 1403 printer font

        public IBM1402StackerForm(IBM1402Stacker stacker) {
            InitializeComponent();

            this.Text = stacker.getStackerName();
            this.stacker = stacker;
            if(cardFont != null) {
                stackerRichTextBox1.Font = cardFont;
            }
            else {
                Debug.WriteLine("Can't initialize 1403 Font for card punch.");
            }

            stackerRichTextBox1.SuspendLayout();
            foreach (String s in stacker.getCardList()) {
                stackerRichTextBox1.AppendText(s);
            }
            stackerRichTextBox1.ResumeLayout();
        }

        //  Method to clear out the stacker
        private void stackerClearButton_Click(object sender, EventArgs e) {
            stackerRichTextBox1.Clear();
            stacker.reset();
        }

        //  Method to write out the stacker contents to a file.

        private void stackerSaveButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Card file (*.crd)|*.crd|Text file (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save stacker" + this.Text + " to a file";
            saveFileDialog.DefaultExt = "crd";
            saveFileDialog.AddExtension = true;

            //  Display the save file dialog and check if the users clicked OK

            if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = saveFileDialog.FileName;
                try {
                    System.IO.File.WriteAllText(fileName, stackerRichTextBox1.Text);
                }
                catch(Exception ex) {
                    MessageBox.Show($"Error saving stacker to file {fileName} {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
