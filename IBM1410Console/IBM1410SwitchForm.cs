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

    public partial class IBM1410SwitchForm : Form
    {

        public const int switchVectorBits = 280;

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

        public IBM1410SwitchForm(SerialPort serialPort) {
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

			//	Testing Data

			// switchVector[0] = true;
			// switchVector[switchVectorBits - 1] = true;

			// setRotarySwitch(new bool[13] { false, false, false, false, false, false, false, true, false, false, false,
			// 	false, false}, SWITCH_ROT_MODE_SW_DK_INDEX, SWITCH_ROT_MODE_SW_DK_LEN);

			// sendSwitchVector();

			//	Initialize Switch Vector

			switchVector[SWITCH_MOM_STARTPRINT_INDEX] = true;			//	The Start Print switch is "backwards"
			switchVector[SWITCH_TOG_ASTERISK_PL2_INDEX] = true;			//	Asterisk Insert on by default
			switchVector[SWITCH_TOG_ASTERISK_PL1_INDEX] = false;		//	Ditto - this one is connected to OFF NORMAL
			switchVector[SWITCH_TOG_AUTO_START_PL1_INDEX] = true;		//	This one also drives OFF NORMAL, and we didn't implement it
			switchVector[SWITCH_ROT_STOR_SCAN_DK1_INDEX + 3] = true;    //	Storage Scan OFF
            switchVector[SWITCH_ROT_CYCLE_CTRL_DK1_INDEX + 2] = true;   //	Cycle Control OFF
			switchVector[SWITCH_ROT_CHECK_CTRL_DK1_INDEX + 2] = true;   //	Check Control STOP NORMAL
			switchVector[SWITCH_ROT_MODE_SW_DK_INDEX + 7] = true;       //	Mode RUN
			switchVector[SWITCH_ROT_ADDR_ENTRY_DK1_INDEX + 5] = true;   //	Address Entry NORMAL

			initalizing = false;
        }

        private void IBM1410SwitchForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

		private void setRotarySwitch(bool[] switchBits, int indexLowBit, int numBits) {
			for(int i = 0; i < numBits; ++i) {
				switchVector[indexLowBit + i] = switchBits[i];
            }
        }

		//	Method to transmit the bits to the FPGA

		private void sendSwitchVector() {

			Byte[] switchBytes = new byte[switchVector.Length / 7];
			byte tempByte = 0x00;
			int currentByte = 0;

			//	First, we send the special flag byte...

			// serialPort.Write(switchFlagByte, 0, switchFlagByte.Length);

			//	Next, we assemble the minions!!!

			for(int i = switchVector.Length - 1; i > 0; i -= 7) {

				tempByte = 0x00;

				for(int j = 0; j < 7; ++j) {
					tempByte = (byte)((tempByte << 1) | (switchVector[i - j] ? 1 : 0));
                }

				switchBytes[currentByte] = tempByte;
				++currentByte;
            }

			Debug.Write("Sending switch data: /");
			for(int i = 0; i < switchBytes.Length; ++i) {
				Debug.Write(switchBytes[i].ToString("X2") + " ");
            }
			Debug.WriteLine("/");
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e) {

			bool[] modeSwitch = new bool[SWITCH_ROT_MODE_SW_DK_LEN];

			//	Ignore changes while we initialize

			if(initalizing) {
				return;
            }
			
			//	First, it goes to a stop position

			setRotarySwitch(modeStop, SWITCH_ROT_MODE_SW_DK_INDEX, SWITCH_ROT_MODE_SW_DK_LEN);
			sendSwitchVector();
			System.Threading.Thread.Sleep(50);

			//	Next, we set the desired mode.

			modeSwitch[(modeComboBox.SelectedIndex * 2) + 1] = true;
			setRotarySwitch(modeSwitch, SWITCH_ROT_MODE_SW_DK_INDEX, SWITCH_ROT_MODE_SW_DK_LEN);
			sendSwitchVector();

		}
	}
}
