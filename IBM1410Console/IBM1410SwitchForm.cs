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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;


namespace IBM1410Console
{

    public partial class IBM1410SwitchForm : Form {

        public const int switchVectorBits = 280;
        public const int SLEEPTIME = 7;

        public const int SWITCH_ALT_PRIORITY_PL1_INDEX = 275;   // 19.10.01.1
        public const int SWITCH_ALT_PRIORITY_PL2_INDEX = 274;   // 19.10.01.1
        public const int SWITCH_MOM_1ST_TST_SW_PL1_INDEX = 273; // 18.14.10.1
        public const int SWITCH_MOM_2ND_TST_SW_PL1_INDEX = 272; // 18.14.10.1
        public const int SWITCH_MOM_3RD_TST_SW_PL1_INDEX = 271; // 18.14.10.1
        public const int SWITCH_MOM_ADDR_DISP_INDEX = 270;  // 14.71.30.1
        public const int SWITCH_MOM_CE_CPR_RST_INDEX = 269; // 12.65.01.1
        public const int SWITCH_MOM_CE_START_INDEX = 268;   // 12.15.02.1
        public const int SWITCH_MOM_CE_STOP_SW_PL1_INDEX = 267; // 12.15.03.1
        public const int SWITCH_MOM_CO_CPR_RST_INDEX = 266; // 12.65.01.1
        public const int SWITCH_MOM_CONS_START_INDEX = 265; // 12.15.02.1
        public const int SWITCH_MOM_CONS_STOP_PL1_INDEX = 264;  // 12.15.03.1
        public const int SWITCH_MOM_IO_CHK_RST_PL1_INDEX = 263; // 13.65.01.1
        public const int SWITCH_MOM_PROG_RESET_INDEX = 262; // 12.65.01.1
        public const int SWITCH_MOM_STARTPRINT_INDEX = 261; // 44.10.01.1
        public const int SWITCH_REL_PWR_ON_RST_INDEX = 260; // 12.65.01.1
        public const int SWITCH_REL_RTC_BUSY_INDEX = 259;   // 14.15.23.1
        public const int SWITCH_ROT_ADDR_ENTRY_DK1_INDEX = 246;    // 40.10.03.1
        public const int SWITCH_ROT_ADDR_ENTRY_DK1_LEN = 13;    // 40.10.03.1
        public const int SWITCH_ROT_ADDR_SEL_DK1_INDEX = 233;  // 14.71.30.1
        public const int SWITCH_ROT_ADDR_SEL_DK1_LEN = 13;  // 14.71.30.1
        public const int SWITCH_ROT_CHECK_CTRL_DK1_INDEX = 220;    // 40.10.03.1
        public const int SWITCH_ROT_CHECK_CTRL_DK1_LEN = 13;    // 40.10.03.1
        public const int SWITCH_ROT_CYCLE_CTRL_DK1_INDEX = 207;    // 40.10.03.1
        public const int SWITCH_ROT_CYCLE_CTRL_DK1_LEN = 13;    // 40.10.03.1
        public const int SWITCH_ROT_HRTC_012_CC_INDEX = 194;   // 14.15.20.1
        public const int SWITCH_ROT_HRTC_012_CC_LEN = 13;   // 14.15.20.1
        public const int SWITCH_ROT_HRTC_01234_CC_INDEX = 181; // 14.15.20.1
        public const int SWITCH_ROT_HRTC_01234_CC_LEN = 13; // 14.15.20.1
        public const int SWITCH_ROT_HRTC_56789_CC_INDEX = 168; // 14.15.20.1
        public const int SWITCH_ROT_HRTC_56789_CC_LEN = 13; // 14.15.20.1
        public const int SWITCH_ROT_HUNDS_SYNC_DK1_INDEX = 155;    // 14.17.19.1
        public const int SWITCH_ROT_HUNDS_SYNC_DK1_LEN = 13;    // 14.17.19.1
        public const int SWITCH_ROT_I_O_UNIT_DK1_INDEX = 149;  // 19.10.01.1
        public const int SWITCH_ROT_I_O_UNIT_DK1_LEN = 6;   // 19.10.01.1
        public const int SWITCH_ROT_M_RTC_023_CC_INDEX = 136;  // 14.15.20.1
        public const int SWITCH_ROT_M_RTC_023_CC_LEN = 13;  // 14.15.20.1
        public const int SWITCH_ROT_M_RTC_578_CC_INDEX = 123;  // 14.15.20.1
        public const int SWITCH_ROT_M_RTC_578_CC_LEN = 13;  // 14.15.20.1
        public const int SWITCH_ROT_MODE_SW_DK_INDEX = 110;    // 40.10.01.1
        public const int SWITCH_ROT_MODE_SW_DK_LEN = 13;    // 40.10.01.1
        public const int SWITCH_ROT_MRTC_01234_CC_INDEX = 97;  // 14.15.20.1
        public const int SWITCH_ROT_MRTC_01234_CC_LEN = 13; // 14.15.20.1
        public const int SWITCH_ROT_MRTC_56789_CC_INDEX = 84;  // 14.15.20.1
        public const int SWITCH_ROT_MRTC_56789_CC_LEN = 13; // 14.15.20.1
        public const int SWITCH_ROT_SCAN_GATE_DK1_INDEX = 71;  // 14.17.18.1
        public const int SWITCH_ROT_SCAN_GATE_DK1_LEN = 13; // 14.17.18.1
        public const int SWITCH_ROT_STOR_SCAN_DK1_INDEX = 58;  // 40.10.03.1
        public const int SWITCH_ROT_STOR_SCAN_DK1_LEN = 13; // 40.10.03.1
        public const int SWITCH_ROT_TENS_SYNC_DK1_INDEX = 45;  // 14.17.17.1
        public const int SWITCH_ROT_TENS_SYNC_DK1_LEN = 13; // 14.17.17.1
        public const int SWITCH_ROT_THOUS_SYNC_DK1_INDEX = 32; // 14.17.19.1
        public const int SWITCH_ROT_THOUS_SYNC_DK1_LEN = 13;    // 14.17.19.1
        public const int SWITCH_ROT_UNITS_SYNC_DK1_INDEX = 19; // 14.17.17.1
        public const int SWITCH_ROT_UNITS_SYNC_DK1_LEN = 13;    // 14.17.17.1
        public const int SWITCH_TOG_1401_MODE_PL1_INDEX = 18;   // 12.65.10.1
        public const int SWITCH_TOG_ADDR_STOP_PL1_INDEX = 17;   // 12.15.04.1
        public const int SWITCH_TOG_ASTERISK_PL1_INDEX = 16;    // 40.10.03.1
        public const int SWITCH_TOG_ASTERISK_PL2_INDEX = 15;    // 15.49.06.1
        public const int SWITCH_TOG_AUTO_START_PL1_INDEX = 14;  // 40.10.03.1
        public const int SWITCH_TOG_CH_1_INDEX = 13;    // 40.10.02.1
        public const int SWITCH_TOG_CH_2_INDEX = 12;    // 40.10.02.1
        public const int SWITCH_TOG_INHIBIT_PO_PL1_INDEX = 11;  // 40.10.03.1
        public const int SWITCH_TOG_INHIBIT_PO_PL2_INDEX = 10;  // 44.10.01.1
        public const int SWITCH_TOG_I_O_CHK_ST_PL1_INDEX = 9;   // 12.15.04.1
        public const int SWITCH_TOG_SENSE_SW_1_PL1_INDEX = 8;   // 15.60.01.1
        public const int SWITCH_TOG_SENSE_SW_2_PL1_INDEX = 7;   // 15.60.02.1
        public const int SWITCH_TOG_SENSE_SW_4_PL1_INDEX = 6;   // 15.60.03.1
        public const int SWITCH_TOG_SENSE_SW_8_PL1_INDEX = 5;   // 15.60.04.1
        public const int SWITCH_TOG_SENSE_SW_A_PL1_INDEX = 4;   // 15.60.05.1
        public const int SWITCH_TOG_SENSE_SW_B_PL1_INDEX = 3;   // 15.60.06.1
        public const int SWITCH_TOG_SENSE_SW_C_PL1_INDEX = 2;   // 15.60.07.1
        public const int SWITCH_TOG_SENSE_SW_W_PL1_INDEX = 1;   // 15.60.08.1
        public const int SWITCH_TOG_WR_INHIBIT_PL1_INDEX = 0;   // 40.10.03.1

