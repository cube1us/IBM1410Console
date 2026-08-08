namespace IBM1410Console
{
    partial class IBM1410TapesForm
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
            labelRecordNumber = new System.Windows.Forms.Label();
            channelLabel = new System.Windows.Forms.Label();
            channelButton = new System.Windows.Forms.Button();
            unitDial = new System.Windows.Forms.NumericUpDown();
            selectLabel = new System.Windows.Forms.Label();
            readyLabel = new System.Windows.Forms.Label();
            loadButton = new System.Windows.Forms.Button();
            startButton = new System.Windows.Forms.Button();
            densityButton = new System.Windows.Forms.Button();
            densityLabel = new System.Windows.Forms.Label();
            unloadButton = new System.Windows.Forms.Button();
            protectLabel = new System.Windows.Forms.Label();
            resetButton = new System.Windows.Forms.Button();
            tapeIndicateLabel = new System.Windows.Forms.Label();
            mountButton = new System.Windows.Forms.Button();
            fileNameLabel = new System.Windows.Forms.Label();
            recordNumberLabel = new System.Windows.Forms.Label();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            labelDriveLightNumbers = new System.Windows.Forms.Label();
            labelDriveLightsCh1 = new System.Windows.Forms.Label();
            labelDriveLightsCh2 = new System.Windows.Forms.Label();
            labelDriveLight10 = new System.Windows.Forms.Label();
            labelDriveLight11 = new System.Windows.Forms.Label();
            labelDriveLight12 = new System.Windows.Forms.Label();
            labelDriveLight13 = new System.Windows.Forms.Label();
            labelDriveLight14 = new System.Windows.Forms.Label();
            labelDriveLight15 = new System.Windows.Forms.Label();
            labelDriveLight16 = new System.Windows.Forms.Label();
            labelDriveLight17 = new System.Windows.Forms.Label();
            labelDriveLight18 = new System.Windows.Forms.Label();
            labelDriveLight19 = new System.Windows.Forms.Label();
            labelDriveLight29 = new System.Windows.Forms.Label();
            labelDriveLight28 = new System.Windows.Forms.Label();
            labelDriveLight27 = new System.Windows.Forms.Label();
            labelDriveLight26 = new System.Windows.Forms.Label();
            labelDriveLight25 = new System.Windows.Forms.Label();
            labelDriveLight24 = new System.Windows.Forms.Label();
            labelDriveLight23 = new System.Windows.Forms.Label();
            labelDriveLight22 = new System.Windows.Forms.Label();
            labelDriveLight21 = new System.Windows.Forms.Label();
            labelDriveLight20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)unitDial).BeginInit();
            SuspendLayout();
            // 
            // labelRecordNumber
            // 
            labelRecordNumber.AutoSize = true;
            labelRecordNumber.Location = new System.Drawing.Point(15, 15);
            labelRecordNumber.Name = "labelRecordNumber";
            labelRecordNumber.Size = new System.Drawing.Size(47, 15);
            labelRecordNumber.TabIndex = 0;
            labelRecordNumber.Text = "Record:";
            // 
            // channelLabel
            // 
            channelLabel.AutoSize = true;
            channelLabel.Location = new System.Drawing.Point(172, 15);
            channelLabel.Name = "channelLabel";
            channelLabel.Size = new System.Drawing.Size(54, 15);
            channelLabel.TabIndex = 2;
            channelLabel.Text = "Channel:";
            // 
            // channelButton
            // 
            channelButton.Location = new System.Drawing.Point(232, 12);
            channelButton.Name = "channelButton";
            channelButton.Size = new System.Drawing.Size(37, 23);
            channelButton.TabIndex = 3;
            channelButton.Text = "1";
            channelButton.UseVisualStyleBackColor = true;
            channelButton.Click += channelButton_Click;
            // 
            // unitDial
            // 
            unitDial.Font = new System.Drawing.Font("Segoe UI", 18F);
            unitDial.Location = new System.Drawing.Point(26, 67);
            unitDial.Name = "unitDial";
            unitDial.ReadOnly = true;
            unitDial.Size = new System.Drawing.Size(36, 39);
            unitDial.TabIndex = 4;
            unitDial.ValueChanged += unitDial_ValueChanged;
            // 
            // selectLabel
            // 
            selectLabel.AutoSize = true;
            selectLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            selectLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            selectLabel.Location = new System.Drawing.Point(98, 52);
            selectLabel.Name = "selectLabel";
            selectLabel.Size = new System.Drawing.Size(42, 15);
            selectLabel.TabIndex = 5;
            selectLabel.Text = "Select";
            // 
            // readyLabel
            // 
            readyLabel.AutoSize = true;
            readyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            readyLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            readyLabel.Location = new System.Drawing.Point(167, 52);
            readyLabel.Name = "readyLabel";
            readyLabel.Size = new System.Drawing.Size(41, 15);
            readyLabel.TabIndex = 6;
            readyLabel.Text = "Ready";
            // 
            // loadButton
            // 
            loadButton.Location = new System.Drawing.Point(92, 79);
            loadButton.Name = "loadButton";
            loadButton.Size = new System.Drawing.Size(52, 27);
            loadButton.TabIndex = 7;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // startButton
            // 
            startButton.Location = new System.Drawing.Point(162, 79);
            startButton.Name = "startButton";
            startButton.Size = new System.Drawing.Size(52, 27);
            startButton.TabIndex = 8;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // densityButton
            // 
            densityButton.Location = new System.Drawing.Point(232, 79);
            densityButton.Name = "densityButton";
            densityButton.Size = new System.Drawing.Size(52, 27);
            densityButton.TabIndex = 10;
            densityButton.Text = "Dens.";
            densityButton.UseVisualStyleBackColor = true;
            densityButton.Click += densityButton_Click;
            // 
            // densityLabel
            // 
            densityLabel.AutoSize = true;
            densityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            densityLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            densityLabel.Location = new System.Drawing.Point(234, 52);
            densityLabel.Name = "densityLabel";
            densityLabel.Size = new System.Drawing.Size(45, 15);
            densityLabel.TabIndex = 9;
            densityLabel.Text = "Hi Den";
            // 
            // unloadButton
            // 
            unloadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            unloadButton.Location = new System.Drawing.Point(302, 79);
            unloadButton.Name = "unloadButton";
            unloadButton.Size = new System.Drawing.Size(52, 27);
            unloadButton.TabIndex = 12;
            unloadButton.Text = "Unload";
            unloadButton.UseVisualStyleBackColor = true;
            unloadButton.Click += unloadButton_Click;
            // 
            // protectLabel
            // 
            protectLabel.AutoSize = true;
            protectLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            protectLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            protectLabel.Location = new System.Drawing.Point(304, 52);
            protectLabel.Name = "protectLabel";
            protectLabel.Size = new System.Drawing.Size(49, 15);
            protectLabel.TabIndex = 11;
            protectLabel.Text = "Protect";
            // 
            // resetButton
            // 
            resetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resetButton.Location = new System.Drawing.Point(372, 79);
            resetButton.Name = "resetButton";
            resetButton.Size = new System.Drawing.Size(52, 27);
            resetButton.TabIndex = 14;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // tapeIndicateLabel
            // 
            tapeIndicateLabel.AutoSize = true;
            tapeIndicateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            tapeIndicateLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            tapeIndicateLabel.Location = new System.Drawing.Point(372, 52);
            tapeIndicateLabel.Name = "tapeIndicateLabel";
            tapeIndicateLabel.Size = new System.Drawing.Size(52, 15);
            tapeIndicateLabel.TabIndex = 13;
            tapeIndicateLabel.Text = "Indicate";
            // 
            // mountButton
            // 
            mountButton.Location = new System.Drawing.Point(26, 126);
            mountButton.Name = "mountButton";
            mountButton.Size = new System.Drawing.Size(61, 32);
            mountButton.TabIndex = 15;
            mountButton.Text = "Mount";
            mountButton.UseVisualStyleBackColor = true;
            mountButton.Click += mountButton_Click;
            // 
            // fileNameLabel
            // 
            fileNameLabel.Location = new System.Drawing.Point(98, 126);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(326, 32);
            fileNameLabel.TabIndex = 16;
            fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recordNumberLabel
            // 
            recordNumberLabel.Location = new System.Drawing.Point(68, 12);
            recordNumberLabel.Name = "recordNumberLabel";
            recordNumberLabel.Size = new System.Drawing.Size(100, 23);
            recordNumberLabel.TabIndex = 17;
            recordNumberLabel.Text = "0";
            recordNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // labelDriveLightNumbers
            // 
            labelDriveLightNumbers.AutoSize = true;
            labelDriveLightNumbers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelDriveLightNumbers.Location = new System.Drawing.Point(85, 176);
            labelDriveLightNumbers.Name = "labelDriveLightNumbers";
            labelDriveLightNumbers.Size = new System.Drawing.Size(320, 15);
            labelDriveLightNumbers.TabIndex = 18;
            labelDriveLightNumbers.Text = "0         1         2         3         4         5         6         7         8         9";
            // 
            // labelDriveLightsCh1
            // 
            labelDriveLightsCh1.AutoSize = true;
            labelDriveLightsCh1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelDriveLightsCh1.Location = new System.Drawing.Point(24, 200);
            labelDriveLightsCh1.Name = "labelDriveLightsCh1";
            labelDriveLightsCh1.Size = new System.Drawing.Size(33, 15);
            labelDriveLightsCh1.TabIndex = 19;
            labelDriveLightsCh1.Text = "CH 1";
            // 
            // labelDriveLightsCh2
            // 
            labelDriveLightsCh2.AutoSize = true;
            labelDriveLightsCh2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelDriveLightsCh2.Location = new System.Drawing.Point(24, 232);
            labelDriveLightsCh2.Name = "labelDriveLightsCh2";
            labelDriveLightsCh2.Size = new System.Drawing.Size(33, 15);
            labelDriveLightsCh2.TabIndex = 20;
            labelDriveLightsCh2.Text = "CH 2";
            // 
            // labelDriveLight10
            // 
            labelDriveLight10.AutoSize = true;
            labelDriveLight10.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight10.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight10.Location = new System.Drawing.Point(82, 199);
            labelDriveLight10.Name = "labelDriveLight10";
            labelDriveLight10.Size = new System.Drawing.Size(23, 28);
            labelDriveLight10.TabIndex = 21;
            labelDriveLight10.Text = "l";
            labelDriveLight10.UseCompatibleTextRendering = true;
            // 
            // labelDriveLight11
            // 
            labelDriveLight11.AutoSize = true;
            labelDriveLight11.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight11.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight11.Location = new System.Drawing.Point(114, 199);
            labelDriveLight11.Name = "labelDriveLight11";
            labelDriveLight11.Size = new System.Drawing.Size(25, 22);
            labelDriveLight11.TabIndex = 22;
            labelDriveLight11.Text = "l";
            // 
            // labelDriveLight12
            // 
            labelDriveLight12.AutoSize = true;
            labelDriveLight12.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight12.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight12.Location = new System.Drawing.Point(148, 199);
            labelDriveLight12.Name = "labelDriveLight12";
            labelDriveLight12.Size = new System.Drawing.Size(25, 22);
            labelDriveLight12.TabIndex = 23;
            labelDriveLight12.Text = "l";
            // 
            // labelDriveLight13
            // 
            labelDriveLight13.AutoSize = true;
            labelDriveLight13.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight13.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight13.Location = new System.Drawing.Point(183, 199);
            labelDriveLight13.Name = "labelDriveLight13";
            labelDriveLight13.Size = new System.Drawing.Size(25, 22);
            labelDriveLight13.TabIndex = 24;
            labelDriveLight13.Text = "l";
            // 
            // labelDriveLight14
            // 
            labelDriveLight14.AutoSize = true;
            labelDriveLight14.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight14.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight14.Location = new System.Drawing.Point(218, 199);
            labelDriveLight14.Name = "labelDriveLight14";
            labelDriveLight14.Size = new System.Drawing.Size(25, 22);
            labelDriveLight14.TabIndex = 25;
            labelDriveLight14.Text = "l";
            // 
            // labelDriveLight15
            // 
            labelDriveLight15.AutoSize = true;
            labelDriveLight15.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight15.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight15.Location = new System.Drawing.Point(252, 199);
            labelDriveLight15.Name = "labelDriveLight15";
            labelDriveLight15.Size = new System.Drawing.Size(25, 22);
            labelDriveLight15.TabIndex = 26;
            labelDriveLight15.Text = "l";
            // 
            // labelDriveLight16
            // 
            labelDriveLight16.AutoSize = true;
            labelDriveLight16.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight16.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight16.Location = new System.Drawing.Point(286, 199);
            labelDriveLight16.Name = "labelDriveLight16";
            labelDriveLight16.Size = new System.Drawing.Size(25, 22);
            labelDriveLight16.TabIndex = 27;
            labelDriveLight16.Text = "l";
            // 
            // labelDriveLight17
            // 
            labelDriveLight17.AutoSize = true;
            labelDriveLight17.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight17.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight17.Location = new System.Drawing.Point(320, 199);
            labelDriveLight17.Name = "labelDriveLight17";
            labelDriveLight17.Size = new System.Drawing.Size(25, 22);
            labelDriveLight17.TabIndex = 28;
            labelDriveLight17.Text = "l";
            // 
            // labelDriveLight18
            // 
            labelDriveLight18.AutoSize = true;
            labelDriveLight18.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight18.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight18.Location = new System.Drawing.Point(354, 199);
            labelDriveLight18.Name = "labelDriveLight18";
            labelDriveLight18.Size = new System.Drawing.Size(25, 22);
            labelDriveLight18.TabIndex = 29;
            labelDriveLight18.Text = "l";
            // 
            // labelDriveLight19
            // 
            labelDriveLight19.AutoSize = true;
            labelDriveLight19.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight19.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight19.Location = new System.Drawing.Point(388, 199);
            labelDriveLight19.Name = "labelDriveLight19";
            labelDriveLight19.Size = new System.Drawing.Size(25, 22);
            labelDriveLight19.TabIndex = 30;
            labelDriveLight19.Text = "l";
            // 
            // labelDriveLight29
            // 
            labelDriveLight29.AutoSize = true;
            labelDriveLight29.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight29.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight29.Location = new System.Drawing.Point(388, 228);
            labelDriveLight29.Name = "labelDriveLight29";
            labelDriveLight29.Size = new System.Drawing.Size(25, 22);
            labelDriveLight29.TabIndex = 40;
            labelDriveLight29.Text = "l";
            // 
            // labelDriveLight28
            // 
            labelDriveLight28.AutoSize = true;
            labelDriveLight28.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight28.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight28.Location = new System.Drawing.Point(354, 228);
            labelDriveLight28.Name = "labelDriveLight28";
            labelDriveLight28.Size = new System.Drawing.Size(25, 22);
            labelDriveLight28.TabIndex = 39;
            labelDriveLight28.Text = "l";
            // 
            // labelDriveLight27
            // 
            labelDriveLight27.AutoSize = true;
            labelDriveLight27.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight27.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight27.Location = new System.Drawing.Point(320, 228);
            labelDriveLight27.Name = "labelDriveLight27";
            labelDriveLight27.Size = new System.Drawing.Size(25, 22);
            labelDriveLight27.TabIndex = 38;
            labelDriveLight27.Text = "l";
            // 
            // labelDriveLight26
            // 
            labelDriveLight26.AutoSize = true;
            labelDriveLight26.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight26.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight26.Location = new System.Drawing.Point(286, 228);
            labelDriveLight26.Name = "labelDriveLight26";
            labelDriveLight26.Size = new System.Drawing.Size(25, 22);
            labelDriveLight26.TabIndex = 37;
            labelDriveLight26.Text = "l";
            // 
            // labelDriveLight25
            // 
            labelDriveLight25.AutoSize = true;
            labelDriveLight25.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight25.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight25.Location = new System.Drawing.Point(252, 228);
            labelDriveLight25.Name = "labelDriveLight25";
            labelDriveLight25.Size = new System.Drawing.Size(25, 22);
            labelDriveLight25.TabIndex = 36;
            labelDriveLight25.Text = "l";
            // 
            // labelDriveLight24
            // 
            labelDriveLight24.AutoSize = true;
            labelDriveLight24.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight24.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight24.Location = new System.Drawing.Point(218, 228);
            labelDriveLight24.Name = "labelDriveLight24";
            labelDriveLight24.Size = new System.Drawing.Size(25, 22);
            labelDriveLight24.TabIndex = 35;
            labelDriveLight24.Text = "l";
            // 
            // labelDriveLight23
            // 
            labelDriveLight23.AutoSize = true;
            labelDriveLight23.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight23.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight23.Location = new System.Drawing.Point(183, 228);
            labelDriveLight23.Name = "labelDriveLight23";
            labelDriveLight23.Size = new System.Drawing.Size(25, 22);
            labelDriveLight23.TabIndex = 34;
            labelDriveLight23.Text = "l";
            // 
            // labelDriveLight22
            // 
            labelDriveLight22.AutoSize = true;
            labelDriveLight22.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight22.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight22.Location = new System.Drawing.Point(148, 228);
            labelDriveLight22.Name = "labelDriveLight22";
            labelDriveLight22.Size = new System.Drawing.Size(25, 22);
            labelDriveLight22.TabIndex = 33;
            labelDriveLight22.Text = "l";
            // 
            // labelDriveLight21
            // 
            labelDriveLight21.AutoSize = true;
            labelDriveLight21.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight21.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight21.Location = new System.Drawing.Point(114, 228);
            labelDriveLight21.Name = "labelDriveLight21";
            labelDriveLight21.Size = new System.Drawing.Size(25, 22);
            labelDriveLight21.TabIndex = 32;
            labelDriveLight21.Text = "l";
            // 
            // labelDriveLight20
            // 
            labelDriveLight20.AutoSize = true;
            labelDriveLight20.Font = new System.Drawing.Font("Wingdings", 15F);
            labelDriveLight20.ForeColor = System.Drawing.Color.DarkGray;
            labelDriveLight20.Location = new System.Drawing.Point(81, 228);
            labelDriveLight20.Name = "labelDriveLight20";
            labelDriveLight20.Size = new System.Drawing.Size(25, 22);
            labelDriveLight20.TabIndex = 31;
            labelDriveLight20.Text = "l";
            // 
            // IBM1410TapesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(449, 271);
            Controls.Add(labelDriveLight29);
            Controls.Add(labelDriveLight28);
            Controls.Add(labelDriveLight27);
            Controls.Add(labelDriveLight26);
            Controls.Add(labelDriveLight25);
            Controls.Add(labelDriveLight24);
            Controls.Add(labelDriveLight23);
            Controls.Add(labelDriveLight22);
            Controls.Add(labelDriveLight21);
            Controls.Add(labelDriveLight20);
            Controls.Add(labelDriveLight19);
            Controls.Add(labelDriveLight18);
            Controls.Add(labelDriveLight17);
            Controls.Add(labelDriveLight16);
            Controls.Add(labelDriveLight15);
            Controls.Add(labelDriveLight14);
            Controls.Add(labelDriveLight13);
            Controls.Add(labelDriveLight12);
            Controls.Add(labelDriveLight11);
            Controls.Add(labelDriveLight10);
            Controls.Add(labelDriveLightsCh2);
            Controls.Add(labelDriveLightsCh1);
            Controls.Add(labelDriveLightNumbers);
            Controls.Add(recordNumberLabel);
            Controls.Add(fileNameLabel);
            Controls.Add(mountButton);
            Controls.Add(resetButton);
            Controls.Add(tapeIndicateLabel);
            Controls.Add(unloadButton);
            Controls.Add(protectLabel);
            Controls.Add(densityButton);
            Controls.Add(densityLabel);
            Controls.Add(startButton);
            Controls.Add(loadButton);
            Controls.Add(readyLabel);
            Controls.Add(selectLabel);
            Controls.Add(unitDial);
            Controls.Add(channelButton);
            Controls.Add(channelLabel);
            Controls.Add(labelRecordNumber);
            Name = "IBM1410TapesForm";
            Text = "IBM1410Tapes";
            FormClosing += IBM1410TapesForm_FormClosing;
            Load += IBM1410TapesForm_Load;
            ((System.ComponentModel.ISupportInitialize)unitDial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelRecordNumber;
        private System.Windows.Forms.Label channelLabel;
        private System.Windows.Forms.Button channelButton;
        private System.Windows.Forms.NumericUpDown unitDial;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.Label readyLabel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button densityButton;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.Button unloadButton;
        private System.Windows.Forms.Label protectLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label tapeIndicateLabel;
        private System.Windows.Forms.Button mountButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label recordNumberLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelDriveLightNumbers;
        private System.Windows.Forms.Label labelDriveLightsCh1;
        private System.Windows.Forms.Label labelDriveLightsCh2;
        private System.Windows.Forms.Label labelDriveLight10;
        private System.Windows.Forms.Label labelDriveLight11;
        private System.Windows.Forms.Label labelDriveLight12;
        private System.Windows.Forms.Label labelDriveLight13;
        private System.Windows.Forms.Label labelDriveLight14;
        private System.Windows.Forms.Label labelDriveLight15;
        private System.Windows.Forms.Label labelDriveLight16;
        private System.Windows.Forms.Label labelDriveLight17;
        private System.Windows.Forms.Label labelDriveLight18;
        private System.Windows.Forms.Label labelDriveLight19;
        private System.Windows.Forms.Label labelDriveLight29;
        private System.Windows.Forms.Label labelDriveLight28;
        private System.Windows.Forms.Label labelDriveLight27;
        private System.Windows.Forms.Label labelDriveLight26;
        private System.Windows.Forms.Label labelDriveLight25;
        private System.Windows.Forms.Label labelDriveLight24;
        private System.Windows.Forms.Label labelDriveLight23;
        private System.Windows.Forms.Label labelDriveLight22;
        private System.Windows.Forms.Label labelDriveLight21;
        private System.Windows.Forms.Label labelDriveLight20;
    }
}