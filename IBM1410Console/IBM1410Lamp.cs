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
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace IBM1410Console
{

    public class IBM1410Lamp
    {

        public System.Windows.Forms.Label label { get; set; }
        public bool setBackground { get; set; } = false;
        public Color onColor { get; set; }
        public Color offColor { get; set; }

        //  Constructor
        public IBM1410Lamp(Label label, bool setBackground, Color onColor, Color offColor) {

            this.label = label;
            this.setBackground = setBackground;
            this.onColor = onColor;
            this.offColor = offColor;
        }

		//	Default constructor

		public IBM1410Lamp() {
			this.label = null;
			this.setBackground = false;
			this.onColor = Color.Black;
			this.offColor = Color.Black;
        }


		public const int lampVectorBits = 203;
		public const int minLampVector = 1;
		public const int lampBytes = lampVectorBits / 7;

		public const int LAMP_11C8A01_INDEX = 202;  // TP B TAG 14.50.02.1
		public const int LAMP_11C8A02_INDEX = 201;  // HP B TAG 14.50.01.1
		public const int LAMP_11C8A04_INDEX = 200;  // MATRIX X1A 45.20.05.1
		public const int LAMP_11C8A05_INDEX = 199;  // CONS HOME 45.30.01.1
		public const int LAMP_11C8A07_INDEX = 198;  // ADDR CH VC 18.14.03.1
		public const int LAMP_11C8A10_INDEX = 197;  // ASM CH ERR 18.13.03.1
		public const int LAMP_11C8A12_INDEX = 196;  // A CH VC 18.11.03.1
		public const int LAMP_11C8A13_INDEX = 195;  // B CH VC 18.12.03.1
		public const int LAMP_11C8B01_INDEX = 194;  // TP A TAG 14.50.02.1
		public const int LAMP_11C8B02_INDEX = 193;  // HP A TAG 14.50.01.1
		public const int LAMP_11C8B04_INDEX = 192;  // MATRIX 33 45.20.09.1
		public const int LAMP_11C8B05_INDEX = 191;  // MATRIX 32 45.20.09.1
		public const int LAMP_11C8C14_INDEX = 190;  // CH SEL A 15.38.02.1
		public const int LAMP_11C8D14_INDEX = 189;  // CH SEL D 15.38.02.1
		public const int LAMP_11C8E14_INDEX = 188;  // E CH SEL 15.38.03.1
		public const int LAMP_11C8F07_INDEX = 187;  // ADDR CH 8 14.45.05.1
		public const int LAMP_11C8F14_INDEX = 186;  // F CH SEL 15.38.05.1
		public const int LAMP_11C8G07_INDEX = 185;  // ADDR CH 4 14.45.04.1
		public const int LAMP_11C8H07_INDEX = 184;  // ADDR CH 2 14.45.03.1
		public const int LAMP_11C8J07_INDEX = 183;  // ADDR CH 1 14.45.02.1
		public const int LAMP_11C8K07_INDEX = 182;  // ADDR CH 0 14.45.01.1
		public const int LAMP_15A1A11_INDEX = 181;  // CARRY IN 16.20.21.1
		public const int LAMP_15A1A12_INDEX = 180;  // B BIGGER 17.14.01.1
		public const int LAMP_15A1A14_INDEX = 179;  // CH 1 INLK 15.62.02.1
		public const int LAMP_15A1A15_INDEX = 178;  // CH 2 INLK 15.63.02.1
		public const int LAMP_15A1A16_INDEX = 177;  // CH1 NO RDY 12.62.01.1
		public const int LAMP_15A1A17_INDEX = 176;  // CH 2 N RDY 13.66.05.1
		public const int LAMP_15A1A19_INDEX = 175;  // A CH VC 18.11.03.1
		public const int LAMP_15A1B14_INDEX = 174;  // RBC ON 13.72.03.1
		public const int LAMP_15A1B15_INDEX = 173;  // CHECK 18.14.11.1
		public const int LAMP_15A1B19_INDEX = 172;  // ASM CH ERR 18.13.03.1
		public const int LAMP_15A1C11_INDEX = 171;  // CARRY OUT 16.14.06.1
		public const int LAMP_15A1C12_INDEX = 170;  // B EQUAL 17.14.03.1
		public const int LAMP_15A1C15_INDEX = 169;  // RBC INTLK 13.73.03.1
		public const int LAMP_15A1C16_INDEX = 168;  // CH 1 BUSY 12.62.02.1
		public const int LAMP_15A1C17_INDEX = 167;  // CH 2 BUSY 13.66.05.1
		public const int LAMP_15A1C19_INDEX = 166;  // B CHAN VC 18.12.03.1
		public const int LAMP_15A1C20_INDEX = 165;  // B RES ERR 18.14.06.1
		public const int LAMP_15A1E11_INDEX = 164;  // COMPL A 16.20.15.1
		public const int LAMP_15A1E12_INDEX = 163;  // B SMALLER 17.14.02.1
		public const int LAMP_15A1E14_INDEX = 162;  // CH 1 READ 15.62.01.1
		public const int LAMP_15A1E15_INDEX = 161;  // CH 2 READ 15.63.01.1
		public const int LAMP_15A1E16_INDEX = 160;  // CH 1 CHECK 12.62.04.1
		public const int LAMP_15A1E17_INDEX = 159;  // CH 2 CHECK 13.66.01.1
		public const int LAMP_15A1E20_INDEX = 158;  // OP ET ERR 18.14.04.1
		public const int LAMP_15A1E21_INDEX = 157;  // RBCI CHECK 13.74.02.1
		public const int LAMP_15A1F11_INDEX = 156;  // COMPL B 16.20.10.1
		public const int LAMP_15A1F12_INDEX = 155;  // OVERFLOW 16.45.02.1
		public const int LAMP_15A1F14_INDEX = 154;  // CH 1 WRITE 15.62.01.1
		public const int LAMP_15A1F15_INDEX = 153;  // CH 2 WRITE 15.63.01.1
		public const int LAMP_15A1F16_INDEX = 152;  // CH 1 COND 12.62.04.1
		public const int LAMP_15A1F17_INDEX = 151;  // CH 2 COND 13.66.01.1
		public const int LAMP_15A1F19_INDEX = 150;  // ADDR CH VC 18.14.03.1
		public const int LAMP_15A1F20_INDEX = 149;  // MOD SET CK 18.14.05.1
		public const int LAMP_15A1G08_INDEX = 148;  // UNITS 16.30.02.1
		public const int LAMP_15A1H08_INDEX = 147;  // BODY 16.30.04.1
		public const int LAMP_15A1H12_INDEX = 146;  // DIV OFLO 16.45.01.1
		public const int LAMP_15A1H14_INDEX = 145;  // CH 1 OVLP 13.60.04.1
		public const int LAMP_15A1H15_INDEX = 144;  // CH 2 OVLP 13.64.08.1
		public const int LAMP_15A1H16_INDEX = 143;  // CH 1 WLR 13.63.03.1
		public const int LAMP_15A1H17_INDEX = 142;  // CH 2 SLR 13.66.06.1
		public const int LAMP_15A1H19_INDEX = 141;  // ADDR X VC 18.14.02.1
		public const int LAMP_15A1H20_INDEX = 140;  // A CHAR SEL 18.14.01.1
		public const int LAMP_15A1J08_INDEX = 139;  // EXTEN 16.30.06.1
		public const int LAMP_15A1K08_INDEX = 138;  // MQ 16.30.07.1
		public const int LAMP_15A1K12_INDEX = 137;  // ZERO BAL 16.14.12.1
		public const int LAMP_15A1K14_INDEX = 136;  // CH1 UNOVLP 13.60.04.1
		public const int LAMP_15A1K15_INDEX = 135;  // CH 2 UNVOL 13.64.08.1
		public const int LAMP_15A1K16_INDEX = 134;  // NO TRF 13.72.04.1
		public const int LAMP_15A1K17_INDEX = 133;  // CH2 NO TRF 13.73.04.1
		public const int LAMP_15A1K20_INDEX = 132;  // B CHAR SEL 15.30.10.1
		public const int LAMP_15A1K21_INDEX = 131;  // OFF-NORMAL 40.10.03.1
		public const int LAMP_15A1K22_INDEX = 130;  // PRIORALERT 19.10.07.1
		public const int LAMP_15A1K23_INDEX = 129;  // 1401 MODE 12.65.10.1
		public const int LAMP_15A1K24_INDEX = 128;  // STOP 11.10.02.1
		public const int LAMP_15A1V01_INDEX = 127;  // A SET ERR 18.14.07.1
		public const int LAMP_15A1W01_INDEX = 126;  // CHECK 18.14.11.1
		public const int LAMP_15A1W04_INDEX = 125;  // CHECK 18.14.11.1
		public const int LAMP_15A2K03_INDEX = 124;  // PRIO SW ON 19.10.01.1
		public const int LAMP_15A2K05_INDEX = 123;  // PRIO SW ON 19.10.01.1
		public const int LAMPS_CYCLE_CE_INDEX = 115;    // LAMPS CYCLE CE 
		public const int LAMPS_CYCLE_CE_LEN = 8;    // LAMPS CYCLE CE 
		public const int LAMPS_CYCLE_CONSOLE_INDEX = 107;   // LAMPS CYCLE CONSOLE 
		public const int LAMPS_CYCLE_CONSOLE_LEN = 8;   // LAMPS CYCLE CONSOLE 
		public const int LAMPS_IRING_INDEX = 94;    // LAMPS IRING 
		public const int LAMPS_IRING_LEN = 13;  // LAMPS IRING 
		public const int LAMPS_LOGIC_GATE_RING_INDEX = 84;  // LAMPS LOGIC GATE RING 
		public const int LAMPS_LOGIC_GATE_RING_LEN = 10;    // LAMPS LOGIC GATE RING 
		public const int LAMPS_MAR_HP_INDEX = 79;   // LAMPS MAR HP 
		public const int LAMPS_MAR_HP_LEN = 5;  // LAMPS MAR HP 
		public const int LAMPS_MAR_THP_INDEX = 74;  // LAMPS MAR THP 
		public const int LAMPS_MAR_THP_LEN = 5; // LAMPS MAR THP 
		public const int LAMPS_MAR_TP_INDEX = 69;   // LAMPS MAR TP 
		public const int LAMPS_MAR_TP_LEN = 5;  // LAMPS MAR TP 
		public const int LAMPS_MAR_TTHP_INDEX = 64; // LAMPS MAR TTHP 
		public const int LAMPS_MAR_TTHP_LEN = 5;    // LAMPS MAR TTHP 
		public const int LAMPS_MAR_UP_INDEX = 59;   // LAMPS MAR UP 
		public const int LAMPS_MAR_UP_LEN = 5;  // LAMPS MAR UP 
		public const int LAMPS_OPMOD_CE_INDEX = 51; // LAMPS OPMOD CE 
		public const int LAMPS_OPMOD_CE_LEN = 8;    // LAMPS OPMOD CE 
		public const int LAMPS_OPREG_CE_INDEX = 43; // LAMPS OPREG CE 
		public const int LAMPS_OPREG_CE_LEN = 8;    // LAMPS OPREG CE 
		public const int LAMPS_SCAN_INDEX = 39; // LAMPS SCAN 
		public const int LAMPS_SCAN_LEN = 4;    // LAMPS SCAN 
		public const int LAMPS_A_CH_INDEX = 31; // LAMPS_A_CH 
		public const int LAMPS_A_CH_LEN = 8;    // LAMPS_A_CH 
		public const int LAMPS_ARING_INDEX = 25;    // LAMPS_ARING 
		public const int LAMPS_ARING_LEN = 6;   // LAMPS_ARING 
		public const int LAMPS_ASSM_CH_INDEX = 17;  // LAMPS_ASSM_CH 
		public const int LAMPS_ASSM_CH_LEN = 8; // LAMPS_ASSM_CH 
		public const int LAMPS_ASSM_CH_NOT_INDEX = 9;   // LAMPS_ASSM_CH_NOT 
		public const int LAMPS_ASSM_CH_NOT_LEN = 8; // LAMPS_ASSM_CH_NOT 
		public const int LAMPS_B_CH_INDEX = 1;  // LAMPS_B_CH 
		public const int LAMPS_B_CH_LEN = 8;    // LAMPS_B_CH 
	}
}
