using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IBM1410Console
{
    public partial class IBM1410SwitchForm : Form
    {
        public IBM1410SwitchForm() {
            InitializeComponent();
            this.CreateHandle();

            addressEntryComboBox.SelectedIndex = 0;
            storageScanComboBox.SelectedIndex = 0;
            cycleControlComboBox.SelectedIndex = 0;
            checkControlComboBox.SelectedIndex = 0;
            densityCh1ComboBox.SelectedIndex = 0;
            densityCh2ComboBox.SelectedIndex = 0;
        }

        private void IBM1410SwitchForm_Load(object sender, EventArgs e) {

        }
    }
}
