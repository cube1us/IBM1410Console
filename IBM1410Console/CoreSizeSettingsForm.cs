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
    public partial class CoreSizeSettingsForm : Form
    {

        public CoreSizeSettingsForm() {
            InitializeComponent();
        }

        public void setCoreSize(string size) {
            coreSizeComboBox.SelectedItem = size;
        }

        public long getCoreSize() {
            return (long) coreSizeComboBox.SelectedItem;
        }

        private void coreSizeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            string s = coreSizeComboBox.SelectedItem.ToString();
            Properties.Settings.Default.CoreSize = Int32.Parse(s);
            Debug.WriteLine("FPGA core size set to " + Properties.Settings.Default.CoreSize);
            Properties.Settings.Default.Save();
        }
    }
}
