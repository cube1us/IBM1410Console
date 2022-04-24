
namespace IBM1410Console
{
    partial class UI1415L
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabPageControl = new System.Windows.Forms.TabControl();
            this.tabCPUStatus = new System.Windows.Forms.TabPage();
            this.panel1415CPUOutline = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelCPU = new System.Windows.Forms.Panel();
            this.panelCPUBorder = new System.Windows.Forms.Panel();
            this.panelIRing = new System.Windows.Forms.Panel();
            this.label_I_2 = new System.Windows.Forms.Label();
            this.label_I_1 = new System.Windows.Forms.Label();
            this.label_I_OP = new System.Windows.Forms.Label();
            this.labelCPU = new System.Windows.Forms.Label();
            this.tabIOChannels = new System.Windows.Forms.TabPage();
            this.tabSystemCheck = new System.Windows.Forms.TabPage();
            this.tabPowerSystemControls = new System.Windows.Forms.TabPage();
            this.tabCEPanel = new System.Windows.Forms.TabPage();
            this.panelARing = new System.Windows.Forms.Panel();
            this.panelClock = new System.Windows.Forms.Panel();
            this.panelScan = new System.Windows.Forms.Panel();
            this.panelCycle = new System.Windows.Forms.Panel();
            this.Arith = new System.Windows.Forms.Panel();
            this.label_I_3 = new System.Windows.Forms.Label();
            this.label_I_4 = new System.Windows.Forms.Label();
            this.label_I_5 = new System.Windows.Forms.Label();
            this.tabPageControl.SuspendLayout();
            this.tabCPUStatus.SuspendLayout();
            this.panel1415CPUOutline.SuspendLayout();
            this.panelCPU.SuspendLayout();
            this.panelCPUBorder.SuspendLayout();
            this.panelIRing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageControl
            // 
            this.tabPageControl.Controls.Add(this.tabCPUStatus);
            this.tabPageControl.Controls.Add(this.tabIOChannels);
            this.tabPageControl.Controls.Add(this.tabSystemCheck);
            this.tabPageControl.Controls.Add(this.tabPowerSystemControls);
            this.tabPageControl.Controls.Add(this.tabCEPanel);
            this.tabPageControl.Location = new System.Drawing.Point(8, 8);
            this.tabPageControl.Name = "tabPageControl";
            this.tabPageControl.SelectedIndex = 0;
            this.tabPageControl.Size = new System.Drawing.Size(571, 374);
            this.tabPageControl.TabIndex = 0;
            this.tabPageControl.Tag = "";
            // 
            // tabCPUStatus
            // 
            this.tabCPUStatus.BackColor = System.Drawing.Color.DarkGray;
            this.tabCPUStatus.Controls.Add(this.panel1415CPUOutline);
            this.tabCPUStatus.Location = new System.Drawing.Point(4, 24);
            this.tabCPUStatus.Name = "tabCPUStatus";
            this.tabCPUStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabCPUStatus.Size = new System.Drawing.Size(563, 346);
            this.tabCPUStatus.TabIndex = 0;
            this.tabCPUStatus.Text = "CPU / STATUS";
            // 
            // panel1415CPUOutline
            // 
            this.panel1415CPUOutline.BackColor = System.Drawing.Color.White;
            this.panel1415CPUOutline.Controls.Add(this.panelStatus);
            this.panel1415CPUOutline.Controls.Add(this.panelCPU);
            this.panel1415CPUOutline.ForeColor = System.Drawing.Color.Transparent;
            this.panel1415CPUOutline.Location = new System.Drawing.Point(16, 8);
            this.panel1415CPUOutline.Margin = new System.Windows.Forms.Padding(0);
            this.panel1415CPUOutline.Name = "panel1415CPUOutline";
            this.panel1415CPUOutline.Size = new System.Drawing.Size(529, 321);
            this.panel1415CPUOutline.TabIndex = 0;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.DarkGray;
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Location = new System.Drawing.Point(434, 4);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(89, 311);
            this.panelStatus.TabIndex = 1;
            // 
            // panelCPU
            // 
            this.panelCPU.BackColor = System.Drawing.Color.DarkGray;
            this.panelCPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCPU.Controls.Add(this.panelCPUBorder);
            this.panelCPU.Controls.Add(this.labelCPU);
            this.panelCPU.Location = new System.Drawing.Point(4, 4);
            this.panelCPU.Name = "panelCPU";
            this.panelCPU.Size = new System.Drawing.Size(426, 311);
            this.panelCPU.TabIndex = 0;
            // 
            // panelCPUBorder
            // 
            this.panelCPUBorder.BackColor = System.Drawing.Color.White;
            this.panelCPUBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCPUBorder.Controls.Add(this.Arith);
            this.panelCPUBorder.Controls.Add(this.panelCycle);
            this.panelCPUBorder.Controls.Add(this.panelScan);
            this.panelCPUBorder.Controls.Add(this.panelClock);
            this.panelCPUBorder.Controls.Add(this.panelARing);
            this.panelCPUBorder.Controls.Add(this.panelIRing);
            this.panelCPUBorder.ForeColor = System.Drawing.Color.Transparent;
            this.panelCPUBorder.Location = new System.Drawing.Point(-1, 31);
            this.panelCPUBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelCPUBorder.Name = "panelCPUBorder";
            this.panelCPUBorder.Size = new System.Drawing.Size(426, 281);
            this.panelCPUBorder.TabIndex = 1;
            // 
            // panelIRing
            // 
            this.panelIRing.BackColor = System.Drawing.Color.DarkGray;
            this.panelIRing.Controls.Add(this.label_I_5);
            this.panelIRing.Controls.Add(this.label_I_4);
            this.panelIRing.Controls.Add(this.label_I_3);
            this.panelIRing.Controls.Add(this.label_I_2);
            this.panelIRing.Controls.Add(this.label_I_1);
            this.panelIRing.Controls.Add(this.label_I_OP);
            this.panelIRing.Location = new System.Drawing.Point(4, 2);
            this.panelIRing.Name = "panelIRing";
            this.panelIRing.Size = new System.Drawing.Size(100, 275);
            this.panelIRing.TabIndex = 0;
            // 
            // label_I_2
            // 
            this.label_I_2.AutoSize = true;
            this.label_I_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_I_2.ForeColor = System.Drawing.Color.DimGray;
            this.label_I_2.Location = new System.Drawing.Point(16, 80);
            this.label_I_2.Name = "label_I_2";
            this.label_I_2.Size = new System.Drawing.Size(15, 15);
            this.label_I_2.TabIndex = 2;
            this.label_I_2.Text = "2";
            // 
            // label_I_1
            // 
            this.label_I_1.AutoSize = true;
            this.label_I_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_I_1.ForeColor = System.Drawing.Color.DimGray;
            this.label_I_1.Location = new System.Drawing.Point(16, 56);
            this.label_I_1.Name = "label_I_1";
            this.label_I_1.Size = new System.Drawing.Size(15, 15);
            this.label_I_1.TabIndex = 1;
            this.label_I_1.Text = "1";
            // 
            // label_I_OP
            // 
            this.label_I_OP.AutoSize = true;
            this.label_I_OP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_I_OP.ForeColor = System.Drawing.Color.DimGray;
            this.label_I_OP.Location = new System.Drawing.Point(16, 32);
            this.label_I_OP.Name = "label_I_OP";
            this.label_I_OP.Size = new System.Drawing.Size(26, 15);
            this.label_I_OP.TabIndex = 0;
            this.label_I_OP.Text = "OP";
            // 
            // labelCPU
            // 
            this.labelCPU.AutoSize = true;
            this.labelCPU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCPU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCPU.Location = new System.Drawing.Point(101, 8);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(166, 15);
            this.labelCPU.TabIndex = 0;
            this.labelCPU.Text = "CENTRAL PROCESSING UNIT";
            // 
            // tabIOChannels
            // 
            this.tabIOChannels.Location = new System.Drawing.Point(4, 24);
            this.tabIOChannels.Name = "tabIOChannels";
            this.tabIOChannels.Padding = new System.Windows.Forms.Padding(3);
            this.tabIOChannels.Size = new System.Drawing.Size(622, 392);
            this.tabIOChannels.TabIndex = 1;
            this.tabIOChannels.Text = "I/O CHANNELS";
            this.tabIOChannels.UseVisualStyleBackColor = true;
            // 
            // tabSystemCheck
            // 
            this.tabSystemCheck.Location = new System.Drawing.Point(4, 24);
            this.tabSystemCheck.Name = "tabSystemCheck";
            this.tabSystemCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabSystemCheck.Size = new System.Drawing.Size(622, 392);
            this.tabSystemCheck.TabIndex = 2;
            this.tabSystemCheck.Text = "SYSTEM CHECK";
            this.tabSystemCheck.UseVisualStyleBackColor = true;
            // 
            // tabPowerSystemControls
            // 
            this.tabPowerSystemControls.Location = new System.Drawing.Point(4, 24);
            this.tabPowerSystemControls.Name = "tabPowerSystemControls";
            this.tabPowerSystemControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPowerSystemControls.Size = new System.Drawing.Size(622, 392);
            this.tabPowerSystemControls.TabIndex = 3;
            this.tabPowerSystemControls.Text = "POWER / SYSTEM CONTROLS";
            this.tabPowerSystemControls.UseVisualStyleBackColor = true;
            // 
            // tabCEPanel
            // 
            this.tabCEPanel.Location = new System.Drawing.Point(4, 24);
            this.tabCEPanel.Name = "tabCEPanel";
            this.tabCEPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tabCEPanel.Size = new System.Drawing.Size(622, 392);
            this.tabCEPanel.TabIndex = 4;
            this.tabCEPanel.Text = "CE PANEL";
            this.tabCEPanel.UseVisualStyleBackColor = true;
            // 
            // panelARing
            // 
            this.panelARing.BackColor = System.Drawing.Color.DarkGray;
            this.panelARing.Location = new System.Drawing.Point(108, 2);
            this.panelARing.Name = "panelARing";
            this.panelARing.Size = new System.Drawing.Size(60, 275);
            this.panelARing.TabIndex = 1;
            // 
            // panelClock
            // 
            this.panelClock.BackColor = System.Drawing.Color.DarkGray;
            this.panelClock.Location = new System.Drawing.Point(172, 2);
            this.panelClock.Name = "panelClock";
            this.panelClock.Size = new System.Drawing.Size(60, 275);
            this.panelClock.TabIndex = 2;
            // 
            // panelScan
            // 
            this.panelScan.BackColor = System.Drawing.Color.DarkGray;
            this.panelScan.Location = new System.Drawing.Point(236, 2);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(60, 275);
            this.panelScan.TabIndex = 3;
            // 
            // panelCycle
            // 
            this.panelCycle.BackColor = System.Drawing.Color.DarkGray;
            this.panelCycle.Location = new System.Drawing.Point(300, 2);
            this.panelCycle.Name = "panelCycle";
            this.panelCycle.Size = new System.Drawing.Size(60, 275);
            this.panelCycle.TabIndex = 4;
            // 
            // Arith
            // 
            this.Arith.BackColor = System.Drawing.Color.DarkGray;
            this.Arith.Location = new System.Drawing.Point(364, 2);
            this.Arith.Name = "Arith";
            this.Arith.Size = new System.Drawing.Size(60, 275);
            this.Arith.TabIndex = 5;
            // 
            // label_I_3
            // 
            this.label_I_3.AutoSize = true;
            this.label_I_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_I_3.ForeColor = System.Drawing.Color.DimGray;
            this.label_I_3.Location = new System.Drawing.Point(16, 104);
            this.label_I_3.Name = "label_I_3";
            this.label_I_3.Size = new System.Drawing.Size(15, 15);
            this.label_I_3.TabIndex = 3;
            this.label_I_3.Text = "3";
            // 
            // label_I_4
            // 
            this.label_I_4.AutoSize = true;
            this.label_I_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_I_4.ForeColor = System.Drawing.Color.DimGray;
            this.label_I_4.Location = new System.Drawing.Point(16, 128);
            this.label_I_4.Name = "label_I_4";
            this.label_I_4.Size = new System.Drawing.Size(15, 15);
            this.label_I_4.TabIndex = 4;
            this.label_I_4.Text = "4";
            // 
            // label_I_5
            // 
            this.label_I_5.AutoSize = true;
            this.label_I_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_I_5.ForeColor = System.Drawing.Color.DimGray;
            this.label_I_5.Location = new System.Drawing.Point(16, 152);
            this.label_I_5.Name = "label_I_5";
            this.label_I_5.Size = new System.Drawing.Size(15, 15);
            this.label_I_5.TabIndex = 5;
            this.label_I_5.Text = "5";
            // 
            // UI1415L
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 604);
            this.Controls.Add(this.tabPageControl);
            this.Name = "UI1415L";
            this.Text = "IBM 1415 Indicator Lights";
            this.tabPageControl.ResumeLayout(false);
            this.tabCPUStatus.ResumeLayout(false);
            this.panel1415CPUOutline.ResumeLayout(false);
            this.panelCPU.ResumeLayout(false);
            this.panelCPU.PerformLayout();
            this.panelCPUBorder.ResumeLayout(false);
            this.panelIRing.ResumeLayout(false);
            this.panelIRing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPageControl;
        private System.Windows.Forms.TabPage tabCPUStatus;
        private System.Windows.Forms.Panel panelCPU;
        private System.Windows.Forms.TabPage tabIOChannels;
        private System.Windows.Forms.TabPage tabSystemCheck;
        private System.Windows.Forms.TabPage tabPowerSystemControls;
        private System.Windows.Forms.TabPage tabCEPanel;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Panel panelIRing;
        private System.Windows.Forms.Label label_I_2;
        private System.Windows.Forms.Label label_I_1;
        private System.Windows.Forms.Label label_I_OP;
        private System.Windows.Forms.Panel panelCPUBorder;
        private System.Windows.Forms.Panel panel1415CPUOutline;
        private System.Windows.Forms.Panel panelARing;
        private System.Windows.Forms.Panel panelScan;
        private System.Windows.Forms.Panel panelClock;
        private System.Windows.Forms.Panel panelCycle;
        private System.Windows.Forms.Panel Arith;
        private System.Windows.Forms.Label label_I_3;
        private System.Windows.Forms.Label label_I_5;
        private System.Windows.Forms.Label label_I_4;
    }
}