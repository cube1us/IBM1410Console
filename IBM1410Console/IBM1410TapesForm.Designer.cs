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
            unitDial.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            selectLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            readyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            densityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            protectLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            tapeIndicateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            mountButton.Click += this.mountButton_Click;
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
            // IBM1410TapesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(449, 176);
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
    }
}