        protected bool initalizing = true;
        protected bool[] switchVector = new bool[switchVectorBits];
        protected byte[] switchFlagByte = new byte[] { 0x80 };

        protected bool[] switchRotZeroes = new bool[13];  // All false, to reset switch bits.

        //	While mode switch is rotating, it hits "stop" first.
        protected readonly bool[] modeStop = { false, false, true, false, false, false, false, false, false, false, false, false, false };


        SerialPort serialPort = null;
        SemaphoreSlim serialOutputSemaphore = null;
        UI1415LForm lampForm = null;
        IBM1410TapesForm tapesForm = null;

        public IBM1410SwitchForm(SerialPort serialPort, SemaphoreSlim serialOutputSemaphore) {
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
            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;

            //	Testing Data

            // switchVector[0] = true;
            // switchVector[switchVectorBits - 1] = true;

            // setRotarySwitch(new bool[13] { false, false, false, false, false, false, false, true, false, false, false,
            // 	false, false}, SWITCH_ROT_MODE_SW_DK_INDEX, SWITCH_ROT_MODE_SW_DK_LEN);

            // sendSwitchVector();

            //	Initialize Switch Vector

            switchVector[SWITCH_MOM_STARTPRINT_INDEX] = true;           //	The Start Print switch is "backwards"
            switchVector[SWITCH_TOG_ASTERISK_PL2_INDEX] = true;         //	Asterisk Insert on by default
            switchVector[SWITCH_TOG_AUTO_START_PL1_INDEX] = true;       //	This one also drives OFF NORMAL, and we didn't implement it
            switchVector[SWITCH_ROT_STOR_SCAN_DK1_INDEX + 3] = true;    //	Storage Scan OFF
            switchVector[SWITCH_ROT_CYCLE_CTRL_DK1_INDEX + 2] = true;   //	Cycle Control OFF
            switchVector[SWITCH_ROT_CHECK_CTRL_DK1_INDEX + 2] = true;   //	Check Control STOP NORMAL
            switchVector[SWITCH_ROT_MODE_SW_DK_INDEX + 7] = true;       //	Mode RUN
            switchVector[SWITCH_ROT_ADDR_ENTRY_DK1_INDEX + 5] = true;   //	Address Entry NORMAL

            switchVector[SWITCH_ROT_SCAN_GATE_DK1_INDEX + 1] = true;    //	SCAN GATE OFF
            switchVector[SWITCH_ROT_THOUS_SYNC_DK1_INDEX + 10] = true;  //	Address stop address at "0"	
            switchVector[SWITCH_ROT_HUNDS_SYNC_DK1_INDEX + 10] = true;
            switchVector[SWITCH_ROT_TENS_SYNC_DK1_INDEX + 10] = true;
            switchVector[SWITCH_ROT_UNITS_SYNC_DK1_INDEX + 10] = true;

            initalizing = false;
        }

