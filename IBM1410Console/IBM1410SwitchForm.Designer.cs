
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
            this.checkTestLabel = new System.Windows.Forms.Label();
            this.asteriskInsertCheckBox = new System.Windows.Forms.CheckBox();
            this.inhibitPrintOutCheckBox = new System.Windows.Forms.CheckBox();
            this.senseACheckBox = new System.Windows.Forms.CheckBox();
            this.senseBCheckBox = new System.Windows.Forms.CheckBox();
            this.senseCCheckBox = new System.Windows.Forms.CheckBox();
            this.senseDCheckBox = new System.Windows.Forms.CheckBox();
            this.senseECheckBox = new System.Windows.Forms.CheckBox();
            this.senseFCheckBox = new System.Windows.Forms.CheckBox();
            this.senseGCheckBox = new System.Windows.Forms.CheckBox();
            this.senseWMCheckBox = new System.Windows.Forms.CheckBox();
            this.senseBitLabel = new System.Windows.Forms.Label();
            this.senseBitLabel2 = new System.Windows.Forms.Label();
            this.tabControlSwitches = new System.Windows.Forms.TabControl();
            this.consoleSwitchTab = new System.Windows.Forms.TabPage();
            this.programResetButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.powerOnButton = new System.Windows.Forms.Button();
            this.powerOffButton = new System.Windows.Forms.Button();
            this.readyButton = new System.Windows.Forms.Button();
            this.DCOffButton = new System.Windows.Forms.Button();
            this.computerResetButton = new System.Windows.Forms.Button();
            this.emergencyOffPanel = new System.Windows.Forms.Panel();
            this.emergencyOffLabel = new System.Windows.Forms.Label();
            this.emergencyOffButton = new System.Windows.Forms.Button();
            this.CESwitchTab = new System.Windows.Forms.TabPage();
            this.priorityProcessingTab = new System.Windows.Forms.TabPage();
            this.priorityUnitSelectcomboBox = new System.Windows.Forms.ComboBox();
            this.priorityOnButton = new System.Windows.Forms.Button();
            this.tabControlSwitches.SuspendLayout();
            this.consoleSwitchTab.SuspendLayout();
            this.emergencyOffPanel.SuspendLayout();
            this.priorityProcessingTab.SuspendLayout();
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
            this.addressEntryComboBox.Location = new System.Drawing.Point(15, 33);
            this.addressEntryComboBox.Name = "addressEntryComboBox";
            this.addressEntryComboBox.Size = new System.Drawing.Size(120, 23);
            this.addressEntryComboBox.TabIndex = 0;
            // 
            // addressEntryLabel
            // 
            this.addressEntryLabel.AutoSize = true;
            this.addressEntryLabel.Location = new System.Drawing.Point(28, 59);
            this.addressEntryLabel.Name = "addressEntryLabel";
            this.addressEntryLabel.Size = new System.Drawing.Size(94, 15);
            this.addressEntryLabel.TabIndex = 1;
            this.addressEntryLabel.Text = "ADDRESS ENTRY";
            // 
            // storageScanLabel
            // 
            this.storageScanLabel.AutoSize = true;
            this.storageScanLabel.Location = new System.Drawing.Point(30, 136);
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
            this.storageScanComboBox.Location = new System.Drawing.Point(15, 110);
            this.storageScanComboBox.Name = "storageScanComboBox";
            this.storageScanComboBox.Size = new System.Drawing.Size(120, 23);
            this.storageScanComboBox.TabIndex = 2;
            // 
            // cycleControlLabel
            // 
            this.cycleControlLabel.AutoSize = true;
            this.cycleControlLabel.Location = new System.Drawing.Point(26, 214);
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
            this.cycleControlComboBox.Location = new System.Drawing.Point(15, 188);
            this.cycleControlComboBox.Name = "cycleControlComboBox";
            this.cycleControlComboBox.Size = new System.Drawing.Size(120, 23);
            this.cycleControlComboBox.TabIndex = 4;
            // 
            // checkControlLabel
            // 
            this.checkControlLabel.AutoSize = true;
            this.checkControlLabel.Location = new System.Drawing.Point(24, 294);
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
            this.checkControlComboBox.Location = new System.Drawing.Point(15, 268);
            this.checkControlComboBox.Name = "checkControlComboBox";
            this.checkControlComboBox.Size = new System.Drawing.Size(120, 23);
            this.checkControlComboBox.TabIndex = 6;
            // 
            // diskWrInhibitCheckBox
            // 
            this.diskWrInhibitCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.diskWrInhibitCheckBox.Location = new System.Drawing.Point(175, 121);
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
            this.densityCH1Label.Location = new System.Drawing.Point(171, 199);
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
            this.densityCh1ComboBox.Location = new System.Drawing.Point(170, 173);
            this.densityCh1ComboBox.Name = "densityCh1ComboBox";
            this.densityCh1ComboBox.Size = new System.Drawing.Size(80, 23);
            this.densityCh1ComboBox.TabIndex = 9;
            // 
            // densityCh2Label
            // 
            this.densityCh2Label.AutoSize = true;
            this.densityCh2Label.Location = new System.Drawing.Point(171, 253);
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
            this.densityCh2ComboBox.Location = new System.Drawing.Point(170, 227);
            this.densityCh2ComboBox.Name = "densityCh2ComboBox";
            this.densityCh2ComboBox.Size = new System.Drawing.Size(80, 23);
            this.densityCh2ComboBox.TabIndex = 11;
            // 
            // startPrintOutButton
            // 
            this.startPrintOutButton.Location = new System.Drawing.Point(211, 314);
            this.startPrintOutButton.Name = "startPrintOutButton";
            this.startPrintOutButton.Size = new System.Drawing.Size(21, 21);
            this.startPrintOutButton.TabIndex = 13;
            this.startPrintOutButton.UseVisualStyleBackColor = true;
            // 
            // startPrintOutLabel
            // 
            this.startPrintOutLabel.Location = new System.Drawing.Point(159, 294);
            this.startPrintOutLabel.Name = "startPrintOutLabel";
            this.startPrintOutLabel.Size = new System.Drawing.Size(46, 63);
            this.startPrintOutLabel.TabIndex = 14;
            this.startPrintOutLabel.Text = "START PRINT OUT";
            this.startPrintOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compat1401CheckBox
            // 
            this.compat1401CheckBox.Location = new System.Drawing.Point(300, 15);
            this.compat1401CheckBox.Name = "compat1401CheckBox";
            this.compat1401CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.compat1401CheckBox.Size = new System.Drawing.Size(70, 59);
            this.compat1401CheckBox.TabIndex = 15;
            this.compat1401CheckBox.Text = "1401 Compatibility";
            this.compat1401CheckBox.UseVisualStyleBackColor = true;
            // 
            // IOCheckReset1401Button
            // 
            this.IOCheckReset1401Button.Location = new System.Drawing.Point(361, 97);
            this.IOCheckReset1401Button.Name = "IOCheckReset1401Button";
            this.IOCheckReset1401Button.Size = new System.Drawing.Size(21, 21);
            this.IOCheckReset1401Button.TabIndex = 16;
            this.IOCheckReset1401Button.UseVisualStyleBackColor = true;
            // 
            // IOCheckReset1401Label
            // 
            this.IOCheckReset1401Label.Location = new System.Drawing.Point(300, 76);
            this.IOCheckReset1401Label.Name = "IOCheckReset1401Label";
            this.IOCheckReset1401Label.Size = new System.Drawing.Size(55, 63);
            this.IOCheckReset1401Label.TabIndex = 17;
            this.IOCheckReset1401Label.Text = "1401 I/O CHECK RESET";
            this.IOCheckReset1401Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IOCheckStop1401CheckBox
            // 
            this.IOCheckStop1401CheckBox.Location = new System.Drawing.Point(300, 145);
            this.IOCheckStop1401CheckBox.Name = "IOCheckStop1401CheckBox";
            this.IOCheckStop1401CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IOCheckStop1401CheckBox.Size = new System.Drawing.Size(70, 59);
            this.IOCheckStop1401CheckBox.TabIndex = 18;
            this.IOCheckStop1401CheckBox.Text = "I/O Check Stop";
            this.IOCheckStop1401CheckBox.UseVisualStyleBackColor = true;
            // 
            // checkTest1Button
            // 
            this.checkTest1Button.Location = new System.Drawing.Point(357, 213);
            this.checkTest1Button.Name = "checkTest1Button";
            this.checkTest1Button.Size = new System.Drawing.Size(21, 21);
            this.checkTest1Button.TabIndex = 19;
            this.checkTest1Button.Text = "1";
            this.checkTest1Button.UseVisualStyleBackColor = true;
            // 
            // checkTest2Button
            // 
            this.checkTest2Button.Location = new System.Drawing.Point(357, 244);
            this.checkTest2Button.Name = "checkTest2Button";
            this.checkTest2Button.Size = new System.Drawing.Size(21, 21);
            this.checkTest2Button.TabIndex = 20;
            this.checkTest2Button.Text = "2";
            this.checkTest2Button.UseVisualStyleBackColor = true;
            // 
            // checkTest3Button
            // 
            this.checkTest3Button.Location = new System.Drawing.Point(357, 275);
            this.checkTest3Button.Name = "checkTest3Button";
            this.checkTest3Button.Size = new System.Drawing.Size(21, 21);
            this.checkTest3Button.TabIndex = 21;
            this.checkTest3Button.Text = "3";
            this.checkTest3Button.UseVisualStyleBackColor = true;
            // 
            // checkTestLabel
            // 
            this.checkTestLabel.Location = new System.Drawing.Point(296, 223);
            this.checkTestLabel.Name = "checkTestLabel";
            this.checkTestLabel.Size = new System.Drawing.Size(55, 63);
            this.checkTestLabel.TabIndex = 22;
            this.checkTestLabel.Text = "CHECK TEST";
            this.checkTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // asteriskInsertCheckBox
            // 
            this.asteriskInsertCheckBox.Checked = true;
            this.asteriskInsertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.asteriskInsertCheckBox.Location = new System.Drawing.Point(288, 314);
            this.asteriskInsertCheckBox.Name = "asteriskInsertCheckBox";
            this.asteriskInsertCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.asteriskInsertCheckBox.Size = new System.Drawing.Size(82, 39);
            this.asteriskInsertCheckBox.TabIndex = 23;
            this.asteriskInsertCheckBox.Text = "ASTERISK INSERT";
            this.asteriskInsertCheckBox.UseVisualStyleBackColor = true;
            // 
            // inhibitPrintOutCheckBox
            // 
            this.inhibitPrintOutCheckBox.Location = new System.Drawing.Point(277, 359);
            this.inhibitPrintOutCheckBox.Name = "inhibitPrintOutCheckBox";
            this.inhibitPrintOutCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.inhibitPrintOutCheckBox.Size = new System.Drawing.Size(93, 64);
            this.inhibitPrintOutCheckBox.TabIndex = 24;
            this.inhibitPrintOutCheckBox.Text = "INHIBIT PRINT OUT CONTROL";
            this.inhibitPrintOutCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.inhibitPrintOutCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseACheckBox
            // 
            this.senseACheckBox.AutoSize = true;
            this.senseACheckBox.Location = new System.Drawing.Point(435, 65);
            this.senseACheckBox.Name = "senseACheckBox";
            this.senseACheckBox.Size = new System.Drawing.Size(69, 19);
            this.senseACheckBox.TabIndex = 25;
            this.senseACheckBox.Text = "A         C";
            this.senseACheckBox.UseVisualStyleBackColor = true;
            // 
            // senseBCheckBox
            // 
            this.senseBCheckBox.AutoSize = true;
            this.senseBCheckBox.Location = new System.Drawing.Point(435, 108);
            this.senseBCheckBox.Name = "senseBCheckBox";
            this.senseBCheckBox.Size = new System.Drawing.Size(70, 19);
            this.senseBCheckBox.TabIndex = 26;
            this.senseBCheckBox.Text = "B          B";
            this.senseBCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseCCheckBox
            // 
            this.senseCCheckBox.AutoSize = true;
            this.senseCCheckBox.Location = new System.Drawing.Point(435, 151);
            this.senseCCheckBox.Name = "senseCCheckBox";
            this.senseCCheckBox.Size = new System.Drawing.Size(72, 19);
            this.senseCCheckBox.TabIndex = 27;
            this.senseCCheckBox.Text = "C          A";
            this.senseCCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseDCheckBox
            // 
            this.senseDCheckBox.AutoSize = true;
            this.senseDCheckBox.Location = new System.Drawing.Point(435, 194);
            this.senseDCheckBox.Name = "senseDCheckBox";
            this.senseDCheckBox.Size = new System.Drawing.Size(70, 19);
            this.senseDCheckBox.TabIndex = 28;
            this.senseDCheckBox.Text = "D          8";
            this.senseDCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseECheckBox
            // 
            this.senseECheckBox.AutoSize = true;
            this.senseECheckBox.Location = new System.Drawing.Point(435, 237);
            this.senseECheckBox.Name = "senseECheckBox";
            this.senseECheckBox.Size = new System.Drawing.Size(71, 19);
            this.senseECheckBox.TabIndex = 29;
            this.senseECheckBox.Text = "E           4";
            this.senseECheckBox.UseVisualStyleBackColor = true;
            // 
            // senseFCheckBox
            // 
            this.senseFCheckBox.AutoSize = true;
            this.senseFCheckBox.Location = new System.Drawing.Point(435, 280);
            this.senseFCheckBox.Name = "senseFCheckBox";
            this.senseFCheckBox.Size = new System.Drawing.Size(71, 19);
            this.senseFCheckBox.TabIndex = 30;
            this.senseFCheckBox.Text = "F           2";
            this.senseFCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseGCheckBox
            // 
            this.senseGCheckBox.AutoSize = true;
            this.senseGCheckBox.Location = new System.Drawing.Point(435, 323);
            this.senseGCheckBox.Name = "senseGCheckBox";
            this.senseGCheckBox.Size = new System.Drawing.Size(70, 19);
            this.senseGCheckBox.TabIndex = 31;
            this.senseGCheckBox.Text = "G          1";
            this.senseGCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseWMCheckBox
            // 
            this.senseWMCheckBox.AutoSize = true;
            this.senseWMCheckBox.Location = new System.Drawing.Point(435, 366);
            this.senseWMCheckBox.Name = "senseWMCheckBox";
            this.senseWMCheckBox.Size = new System.Drawing.Size(81, 19);
            this.senseWMCheckBox.TabIndex = 32;
            this.senseWMCheckBox.Text = "           WM";
            this.senseWMCheckBox.UseVisualStyleBackColor = true;
            // 
            // senseBitLabel
            // 
            this.senseBitLabel.AutoSize = true;
            this.senseBitLabel.Location = new System.Drawing.Point(434, 35);
            this.senseBitLabel.Name = "senseBitLabel";
            this.senseBitLabel.Size = new System.Drawing.Size(71, 15);
            this.senseBitLabel.TabIndex = 33;
            this.senseBitLabel.Text = "SENSE     BIT";
            // 
            // senseBitLabel2
            // 
            this.senseBitLabel2.Location = new System.Drawing.Point(438, 399);
            this.senseBitLabel2.Name = "senseBitLabel2";
            this.senseBitLabel2.Size = new System.Drawing.Size(67, 33);
            this.senseBitLabel2.TabIndex = 34;
            this.senseBitLabel2.Text = "SENSE-BIT SWITCHES";
            // 
            // tabControlSwitches
            // 
            this.tabControlSwitches.Controls.Add(this.consoleSwitchTab);
            this.tabControlSwitches.Controls.Add(this.CESwitchTab);
            this.tabControlSwitches.Controls.Add(this.priorityProcessingTab);
            this.tabControlSwitches.Location = new System.Drawing.Point(12, 12);
            this.tabControlSwitches.Name = "tabControlSwitches";
            this.tabControlSwitches.SelectedIndex = 0;
            this.tabControlSwitches.Size = new System.Drawing.Size(898, 497);
            this.tabControlSwitches.TabIndex = 35;
            // 
            // consoleSwitchTab
            // 
            this.consoleSwitchTab.BackColor = System.Drawing.Color.DarkGray;
            this.consoleSwitchTab.Controls.Add(this.programResetButton);
            this.consoleSwitchTab.Controls.Add(this.stopButton);
            this.consoleSwitchTab.Controls.Add(this.modeLabel);
            this.consoleSwitchTab.Controls.Add(this.modeComboBox);
            this.consoleSwitchTab.Controls.Add(this.startButton);
            this.consoleSwitchTab.Controls.Add(this.powerOnButton);
            this.consoleSwitchTab.Controls.Add(this.powerOffButton);
            this.consoleSwitchTab.Controls.Add(this.readyButton);
            this.consoleSwitchTab.Controls.Add(this.DCOffButton);
            this.consoleSwitchTab.Controls.Add(this.storageScanComboBox);
            this.consoleSwitchTab.Controls.Add(this.senseBitLabel2);
            this.consoleSwitchTab.Controls.Add(this.computerResetButton);
            this.consoleSwitchTab.Controls.Add(this.addressEntryComboBox);
            this.consoleSwitchTab.Controls.Add(this.emergencyOffPanel);
            this.consoleSwitchTab.Controls.Add(this.senseBitLabel);
            this.consoleSwitchTab.Controls.Add(this.addressEntryLabel);
            this.consoleSwitchTab.Controls.Add(this.senseWMCheckBox);
            this.consoleSwitchTab.Controls.Add(this.storageScanLabel);
            this.consoleSwitchTab.Controls.Add(this.senseGCheckBox);
            this.consoleSwitchTab.Controls.Add(this.cycleControlComboBox);
            this.consoleSwitchTab.Controls.Add(this.senseFCheckBox);
            this.consoleSwitchTab.Controls.Add(this.cycleControlLabel);
            this.consoleSwitchTab.Controls.Add(this.senseECheckBox);
            this.consoleSwitchTab.Controls.Add(this.checkControlComboBox);
            this.consoleSwitchTab.Controls.Add(this.senseDCheckBox);
            this.consoleSwitchTab.Controls.Add(this.checkControlLabel);
            this.consoleSwitchTab.Controls.Add(this.senseCCheckBox);
            this.consoleSwitchTab.Controls.Add(this.diskWrInhibitCheckBox);
            this.consoleSwitchTab.Controls.Add(this.senseBCheckBox);
            this.consoleSwitchTab.Controls.Add(this.densityCh1ComboBox);
            this.consoleSwitchTab.Controls.Add(this.senseACheckBox);
            this.consoleSwitchTab.Controls.Add(this.densityCH1Label);
            this.consoleSwitchTab.Controls.Add(this.inhibitPrintOutCheckBox);
            this.consoleSwitchTab.Controls.Add(this.densityCh2ComboBox);
            this.consoleSwitchTab.Controls.Add(this.asteriskInsertCheckBox);
            this.consoleSwitchTab.Controls.Add(this.densityCh2Label);
            this.consoleSwitchTab.Controls.Add(this.checkTestLabel);
            this.consoleSwitchTab.Controls.Add(this.startPrintOutButton);
            this.consoleSwitchTab.Controls.Add(this.checkTest3Button);
            this.consoleSwitchTab.Controls.Add(this.startPrintOutLabel);
            this.consoleSwitchTab.Controls.Add(this.checkTest2Button);
            this.consoleSwitchTab.Controls.Add(this.compat1401CheckBox);
            this.consoleSwitchTab.Controls.Add(this.checkTest1Button);
            this.consoleSwitchTab.Controls.Add(this.IOCheckReset1401Button);
            this.consoleSwitchTab.Controls.Add(this.IOCheckStop1401CheckBox);
            this.consoleSwitchTab.Controls.Add(this.IOCheckReset1401Label);
            this.consoleSwitchTab.Location = new System.Drawing.Point(4, 24);
            this.consoleSwitchTab.Name = "consoleSwitchTab";
            this.consoleSwitchTab.Padding = new System.Windows.Forms.Padding(3);
            this.consoleSwitchTab.Size = new System.Drawing.Size(890, 469);
            this.consoleSwitchTab.TabIndex = 0;
            this.consoleSwitchTab.Text = "1415 Console Switches";
            // 
            // programResetButton
            // 
            this.programResetButton.Location = new System.Drawing.Point(783, 379);
            this.programResetButton.Name = "programResetButton";
            this.programResetButton.Size = new System.Drawing.Size(82, 53);
            this.programResetButton.TabIndex = 45;
            this.programResetButton.Text = "PROGRAM RESET";
            this.programResetButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Crimson;
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(639, 379);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(82, 53);
            this.stopButton.TabIndex = 44;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(632, 305);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(41, 15);
            this.modeLabel.TabIndex = 42;
            this.modeLabel.Text = "MODE";
            // 
            // modeComboBox
            // 
            this.modeComboBox.AllowDrop = true;
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            "C.E.",
            "I/E CYCLE",
            "ADDRESS SET",
            "RUN",
            "DISPLAY",
            "ALTER"});
            this.modeComboBox.Location = new System.Drawing.Point(592, 323);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(120, 23);
            this.modeComboBox.TabIndex = 41;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.SeaGreen;
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(551, 380);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(82, 53);
            this.startButton.TabIndex = 43;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // powerOnButton
            // 
            this.powerOnButton.Enabled = false;
            this.powerOnButton.Location = new System.Drawing.Point(666, 224);
            this.powerOnButton.Name = "powerOnButton";
            this.powerOnButton.Size = new System.Drawing.Size(82, 53);
            this.powerOnButton.TabIndex = 40;
            this.powerOnButton.Text = "POWER    ON";
            this.powerOnButton.UseVisualStyleBackColor = true;
            // 
            // powerOffButton
            // 
            this.powerOffButton.BackColor = System.Drawing.Color.Crimson;
            this.powerOffButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.powerOffButton.Location = new System.Drawing.Point(552, 224);
            this.powerOffButton.Name = "powerOffButton";
            this.powerOffButton.Size = new System.Drawing.Size(82, 53);
            this.powerOffButton.TabIndex = 39;
            this.powerOffButton.Text = "POWER   OFF";
            this.powerOffButton.UseVisualStyleBackColor = false;
            // 
            // readyButton
            // 
            this.readyButton.BackColor = System.Drawing.Color.SeaGreen;
            this.readyButton.Enabled = false;
            this.readyButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.readyButton.Location = new System.Drawing.Point(666, 146);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(82, 53);
            this.readyButton.TabIndex = 38;
            this.readyButton.Text = "READY";
            this.readyButton.UseVisualStyleBackColor = false;
            // 
            // DCOffButton
            // 
            this.DCOffButton.Enabled = false;
            this.DCOffButton.Location = new System.Drawing.Point(552, 146);
            this.DCOffButton.Name = "DCOffButton";
            this.DCOffButton.Size = new System.Drawing.Size(82, 53);
            this.DCOffButton.TabIndex = 37;
            this.DCOffButton.Text = "DC OFF";
            this.DCOffButton.UseVisualStyleBackColor = true;
            // 
            // computerResetButton
            // 
            this.computerResetButton.Location = new System.Drawing.Point(666, 47);
            this.computerResetButton.Name = "computerResetButton";
            this.computerResetButton.Size = new System.Drawing.Size(82, 53);
            this.computerResetButton.TabIndex = 36;
            this.computerResetButton.Text = "COMPUTER RESET";
            this.computerResetButton.UseVisualStyleBackColor = true;
            // 
            // emergencyOffPanel
            // 
            this.emergencyOffPanel.Controls.Add(this.emergencyOffLabel);
            this.emergencyOffPanel.Controls.Add(this.emergencyOffButton);
            this.emergencyOffPanel.Location = new System.Drawing.Point(552, 15);
            this.emergencyOffPanel.Name = "emergencyOffPanel";
            this.emergencyOffPanel.Size = new System.Drawing.Size(82, 117);
            this.emergencyOffPanel.TabIndex = 35;
            // 
            // emergencyOffLabel
            // 
            this.emergencyOffLabel.Location = new System.Drawing.Point(4, 2);
            this.emergencyOffLabel.Name = "emergencyOffLabel";
            this.emergencyOffLabel.Size = new System.Drawing.Size(77, 33);
            this.emergencyOffLabel.TabIndex = 1;
            this.emergencyOffLabel.Text = "Emergency Off";
            this.emergencyOffLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emergencyOffButton
            // 
            this.emergencyOffButton.BackColor = System.Drawing.Color.Crimson;
            this.emergencyOffButton.ForeColor = System.Drawing.Color.White;
            this.emergencyOffButton.Location = new System.Drawing.Point(31, 38);
            this.emergencyOffButton.Name = "emergencyOffButton";
            this.emergencyOffButton.Size = new System.Drawing.Size(23, 72);
            this.emergencyOffButton.TabIndex = 0;
            this.emergencyOffButton.Text = "PULL";
            this.emergencyOffButton.UseVisualStyleBackColor = false;
            // 
            // CESwitchTab
            // 
            this.CESwitchTab.BackColor = System.Drawing.Color.DarkGray;
            this.CESwitchTab.Location = new System.Drawing.Point(4, 24);
            this.CESwitchTab.Name = "CESwitchTab";
            this.CESwitchTab.Padding = new System.Windows.Forms.Padding(3);
            this.CESwitchTab.Size = new System.Drawing.Size(890, 469);
            this.CESwitchTab.TabIndex = 1;
            this.CESwitchTab.Text = "1411 CE Switches";
            // 
            // priorityProcessingTab
            // 
            this.priorityProcessingTab.BackColor = System.Drawing.Color.DarkGray;
            this.priorityProcessingTab.Controls.Add(this.priorityUnitSelectcomboBox);
            this.priorityProcessingTab.Controls.Add(this.priorityOnButton);
            this.priorityProcessingTab.Location = new System.Drawing.Point(4, 24);
            this.priorityProcessingTab.Name = "priorityProcessingTab";
            this.priorityProcessingTab.Padding = new System.Windows.Forms.Padding(3);
            this.priorityProcessingTab.Size = new System.Drawing.Size(890, 469);
            this.priorityProcessingTab.TabIndex = 2;
            this.priorityProcessingTab.Text = "Priority Processing";
            // 
            // priorityUnitSelectcomboBox
            // 
            this.priorityUnitSelectcomboBox.AllowDrop = true;
            this.priorityUnitSelectcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityUnitSelectcomboBox.FormattingEnabled = true;
            this.priorityUnitSelectcomboBox.Items.AddRange(new object[] {
            "OFF",
            "CARD READER",
            "PRINTER",
            "CARD PUNCH",
            "PAPER TAPE READER"});
            this.priorityUnitSelectcomboBox.Location = new System.Drawing.Point(118, 157);
            this.priorityUnitSelectcomboBox.Name = "priorityUnitSelectcomboBox";
            this.priorityUnitSelectcomboBox.Size = new System.Drawing.Size(150, 23);
            this.priorityUnitSelectcomboBox.TabIndex = 47;
            // 
            // priorityOnButton
            // 
            this.priorityOnButton.BackColor = System.Drawing.Color.Gray;
            this.priorityOnButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.priorityOnButton.Location = new System.Drawing.Point(153, 71);
            this.priorityOnButton.Name = "priorityOnButton";
            this.priorityOnButton.Size = new System.Drawing.Size(82, 53);
            this.priorityOnButton.TabIndex = 46;
            this.priorityOnButton.Text = "PRIORITY ON";
            this.priorityOnButton.UseVisualStyleBackColor = false;
            // 
            // IBM1410SwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 550);
            this.Controls.Add(this.tabControlSwitches);
            this.Name = "IBM1410SwitchForm";
            this.Text = "IBM1410SwitchForm";
            this.Load += new System.EventHandler(this.IBM1410SwitchForm_Load);
            this.tabControlSwitches.ResumeLayout(false);
            this.consoleSwitchTab.ResumeLayout(false);
            this.consoleSwitchTab.PerformLayout();
            this.emergencyOffPanel.ResumeLayout(false);
            this.priorityProcessingTab.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label checkTestLabel;
        private System.Windows.Forms.CheckBox asteriskInsertCheckBox;
        private System.Windows.Forms.CheckBox inhibitPrintOutCheckBox;
        private System.Windows.Forms.CheckBox senseACheckBox;
        private System.Windows.Forms.CheckBox senseBCheckBox;
        private System.Windows.Forms.CheckBox senseCCheckBox;
        private System.Windows.Forms.CheckBox senseDCheckBox;
        private System.Windows.Forms.CheckBox senseECheckBox;
        private System.Windows.Forms.CheckBox senseFCheckBox;
        private System.Windows.Forms.CheckBox senseGCheckBox;
        private System.Windows.Forms.CheckBox senseWMCheckBox;
        private System.Windows.Forms.Label senseBitLabel;
        private System.Windows.Forms.Label senseBitLabel2;
        private System.Windows.Forms.TabControl tabControlSwitches;
        private System.Windows.Forms.TabPage consoleSwitchTab;
        private System.Windows.Forms.TabPage CESwitchTab;
        private System.Windows.Forms.Button computerResetButton;
        private System.Windows.Forms.Panel emergencyOffPanel;
        private System.Windows.Forms.Label emergencyOffLabel;
        private System.Windows.Forms.Button emergencyOffButton;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Button powerOnButton;
        private System.Windows.Forms.Button powerOffButton;
        private System.Windows.Forms.Button readyButton;
        private System.Windows.Forms.Button DCOffButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Button programResetButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TabPage priorityProcessingTab;
        private System.Windows.Forms.ComboBox priorityUnitSelectcomboBox;
        private System.Windows.Forms.Button priorityOnButton;
    }
}