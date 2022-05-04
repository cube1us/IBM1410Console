﻿
namespace IBM1410Console
{
    partial class IBM1410SwitchForm
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
            this.addressEntryComboBox = new System.Windows.Forms.ComboBox();
            this.addressEntryLabel = new System.Windows.Forms.Label();
            this.storageScanLabel = new System.Windows.Forms.Label();
            this.storageScanComboBox = new System.Windows.Forms.ComboBox();
            this.cycleControlLabel = new System.Windows.Forms.Label();
            this.cycleControlComboBox = new System.Windows.Forms.ComboBox();
            this.checkControlLabel = new System.Windows.Forms.Label();
            this.checkControlComboBox = new System.Windows.Forms.ComboBox();
            this.diskWrInhibitCheckBox = new System.Windows.Forms.CheckBox();
            this.densityCH1Label = new System.Windows.Forms.Label();
            this.densityCh1ComboBox = new System.Windows.Forms.ComboBox();
            this.densityCh2Label = new System.Windows.Forms.Label();
            this.densityCh2ComboBox = new System.Windows.Forms.ComboBox();
            this.startPrintOutButton = new System.Windows.Forms.Button();
            this.startPrintOutLabel = new System.Windows.Forms.Label();
            this.compat1401CheckBox = new System.Windows.Forms.CheckBox();
            this.IOCheckReset1401Button = new System.Windows.Forms.Button();
            this.IOCheckReset1401Label = new System.Windows.Forms.Label();
            this.IOCheckStop1401CheckBox = new System.Windows.Forms.CheckBox();
            this.checkTest1Button = new System.Windows.Forms.Button();
            this.checkTest2Button = new System.Windows.Forms.Button();
            this.checkTest3Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.asteriskInsertCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // addressEntryComboBox
            // 
            this.addressEntryComboBox.AllowDrop = true;
            this.addressEntryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addressEntryComboBox.FormattingEnabled = true;
            this.addressEntryComboBox.Items.AddRange(new object[] {
            "I/NORMAL",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.addressEntryComboBox.Location = new System.Drawing.Point(22, 32);
            this.addressEntryComboBox.Name = "addressEntryComboBox";
            this.addressEntryComboBox.Size = new System.Drawing.Size(120, 23);
            this.addressEntryComboBox.TabIndex = 0;
            // 
            // addressEntryLabel
            // 
            this.addressEntryLabel.AutoSize = true;
            this.addressEntryLabel.Location = new System.Drawing.Point(35, 58);
            this.addressEntryLabel.Name = "addressEntryLabel";
            this.addressEntryLabel.Size = new System.Drawing.Size(94, 15);
            this.addressEntryLabel.TabIndex = 1;
            this.addressEntryLabel.Text = "ADDRESS ENTRY";
            // 
            // storageScanLabel
            // 
            this.storageScanLabel.AutoSize = true;
            this.storageScanLabel.Location = new System.Drawing.Point(37, 135);
            this.storageScanLabel.Name = "storageScanLabel";
            this.storageScanLabel.Size = new System.Drawing.Size(90, 15);
            this.storageScanLabel.TabIndex = 3;
            this.storageScanLabel.Text = "STORAGE SCAN";
            // 
            // storageScanComboBox
            // 
            this.storageScanComboBox.AllowDrop = true;
            this.storageScanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storageScanComboBox.FormattingEnabled = true;
            this.storageScanComboBox.Items.AddRange(new object[] {
            "OFF",
            "LOAD +1",
            "LOAD  0",
            "REGEN 0",
            "REGEN +1"});
            this.storageScanComboBox.Location = new System.Drawing.Point(22, 109);
            this.storageScanComboBox.Name = "storageScanComboBox";
            this.storageScanComboBox.Size = new System.Drawing.Size(120, 23);
            this.storageScanComboBox.TabIndex = 2;
            // 
            // cycleControlLabel
            // 
            this.cycleControlLabel.AutoSize = true;
            this.cycleControlLabel.Location = new System.Drawing.Point(33, 213);
            this.cycleControlLabel.Name = "cycleControlLabel";
            this.cycleControlLabel.Size = new System.Drawing.Size(99, 15);
            this.cycleControlLabel.TabIndex = 5;
            this.cycleControlLabel.Text = "CYCLE CONTROL";
            // 
            // cycleControlComboBox
            // 
            this.cycleControlComboBox.AllowDrop = true;
            this.cycleControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cycleControlComboBox.FormattingEnabled = true;
            this.cycleControlComboBox.Items.AddRange(new object[] {
            "OFF",
            "LOGIC STEP",
            "STORAGE CYCLE"});
            this.cycleControlComboBox.Location = new System.Drawing.Point(22, 187);
            this.cycleControlComboBox.Name = "cycleControlComboBox";
            this.cycleControlComboBox.Size = new System.Drawing.Size(120, 23);
            this.cycleControlComboBox.TabIndex = 4;
            // 
            // checkControlLabel
            // 
            this.checkControlLabel.AutoSize = true;
            this.checkControlLabel.Location = new System.Drawing.Point(31, 293);
            this.checkControlLabel.Name = "checkControlLabel";
            this.checkControlLabel.Size = new System.Drawing.Size(102, 15);
            this.checkControlLabel.TabIndex = 7;
            this.checkControlLabel.Text = "CHECK CONTROL";
            // 
            // checkControlComboBox
            // 
            this.checkControlComboBox.AllowDrop = true;
            this.checkControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkControlComboBox.FormattingEnabled = true;
            this.checkControlComboBox.Items.AddRange(new object[] {
            "STOP NORMAL",
            "RESTART",
            "RESET & RESTART"});
            this.checkControlComboBox.Location = new System.Drawing.Point(22, 267);
            this.checkControlComboBox.Name = "checkControlComboBox";
            this.checkControlComboBox.Size = new System.Drawing.Size(120, 23);
            this.checkControlComboBox.TabIndex = 6;
            // 
            // diskWrInhibitCheckBox
            // 
            this.diskWrInhibitCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.diskWrInhibitCheckBox.Location = new System.Drawing.Point(182, 120);
            this.diskWrInhibitCheckBox.Name = "diskWrInhibitCheckBox";
            this.diskWrInhibitCheckBox.Size = new System.Drawing.Size(71, 46);
            this.diskWrInhibitCheckBox.TabIndex = 8;
            this.diskWrInhibitCheckBox.Text = "Disk WR Inhibit";
            this.diskWrInhibitCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.diskWrInhibitCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.diskWrInhibitCheckBox.UseVisualStyleBackColor = true;
            // 
            // densityCH1Label
            // 
            this.densityCH1Label.AutoSize = true;
            this.densityCH1Label.Location = new System.Drawing.Point(178, 198);
            this.densityCH1Label.Name = "densityCH1Label";
            this.densityCH1Label.Size = new System.Drawing.Size(78, 15);
            this.densityCH1Label.TabIndex = 10;
            this.densityCH1Label.Text = "DENSITY CH1";
            // 
            // densityCh1ComboBox
            // 
            this.densityCh1ComboBox.AllowDrop = true;
            this.densityCh1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.densityCh1ComboBox.FormattingEnabled = true;
            this.densityCh1ComboBox.Items.AddRange(new object[] {
            "200/556",
            "200/800",
            "556/800"});
            this.densityCh1ComboBox.Location = new System.Drawing.Point(177, 172);
            this.densityCh1ComboBox.Name = "densityCh1ComboBox";
            this.densityCh1ComboBox.Size = new System.Drawing.Size(80, 23);
            this.densityCh1ComboBox.TabIndex = 9;
            // 
            // densityCh2Label
            // 
            this.densityCh2Label.AutoSize = true;
            this.densityCh2Label.Location = new System.Drawing.Point(178, 252);
            this.densityCh2Label.Name = "densityCh2Label";
            this.densityCh2Label.Size = new System.Drawing.Size(78, 15);
            this.densityCh2Label.TabIndex = 12;
            this.densityCh2Label.Text = "DENSITY CH1";
            // 
            // densityCh2ComboBox
            // 
            this.densityCh2ComboBox.AllowDrop = true;
            this.densityCh2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.densityCh2ComboBox.FormattingEnabled = true;
            this.densityCh2ComboBox.Items.AddRange(new object[] {
            "200/556",
            "200/800",
            "556/800"});
            this.densityCh2ComboBox.Location = new System.Drawing.Point(177, 226);
            this.densityCh2ComboBox.Name = "densityCh2ComboBox";
            this.densityCh2ComboBox.Size = new System.Drawing.Size(80, 23);
            this.densityCh2ComboBox.TabIndex = 11;
            // 
            // startPrintOutButton
            // 
            this.startPrintOutButton.Location = new System.Drawing.Point(218, 313);
            this.startPrintOutButton.Name = "startPrintOutButton";
            this.startPrintOutButton.Size = new System.Drawing.Size(21, 21);
            this.startPrintOutButton.TabIndex = 13;
            this.startPrintOutButton.UseVisualStyleBackColor = true;
            // 
            // startPrintOutLabel
            // 
            this.startPrintOutLabel.Location = new System.Drawing.Point(166, 293);
            this.startPrintOutLabel.Name = "startPrintOutLabel";
            this.startPrintOutLabel.Size = new System.Drawing.Size(46, 63);
            this.startPrintOutLabel.TabIndex = 14;
            this.startPrintOutLabel.Text = "START PRINT OUT";
            this.startPrintOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compat1401CheckBox
            // 
            this.compat1401CheckBox.Location = new System.Drawing.Point(307, 32);
            this.compat1401CheckBox.Name = "compat1401CheckBox";
            this.compat1401CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.compat1401CheckBox.Size = new System.Drawing.Size(70, 59);
            this.compat1401CheckBox.TabIndex = 15;
            this.compat1401CheckBox.Text = "1401 Compatibility";
            this.compat1401CheckBox.UseVisualStyleBackColor = true;
            // 
            // IOCheckReset1401Button
            // 
            this.IOCheckReset1401Button.Location = new System.Drawing.Point(364, 115);
            this.IOCheckReset1401Button.Name = "IOCheckReset1401Button";
            this.IOCheckReset1401Button.Size = new System.Drawing.Size(21, 21);
            this.IOCheckReset1401Button.TabIndex = 16;
            this.IOCheckReset1401Button.UseVisualStyleBackColor = true;
            // 
            // IOCheckReset1401Label
            // 
            this.IOCheckReset1401Label.Location = new System.Drawing.Point(307, 94);
            this.IOCheckReset1401Label.Name = "IOCheckReset1401Label";
            this.IOCheckReset1401Label.Size = new System.Drawing.Size(55, 63);
            this.IOCheckReset1401Label.TabIndex = 17;
            this.IOCheckReset1401Label.Text = "1401 I/O CHECK RESET";
            this.IOCheckReset1401Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IOCheckStop1401CheckBox
            // 
            this.IOCheckStop1401CheckBox.Location = new System.Drawing.Point(307, 160);
            this.IOCheckStop1401CheckBox.Name = "IOCheckStop1401CheckBox";
            this.IOCheckStop1401CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IOCheckStop1401CheckBox.Size = new System.Drawing.Size(70, 59);
            this.IOCheckStop1401CheckBox.TabIndex = 18;
            this.IOCheckStop1401CheckBox.Text = "I/O Check Stop";
            this.IOCheckStop1401CheckBox.UseVisualStyleBackColor = true;
            // 
            // checkTest1Button
            // 
            this.checkTest1Button.Location = new System.Drawing.Point(364, 228);
            this.checkTest1Button.Name = "checkTest1Button";
            this.checkTest1Button.Size = new System.Drawing.Size(21, 21);
            this.checkTest1Button.TabIndex = 19;
            this.checkTest1Button.Text = "1";
            this.checkTest1Button.UseVisualStyleBackColor = true;
            // 
            // checkTest2Button
            // 
            this.checkTest2Button.Location = new System.Drawing.Point(364, 259);
            this.checkTest2Button.Name = "checkTest2Button";
            this.checkTest2Button.Size = new System.Drawing.Size(21, 21);
            this.checkTest2Button.TabIndex = 20;
            this.checkTest2Button.Text = "2";
            this.checkTest2Button.UseVisualStyleBackColor = true;
            // 
            // checkTest3Button
            // 
            this.checkTest3Button.Location = new System.Drawing.Point(364, 290);
            this.checkTest3Button.Name = "checkTest3Button";
            this.checkTest3Button.Size = new System.Drawing.Size(21, 21);
            this.checkTest3Button.TabIndex = 21;
            this.checkTest3Button.Text = "3";
            this.checkTest3Button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(303, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 63);
            this.label1.TabIndex = 22;
            this.label1.Text = "CHECK TEST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // asteriskInsertCheckBox
            // 
            this.asteriskInsertCheckBox.Checked = true;
            this.asteriskInsertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.asteriskInsertCheckBox.Location = new System.Drawing.Point(295, 329);
            this.asteriskInsertCheckBox.Name = "asteriskInsertCheckBox";
            this.asteriskInsertCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.asteriskInsertCheckBox.Size = new System.Drawing.Size(82, 39);
            this.asteriskInsertCheckBox.TabIndex = 23;
            this.asteriskInsertCheckBox.Text = "ASTERISK INSERT";
            this.asteriskInsertCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(284, 374);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(93, 64);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "INHIBIT PRINT OUT CONTROL";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // IBM1410SwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.asteriskInsertCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkTest3Button);
            this.Controls.Add(this.checkTest2Button);
            this.Controls.Add(this.checkTest1Button);
            this.Controls.Add(this.IOCheckStop1401CheckBox);
            this.Controls.Add(this.IOCheckReset1401Label);
            this.Controls.Add(this.IOCheckReset1401Button);
            this.Controls.Add(this.compat1401CheckBox);
            this.Controls.Add(this.startPrintOutLabel);
            this.Controls.Add(this.startPrintOutButton);
            this.Controls.Add(this.densityCh2Label);
            this.Controls.Add(this.densityCh2ComboBox);
            this.Controls.Add(this.densityCH1Label);
            this.Controls.Add(this.densityCh1ComboBox);
            this.Controls.Add(this.diskWrInhibitCheckBox);
            this.Controls.Add(this.checkControlLabel);
            this.Controls.Add(this.checkControlComboBox);
            this.Controls.Add(this.cycleControlLabel);
            this.Controls.Add(this.cycleControlComboBox);
            this.Controls.Add(this.storageScanLabel);
            this.Controls.Add(this.storageScanComboBox);
            this.Controls.Add(this.addressEntryLabel);
            this.Controls.Add(this.addressEntryComboBox);
            this.Name = "IBM1410SwitchForm";
            this.Text = "IBM1410SwitchForm";
            this.Load += new System.EventHandler(this.IBM1410SwitchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox addressEntryComboBox;
        private System.Windows.Forms.Label addressEntryLabel;
        private System.Windows.Forms.Label storageScanLabel;
        private System.Windows.Forms.ComboBox storageScanComboBox;
        private System.Windows.Forms.Label cycleControlLabel;
        private System.Windows.Forms.ComboBox cycleControlComboBox;
        private System.Windows.Forms.Label checkControlLabel;
        private System.Windows.Forms.ComboBox checkControlComboBox;
        private System.Windows.Forms.CheckBox diskWrInhibitCheckBox;
        private System.Windows.Forms.Label densityCH1Label;
        private System.Windows.Forms.ComboBox densityCh1ComboBox;
        private System.Windows.Forms.Label densityCh2Label;
        private System.Windows.Forms.ComboBox densityCh2ComboBox;
        private System.Windows.Forms.Button startPrintOutButton;
        private System.Windows.Forms.Label startPrintOutLabel;
        private System.Windows.Forms.CheckBox compat1401CheckBox;
        private System.Windows.Forms.Button IOCheckReset1401Button;
        private System.Windows.Forms.Label IOCheckReset1401Label;
        private System.Windows.Forms.CheckBox IOCheckStop1401CheckBox;
        private System.Windows.Forms.Button checkTest1Button;
        private System.Windows.Forms.Button checkTest2Button;
        private System.Windows.Forms.Button checkTest3Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox asteriskInsertCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}