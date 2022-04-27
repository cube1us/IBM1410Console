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
        
        private Color onWhite = Color.White;
        private Color onRed = Color.FromArgb(0xa0,0,0);
        private Color offDarkGray = Color.DarkGray;
        private Color bgRed = Color.FromArgb(100, 0, 0);
        

        public UI1415LForm(SerialDataPublisher lightOutputPublisher) {
            InitializeComponent();
            this.CreateHandle();    // This ensures that controls are created before receiving data from the FPGA 
            this.initLamps();

        }

        //  Initialize lamp arrays

        public void initLamps() {

            lamps[IBM1410Lamp.LAMP_11C8A01_INDEX] = new IBM1410Lamp(label_CE_Index_T_B, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A02_INDEX] = new IBM1410Lamp(label_CE_Index_H_B, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A04_INDEX] = new IBM1410Lamp(label_CE_Matrix_X1A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A05_INDEX] = new IBM1410Lamp(label_CE_Matrix_H, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A07_INDEX] = new IBM1410Lamp(label_CE_ADDR_ER, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A10_INDEX] = new IBM1410Lamp(label_CE_Assem_ER,false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A12_INDEX] = new IBM1410Lamp(label_CE_A_ER, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8A13_INDEX] = new IBM1410Lamp(label_CE_B_ER, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8B01_INDEX] = new IBM1410Lamp(label_CE_Index_T_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8B02_INDEX] = new IBM1410Lamp(label_CE_Index_H_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8B04_INDEX] = new IBM1410Lamp(label_CE_Matrix_32, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8B05_INDEX] = new IBM1410Lamp(label_CE_Index_T_B, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8C14_INDEX] = new IBM1410Lamp(label_CE_AChSel_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8D14_INDEX] = new IBM1410Lamp(label_CE_AChSel_d, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8E14_INDEX] = new IBM1410Lamp(label_CE_AChSel_E, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8F14_INDEX] = new IBM1410Lamp(label_CE_AChSel_F, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8F07_INDEX] = new IBM1410Lamp(label_CE_ADDR_8, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8G07_INDEX] = new IBM1410Lamp(label_CE_ADDR_4, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8H07_INDEX] = new IBM1410Lamp(label_CE_ADDR_2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8J07_INDEX] = new IBM1410Lamp(label_CE_ADDR_1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_11C8K07_INDEX] = new IBM1410Lamp(label_CE_ADDR_0, false, onWhite, offDarkGray);

            lamps[IBM1410Lamp.LAMP_15A1A11_INDEX] = new IBM1410Lamp(label_Carry_In, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1A12_INDEX] = new IBM1410Lamp(label_B_GT_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1A14_INDEX] = new IBM1410Lamp(label_Interlock_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1A15_INDEX] = new IBM1410Lamp(label_Interlock_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1A16_INDEX] = new IBM1410Lamp(label_NotReady_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1A17_INDEX] = new IBM1410Lamp(label_NotReady_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1A19_INDEX] = new IBM1410Lamp(label_Check_AChannel, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1B14_INDEX] = new IBM1410Lamp(label_RBCInterlock_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1B15_INDEX] = new IBM1410Lamp(label_Check_Address, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1B19_INDEX] = new IBM1410Lamp(label_Check_Assembly, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C11_INDEX] = new IBM1410Lamp(label_Carry_Out, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C12_INDEX] = new IBM1410Lamp(label_B_EQ_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C15_INDEX] = new IBM1410Lamp(label_RBCInterlock_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C16_INDEX] = new IBM1410Lamp(label_Busy_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C17_INDEX] = new IBM1410Lamp(label_Busy_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C19_INDEX] = new IBM1410Lamp(label_Check_BChannel, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1C20_INDEX] = new IBM1410Lamp(label_Check_BRegisterSet, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E11_INDEX] = new IBM1410Lamp(label_A_Compl, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E12_INDEX] = new IBM1410Lamp(label_B_LT_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E14_INDEX] = new IBM1410Lamp(label_Read_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E15_INDEX] = new IBM1410Lamp(label_Read_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E16_INDEX] = new IBM1410Lamp(label_DataCheck_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E17_INDEX] = new IBM1410Lamp(label_DataCheck_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E20_INDEX] = new IBM1410Lamp(label_Check_OPRegisterSet, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1E21_INDEX] = new IBM1410Lamp(label_Check_RBCInterlock, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F11_INDEX] = new IBM1410Lamp(label_B_Compl, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F12_INDEX] = new IBM1410Lamp(label_Overflow, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F14_INDEX] = new IBM1410Lamp(label_Write_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F15_INDEX] = new IBM1410Lamp(label_Write_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F16_INDEX] = new IBM1410Lamp(label_Condition_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F17_INDEX] = new IBM1410Lamp(label_Condition_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F19_INDEX] = new IBM1410Lamp(label_Check_AddressChannel, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1F20_INDEX] = new IBM1410Lamp(label_Check_OPModifierSet, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1G08_INDEX] = new IBM1410Lamp(label_SubScan_U, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H08_INDEX] = new IBM1410Lamp(label_SubScan_B, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H12_INDEX] = new IBM1410Lamp(label_Divide_Overflow, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H14_INDEX] = new IBM1410Lamp(label_OverlapInProcess_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H15_INDEX] = new IBM1410Lamp(label_OverlapInProcess_Ch2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H16_INDEX] = new IBM1410Lamp(label_WrongLengthRecord_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H17_INDEX] = new IBM1410Lamp(label_WrongLengthRecord_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1H19_INDEX] = new IBM1410Lamp(label_Check_AddressExit, false, onRed, offDarkGray) ;
            lamps[IBM1410Lamp.LAMP_15A1H20_INDEX] = new IBM1410Lamp(label_Check_ACharacterSelect, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1J08_INDEX] = new IBM1410Lamp(label_SubScan_E, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K08_INDEX] = new IBM1410Lamp(label_SubScan_MQ, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K12_INDEX] = new IBM1410Lamp(label_Zero_Balance, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K14_INDEX] = new IBM1410Lamp(label_NotOverlapInProcess_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K15_INDEX] = new IBM1410Lamp(label_NotOverlapInProcess_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K16_INDEX] = new IBM1410Lamp(label_NoTransfer_CH1, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K17_INDEX] = new IBM1410Lamp(label_NoTransfer_CH2, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K20_INDEX] = new IBM1410Lamp(label_Check_BCharacterSelect, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K21_INDEX] = new IBM1410Lamp(label_SystemControls_OffNormal, true, onRed, bgRed);
            lamps[IBM1410Lamp.LAMP_15A1K22_INDEX] = new IBM1410Lamp(label_SystemControls_PriorityAlert, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K23_INDEX] = new IBM1410Lamp(label_SystemControls_1401Compat, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1K24_INDEX] = new IBM1410Lamp(label_SystemControls_Stop, true, onRed, bgRed);
            lamps[IBM1410Lamp.LAMP_15A1V01_INDEX] = new IBM1410Lamp(label_Check_ARegisterSet, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1W01_INDEX] = new IBM1410Lamp(label_Check_IOInterlock, false, onRed, offDarkGray);
            lamps[IBM1410Lamp.LAMP_15A1W04_INDEX] = new IBM1410Lamp(label_Check_Instruction, false, onRed, offDarkGray);
            // Have not yet created the priority switch lamps 15A2K03, 15A2K05

            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 0] = new IBM1410Lamp(label_CE_CYC_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 1] = new IBM1410Lamp(label_CE_CYC_B, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 2] = new IBM1410Lamp(label_CE_CYC_C, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 3] = new IBM1410Lamp(label_CE_CYC_D, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 4] = new IBM1410Lamp(label_CE_CYC_E, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 5] = new IBM1410Lamp(label_CE_CYC_F, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 6] = new IBM1410Lamp(label_CE_CYC_I, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CE_INDEX + 7] = new IBM1410Lamp(label_CE_CYC_X, false, onWhite, offDarkGray);

            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 0] = new IBM1410Lamp(label_Cycle_A, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 1] = new IBM1410Lamp(label_Cycle_B, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 2] = new IBM1410Lamp(label_Cycle_C, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 3] = new IBM1410Lamp(label_Cycle_D, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 4] = new IBM1410Lamp(label_Cycle_E, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 5] = new IBM1410Lamp(label_Cycle_F, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 6] = new IBM1410Lamp(label_Cycle_I, false, onWhite, offDarkGray);
            lamps[IBM1410Lamp.LAMPS_CYCLE_CONSOLE_INDEX + 7] = new IBM1410Lamp(label_Cycle_X, false, onWhite, offDarkGray);










        }
    }
}
