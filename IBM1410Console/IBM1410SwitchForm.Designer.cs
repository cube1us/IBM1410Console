
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
            addressEntryComboBox = new System.Windows.Forms.ComboBox();
            addressEntryLabel = new System.Windows.Forms.Label();
            storageScanLabel = new System.Windows.Forms.Label();
            storageScanComboBox = new System.Windows.Forms.ComboBox();
            cycleControlLabel = new System.Windows.Forms.Label();
            cycleControlComboBox = new System.Windows.Forms.ComboBox();
            checkControlLabel = new System.Windows.Forms.Label();
            checkControlComboBox = new System.Windows.Forms.ComboBox();
            diskWrInhibitCheckBox = new System.Windows.Forms.CheckBox();
            densityCH1Label = new System.Windows.Forms.Label();
            densityCh1ComboBox = new System.Windows.Forms.ComboBox();
            densityCh2Label = new System.Windows.Forms.Label();
            densityCh2ComboBox = new System.Windows.Forms.ComboBox();
            startPrintOutButton = new System.Windows.Forms.Button();
            startPrintOutLabel = new System.Windows.Forms.Label();
            compat1401CheckBox = new System.Windows.Forms.CheckBox();
            IOCheckReset1401Button = new System.Windows.Forms.Button();
            IOCheckReset1401Label = new System.Windows.Forms.Label();
            IOCheckStop1401CheckBox = new System.Windows.Forms.CheckBox();
            checkTest1Button = new System.Windows.Forms.Button();
            checkTest2Button = new System.Windows.Forms.Button();
            checkTest3Button = new System.Windows.Forms.Button();
            checkTestLabel = new System.Windows.Forms.Label();
            asteriskInsertCheckBox = new System.Windows.Forms.CheckBox();
            inhibitPrintOutCheckBox = new System.Windows.Forms.CheckBox();
            senseACheckBox = new System.Windows.Forms.CheckBox();
            senseBCheckBox = new System.Windows.Forms.CheckBox();
            senseCCheckBox = new System.Windows.Forms.CheckBox();
            senseDCheckBox = new System.Windows.Forms.CheckBox();
            senseECheckBox = new System.Windows.Forms.CheckBox();
            senseFCheckBox = new System.Windows.Forms.CheckBox();
            senseGCheckBox = new System.Windows.Forms.CheckBox();
            senseWMCheckBox = new System.Windows.Forms.CheckBox();
            senseBitLabel = new System.Windows.Forms.Label();
            senseBitLabel2 = new System.Windows.Forms.Label();
            tabControlSwitches = new System.Windows.Forms.TabControl();
            consoleSwitchTab = new System.Windows.Forms.TabPage();
            programResetButton = new System.Windows.Forms.Button();
            stopButton = new System.Windows.Forms.Button();
            modeLabel = new System.Windows.Forms.Label();
            modeComboBox = new System.Windows.Forms.ComboBox();
            startButton = new System.Windows.Forms.Button();
            powerOnButton = new System.Windows.Forms.Button();
            powerOffButton = new System.Windows.Forms.Button();
            readyButton = new System.Windows.Forms.Button();
            DCOffButton = new System.Windows.Forms.Button();
            computerResetButton = new System.Windows.Forms.Button();
            emergencyOffPanel = new System.Windows.Forms.Panel();
            emergencyOffLabel = new System.Windows.Forms.Label();
            emergencyOffButton = new System.Windows.Forms.Button();
            CESwitchTab = new System.Windows.Forms.TabPage();
            addrStopScopeSyncLabel = new System.Windows.Forms.Label();
            unitsLabel = new System.Windows.Forms.Label();
            unitsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            tensLabel = new System.Windows.Forms.Label();
            tensNumericUpDown = new System.Windows.Forms.NumericUpDown();
            hundredsLabel = new System.Windows.Forms.Label();
            hundredsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            thousandsLabel = new System.Windows.Forms.Label();
            thousandsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            scanGateLabel = new System.Windows.Forms.Label();
            scanGateComboBox = new System.Windows.Forms.ComboBox();
            addrTransferLabel = new System.Windows.Forms.Label();
            addrTransferButton = new System.Windows.Forms.Button();
            addrTransferComboBox = new System.Windows.Forms.ComboBox();
            BCharSelLabel = new System.Windows.Forms.Label();
            BCharSelComboBox = new System.Windows.Forms.ComboBox();
            addrStopCheckBox = new System.Windows.Forms.CheckBox();
            priorityProcessingTab = new System.Windows.Forms.TabPage();
            priorityProcessingButtonLabel = new System.Windows.Forms.Label();
            priorityProcessingLabel = new System.Windows.Forms.Label();
            priorityUnitSelectcomboBox = new System.Windows.Forms.ComboBox();
            tabControlSwitches.SuspendLayout();
            consoleSwitchTab.SuspendLayout();
            emergencyOffPanel.SuspendLayout();
            CESwitchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)unitsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tensNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hundredsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thousandsNumericUpDown).BeginInit();
            priorityProcessingTab.SuspendLayout();
            SuspendLayout();
            // 
            // addressEntryComboBox
            // 
            addressEntryComboBox.AllowDrop = true;
            addressEntryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            addressEntryComboBox.FormattingEnabled = true;
            addressEntryComboBox.Items.AddRange(new object[] { "A", "B", "C", "D", "NORMAL", "E", "F" });
            addressEntryComboBox.Location = new System.Drawing.Point(15, 33);
            addressEntryComboBox.Name = "addressEntryComboBox";
            addressEntryComboBox.Size = new System.Drawing.Size(120, 23);
            addressEntryComboBox.TabIndex = 0;
            addressEntryComboBox.SelectedIndexChanged += addressEntryComboBox_SelectedIndexChanged;
            // 
            // addressEntryLabel
            // 
            addressEntryLabel.AutoSize = true;
            addressEntryLabel.Location = new System.Drawing.Point(28, 59);
            addressEntryLabel.Name = "addressEntryLabel";
            addressEntryLabel.Size = new System.Drawing.Size(94, 15);
            addressEntryLabel.TabIndex = 1;
            addressEntryLabel.Text = "ADDRESS ENTRY";
            // 
            // storageScanLabel
            // 
            storageScanLabel.AutoSize = true;
            storageScanLabel.Location = new System.Drawing.Point(30, 136);
            storageScanLabel.Name = "storageScanLabel";
            storageScanLabel.Size = new System.Drawing.Size(90, 15);
            storageScanLabel.TabIndex = 3;
            storageScanLabel.Text = "STORAGE SCAN";
            // 
            // storageScanComboBox
            // 
            storageScanComboBox.AllowDrop = true;
            storageScanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            storageScanComboBox.FormattingEnabled = true;
            storageScanComboBox.Items.AddRange(new object[] { "LOAD +1", "LOAD  0", "OFF", "REGEN 0", "REGEN +1" });
            storageScanComboBox.Location = new System.Drawing.Point(15, 110);
            storageScanComboBox.Name = "storageScanComboBox";
            storageScanComboBox.Size = new System.Drawing.Size(120, 23);
            storageScanComboBox.TabIndex = 2;
            storageScanComboBox.SelectedIndexChanged += storageScanComboBox_SelectedIndexChanged;
            // 
            // cycleControlLabel
            // 
            cycleControlLabel.AutoSize = true;
            cycleControlLabel.Location = new System.Drawing.Point(26, 214);
            cycleControlLabel.Name = "cycleControlLabel";
            cycleControlLabel.Size = new System.Drawing.Size(99, 15);
            cycleControlLabel.TabIndex = 5;
            cycleControlLabel.Text = "CYCLE CONTROL";
            // 
            // cycleControlComboBox
            // 
            cycleControlComboBox.AllowDrop = true;
            cycleControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cycleControlComboBox.FormattingEnabled = true;
            cycleControlComboBox.Items.AddRange(new object[] { "LOGIC STEP", "OFF", "STORAGE CYCLE" });
            cycleControlComboBox.Location = new System.Drawing.Point(15, 188);
            cycleControlComboBox.Name = "cycleControlComboBox";
            cycleControlComboBox.Size = new System.Drawing.Size(120, 23);
            cycleControlComboBox.TabIndex = 4;
            cycleControlComboBox.SelectedIndexChanged += cycleControlComboBox_SelectedIndexChanged;
            // 
            // checkControlLabel
            // 
            checkControlLabel.AutoSize = true;
            checkControlLabel.Location = new System.Drawing.Point(24, 294);
            checkControlLabel.Name = "checkControlLabel";
            checkControlLabel.Size = new System.Drawing.Size(102, 15);
            checkControlLabel.TabIndex = 7;
            checkControlLabel.Text = "CHECK CONTROL";
            // 
            // checkControlComboBox
            // 
            checkControlComboBox.AllowDrop = true;
            checkControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            checkControlComboBox.FormattingEnabled = true;
            checkControlComboBox.Items.AddRange(new object[] { "RESTART", "STOP NORMAL", "RESET & RESTART" });
            checkControlComboBox.Location = new System.Drawing.Point(15, 268);
            checkControlComboBox.Name = "checkControlComboBox";
            checkControlComboBox.Size = new System.Drawing.Size(120, 23);
            checkControlComboBox.TabIndex = 6;
            checkControlComboBox.SelectedIndexChanged += checkControlComboBox_SelectedIndexChanged;
            // 
            // diskWrInhibitCheckBox
            // 
            diskWrInhibitCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            diskWrInhibitCheckBox.Location = new System.Drawing.Point(175, 121);
            diskWrInhibitCheckBox.Name = "diskWrInhibitCheckBox";
            diskWrInhibitCheckBox.Size = new System.Drawing.Size(71, 46);
            diskWrInhibitCheckBox.TabIndex = 8;
            diskWrInhibitCheckBox.Text = "Disk WR Inhibit";
            diskWrInhibitCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            diskWrInhibitCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            diskWrInhibitCheckBox.UseVisualStyleBackColor = true;
            diskWrInhibitCheckBox.CheckedChanged += diskWrInhibitCheckBox_CheckedChanged;
            // 
            // densityCH1Label
            // 
            densityCH1Label.AutoSize = true;
            densityCH1Label.Location = new System.Drawing.Point(171, 199);
            densityCH1Label.Name = "densityCH1Label";
            densityCH1Label.Size = new System.Drawing.Size(78, 15);
            densityCH1Label.TabIndex = 10;
            densityCH1Label.Text = "DENSITY CH1";
            // 
            // densityCh1ComboBox
            // 
            densityCh1ComboBox.AllowDrop = true;
            densityCh1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            densityCh1ComboBox.FormattingEnabled = true;
            densityCh1ComboBox.Items.AddRange(new object[] { "200/556", "556/800" });
            densityCh1ComboBox.Location = new System.Drawing.Point(170, 173);
            densityCh1ComboBox.Name = "densityCh1ComboBox";
            densityCh1ComboBox.Size = new System.Drawing.Size(80, 23);
            densityCh1ComboBox.TabIndex = 9;
            densityCh1ComboBox.SelectedIndexChanged += densityCh1ComboBox_SelectedIndexChanged;
            // 
            // densityCh2Label
            // 
            densityCh2Label.AutoSize = true;
            densityCh2Label.Location = new System.Drawing.Point(171, 253);
            densityCh2Label.Name = "densityCh2Label";
            densityCh2Label.Size = new System.Drawing.Size(78, 15);
            densityCh2Label.TabIndex = 12;
            densityCh2Label.Text = "DENSITY CH1";
            // 
            // densityCh2ComboBox
            // 
            densityCh2ComboBox.AllowDrop = true;
            densityCh2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            densityCh2ComboBox.FormattingEnabled = true;
            densityCh2ComboBox.Items.AddRange(new object[] { "200/556", "556/800" });
            densityCh2ComboBox.Location = new System.Drawing.Point(170, 227);
            densityCh2ComboBox.Name = "densityCh2ComboBox";
            densityCh2ComboBox.Size = new System.Drawing.Size(80, 23);
            densityCh2ComboBox.TabIndex = 11;
            densityCh2ComboBox.SelectedIndexChanged += densityCh2ComboBox_SelectedIndexChanged;
            // 
            // startPrintOutButton
            // 
            startPrintOutButton.Location = new System.Drawing.Point(211, 314);
            startPrintOutButton.Name = "startPrintOutButton";
            startPrintOutButton.Size = new System.Drawing.Size(21, 21);
            startPrintOutButton.TabIndex = 13;
            startPrintOutButton.UseVisualStyleBackColor = true;
            startPrintOutButton.Click += startPrintOutButton_Click;
            // 
            // startPrintOutLabel
            // 
            startPrintOutLabel.Location = new System.Drawing.Point(159, 294);
            startPrintOutLabel.Name = "startPrintOutLabel";
            startPrintOutLabel.Size = new System.Drawing.Size(46, 63);
            startPrintOutLabel.TabIndex = 14;
            startPrintOutLabel.Text = "START PRINT OUT";
            startPrintOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compat1401CheckBox
            // 
            compat1401CheckBox.Location = new System.Drawing.Point(300, 15);
            compat1401CheckBox.Name = "compat1401CheckBox";
            compat1401CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            compat1401CheckBox.Size = new System.Drawing.Size(70, 59);
            compat1401CheckBox.TabIndex = 15;
            compat1401CheckBox.Text = "1401 Compatibility";
            compat1401CheckBox.UseVisualStyleBackColor = true;
            compat1401CheckBox.CheckedChanged += compat1401CheckBox_CheckedChanged;
            // 
            // IOCheckReset1401Button
            // 
            IOCheckReset1401Button.Location = new System.Drawing.Point(361, 97);
            IOCheckReset1401Button.Name = "IOCheckReset1401Button";
            IOCheckReset1401Button.Size = new System.Drawing.Size(21, 21);
            IOCheckReset1401Button.TabIndex = 16;
            IOCheckReset1401Button.UseVisualStyleBackColor = true;
            IOCheckReset1401Button.Click += IOCheckReset1401Button_Click;
            // 
            // IOCheckReset1401Label
            // 
            IOCheckReset1401Label.Location = new System.Drawing.Point(300, 76);
            IOCheckReset1401Label.Name = "IOCheckReset1401Label";
            IOCheckReset1401Label.Size = new System.Drawing.Size(55, 63);
            IOCheckReset1401Label.TabIndex = 17;
            IOCheckReset1401Label.Text = "1401 I/O CHECK RESET";
            IOCheckReset1401Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IOCheckStop1401CheckBox
            // 
            IOCheckStop1401CheckBox.Location = new System.Drawing.Point(300, 145);
            IOCheckStop1401CheckBox.Name = "IOCheckStop1401CheckBox";
            IOCheckStop1401CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            IOCheckStop1401CheckBox.Size = new System.Drawing.Size(70, 59);
            IOCheckStop1401CheckBox.TabIndex = 18;
            IOCheckStop1401CheckBox.Text = "I/O Check Stop";
            IOCheckStop1401CheckBox.UseVisualStyleBackColor = true;
            IOCheckStop1401CheckBox.CheckedChanged += IOCheckStop1401CheckBox_CheckedChanged;
            // 
            // checkTest1Button
            // 
            checkTest1Button.BackColor = System.Drawing.Color.LightGray;
            checkTest1Button.Location = new System.Drawing.Point(357, 213);
            checkTest1Button.Name = "checkTest1Button";
            checkTest1Button.Size = new System.Drawing.Size(21, 21);
            checkTest1Button.TabIndex = 19;
            checkTest1Button.Text = "1";
            checkTest1Button.UseVisualStyleBackColor = false;
            checkTest1Button.Click += checkTest1Button_Click;
            // 
            // checkTest2Button
            // 
            checkTest2Button.BackColor = System.Drawing.Color.LightGray;
            checkTest2Button.Location = new System.Drawing.Point(357, 244);
            checkTest2Button.Name = "checkTest2Button";
            checkTest2Button.Size = new System.Drawing.Size(21, 21);
            checkTest2Button.TabIndex = 20;
            checkTest2Button.Text = "2";
            checkTest2Button.UseVisualStyleBackColor = false;
            checkTest2Button.Click += checkTest2Button_Click;
            // 
            // checkTest3Button
            // 
            checkTest3Button.BackColor = System.Drawing.Color.LightGray;
            checkTest3Button.Location = new System.Drawing.Point(357, 275);
            checkTest3Button.Name = "checkTest3Button";
            checkTest3Button.Size = new System.Drawing.Size(21, 21);
            checkTest3Button.TabIndex = 21;
            checkTest3Button.Text = "3";
            checkTest3Button.UseVisualStyleBackColor = false;
            checkTest3Button.Click += checkTest3Button_Click;
            // 
            // checkTestLabel
            // 
            checkTestLabel.Location = new System.Drawing.Point(296, 223);
            checkTestLabel.Name = "checkTestLabel";
            checkTestLabel.Size = new System.Drawing.Size(55, 63);
            checkTestLabel.TabIndex = 22;
            checkTestLabel.Text = "CHECK TEST";
            checkTestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // asteriskInsertCheckBox
            // 
            asteriskInsertCheckBox.Checked = true;
            asteriskInsertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            asteriskInsertCheckBox.Location = new System.Drawing.Point(288, 314);
            asteriskInsertCheckBox.Name = "asteriskInsertCheckBox";
            asteriskInsertCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            asteriskInsertCheckBox.Size = new System.Drawing.Size(82, 39);
            asteriskInsertCheckBox.TabIndex = 23;
            asteriskInsertCheckBox.Text = "ASTERISK INSERT";
            asteriskInsertCheckBox.UseVisualStyleBackColor = true;
            asteriskInsertCheckBox.CheckedChanged += asteriskInsertCheckBox_CheckedChanged;
            // 
            // inhibitPrintOutCheckBox
            // 
            inhibitPrintOutCheckBox.Location = new System.Drawing.Point(277, 359);
            inhibitPrintOutCheckBox.Name = "inhibitPrintOutCheckBox";
            inhibitPrintOutCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            inhibitPrintOutCheckBox.Size = new System.Drawing.Size(93, 64);
            inhibitPrintOutCheckBox.TabIndex = 24;
            inhibitPrintOutCheckBox.Text = "INHIBIT PRINT OUT CONTROL";
            inhibitPrintOutCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            inhibitPrintOutCheckBox.UseVisualStyleBackColor = true;
            inhibitPrintOutCheckBox.CheckedChanged += inhibitPrintOutCheckBox_CheckedChanged;
            // 
            // senseACheckBox
            // 
            senseACheckBox.AutoSize = true;
            senseACheckBox.Location = new System.Drawing.Point(435, 65);
            senseACheckBox.Name = "senseACheckBox";
            senseACheckBox.Size = new System.Drawing.Size(69, 19);
            senseACheckBox.TabIndex = 25;
            senseACheckBox.Text = "A         C";
            senseACheckBox.UseVisualStyleBackColor = true;
            senseACheckBox.CheckedChanged += senseACheckBox_CheckedChanged;
            // 
            // senseBCheckBox
            // 
            senseBCheckBox.AutoSize = true;
            senseBCheckBox.Location = new System.Drawing.Point(435, 108);
            senseBCheckBox.Name = "senseBCheckBox";
            senseBCheckBox.Size = new System.Drawing.Size(70, 19);
            senseBCheckBox.TabIndex = 26;
            senseBCheckBox.Text = "B          B";
            senseBCheckBox.UseVisualStyleBackColor = true;
            senseBCheckBox.CheckedChanged += senseBCheckBox_CheckedChanged;
            // 
            // senseCCheckBox
            // 
            senseCCheckBox.AutoSize = true;
            senseCCheckBox.Location = new System.Drawing.Point(435, 151);
            senseCCheckBox.Name = "senseCCheckBox";
            senseCCheckBox.Size = new System.Drawing.Size(72, 19);
            senseCCheckBox.TabIndex = 27;
            senseCCheckBox.Text = "C          A";
            senseCCheckBox.UseVisualStyleBackColor = true;
            senseCCheckBox.CheckedChanged += senseCCheckBox_CheckedChanged;
            // 
            // senseDCheckBox
            // 
            senseDCheckBox.AutoSize = true;
            senseDCheckBox.Location = new System.Drawing.Point(435, 194);
            senseDCheckBox.Name = "senseDCheckBox";
            senseDCheckBox.Size = new System.Drawing.Size(70, 19);
            senseDCheckBox.TabIndex = 28;
            senseDCheckBox.Text = "D          8";
            senseDCheckBox.UseVisualStyleBackColor = true;
            senseDCheckBox.CheckedChanged += senseDCheckBox_CheckedChanged;
            // 
            // senseECheckBox
            // 
            senseECheckBox.AutoSize = true;
            senseECheckBox.Location = new System.Drawing.Point(435, 237);
            senseECheckBox.Name = "senseECheckBox";
            senseECheckBox.Size = new System.Drawing.Size(71, 19);
            senseECheckBox.TabIndex = 29;
            senseECheckBox.Text = "E           4";
            senseECheckBox.UseVisualStyleBackColor = true;
            senseECheckBox.CheckedChanged += senseECheckBox_CheckedChanged;
            // 
            // senseFCheckBox
            // 
            senseFCheckBox.AutoSize = true;
            senseFCheckBox.Location = new System.Drawing.Point(435, 280);
            senseFCheckBox.Name = "senseFCheckBox";
            senseFCheckBox.Size = new System.Drawing.Size(71, 19);
            senseFCheckBox.TabIndex = 30;
            senseFCheckBox.Text = "F           2";
            senseFCheckBox.UseVisualStyleBackColor = true;
            senseFCheckBox.CheckedChanged += senseFCheckBox_CheckedChanged;
            // 
            // senseGCheckBox
            // 
            senseGCheckBox.AutoSize = true;
            senseGCheckBox.Location = new System.Drawing.Point(435, 323);
            senseGCheckBox.Name = "senseGCheckBox";
            senseGCheckBox.Size = new System.Drawing.Size(70, 19);
            senseGCheckBox.TabIndex = 31;
            senseGCheckBox.Text = "G          1";
            senseGCheckBox.UseVisualStyleBackColor = true;
            senseGCheckBox.CheckedChanged += senseGCheckBox_CheckedChanged;
            // 
            // senseWMCheckBox
            // 
            senseWMCheckBox.AutoSize = true;
            senseWMCheckBox.Location = new System.Drawing.Point(435, 366);
            senseWMCheckBox.Name = "senseWMCheckBox";
            senseWMCheckBox.Size = new System.Drawing.Size(81, 19);
            senseWMCheckBox.TabIndex = 32;
            senseWMCheckBox.Text = "           WM";
            senseWMCheckBox.UseVisualStyleBackColor = true;
            senseWMCheckBox.CheckedChanged += senseWMCheckBox_CheckedChanged;
            // 
            // senseBitLabel
            // 
            senseBitLabel.AutoSize = true;
            senseBitLabel.Location = new System.Drawing.Point(434, 35);
            senseBitLabel.Name = "senseBitLabel";
            senseBitLabel.Size = new System.Drawing.Size(71, 15);
            senseBitLabel.TabIndex = 33;
            senseBitLabel.Text = "SENSE     BIT";
            // 
            // senseBitLabel2
            // 
            senseBitLabel2.Location = new System.Drawing.Point(438, 399);
            senseBitLabel2.Name = "senseBitLabel2";
            senseBitLabel2.Size = new System.Drawing.Size(67, 33);
            senseBitLabel2.TabIndex = 34;
            senseBitLabel2.Text = "SENSE-BIT SWITCHES";
            // 
            // tabControlSwitches
            // 
            tabControlSwitches.Controls.Add(consoleSwitchTab);
            tabControlSwitches.Controls.Add(CESwitchTab);
            tabControlSwitches.Controls.Add(priorityProcessingTab);
            tabControlSwitches.Location = new System.Drawing.Point(12, 12);
            tabControlSwitches.Name = "tabControlSwitches";
            tabControlSwitches.SelectedIndex = 0;
            tabControlSwitches.Size = new System.Drawing.Size(898, 497);
            tabControlSwitches.TabIndex = 35;
            // 
            // consoleSwitchTab
            // 
            consoleSwitchTab.BackColor = System.Drawing.Color.DarkGray;
            consoleSwitchTab.Controls.Add(programResetButton);
            consoleSwitchTab.Controls.Add(stopButton);
            consoleSwitchTab.Controls.Add(modeLabel);
            consoleSwitchTab.Controls.Add(modeComboBox);
            consoleSwitchTab.Controls.Add(startButton);
            consoleSwitchTab.Controls.Add(powerOnButton);
            consoleSwitchTab.Controls.Add(powerOffButton);
            consoleSwitchTab.Controls.Add(readyButton);
            consoleSwitchTab.Controls.Add(DCOffButton);
            consoleSwitchTab.Controls.Add(storageScanComboBox);
            consoleSwitchTab.Controls.Add(senseBitLabel2);
            consoleSwitchTab.Controls.Add(computerResetButton);
            consoleSwitchTab.Controls.Add(addressEntryComboBox);
            consoleSwitchTab.Controls.Add(emergencyOffPanel);
            consoleSwitchTab.Controls.Add(senseBitLabel);
            consoleSwitchTab.Controls.Add(addressEntryLabel);
            consoleSwitchTab.Controls.Add(senseWMCheckBox);
            consoleSwitchTab.Controls.Add(storageScanLabel);
            consoleSwitchTab.Controls.Add(senseGCheckBox);
            consoleSwitchTab.Controls.Add(cycleControlComboBox);
            consoleSwitchTab.Controls.Add(senseFCheckBox);
            consoleSwitchTab.Controls.Add(cycleControlLabel);
            consoleSwitchTab.Controls.Add(senseECheckBox);
            consoleSwitchTab.Controls.Add(checkControlComboBox);
            consoleSwitchTab.Controls.Add(senseDCheckBox);
            consoleSwitchTab.Controls.Add(checkControlLabel);
            consoleSwitchTab.Controls.Add(senseCCheckBox);
            consoleSwitchTab.Controls.Add(diskWrInhibitCheckBox);
            consoleSwitchTab.Controls.Add(senseBCheckBox);
            consoleSwitchTab.Controls.Add(densityCh1ComboBox);
            consoleSwitchTab.Controls.Add(senseACheckBox);
            consoleSwitchTab.Controls.Add(densityCH1Label);
            consoleSwitchTab.Controls.Add(inhibitPrintOutCheckBox);
            consoleSwitchTab.Controls.Add(densityCh2ComboBox);
            consoleSwitchTab.Controls.Add(asteriskInsertCheckBox);
            consoleSwitchTab.Controls.Add(densityCh2Label);
            consoleSwitchTab.Controls.Add(checkTestLabel);
            consoleSwitchTab.Controls.Add(startPrintOutButton);
            consoleSwitchTab.Controls.Add(checkTest3Button);
            consoleSwitchTab.Controls.Add(startPrintOutLabel);
            consoleSwitchTab.Controls.Add(checkTest2Button);
            consoleSwitchTab.Controls.Add(compat1401CheckBox);
            consoleSwitchTab.Controls.Add(checkTest1Button);
            consoleSwitchTab.Controls.Add(IOCheckReset1401Button);
            consoleSwitchTab.Controls.Add(IOCheckStop1401CheckBox);
            consoleSwitchTab.Controls.Add(IOCheckReset1401Label);
            consoleSwitchTab.Location = new System.Drawing.Point(4, 24);
            consoleSwitchTab.Name = "consoleSwitchTab";
            consoleSwitchTab.Padding = new System.Windows.Forms.Padding(3);
            consoleSwitchTab.Size = new System.Drawing.Size(890, 469);
            consoleSwitchTab.TabIndex = 0;
            consoleSwitchTab.Text = "1415 Console Switches";
            // 
            // programResetButton
            // 
            programResetButton.Location = new System.Drawing.Point(783, 379);
            programResetButton.Name = "programResetButton";
            programResetButton.Size = new System.Drawing.Size(82, 53);
            programResetButton.TabIndex = 45;
            programResetButton.Text = "PROGRAM RESET";
            programResetButton.UseVisualStyleBackColor = true;
            programResetButton.Click += programResetButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackColor = System.Drawing.Color.Crimson;
            stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            stopButton.Location = new System.Drawing.Point(639, 379);
            stopButton.Name = "stopButton";
            stopButton.Size = new System.Drawing.Size(82, 53);
            stopButton.TabIndex = 44;
            stopButton.Text = "STOP";
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += stopButton_Click;
            // 
            // modeLabel
            // 
            modeLabel.AutoSize = true;
            modeLabel.Location = new System.Drawing.Point(632, 305);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new System.Drawing.Size(41, 15);
            modeLabel.TabIndex = 42;
            modeLabel.Text = "MODE";
            // 
            // modeComboBox
            // 
            modeComboBox.AllowDrop = true;
            modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Items.AddRange(new object[] { "C.E.", "I/E CYCLE", "ADDRESS SET", "RUN", "DISPLAY", "ALTER" });
            modeComboBox.Location = new System.Drawing.Point(592, 323);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new System.Drawing.Size(120, 23);
            modeComboBox.TabIndex = 41;
            modeComboBox.SelectedIndexChanged += modeComboBox_SelectedIndexChanged;
            // 
            // startButton
            // 
            startButton.BackColor = System.Drawing.Color.SeaGreen;
            startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            startButton.Location = new System.Drawing.Point(551, 380);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(82, 53);
            startButton.TabIndex = 43;
            startButton.Text = "START";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // powerOnButton
            // 
            powerOnButton.Enabled = false;
            powerOnButton.Location = new System.Drawing.Point(666, 224);
            powerOnButton.Name = "powerOnButton";
            powerOnButton.Size = new System.Drawing.Size(82, 53);
            powerOnButton.TabIndex = 40;
            powerOnButton.Text = "POWER    ON";
            powerOnButton.UseVisualStyleBackColor = true;
            // 
            // powerOffButton
            // 
            powerOffButton.BackColor = System.Drawing.Color.Crimson;
            powerOffButton.ForeColor = System.Drawing.SystemColors.ControlText;
            powerOffButton.Location = new System.Drawing.Point(552, 224);
            powerOffButton.Name = "powerOffButton";
            powerOffButton.Size = new System.Drawing.Size(82, 53);
            powerOffButton.TabIndex = 39;
            powerOffButton.Text = "POWER   OFF";
            powerOffButton.UseVisualStyleBackColor = false;
            // 
            // readyButton
            // 
            readyButton.BackColor = System.Drawing.Color.SeaGreen;
            readyButton.Enabled = false;
            readyButton.ForeColor = System.Drawing.SystemColors.ControlText;
            readyButton.Location = new System.Drawing.Point(666, 146);
            readyButton.Name = "readyButton";
            readyButton.Size = new System.Drawing.Size(82, 53);
            readyButton.TabIndex = 38;
            readyButton.Text = "READY";
            readyButton.UseVisualStyleBackColor = false;
            // 
            // DCOffButton
            // 
            DCOffButton.Enabled = false;
            DCOffButton.Location = new System.Drawing.Point(552, 146);
            DCOffButton.Name = "DCOffButton";
            DCOffButton.Size = new System.Drawing.Size(82, 53);
            DCOffButton.TabIndex = 37;
            DCOffButton.Text = "DC OFF";
            DCOffButton.UseVisualStyleBackColor = true;
            // 
            // computerResetButton
            // 
            computerResetButton.Location = new System.Drawing.Point(666, 47);
            computerResetButton.Name = "computerResetButton";
            computerResetButton.Size = new System.Drawing.Size(82, 53);
            computerResetButton.TabIndex = 36;
            computerResetButton.Text = "COMPUTER RESET";
            computerResetButton.UseVisualStyleBackColor = true;
            computerResetButton.Click += computerResetButton_Click;
            // 
            // emergencyOffPanel
            // 
            emergencyOffPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            emergencyOffPanel.Controls.Add(emergencyOffLabel);
            emergencyOffPanel.Controls.Add(emergencyOffButton);
            emergencyOffPanel.Location = new System.Drawing.Point(552, 15);
            emergencyOffPanel.Name = "emergencyOffPanel";
            emergencyOffPanel.Size = new System.Drawing.Size(82, 117);
            emergencyOffPanel.TabIndex = 35;
            // 
            // emergencyOffLabel
            // 
            emergencyOffLabel.Location = new System.Drawing.Point(4, 2);
            emergencyOffLabel.Name = "emergencyOffLabel";
            emergencyOffLabel.Size = new System.Drawing.Size(77, 33);
            emergencyOffLabel.TabIndex = 1;
            emergencyOffLabel.Text = "Emergency Off";
            emergencyOffLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emergencyOffButton
            // 
            emergencyOffButton.BackColor = System.Drawing.Color.Crimson;
            emergencyOffButton.ForeColor = System.Drawing.Color.White;
            emergencyOffButton.Location = new System.Drawing.Point(31, 38);
            emergencyOffButton.Name = "emergencyOffButton";
            emergencyOffButton.Size = new System.Drawing.Size(23, 72);
            emergencyOffButton.TabIndex = 0;
            emergencyOffButton.Text = "PULL";
            emergencyOffButton.UseVisualStyleBackColor = false;
            // 
            // CESwitchTab
            // 
            CESwitchTab.BackColor = System.Drawing.Color.DarkGray;
            CESwitchTab.Controls.Add(addrStopScopeSyncLabel);
            CESwitchTab.Controls.Add(unitsLabel);
            CESwitchTab.Controls.Add(unitsNumericUpDown);
            CESwitchTab.Controls.Add(tensLabel);
            CESwitchTab.Controls.Add(tensNumericUpDown);
            CESwitchTab.Controls.Add(hundredsLabel);
            CESwitchTab.Controls.Add(hundredsNumericUpDown);
            CESwitchTab.Controls.Add(thousandsLabel);
            CESwitchTab.Controls.Add(thousandsNumericUpDown);
            CESwitchTab.Controls.Add(scanGateLabel);
            CESwitchTab.Controls.Add(scanGateComboBox);
            CESwitchTab.Controls.Add(addrTransferLabel);
            CESwitchTab.Controls.Add(addrTransferButton);
            CESwitchTab.Controls.Add(addrTransferComboBox);
            CESwitchTab.Controls.Add(BCharSelLabel);
            CESwitchTab.Controls.Add(BCharSelComboBox);
            CESwitchTab.Controls.Add(addrStopCheckBox);
            CESwitchTab.Location = new System.Drawing.Point(4, 24);
            CESwitchTab.Name = "CESwitchTab";
            CESwitchTab.Padding = new System.Windows.Forms.Padding(3);
            CESwitchTab.Size = new System.Drawing.Size(890, 469);
            CESwitchTab.TabIndex = 1;
            CESwitchTab.Text = "1411 CE Switches";
            // 
            // addrStopScopeSyncLabel
            // 
            addrStopScopeSyncLabel.ForeColor = System.Drawing.Color.White;
            addrStopScopeSyncLabel.Location = new System.Drawing.Point(58, 308);
            addrStopScopeSyncLabel.Name = "addrStopScopeSyncLabel";
            addrStopScopeSyncLabel.Size = new System.Drawing.Size(440, 74);
            addrStopScopeSyncLabel.TabIndex = 16;
            addrStopScopeSyncLabel.Text = resources.GetString("addrStopScopeSyncLabel.Text");
            addrStopScopeSyncLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // unitsLabel
            // 
            unitsLabel.AutoSize = true;
            unitsLabel.ForeColor = System.Drawing.Color.White;
            unitsLabel.Location = new System.Drawing.Point(478, 252);
            unitsLabel.Name = "unitsLabel";
            unitsLabel.Size = new System.Drawing.Size(39, 15);
            unitsLabel.TabIndex = 15;
            unitsLabel.Text = "UNITS";
            // 
            // unitsNumericUpDown
            // 
            unitsNumericUpDown.Location = new System.Drawing.Point(465, 280);
            unitsNumericUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            unitsNumericUpDown.Name = "unitsNumericUpDown";
            unitsNumericUpDown.Size = new System.Drawing.Size(63, 23);
            unitsNumericUpDown.TabIndex = 14;
            unitsNumericUpDown.ValueChanged += unitsNumericUpDown_ValueChanged;
            // 
            // tensLabel
            // 
            tensLabel.AutoSize = true;
            tensLabel.ForeColor = System.Drawing.Color.White;
            tensLabel.Location = new System.Drawing.Point(379, 252);
            tensLabel.Name = "tensLabel";
            tensLabel.Size = new System.Drawing.Size(34, 15);
            tensLabel.TabIndex = 13;
            tensLabel.Text = "TENS";
            // 
            // tensNumericUpDown
            // 
            tensNumericUpDown.Location = new System.Drawing.Point(365, 280);
            tensNumericUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            tensNumericUpDown.Name = "tensNumericUpDown";
            tensNumericUpDown.Size = new System.Drawing.Size(63, 23);
            tensNumericUpDown.TabIndex = 12;
            tensNumericUpDown.ValueChanged += tensNumericUpDown_ValueChanged;
            // 
            // hundredsLabel
            // 
            hundredsLabel.AutoSize = true;
            hundredsLabel.ForeColor = System.Drawing.Color.White;
            hundredsLabel.Location = new System.Drawing.Point(265, 252);
            hundredsLabel.Name = "hundredsLabel";
            hundredsLabel.Size = new System.Drawing.Size(68, 15);
            hundredsLabel.TabIndex = 11;
            hundredsLabel.Text = "HUNDREDS";
            // 
            // hundredsNumericUpDown
            // 
            hundredsNumericUpDown.Location = new System.Drawing.Point(265, 280);
            hundredsNumericUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            hundredsNumericUpDown.Name = "hundredsNumericUpDown";
            hundredsNumericUpDown.Size = new System.Drawing.Size(63, 23);
            hundredsNumericUpDown.TabIndex = 10;
            hundredsNumericUpDown.ValueChanged += hundredsNumericUpDown_ValueChanged;
            // 
            // thousandsLabel
            // 
            thousandsLabel.AutoSize = true;
            thousandsLabel.ForeColor = System.Drawing.Color.White;
            thousandsLabel.Location = new System.Drawing.Point(160, 252);
            thousandsLabel.Name = "thousandsLabel";
            thousandsLabel.Size = new System.Drawing.Size(76, 15);
            thousandsLabel.TabIndex = 9;
            thousandsLabel.Text = "THOUSANDS";
            // 
            // thousandsNumericUpDown
            // 
            thousandsNumericUpDown.Location = new System.Drawing.Point(165, 280);
            thousandsNumericUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            thousandsNumericUpDown.Name = "thousandsNumericUpDown";
            thousandsNumericUpDown.Size = new System.Drawing.Size(63, 23);
            thousandsNumericUpDown.TabIndex = 8;
            thousandsNumericUpDown.ValueChanged += thousandsNumericUpDown_ValueChanged;
            // 
            // scanGateLabel
            // 
            scanGateLabel.AutoSize = true;
            scanGateLabel.ForeColor = System.Drawing.Color.White;
            scanGateLabel.Location = new System.Drawing.Point(43, 252);
            scanGateLabel.Name = "scanGateLabel";
            scanGateLabel.Size = new System.Drawing.Size(68, 15);
            scanGateLabel.TabIndex = 7;
            scanGateLabel.Text = "SCAN GATE";
            // 
            // scanGateComboBox
            // 
            scanGateComboBox.AllowDrop = true;
            scanGateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            scanGateComboBox.FormattingEnabled = true;
            scanGateComboBox.Items.AddRange(new object[] { "OFF", "NO", "1ST", "2ND", "3RD" });
            scanGateComboBox.Location = new System.Drawing.Point(43, 280);
            scanGateComboBox.Name = "scanGateComboBox";
            scanGateComboBox.Size = new System.Drawing.Size(68, 23);
            scanGateComboBox.TabIndex = 6;
            scanGateComboBox.SelectedIndexChanged += scanGateComboBox_SelectedIndexChanged;
            // 
            // addrTransferLabel
            // 
            addrTransferLabel.ForeColor = System.Drawing.Color.White;
            addrTransferLabel.Location = new System.Drawing.Point(308, 91);
            addrTransferLabel.Name = "addrTransferLabel";
            addrTransferLabel.Size = new System.Drawing.Size(190, 74);
            addrTransferLabel.TabIndex = 5;
            addrTransferLabel.Text = "|                                          |  |_________________________|  TRANSFER ADDRESS TO   STORAGE ADDRESS REGISTER";
            addrTransferLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addrTransferButton
            // 
            addrTransferButton.Location = new System.Drawing.Point(457, 67);
            addrTransferButton.Name = "addrTransferButton";
            addrTransferButton.Size = new System.Drawing.Size(27, 23);
            addrTransferButton.TabIndex = 4;
            addrTransferButton.UseVisualStyleBackColor = true;
            addrTransferButton.Click += addrTransferButton_Click;
            // 
            // addrTransferComboBox
            // 
            addrTransferComboBox.AllowDrop = true;
            addrTransferComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            addrTransferComboBox.FormattingEnabled = true;
            addrTransferComboBox.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "I" });
            addrTransferComboBox.Location = new System.Drawing.Point(302, 68);
            addrTransferComboBox.Name = "addrTransferComboBox";
            addrTransferComboBox.Size = new System.Drawing.Size(68, 23);
            addrTransferComboBox.TabIndex = 3;
            addrTransferComboBox.SelectedIndexChanged += addrTransferComboBox_SelectedIndexChanged;
            // 
            // BCharSelLabel
            // 
            BCharSelLabel.AutoSize = true;
            BCharSelLabel.ForeColor = System.Drawing.Color.White;
            BCharSelLabel.Location = new System.Drawing.Point(153, 43);
            BCharSelLabel.Name = "BCharSelLabel";
            BCharSelLabel.Size = new System.Drawing.Size(90, 15);
            BCharSelLabel.TabIndex = 2;
            BCharSelLabel.Text = "B CH CHAR SEL";
            // 
            // BCharSelComboBox
            // 
            BCharSelComboBox.AllowDrop = true;
            BCharSelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            BCharSelComboBox.FormattingEnabled = true;
            BCharSelComboBox.Items.AddRange(new object[] { "NORMAL", "B0", "B1", "B2", "B3" });
            BCharSelComboBox.Location = new System.Drawing.Point(162, 68);
            BCharSelComboBox.Name = "BCharSelComboBox";
            BCharSelComboBox.Size = new System.Drawing.Size(66, 23);
            BCharSelComboBox.TabIndex = 1;
            // 
            // addrStopCheckBox
            // 
            addrStopCheckBox.AutoSize = true;
            addrStopCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            addrStopCheckBox.ForeColor = System.Drawing.Color.White;
            addrStopCheckBox.Location = new System.Drawing.Point(43, 43);
            addrStopCheckBox.Name = "addrStopCheckBox";
            addrStopCheckBox.Size = new System.Drawing.Size(72, 33);
            addrStopCheckBox.TabIndex = 0;
            addrStopCheckBox.Text = "ADDR STOP";
            addrStopCheckBox.UseVisualStyleBackColor = true;
            addrStopCheckBox.CheckedChanged += addrStopCheckBox_CheckedChanged;
            // 
            // priorityProcessingTab
            // 
            priorityProcessingTab.BackColor = System.Drawing.Color.DarkGray;
            priorityProcessingTab.Controls.Add(priorityProcessingButtonLabel);
            priorityProcessingTab.Controls.Add(priorityProcessingLabel);
            priorityProcessingTab.Controls.Add(priorityUnitSelectcomboBox);
            priorityProcessingTab.Location = new System.Drawing.Point(4, 24);
            priorityProcessingTab.Name = "priorityProcessingTab";
            priorityProcessingTab.Padding = new System.Windows.Forms.Padding(3);
            priorityProcessingTab.Size = new System.Drawing.Size(890, 469);
            priorityProcessingTab.TabIndex = 2;
            priorityProcessingTab.Text = "Priority Processing";
            // 
            // priorityProcessingButtonLabel
            // 
            priorityProcessingButtonLabel.BackColor = System.Drawing.Color.Gainsboro;
            priorityProcessingButtonLabel.Location = new System.Drawing.Point(153, 71);
            priorityProcessingButtonLabel.Name = "priorityProcessingButtonLabel";
            priorityProcessingButtonLabel.Size = new System.Drawing.Size(82, 53);
            priorityProcessingButtonLabel.TabIndex = 49;
            priorityProcessingButtonLabel.Text = "PRIORITY   ON";
            priorityProcessingButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            priorityProcessingButtonLabel.Click += priorityProcessingButtonLabel_Click;
            // 
            // priorityProcessingLabel
            // 
            priorityProcessingLabel.AutoSize = true;
            priorityProcessingLabel.ForeColor = System.Drawing.Color.White;
            priorityProcessingLabel.Location = new System.Drawing.Point(128, 198);
            priorityProcessingLabel.Name = "priorityProcessingLabel";
            priorityProcessingLabel.Size = new System.Drawing.Size(128, 15);
            priorityProcessingLabel.TabIndex = 48;
            priorityProcessingLabel.Text = "PRIORITY PROCESSING";
            // 
            // priorityUnitSelectcomboBox
            // 
            priorityUnitSelectcomboBox.AllowDrop = true;
            priorityUnitSelectcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            priorityUnitSelectcomboBox.FormattingEnabled = true;
            priorityUnitSelectcomboBox.Items.AddRange(new object[] { "OFF", "CARD READER", "PRINTER", "CARD PUNCH", "PAPER TAPE READER" });
            priorityUnitSelectcomboBox.Location = new System.Drawing.Point(118, 157);
            priorityUnitSelectcomboBox.Name = "priorityUnitSelectcomboBox";
            priorityUnitSelectcomboBox.Size = new System.Drawing.Size(150, 23);
            priorityUnitSelectcomboBox.TabIndex = 47;
            // 
            // IBM1410SwitchForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1054, 550);
            Controls.Add(tabControlSwitches);
            Name = "IBM1410SwitchForm";
            Text = "IBM1410SwitchForm";
            FormClosing += IBM1410SwitchForm_FormClosing;
            Load += IBM1410SwitchForm_Load;
            tabControlSwitches.ResumeLayout(false);
            consoleSwitchTab.ResumeLayout(false);
            consoleSwitchTab.PerformLayout();
            emergencyOffPanel.ResumeLayout(false);
            CESwitchTab.ResumeLayout(false);
            CESwitchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)unitsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tensNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)hundredsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)thousandsNumericUpDown).EndInit();
            priorityProcessingTab.ResumeLayout(false);
            priorityProcessingTab.PerformLayout();
            ResumeLayout(false);
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