        //  To avoid circular constructors, this class uses a separate method to set the
        //  references to the tape and switch forms.

        public void setForms(UI1415LForm lampForm, IBM1410TapesForm tapesForm) {
            this.lampForm = lampForm;
            this.tapesForm = tapesForm;
        }

        private void IBM1410SwitchForm_FormClosing(object sender, FormClosingEventArgs e) {

            //  First, remember the size and location of the window...

            if (this.WindowState == FormWindowState.Normal) {
                // save location and size if the state is normal
                Properties.Settings.Default.SwitchesLoc = this.Location;
                Properties.Settings.Default.SwitchesSize = this.Size;
            }
            else {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.SwitchesLoc = this.RestoreBounds.Location;
                Properties.Settings.Default.SwitchesSize = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();

            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void setRotarySwitch(bool[] switchBits, int indexLowBit, int numBits) {
            for (int i = 0; i < numBits; ++i) {
                switchVector[indexLowBit + i] = switchBits[i];
            }

            sendSwitchVector();
        }

        private void setToggleSwitch(int indexBit, bool status) {
            switchVector[indexBit] = status;
            sendSwitchVector();
        }

        private void toggleAltSwitch(int indexBit) {

            switchVector[indexBit] = !switchVector[indexBit];
            sendSwitchVector();
        }

        private void toggleMomentarySwitch(bool onValue, int indexBit) {
            switchVector[indexBit] = onValue;
            sendSwitchVector();

            System.Threading.Thread.Sleep(SLEEPTIME);
            switchVector[indexBit] = !onValue;
            sendSwitchVector();
        }

        //	Method to transmit the bits to the FPGA

        private void sendSwitchVector() {

            Byte[] switchBytes = new byte[switchVector.Length / 7];
            byte tempByte = 0x00;
            int currentByte = 0;

            //  Wait for access to the serial port for output

            serialOutputSemaphore.Wait();

            //	First, we send the special flag byte...

            serialPort.Write(switchFlagByte, 0, switchFlagByte.Length);

            //	Next, we assemble the minions!!!

            for (int i = switchVector.Length - 1; i > 0; i -= 7) {

                tempByte = 0x00;

                for (int j = 0; j < 7; ++j) {
                    tempByte = (byte)((tempByte << 1) | (switchVector[i - j] ? 1 : 0));
                }

                switchBytes[currentByte] = tempByte;
                ++currentByte;
            }

            Debug.Write("Sending switch data: /");
            for (int i = 0; i < switchBytes.Length; ++i) {
                Debug.Write(switchBytes[i].ToString("X2") + " ");
            }
            Debug.WriteLine("/");

            serialPort.Write(switchBytes, 0, switchBytes.Length);

            serialOutputSemaphore.Release();
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            bool[] modeSwitch = new bool[SWITCH_ROT_MODE_SW_DK_LEN];

            //	Ignore changes while we initialize

            if (initalizing) {
                return;
            }

            //	First, it goes to a stop position

            setRotarySwitch(modeStop, SWITCH_ROT_MODE_SW_DK_INDEX, SWITCH_ROT_MODE_SW_DK_LEN);
            System.Threading.Thread.Sleep(SLEEPTIME);

            //	Next, we set the desired mode.

            modeSwitch[(modeComboBox.SelectedIndex * 2) + 1] = true;
            setRotarySwitch(modeSwitch, SWITCH_ROT_MODE_SW_DK_INDEX, SWITCH_ROT_MODE_SW_DK_LEN);
        }

        private void priorityProcessingButtonLabel_Click(object sender, EventArgs e) {
            switchVector[SWITCH_ALT_PRIORITY_PL1_INDEX] = !switchVector[SWITCH_ALT_PRIORITY_PL1_INDEX];
            toggleAltSwitch(SWITCH_ALT_PRIORITY_PL2_INDEX);
        }

        private void computerResetButton_Click(object sender, EventArgs e) {
            resetFormStates();  // Tell other forms about the reset
            toggleMomentarySwitch(true, SWITCH_MOM_CO_CPR_RST_INDEX);
        }

        private void startButton_Click(object sender, EventArgs e) {
            toggleMomentarySwitch(true, SWITCH_MOM_CONS_START_INDEX);
        }

        private void cycleControlComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            bool[] cycleSwitch = new bool[SWITCH_ROT_CYCLE_CTRL_DK1_LEN];

            //	Ignore changes while we initialize

            if (initalizing) {
                return;
            }

            cycleSwitch[cycleControlComboBox.SelectedIndex + 1] = true;
            setRotarySwitch(cycleSwitch, SWITCH_ROT_CYCLE_CTRL_DK1_INDEX, SWITCH_ROT_CYCLE_CTRL_DK1_LEN);
        }

        private void addressEntryComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            bool[] addrEntrySwitch = new bool[SWITCH_ROT_ADDR_ENTRY_DK1_LEN];

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            addrEntrySwitch[addressEntryComboBox.SelectedIndex + 1] = true;
            setRotarySwitch(addrEntrySwitch, SWITCH_ROT_ADDR_ENTRY_DK1_INDEX, SWITCH_ROT_ADDR_ENTRY_DK1_LEN);
        }

