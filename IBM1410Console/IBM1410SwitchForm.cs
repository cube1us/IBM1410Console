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

            addressEntryComboBox.SelectedIndex = 4;
            storageScanComboBox.SelectedIndex = 2;
            cycleControlComboBox.SelectedIndex = 1;
            checkControlComboBox.SelectedIndex = 1;
            densityCh1ComboBox.SelectedIndex = 0;
            densityCh2ComboBox.SelectedIndex = 0;
            modeComboBox.SelectedIndex = 3;
            priorityUnitSelectcomboBox.SelectedIndex = 0;
            BCharSelComboBox.SelectedIndex = 0;
            addrTransferComboBox.SelectedIndex = 6;
            scanGateComboBox.SelectedIndex = 0;
        }
    }
}
