
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBM1410SwitchForm));
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
            this.addrStopScopeSyncLabel = new System.Windows.Forms.Label();
            this.unitsLabel = new System.Windows.Forms.Label();
            this.unitsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tensLabel = new System.Windows.Forms.Label();
            this.tensNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hundredsLabel = new System.Windows.Forms.Label();
            this.hundredsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thousandsLabel = new System.Windows.Forms.Label();
            this.thousandsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scanGateLabel = new System.Windows.Forms.Label();
            this.scanGateComboBox = new System.Windows.Forms.ComboBox();
            this.addrTransferLabel = new System.Windows.Forms.Label();
            this.addrTransferButton = new System.Windows.Forms.Button();
            this.addrTransferComboBox = new System.Windows.Forms.ComboBox();
            this.BCharSelLabel = new System.Windows.Forms.Label();
            this.BCharSelComboBox = new System.Windows.Forms.ComboBox();
            this.addrStopCheckBox = new System.Windows.Forms.CheckBox();
            this.priorityProcessingTab = new System.Windows.Forms.TabPage();
            this.priorityProcessingButtonLabel = new System.Windows.Forms.Label();
            this.priorityProcessingLabel = new System.Windows.Forms.Label();
            this.priorityUnitSelectcomboBox = new System.Windows.Forms.ComboBox();
            this.tabControlSwitches.SuspendLayout();
            this.consoleSwitchTab.SuspendLayout();
            this.emergencyOffPanel.SuspendLayout();
            this.CESwitchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tensNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hundredsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thousandsNumericUpDown)).BeginInit();
            this.priorityProcessingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // addressEntryComboBox
            // 
            this.addressEntryComboBox.AllowDrop = true;
            this.addressEntryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addressEntryComboBox.FormattingEnabled = true;
            this.addressEntryComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "NORMAL",
            "E",
            "F"});
            this.addressEntryComboBox.Location = new System.Drawing.Point(15, 33);
            this.addressEntryComboBox.Name = "addressEntryComboBox";
            this.addressEntryComboBox.Size = new System.Drawing.Size(120, 23);
            this.addressEntryComboBox.TabIndex = 0;
            this.addressEntryComboBox.SelectedIndexChanged += new System.EventHandler(this.addressEntryComboBox_SelectedIndexChanged);
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
            "LOAD +1",
            "LOAD  0",
            "OFF",
            "REGEN 0",
            "REGEN +1"});
            this.storageScanComboBox.Location = new System.Drawing.Point(15, 110);
            this.storageScanComboBox.Name = "storageScanComboBox";
            this.storageScanComboBox.Size = new System.Drawing.Size(120, 23);
            this.storageScanComboBox.TabIndex = 2;
            this.storageScanComboBox.SelectedIndexChanged += new System.EventHandler(this.storageScanComboBox_SelectedIndexChanged);
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
            "LOGIC STEP",
            "OFF",
            "STORAGE CYCLE"});
            this.cycleControlComboBox.Location = new System.Drawing.Point(15, 188);
            this.cycleControlComboBox.Name = "cycleControlComboBox";
            this.cycleControlComboBox.Size = new System.Drawing.Size(120, 23);
            this.cycleControlComboBox.TabIndex = 4;
            this.cycleControlComboBox.SelectedIndexChanged += new System.EventHandler(this.cycleControlComboBox_SelectedIndexChanged);
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
            "RESTART",
            "STOP NORMAL",
            "RESET & RESTART"});
            this.checkControlComboBox.Location = new System.Drawing.Point(15, 268);
            this.checkControlComboBox.Name = "checkControlComboBox";
            this.checkControlComboBox.Size = new System.Drawing.Size(120, 23);
            this.checkControlComboBox.TabIndex = 6;
            this.checkControlComboBox.SelectedIndexChanged += new System.EventHandler(this.checkControlComboBox_SelectedIndexChanged);
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
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.modeComboBox_SelectedIndexChanged);
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
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
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
            this.computerResetButton.Click += new System.EventHandler(this.computerResetButton_Click);
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
            this.CESwitchTab.Controls.Add(this.addrStopScopeSyncLabel);
            this.CESwitchTab.Controls.Add(this.unitsLabel);
            this.CESwitchTab.Controls.Add(this.unitsNumericUpDown);
            this.CESwitchTab.Controls.Add(this.tensLabel);
            this.CESwitchTab.Controls.Add(this.tensNumericUpDown);
            this.CESwitchTab.Controls.Add(this.hundredsLabel);
            this.CESwitchTab.Controls.Add(this.hundredsNumericUpDown);
            this.CESwitchTab.Controls.Add(this.thousandsLabel);
            this.CESwitchTab.Controls.Add(this.thousandsNumericUpDown);
            this.CESwitchTab.Controls.Add(this.scanGateLabel);
            this.CESwitchTab.Controls.Add(this.scanGateComboBox);
            this.CESwitchTab.Controls.Add(this.addrTransferLabel);
            this.CESwitchTab.Controls.Add(this.addrTransferButton);
            this.CESwitchTab.Controls.Add(this.addrTransferComboBox);
            this.CESwitchTab.Controls.Add(this.BCharSelLabel);
            this.CESwitchTab.Controls.Add(this.BCharSelComboBox);
            this.CESwitchTab.Controls.Add(this.addrStopCheckBox);
            this.CESwitchTab.Location = new System.Drawing.Point(4, 24);
            this.CESwitchTab.Name = "CESwitchTab";
            this.CESwitchTab.Padding = new System.Windows.Forms.Padding(3);
            this.CESwitchTab.Size = new System.Drawing.Size(890, 469);
            this.CESwitchTab.TabIndex = 1;
            this.CESwitchTab.Text = "1411 CE Switches";
            // 
            // addrStopScopeSyncLabel
            // 
            this.addrStopScopeSyncLabel.ForeColor = System.Drawing.Color.White;
            this.addrStopScopeSyncLabel.Location = new System.Drawing.Point(58, 308);
            this.addrStopScopeSyncLabel.Name = "addrStopScopeSyncLabel";
            this.addrStopScopeSyncLabel.Size = new System.Drawing.Size(440, 74);
            this.addrStopScopeSyncLabel.TabIndex = 16;
            this.addrStopScopeSyncLabel.Text = resources.GetString("addrStopScopeSyncLabel.Text");
            this.addrStopScopeSyncLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // unitsLabel
            // 
            this.unitsLabel.AutoSize = true;
            this.unitsLabel.ForeColor = System.Drawing.Color.White;
            this.unitsLabel.Location = new System.Drawing.Point(478, 252);
            this.unitsLabel.Name = "unitsLabel";
            this.unitsLabel.Size = new System.Drawing.Size(39, 15);
            this.unitsLabel.TabIndex = 15;
            this.unitsLabel.Text = "UNITS";
            // 
            // unitsNumericUpDown
            // 
            this.unitsNumericUpDown.Location = new System.Drawing.Point(465, 280);
            this.unitsNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.unitsNumericUpDown.Name = "unitsNumericUpDown";
            this.unitsNumericUpDown.Size = new System.Drawing.Size(63, 23);
            this.unitsNumericUpDown.TabIndex = 14;
            // 
            // tensLabel
            // 
            this.tensLabel.AutoSize = true;
            this.tensLabel.ForeColor = System.Drawing.Color.White;
            this.tensLabel.Location = new System.Drawing.Point(379, 252);
            this.tensLabel.Name = "tensLabel";
            this.tensLabel.Size = new System.Drawing.Size(34, 15);
            this.tensLabel.TabIndex = 13;
            this.tensLabel.Text = "TENS";
            // 
            // tensNumericUpDown
            // 
            this.tensNumericUpDown.Location = new System.Drawing.Point(365, 280);
            this.tensNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tensNumericUpDown.Name = "tensNumericUpDown";
            this.tensNumericUpDown.Size = new System.Drawing.Size(63, 23);
            this.tensNumericUpDown.TabIndex = 12;
            // 
            // hundredsLabel
            // 
            this.hundredsLabel.AutoSize = true;
            this.hundredsLabel.ForeColor = System.Drawing.Color.White;
            this.hundredsLabel.Location = new System.Drawing.Point(265, 252);
            this.hundredsLabel.Name = "hundredsLabel";
            this.hundredsLabel.Size = new System.Drawing.Size(68, 15);
            this.hundredsLabel.TabIndex = 11;
            this.hundredsLabel.Text = "HUNDREDS";
            // 
            // hundredsNumericUpDown
            // 
            this.hundredsNumericUpDown.Location = new System.Drawing.Point(265, 280);
            this.hundredsNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.hundredsNumericUpDown.Name = "hundredsNumericUpDown";
            this.hundredsNumericUpDown.Size = new System.Drawing.Size(63, 23);
            this.hundredsNumericUpDown.TabIndex = 10;
            // 
            // thousandsLabel
            // 
            this.thousandsLabel.AutoSize = true;
            this.thousandsLabel.ForeColor = System.Drawing.Color.White;
            this.thousandsLabel.Location = new System.Drawing.Point(160, 252);
            this.thousandsLabel.Name = "thousandsLabel";
            this.thousandsLabel.Size = new System.Drawing.Size(76, 15);
            this.thousandsLabel.TabIndex = 9;
            this.thousandsLabel.Text = "THOUSANDS";
            // 
            // thousandsNumericUpDown
            // 
            this.thousandsNumericUpDown.Location = new System.Drawing.Point(165, 280);
            this.thousandsNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.thousandsNumericUpDown.Name = "thousandsNumericUpDown";
            this.thousandsNumericUpDown.Size = new System.Drawing.Size(63, 23);
            this.thousandsNumericUpDown.TabIndex = 8;
            // 
            // scanGateLabel
            // 
            this.scanGateLabel.AutoSize = true;
            this.scanGateLabel.ForeColor = System.Drawing.Color.White;
            this.scanGateLabel.Location = new System.Drawing.Point(43, 252);
            this.scanGateLabel.Name = "scanGateLabel";
            this.scanGateLabel.Size = new System.Drawing.Size(68, 15);
            this.scanGateLabel.TabIndex = 7;
            this.scanGateLabel.Text = "SCAN GATE";
            // 
            // scanGateComboBox
            // 
            this.scanGateComboBox.AllowDrop = true;
            this.scanGateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scanGateComboBox.FormattingEnabled = true;
            this.scanGateComboBox.Items.AddRange(new object[] {
            "OFF",
            "NO",
            "1ST",
            "2ND",
            "3RD"});
            this.scanGateComboBox.Location = new System.Drawing.Point(43, 280);
            this.scanGateComboBox.Name = "scanGateComboBox";
            this.scanGateComboBox.Size = new System.Drawing.Size(68, 23);
            this.scanGateComboBox.TabIndex = 6;
            // 
            // addrTransferLabel
            // 
            this.addrTransferLabel.ForeColor = System.Drawing.Color.White;
            this.addrTransferLabel.Location = new System.Drawing.Point(308, 91);
            this.addrTransferLabel.Name = "addrTransferLabel";
            this.addrTransferLabel.Size = new System.Drawing.Size(190, 74);
            this.addrTransferLabel.TabIndex = 5;
            this.addrTransferLabel.Text = "|                                          |  |_________________________|  TRANSF" +
    "ER ADDRESS TO   STORAGE ADDRESS REGISTER";
            this.addrTransferLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addrTransferButton
            // 
            this.addrTransferButton.Location = new System.Drawing.Point(457, 67);
            this.addrTransferButton.Name = "addrTransferButton";
            this.addrTransferButton.Size = new System.Drawing.Size(27, 23);
            this.addrTransferButton.TabIndex = 4;
            this.addrTransferButton.UseVisualStyleBackColor = true;
            // 
            // addrTransferComboBox
            // 
            this.addrTransferComboBox.AllowDrop = true;
            this.addrTransferComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addrTransferComboBox.FormattingEnabled = true;
            this.addrTransferComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "I"});
            this.addrTransferComboBox.Location = new System.Drawing.Point(302, 68);
            this.addrTransferComboBox.Name = "addrTransferComboBox";
            this.addrTransferComboBox.Size = new System.Drawing.Size(68, 23);
            this.addrTransferComboBox.TabIndex = 3;
            // 
            // BCharSelLabel
            // 
            this.BCharSelLabel.AutoSize = true;
            this.BCharSelLabel.ForeColor = System.Drawing.Color.White;
            this.BCharSelLabel.Location = new System.Drawing.Point(153, 43);
            this.BCharSelLabel.Name = "BCharSelLabel";
            this.BCharSelLabel.Size = new System.Drawing.Size(90, 15);
            this.BCharSelLabel.TabIndex = 2;
            this.BCharSelLabel.Text = "B CH CHAR SEL";
            // 
            // BCharSelComboBox
            // 
            this.BCharSelComboBox.AllowDrop = true;
            this.BCharSelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BCharSelComboBox.FormattingEnabled = true;
            this.BCharSelComboBox.Items.AddRange(new object[] {
            "NORMAL",
            "B0",
            "B1",
            "B2",
            "B3"});
            this.BCharSelComboBox.Location = new System.Drawing.Point(162, 68);
            this.BCharSelComboBox.Name = "BCharSelComboBox";
            this.BCharSelComboBox.Size = new System.Drawing.Size(66, 23);
            this.BCharSelComboBox.TabIndex = 1;
            // 
            // addrStopCheckBox
            // 
            this.addrStopCheckBox.AutoSize = true;
            this.addrStopCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addrStopCheckBox.ForeColor = System.Drawing.Color.White;
            this.addrStopCheckBox.Location = new System.Drawing.Point(43, 43);
            this.addrStopCheckBox.Name = "addrStopCheckBox";
            this.addrStopCheckBox.Size = new System.Drawing.Size(72, 33);
            this.addrStopCheckBox.TabIndex = 0;
            this.addrStopCheckBox.Text = "ADDR STOP";
            this.addrStopCheckBox.UseVisualStyleBackColor = true;
            // 
            // priorityProcessingTab
            // 
            this.priorityProcessingTab.BackColor = System.Drawing.Color.DarkGray;
            this.priorityProcessingTab.Controls.Add(this.priorityProcessingButtonLabel);
            this.priorityProcessingTab.Controls.Add(this.priorityProcessingLabel);
            this.priorityProcessingTab.Controls.Add(this.priorityUnitSelectcomboBox);
            this.priorityProcessingTab.Location = new System.Drawing.Point(4, 24);
            this.priorityProcessingTab.Name = "priorityProcessingTab";
            this.priorityProcessingTab.Padding = new System.Windows.Forms.Padding(3);
            this.priorityProcessingTab.Size = new System.Drawing.Size(890, 469);
            this.priorityProcessingTab.TabIndex = 2;
            this.priorityProcessingTab.Text = "Priority Processing";
            // 
            // priorityProcessingButtonLabel
            // 
            this.priorityProcessingButtonLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.priorityProcessingButtonLabel.Location = new System.Drawing.Point(153, 71);
            this.priorityProcessingButtonLabel.Name = "priorityProcessingButtonLabel";
            this.priorityProcessingButtonLabel.Size = new System.Drawing.Size(82, 53);
            this.priorityProcessingButtonLabel.TabIndex = 49;
            this.priorityProcessingButtonLabel.Text = "PRIORITY   ON";
            this.priorityProcessingButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.priorityProcessingButtonLabel.Click += new System.EventHandler(this.priorityProcessingButtonLabel_Click);
            // 
            // priorityProcessingLabel
            // 
            this.priorityProcessingLabel.AutoSize = true;
            this.priorityProcessingLabel.ForeColor = System.Drawing.Color.White;
            this.priorityProcessingLabel.Location = new System.Drawing.Point(128, 198);
            this.priorityProcessingLabel.Name = "priorityProcessingLabel";
            this.priorityProcessingLabel.Size = new System.Drawing.Size(128, 15);
            this.priorityProcessingLabel.TabIndex = 48;
            this.priorityProcessingLabel.Text = "PRIORITY PROCESSING";
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
            // IBM1410SwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 550);
            this.Controls.Add(this.tabControlSwitches);
            this.Name = "IBM1410SwitchForm";
            this.Text = "IBM1410SwitchForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IBM1410SwitchForm_FormClosing);
            this.tabControlSwitches.ResumeLayout(false);
            this.consoleSwitchTab.ResumeLayout(false);
            this.consoleSwitchTab.PerformLayout();
            this.emergencyOffPanel.ResumeLayout(false);
            this.CESwitchTab.ResumeLayout(false);
            this.CESwitchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tensNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hundredsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thousandsNumericUpDown)).EndInit();
            this.priorityProcessingTab.ResumeLayout(false);
            this.priorityProcessingTab.PerformLayout();
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
        private System.Windows.Forms.Label addrStopScopeSyncLabel;
        private System.Windows.Forms.Label unitsLabel;
        private System.Windows.Forms.NumericUpDown unitsNumericUpDown;
        private System.Windows.Forms.Label tensLabel;
        private System.Windows.Forms.NumericUpDown tensNumericUpDown;
        private System.Windows.Forms.Label hundredsLabel;
        private System.Windows.Forms.NumericUpDown hundredsNumericUpDown;
        private System.Windows.Forms.Label thousandsLabel;
        private System.Windows.Forms.NumericUpDown thousandsNumericUpDown;
        private System.Windows.Forms.Label scanGateLabel;
        private System.Windows.Forms.ComboBox scanGateComboBox;
        private System.Windows.Forms.Label addrTransferLabel;
        private System.Windows.Forms.Button addrTransferButton;
        private System.Windows.Forms.ComboBox addrTransferComboBox;
        private System.Windows.Forms.Label BCharSelLabel;
        private System.Windows.Forms.ComboBox BCharSelComboBox;
        private System.Windows.Forms.CheckBox addrStopCheckBox;
        private System.Windows.Forms.Label priorityProcessingLabel;
        public System.Windows.Forms.Label priorityProcessingButtonLabel;
    }
}