        private void checkControlComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            bool[] checkControlSwitch = new bool[SWITCH_ROT_CHECK_CTRL_DK1_LEN];

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            checkControlSwitch[checkControlComboBox.SelectedIndex + 1] = true;
            setRotarySwitch(checkControlSwitch, SWITCH_ROT_CHECK_CTRL_DK1_INDEX, SWITCH_ROT_CHECK_CTRL_DK1_LEN);
        }

        private void storageScanComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            bool[] storageScanSwitch = new bool[SWITCH_ROT_STOR_SCAN_DK1_LEN];

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            storageScanSwitch[storageScanComboBox.SelectedIndex + 1] = true;
            setRotarySwitch(storageScanSwitch, SWITCH_ROT_STOR_SCAN_DK1_INDEX, SWITCH_ROT_STOR_SCAN_DK1_LEN);
        }

        private void diskWrInhibitCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_WR_INHIBIT_PL1_INDEX, diskWrInhibitCheckBox.Checked);
        }

        private void densityCh1ComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            //	Really, this is a three position toggle, but I eliminated, at least temporarily,
            //	the middle (200/800) position so as to avoid all of the switch index values changing.

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            setToggleSwitch(SWITCH_TOG_CH_1_INDEX, densityCh1ComboBox.SelectedIndex > 0);
        }

        private void densityCh2ComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            //	Really, this is a three position toggle, but I eliminated, at least temporarily,
            //	the middle (200/800) position so as to avoid all of the switch index values changing.

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            setToggleSwitch(SWITCH_TOG_CH_2_INDEX, densityCh2ComboBox.SelectedIndex > 0);
        }

        private void startPrintOutButton_Click(object sender, EventArgs e) {
            toggleMomentarySwitch(false, SWITCH_MOM_STARTPRINT_INDEX);   // This is one of the "backwards" switches.
        }

        private void compat1401CheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_1401_MODE_PL1_INDEX, compat1401CheckBox.Checked);
        }

        private void IOCheckReset1401Button_Click(object sender, EventArgs e) {
            toggleMomentarySwitch(true, SWITCH_MOM_IO_CHK_RST_PL1_INDEX);
        }

        private void IOCheckStop1401CheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_I_O_CHK_ST_PL1_INDEX, IOCheckStop1401CheckBox.Checked);
        }

        private void checkTest1Button_Click(object sender, EventArgs e) {

            //	For ease of use, treat like an alternating switch...

            checkTest1Button.BackColor = !switchVector[SWITCH_MOM_1ST_TST_SW_PL1_INDEX] ? Color.Red : Color.DarkGray;
            toggleAltSwitch(SWITCH_MOM_1ST_TST_SW_PL1_INDEX);
        }

        private void checkTest2Button_Click(object sender, EventArgs e) {

            //	For ease of use, treat like an alternating switch...

            checkTest2Button.BackColor = !switchVector[SWITCH_MOM_2ND_TST_SW_PL1_INDEX] ? Color.Red : Color.DarkGray;
            toggleAltSwitch(SWITCH_MOM_2ND_TST_SW_PL1_INDEX);
        }

        private void checkTest3Button_Click(object sender, EventArgs e) {

            //	For ease of use, treat like an alternating switch...

            checkTest3Button.BackColor = !switchVector[SWITCH_MOM_3RD_TST_SW_PL1_INDEX] ? Color.Red : Color.LightGray;
            toggleAltSwitch(SWITCH_MOM_3RD_TST_SW_PL1_INDEX);
        }

        private void asteriskInsertCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_ASTERISK_PL2_INDEX, asteriskInsertCheckBox.Checked);
        }

        private void inhibitPrintOutCheckBox_CheckedChanged(object sender, EventArgs e) {
            switchVector[SWITCH_TOG_INHIBIT_PO_PL2_INDEX] = inhibitPrintOutCheckBox.Checked;  // Two simultaneous changes
            setToggleSwitch(SWITCH_TOG_INHIBIT_PO_PL1_INDEX, inhibitPrintOutCheckBox.Checked);
        }

        //	Note that the 1410 switch names are by BIT NUMBER, not the 1401 ABCDEFGH

        private void senseACheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_C_PL1_INDEX, senseACheckBox.Checked);
        }

        private void senseBCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_B_PL1_INDEX, senseBCheckBox.Checked);
        }

        private void senseCCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_A_PL1_INDEX, senseCCheckBox.Checked);
        }

        private void senseDCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_8_PL1_INDEX, senseDCheckBox.Checked);
        }

        private void senseECheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_4_PL1_INDEX, senseECheckBox.Checked);
        }

        private void senseFCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_2_PL1_INDEX, senseFCheckBox.Checked);
        }

        private void senseGCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_1_PL1_INDEX, senseGCheckBox.Checked);
        }

        private void senseWMCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_SENSE_SW_W_PL1_INDEX, senseWMCheckBox.Checked);
        }

        private void programResetButton_Click(object sender, EventArgs e) {
            resetFormStates();  //  Tell other forms about the reset.
            toggleMomentarySwitch(true, SWITCH_MOM_PROG_RESET_INDEX);
        }

        private void stopButton_Click(object sender, EventArgs e) {
            toggleMomentarySwitch(true, SWITCH_MOM_CONS_STOP_PL1_INDEX);
        }

        private void addrStopCheckBox_CheckedChanged(object sender, EventArgs e) {
            setToggleSwitch(SWITCH_TOG_ADDR_STOP_PL1_INDEX, addrStopCheckBox.Checked);
        }

        private void addrTransferComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            bool[] addrSelSwitch = new bool[SWITCH_ROT_ADDR_SEL_DK1_LEN];

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            addrSelSwitch[addrTransferComboBox.SelectedIndex + 1] = true;  // This switch starts at 2nd position
            setRotarySwitch(addrSelSwitch, SWITCH_ROT_ADDR_SEL_DK1_INDEX, SWITCH_ROT_ADDR_SEL_DK1_LEN);
        }

        private void addrTransferButton_Click(object sender, EventArgs e) {
            toggleMomentarySwitch(true, SWITCH_MOM_ADDR_DISP_INDEX);
        }

        private void scanGateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            bool[] scanGateSwitch = new bool[SWITCH_ROT_SCAN_GATE_DK1_LEN];

            // Ignore changes while initializing.

            if (initalizing) {
                return;
            }

            //	Note:  Page 14.18.17.1 says "NOTE: SCAN GATE SWTICH IS A CIRCUIT OPENING SWITCH
            //  (so it is "upside down).  But I decided to handle that in the FPGA itself.

            scanGateSwitch[scanGateComboBox.SelectedIndex + 1] = true;
            setRotarySwitch(scanGateSwitch, SWITCH_ROT_SCAN_GATE_DK1_INDEX, SWITCH_ROT_SCAN_GATE_DK1_LEN);
        }

        private void thousandsNumericUpDown_ValueChanged(object sender, EventArgs e) {
            bool[] numericSwitch = new bool[SWITCH_ROT_THOUS_SYNC_DK1_LEN];

            if (thousandsNumericUpDown.Value == 0) {
                numericSwitch[10] = true;
            }
            else {
                numericSwitch[(int)thousandsNumericUpDown.Value + 1] = true;
            }
            setRotarySwitch(numericSwitch, SWITCH_ROT_THOUS_SYNC_DK1_INDEX, SWITCH_ROT_THOUS_SYNC_DK1_LEN);
        }

        private void hundredsNumericUpDown_ValueChanged(object sender, EventArgs e) {
            bool[] numericSwitch = new bool[SWITCH_ROT_HUNDS_SYNC_DK1_LEN];

            if (hundredsNumericUpDown.Value == 0) {
                numericSwitch[10] = true;
            }
            else {
                numericSwitch[(int)hundredsNumericUpDown.Value + 1] = true;
            }
            setRotarySwitch(numericSwitch, SWITCH_ROT_HUNDS_SYNC_DK1_INDEX, SWITCH_ROT_HUNDS_SYNC_DK1_LEN);
        }

        private void tensNumericUpDown_ValueChanged(object sender, EventArgs e) {
            bool[] numericSwitch = new bool[SWITCH_ROT_TENS_SYNC_DK1_LEN];

            if (tensNumericUpDown.Value == 0) {
                numericSwitch[10] = true;
            }
            else {
                numericSwitch[(int)tensNumericUpDown.Value + 1] = true;
            }
            setRotarySwitch(numericSwitch, SWITCH_ROT_TENS_SYNC_DK1_INDEX, SWITCH_ROT_TENS_SYNC_DK1_LEN);
        }

        private void unitsNumericUpDown_ValueChanged(object sender, EventArgs e) {
            bool[] numericSwitch = new bool[SWITCH_ROT_UNITS_SYNC_DK1_LEN];

            if (unitsNumericUpDown.Value == 0) {
                numericSwitch[10] = true;
            }
            else {
                numericSwitch[(int)unitsNumericUpDown.Value + 1] = true;
            }
            setRotarySwitch(numericSwitch, SWITCH_ROT_UNITS_SYNC_DK1_INDEX, SWITCH_ROT_UNITS_SYNC_DK1_LEN);
        }

        private void IBM1410SwitchForm_Load(object sender, EventArgs e) {

            //  If we have saved settings for this window, use them.

            if (Properties.Settings.Default.SwitchesSize.Width != 0 &&
                Properties.Settings.Default.SwitchesSize.Height != 0) {
                this.Size = Properties.Settings.Default.SwitchesSize;
                this.Location = Properties.Settings.Default.SwitchesLoc;
            }
        }

        //  Method to reset lamps and tape on a computer or program reset

        private void resetFormStates() {

            if(lampForm == null || tapesForm == null) return;

            Action resetLampOffset = delegate {
                lampForm.resetLampOffset();
            };

            Action resetTapeSerialState = delegate { 
                tapesForm.tapeSerialStateReset();
            };

            this.Invoke(resetLampOffset);
            this.Invoke(resetTapeSerialState);            
        }


    }
}
