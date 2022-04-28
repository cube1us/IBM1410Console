using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IBM1410Console
{

    public partial class UI1415LForm : Form
    {

        private IBM1410Lamp[] lamps = new IBM1410Lamp[IBM1410Lamp.lampVectorBits];
        bool[] oldLamps = new bool[IBM1410Lamp.lampVectorBits];
        bool[] newLamps = new bool[IBM1410Lamp.lampVectorBits];
        int lampByte = 0;

        private Color onWhite = Color.White;
        private Color onRed = Color.FromArgb(0xa0,0,0);
        private Color offDimGray = Color.DimGray;
        private Color bgRed = Color.FromArgb(100, 0, 0);

        private int testIndex = IBM1410Lamp.lampVectorBits - 1;
        
        public UI1415LForm(SerialDataPublisher lightOutputPublisher) {
            InitializeComponent();
            this.CreateHandle();    // This ensures that controls are created before receiving data from the FPGA 
            this.initLamps();

        }

        //  Initialize lamp arrays

        public void initLamps() {

            lamps[IBM1410Lamp.LAMP_11C8A01_INDEX] = new IBM1410Lamp(label_CE_Index_T_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A02_INDEX] = new IBM1410Lamp(label_CE_Index_H_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A04_INDEX] = new IBM1410Lamp(label_CE_Matrix_X1A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A05_INDEX] = new IBM1410Lamp(label_CE_Matrix_H, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A07_INDEX] = new IBM1410Lamp(label_CE_ADDR_ER, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A10_INDEX] = new IBM1410Lamp(label_CE_Assem_ER,false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A12_INDEX] = new IBM1410Lamp(label_CE_A_ER, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8A13_INDEX] = new IBM1410Lamp(label_CE_B_ER, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8B01_INDEX] = new IBM1410Lamp(label_CE_Index_T_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8B02_INDEX] = new IBM1410Lamp(label_CE_Index_H_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8B04_INDEX] = new IBM1410Lamp(label_CE_Matrix_33, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8B05_INDEX] = new IBM1410Lamp(label_CE_Matrix_32, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8C14_INDEX] = new IBM1410Lamp(label_CE_AChSel_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8D14_INDEX] = new IBM1410Lamp(label_CE_AChSel_d, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8E14_INDEX] = new IBM1410Lamp(label_CE_AChSel_E, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8F14_INDEX] = new IBM1410Lamp(label_CE_AChSel_F, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8F07_INDEX] = new IBM1410Lamp(label_CE_ADDR_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8G07_INDEX] = new IBM1410Lamp(label_CE_ADDR_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8H07_INDEX] = new IBM1410Lamp(label_CE_ADDR_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8J07_INDEX] = new IBM1410Lamp(label_CE_ADDR_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_11C8K07_INDEX] = new IBM1410Lamp(label_CE_ADDR_0, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMP_15A1A11_INDEX] = new IBM1410Lamp(label_Carry_In, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1A12_INDEX] = new IBM1410Lamp(label_B_GT_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1A14_INDEX] = new IBM1410Lamp(label_Interlock_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1A15_INDEX] = new IBM1410Lamp(label_Interlock_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1A16_INDEX] = new IBM1410Lamp(label_NotReady_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1A17_INDEX] = new IBM1410Lamp(label_NotReady_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1A19_INDEX] = new IBM1410Lamp(label_Check_AChannel, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1B14_INDEX] = new IBM1410Lamp(label_RBCInterlock_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1B15_INDEX] = new IBM1410Lamp(label_Check_Address, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1B19_INDEX] = new IBM1410Lamp(label_Check_Assembly, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C11_INDEX] = new IBM1410Lamp(label_Carry_Out, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C12_INDEX] = new IBM1410Lamp(label_B_EQ_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C15_INDEX] = new IBM1410Lamp(label_RBCInterlock_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C16_INDEX] = new IBM1410Lamp(label_Busy_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C17_INDEX] = new IBM1410Lamp(label_Busy_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C19_INDEX] = new IBM1410Lamp(label_Check_BChannel, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1C20_INDEX] = new IBM1410Lamp(label_Check_BRegisterSet, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E11_INDEX] = new IBM1410Lamp(label_A_Compl, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E12_INDEX] = new IBM1410Lamp(label_B_LT_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E14_INDEX] = new IBM1410Lamp(label_Read_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E15_INDEX] = new IBM1410Lamp(label_Read_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E16_INDEX] = new IBM1410Lamp(label_DataCheck_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E17_INDEX] = new IBM1410Lamp(label_DataCheck_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E20_INDEX] = new IBM1410Lamp(label_Check_OPRegisterSet, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1E21_INDEX] = new IBM1410Lamp(label_Check_RBCInterlock, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F11_INDEX] = new IBM1410Lamp(label_B_Compl, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F12_INDEX] = new IBM1410Lamp(label_Overflow, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F14_INDEX] = new IBM1410Lamp(label_Write_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F15_INDEX] = new IBM1410Lamp(label_Write_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F16_INDEX] = new IBM1410Lamp(label_Condition_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F17_INDEX] = new IBM1410Lamp(label_Condition_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F19_INDEX] = new IBM1410Lamp(label_Check_AddressChannel, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1F20_INDEX] = new IBM1410Lamp(label_Check_OPModifierSet, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1G08_INDEX] = new IBM1410Lamp(label_SubScan_U, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H08_INDEX] = new IBM1410Lamp(label_SubScan_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H12_INDEX] = new IBM1410Lamp(label_Divide_Overflow, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H14_INDEX] = new IBM1410Lamp(label_OverlapInProcess_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H15_INDEX] = new IBM1410Lamp(label_OverlapInProcess_Ch2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H16_INDEX] = new IBM1410Lamp(label_WrongLengthRecord_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H17_INDEX] = new IBM1410Lamp(label_WrongLengthRecord_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1H19_INDEX] = new IBM1410Lamp(label_Check_AddressExit, false, onRed, offDimGray) ;
            lamps[IBM1410Lamp.LAMP_15A1H20_INDEX] = new IBM1410Lamp(label_Check_ACharacterSelect, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1J08_INDEX] = new IBM1410Lamp(label_SubScan_E, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K08_INDEX] = new IBM1410Lamp(label_SubScan_MQ, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K12_INDEX] = new IBM1410Lamp(label_Zero_Balance, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K14_INDEX] = new IBM1410Lamp(label_NotOverlapInProcess_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K15_INDEX] = new IBM1410Lamp(label_NotOverlapInProcess_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K16_INDEX] = new IBM1410Lamp(label_NoTransfer_CH1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K17_INDEX] = new IBM1410Lamp(label_NoTransfer_CH2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K20_INDEX] = new IBM1410Lamp(label_Check_BCharacterSelect, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K21_INDEX] = new IBM1410Lamp(label_SystemControls_OffNormal, true, onRed, bgRed);
            lamps[IBM1410Lamp.LAMP_15A1K22_INDEX] = new IBM1410Lamp(label_SystemControls_PriorityAlert, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K23_INDEX] = new IBM1410Lamp(label_SystemControls_1401Compat, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1K24_INDEX] = new IBM1410Lamp(label_SystemControls_Stop, true, onRed, bgRed);
            lamps[IBM1410Lamp.LAMP_15A1V01_INDEX] = new IBM1410Lamp(label_Check_ARegisterSet, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1W01_INDEX] = new IBM1410Lamp(label_Check_IOInterlock, false, onRed, offDimGray);
            lamps[IBM1410Lamp.LAMP_15A1W04_INDEX] = new IBM1410Lamp(label_Check_Instruction, false, onRed, offDimGray);
            // Have not yet created the priority switch lamps 15A2K03, 15A2K05

            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 0] = new IBM1410Lamp(label_CE_CYC_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 1] = new IBM1410Lamp(label_CE_CYC_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 2] = new IBM1410Lamp(label_CE_CYC_C, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 3] = new IBM1410Lamp(label_CE_CYC_D, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 4] = new IBM1410Lamp(label_CE_CYC_E, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 5] = new IBM1410Lamp(label_CE_CYC_F, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 6] = new IBM1410Lamp(label_CE_CYC_I, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 7] = new IBM1410Lamp(label_CE_CYC_X, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 0] = new IBM1410Lamp(label_Cycle_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 1] = new IBM1410Lamp(label_Cycle_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 2] = new IBM1410Lamp(label_Cycle_C, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 3] = new IBM1410Lamp(label_Cycle_D, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 4] = new IBM1410Lamp(label_Cycle_E, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 5] = new IBM1410Lamp(label_Cycle_F, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 6] = new IBM1410Lamp(label_Cycle_I, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 7] = new IBM1410Lamp(label_Cycle_X, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 0] = new IBM1410Lamp(label_I_OP, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 1] = new IBM1410Lamp(label_I_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 2] = new IBM1410Lamp(label_I_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 3] = new IBM1410Lamp(label_I_3, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 4] = new IBM1410Lamp(label_I_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 5] = new IBM1410Lamp(label_I_5, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 6] = new IBM1410Lamp(label_I_6, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 7] = new IBM1410Lamp(label_I_7, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 8] = new IBM1410Lamp(label_I_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 9] = new IBM1410Lamp(label_I_9, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 10] = new IBM1410Lamp(label_I_10, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 11] = new IBM1410Lamp(label_I_11, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_IRING_INDEX + 12] = new IBM1410Lamp(label_I_12, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 0] = new IBM1410Lamp(label_CLK_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 1] = new IBM1410Lamp(label_CLK_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 2] = new IBM1410Lamp(label_CLK_C, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 3] = new IBM1410Lamp(label_CLK_D, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 4] = new IBM1410Lamp(label_CLK_E, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 5] = new IBM1410Lamp(label_CLK_F, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 6] = new IBM1410Lamp(label_CLK_G, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 7] = new IBM1410Lamp(label_CLK_H, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 8] = new IBM1410Lamp(label_CLK_J, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_LOGIC_GATE_RING_INDEX + 9] = new IBM1410Lamp(label_CLK_K, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_MAR_HP_INDEX + 0] = new IBM1410Lamp(label_CE_STAR_H_0, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_HP_INDEX + 1] = new IBM1410Lamp(label_CE_STAR_H_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_HP_INDEX + 2] = new IBM1410Lamp(label_CE_STAR_H_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_HP_INDEX + 3] = new IBM1410Lamp(label_CE_STAR_H_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_HP_INDEX + 4] = new IBM1410Lamp(label_CE_STAR_H_8, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_MAR_THP_INDEX + 0] = new IBM1410Lamp(label_CE_STAR_TH_0, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_THP_INDEX + 1] = new IBM1410Lamp(label_CE_STAR_TH_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_THP_INDEX + 2] = new IBM1410Lamp(label_CE_STAR_TH_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_THP_INDEX + 3] = new IBM1410Lamp(label_CE_STAR_TH_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_THP_INDEX + 4] = new IBM1410Lamp(label_CE_STAR_TH_8, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_MAR_TP_INDEX + 0] = new IBM1410Lamp(label_CE_STAR_T_0, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TP_INDEX + 1] = new IBM1410Lamp(label_CE_STAR_T_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TP_INDEX + 2] = new IBM1410Lamp(label_CE_STAR_T_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TP_INDEX + 3] = new IBM1410Lamp(label_CE_STAR_T_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TP_INDEX + 4] = new IBM1410Lamp(label_CE_STAR_T_8, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_MAR_TTHP_INDEX + 0] = new IBM1410Lamp(label_CE_STAR_TTH_0, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TTHP_INDEX + 1] = new IBM1410Lamp(label_CE_STAR_TTH_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TTHP_INDEX + 2] = new IBM1410Lamp(label_CE_STAR_TTH_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TTHP_INDEX + 3] = new IBM1410Lamp(label_CE_STAR_TTH_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_TTHP_INDEX + 4] = new IBM1410Lamp(label_CE_STAR_TTH_8, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_MAR_UP_INDEX + 0] = new IBM1410Lamp(label_CE_STAR_U_0, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_UP_INDEX + 1] = new IBM1410Lamp(label_CE_STAR_U_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_UP_INDEX + 2] = new IBM1410Lamp(label_CE_STAR_U_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_UP_INDEX + 3] = new IBM1410Lamp(label_CE_STAR_U_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_MAR_UP_INDEX + 4] = new IBM1410Lamp(label_CE_STAR_U_8, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 0] = new IBM1410Lamp(label_CE_MOD_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 1] = new IBM1410Lamp(label_CE_MOD_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 2] = new IBM1410Lamp(label_CE_MOD_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 3] = new IBM1410Lamp(label_CE_MOD_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 4] = new IBM1410Lamp(label_CE_MOD_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 5] = new IBM1410Lamp(label_CE_MOD_B, false, onWhite, offDimGray);
            // NOTE: 6 is not actually used
            lamps[IBM1410Lamp.LAMPS_OPMOD_CE_INDEX + 7] = new IBM1410Lamp(label_CE_MOD_C, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 0] = new IBM1410Lamp(label_CE_OP_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 1] = new IBM1410Lamp(label_CE_OP_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 2] = new IBM1410Lamp(label_CE_OP_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 3] = new IBM1410Lamp(label_CE_OP_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 4] = new IBM1410Lamp(label_CE_OP_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 5] = new IBM1410Lamp(label_CE_OP_B, false, onWhite, offDimGray);
            // NOTE: 6 is not actually used
            lamps[IBM1410Lamp.LAMPS_OPREG_CE_INDEX + 7] = new IBM1410Lamp(label_CE_OP_C, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_SCAN_INDEX + 0] = new IBM1410Lamp(label_Scan_N, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_SCAN_INDEX + 1] = new IBM1410Lamp(label_Scan_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_SCAN_INDEX + 2] = new IBM1410Lamp(label_Scan_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_SCAN_INDEX + 3] = new IBM1410Lamp(label_Scan_3, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 0] = new IBM1410Lamp(label_CE_A_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 1] = new IBM1410Lamp(label_CE_A_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 2] = new IBM1410Lamp(label_CE_A_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 3] = new IBM1410Lamp(label_CE_A_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 4] = new IBM1410Lamp(label_CE_A_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 5] = new IBM1410Lamp(label_CE_A_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 6] = new IBM1410Lamp(label_CE_A_WM, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_A_CH_INDEX + 7] = new IBM1410Lamp(label_CE_A_C, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_ARING_INDEX + 0] = new IBM1410Lamp(label_A_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ARING_INDEX + 1] = new IBM1410Lamp(label_A_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ARING_INDEX + 2] = new IBM1410Lamp(label_A_3, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ARING_INDEX + 3] = new IBM1410Lamp(label_A_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ARING_INDEX + 4] = new IBM1410Lamp(label_A_5, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ARING_INDEX + 5] = new IBM1410Lamp(label_A_6, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 0] = new IBM1410Lamp(label_CE_Assem_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 1] = new IBM1410Lamp(label_CE_Assem_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 2] = new IBM1410Lamp(label_CE_Assem_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 3] = new IBM1410Lamp(label_CE_Assem_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 4] = new IBM1410Lamp(label_CE_Assem_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 5] = new IBM1410Lamp(label_CE_Assem_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 6] = new IBM1410Lamp(label_CE_Assem_WM, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_INDEX + 7] = new IBM1410Lamp(label_CE_Assem_C, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 0] = new IBM1410Lamp(label_CE_Assem_Not1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 1] = new IBM1410Lamp(label_CE_Assem_Not2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 2] = new IBM1410Lamp(label_CE_Assem_Not4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 3] = new IBM1410Lamp(label_CE_Assem_Not8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 4] = new IBM1410Lamp(label_CE_Assem_NotA, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 5] = new IBM1410Lamp(label_CE_Assem_NotB, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 6] = new IBM1410Lamp(label_CE_Assem_NotWM, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_ASSM_CH_NOT_INDEX + 7] = new IBM1410Lamp(label_CE_Assem_NotC, false, onWhite, offDimGray);

            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 0] = new IBM1410Lamp(label_CE_B_1, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 1] = new IBM1410Lamp(label_CE_B_2, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 2] = new IBM1410Lamp(label_CE_B_4, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 3] = new IBM1410Lamp(label_CE_B_8, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 4] = new IBM1410Lamp(label_CE_B_A, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 5] = new IBM1410Lamp(label_CE_B_B, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 6] = new IBM1410Lamp(label_CE_B_WM, false, onWhite, offDimGray);
            lamps[IBM1410Lamp.LAMPS_B_CH_INDEX + 7] = new IBM1410Lamp(label_CE_B_C, false, onWhite, offDimGray);

            for(int i=0; i < IBM1410Lamp.lampVectorBits; ++i) {
                oldLamps[0] = newLamps[i] = false;
            }
        }

        //  This routine is invoked when we receive a byte of serial data

        void lampOutputAvailable(object sender, SerialDataEventArgs e ) {

            const int lampCodeByte = 0x80;
            int c = e.SerialByte;       // Contains 7 bits of lamp data

            //  Is this data really for us?

            if(e.DispatchCode != lampCodeByte) {
                return;
            }

            //  Move this set of data into the lamp array.  If the lamp array is full, 
            //  Then send a message to process any changes.  Don't do that on this thread
            //  thread coming from serial input!

            // TODO

        }

        private void testButton_Click(object sender, EventArgs e) {


            //  Locate the previous  lamp to turn off

            int previous = (testIndex == IBM1410Lamp.lampVectorBits - 1 ? IBM1410Lamp.minLampVector : testIndex + 1);
            IBM1410Lamp lamp;

            lamp = lamps[previous];
            if(lamp != null && lamp.label != null) {
                if (lamp.setBackground) {
                    lamp.label.BackColor = lamp.offColor;
                }
                else {
                    lamp.label.ForeColor = lamp.offColor;
                }
            }

            //  Turn on this lamp.

            lamp = lamps[testIndex];
            if (lamp != null && lamp.label != null) {
                if (lamp.setBackground) {
                    lamp.label.BackColor = lamp.onColor;
                }
                else {
                    lamp.label.ForeColor = lamp.onColor;
                }
            }

            if (--testIndex < IBM1410Lamp.minLampVector) {
                testIndex = IBM1410Lamp.lampVectorBits - 1;
            }
        }
    }
}
