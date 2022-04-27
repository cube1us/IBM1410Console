using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IBM1410Console;

namespace IBM1410Console
{

    public partial class UI1415LForm : Form
    {

        private IBM1410Lamp[] Lamps = new IBM1410Lamp[IBM1410Lamp.lampVectorBits];

        public UI1415LForm(SerialDataPublisher lightOutputPublisher) {
            InitializeComponent();
            this.CreateHandle();    // This ensures that controls are created before receiving data from the FPGA 
            this.initLamps();

        }

        public void initLamps() {

        }
    }
}
