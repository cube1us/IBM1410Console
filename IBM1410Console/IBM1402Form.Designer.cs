namespace IBM1410Console
{
    partial class IBM1402Form
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
            punchStartButton = new System.Windows.Forms.Button();
            punchStopButton = new System.Windows.Forms.Button();
            readerStartButton = new System.Windows.Forms.Button();
            readerStopButton = new System.Windows.Forms.Button();
            readerEOFButton = new System.Windows.Forms.Button();
            labelPunchCheck = new System.Windows.Forms.Label();
            labelPunchReady = new System.Windows.Forms.Label();
            labelPunchStop = new System.Windows.Forms.Label();
            labelChips = new System.Windows.Forms.Label();
            labelStacker = new System.Windows.Forms.Label();
            labelPower = new System.Windows.Forms.Label();
            labelValidity = new System.Windows.Forms.Label();
            labelReaderReady = new System.Windows.Forms.Label();
            labelReaderCheck = new System.Windows.Forms.Label();
            labelFuse = new System.Windows.Forms.Label();
            labelTransport = new System.Windows.Forms.Label();
            labelReaderStop = new System.Windows.Forms.Label();
            loadButton = new System.Windows.Forms.Button();
            hoppersButton = new System.Windows.Forms.Button();
            punch0PocketCountLabel = new System.Windows.Forms.Label();
            punch4PocketCountLabel = new System.Windows.Forms.Label();
            pocket82CountLabel = new System.Windows.Forms.Label();
            reader1PocketLabel = new System.Windows.Forms.Label();
            reader0PocketCountLabel = new System.Windows.Forms.Label();
            readerOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            SuspendLayout();
            // 
            // punchStartButton
            // 
            punchStartButton.BackColor = System.Drawing.Color.SeaGreen;
            punchStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            punchStartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            punchStartButton.Location = new System.Drawing.Point(12, 49);
            punchStartButton.Name = "punchStartButton";
            punchStartButton.Size = new System.Drawing.Size(82, 53);
            punchStartButton.TabIndex = 44;
            punchStartButton.Text = "START";
            punchStartButton.UseVisualStyleBackColor = false;
            // 
            // punchStopButton
            // 
            punchStopButton.BackColor = System.Drawing.Color.Crimson;
            punchStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            punchStopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            punchStopButton.Location = new System.Drawing.Point(100, 49);
            punchStopButton.Name = "punchStopButton";
            punchStopButton.Size = new System.Drawing.Size(82, 53);
            punchStopButton.TabIndex = 45;
            punchStopButton.Text = "STOP";
            punchStopButton.UseVisualStyleBackColor = false;
            // 
            // readerStartButton
            // 
            readerStartButton.BackColor = System.Drawing.Color.SeaGreen;
            readerStartButton.Enabled = false;
            readerStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            readerStartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            readerStartButton.Location = new System.Drawing.Point(782, 49);
            readerStartButton.Name = "readerStartButton";
            readerStartButton.Size = new System.Drawing.Size(82, 53);
            readerStartButton.TabIndex = 46;
            readerStartButton.Text = "START";
            readerStartButton.UseVisualStyleBackColor = false;
            readerStartButton.Click += readerStartButton_Click;
            // 
            // readerStopButton
            // 
            readerStopButton.BackColor = System.Drawing.Color.Crimson;
            readerStopButton.Enabled = false;
            readerStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            readerStopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            readerStopButton.Location = new System.Drawing.Point(694, 49);
            readerStopButton.Name = "readerStopButton";
            readerStopButton.Size = new System.Drawing.Size(82, 53);
            readerStopButton.TabIndex = 47;
            readerStopButton.Text = "STOP";
            readerStopButton.UseVisualStyleBackColor = false;
            readerStopButton.Click += readerStopButton_Click;
            // 
            // readerEOFButton
            // 
            readerEOFButton.BackColor = System.Drawing.Color.SeaGreen;
            readerEOFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            readerEOFButton.ForeColor = System.Drawing.SystemColors.ControlText;
            readerEOFButton.Location = new System.Drawing.Point(606, 49);
            readerEOFButton.Name = "readerEOFButton";
            readerEOFButton.Size = new System.Drawing.Size(82, 53);
            readerEOFButton.TabIndex = 48;
            readerEOFButton.Text = "EOF";
            readerEOFButton.UseVisualStyleBackColor = false;
            readerEOFButton.Click += readerEOFButton_Click;
            // 
            // labelPunchCheck
            // 
            labelPunchCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelPunchCheck.ForeColor = System.Drawing.Color.DimGray;
            labelPunchCheck.Location = new System.Drawing.Point(188, 56);
            labelPunchCheck.Name = "labelPunchCheck";
            labelPunchCheck.Size = new System.Drawing.Size(57, 37);
            labelPunchCheck.TabIndex = 49;
            labelPunchCheck.Text = "PUNCH CHECK";
            labelPunchCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPunchReady
            // 
            labelPunchReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelPunchReady.ForeColor = System.Drawing.Color.DimGray;
            labelPunchReady.Location = new System.Drawing.Point(188, 9);
            labelPunchReady.Name = "labelPunchReady";
            labelPunchReady.Size = new System.Drawing.Size(57, 37);
            labelPunchReady.TabIndex = 50;
            labelPunchReady.Text = "PUNCH READY";
            labelPunchReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPunchStop
            // 
            labelPunchStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelPunchStop.ForeColor = System.Drawing.Color.DimGray;
            labelPunchStop.Location = new System.Drawing.Point(188, 108);
            labelPunchStop.Name = "labelPunchStop";
            labelPunchStop.Size = new System.Drawing.Size(57, 35);
            labelPunchStop.TabIndex = 51;
            labelPunchStop.Text = "PUNCH STOP";
            labelPunchStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChips
            // 
            labelChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelChips.ForeColor = System.Drawing.Color.DimGray;
            labelChips.Location = new System.Drawing.Point(251, 9);
            labelChips.Name = "labelChips";
            labelChips.Size = new System.Drawing.Size(57, 37);
            labelChips.TabIndex = 52;
            labelChips.Text = "CHIPS";
            labelChips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStacker
            // 
            labelStacker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelStacker.ForeColor = System.Drawing.Color.DimGray;
            labelStacker.Location = new System.Drawing.Point(314, 9);
            labelStacker.Name = "labelStacker";
            labelStacker.Size = new System.Drawing.Size(73, 37);
            labelStacker.TabIndex = 53;
            labelStacker.Text = "STACKER";
            labelStacker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPower
            // 
            labelPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelPower.ForeColor = System.Drawing.Color.DimGray;
            labelPower.Location = new System.Drawing.Point(393, 9);
            labelPower.Name = "labelPower";
            labelPower.Size = new System.Drawing.Size(57, 37);
            labelPower.TabIndex = 54;
            labelPower.Text = "POWER";
            labelPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelValidity
            // 
            labelValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelValidity.ForeColor = System.Drawing.Color.DimGray;
            labelValidity.Location = new System.Drawing.Point(456, 9);
            labelValidity.Name = "labelValidity";
            labelValidity.Size = new System.Drawing.Size(73, 37);
            labelValidity.TabIndex = 55;
            labelValidity.Text = "VALIDITY";
            labelValidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReaderReady
            // 
            labelReaderReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelReaderReady.ForeColor = System.Drawing.Color.DimGray;
            labelReaderReady.Location = new System.Drawing.Point(535, 9);
            labelReaderReady.Name = "labelReaderReady";
            labelReaderReady.Size = new System.Drawing.Size(65, 37);
            labelReaderReady.TabIndex = 56;
            labelReaderReady.Text = "READER READY";
            labelReaderReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReaderCheck
            // 
            labelReaderCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelReaderCheck.ForeColor = System.Drawing.Color.DimGray;
            labelReaderCheck.Location = new System.Drawing.Point(535, 56);
            labelReaderCheck.Name = "labelReaderCheck";
            labelReaderCheck.Size = new System.Drawing.Size(65, 37);
            labelReaderCheck.TabIndex = 57;
            labelReaderCheck.Text = "READER CHECK";
            labelReaderCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFuse
            // 
            labelFuse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelFuse.ForeColor = System.Drawing.Color.DimGray;
            labelFuse.Location = new System.Drawing.Point(322, 56);
            labelFuse.Name = "labelFuse";
            labelFuse.Size = new System.Drawing.Size(57, 37);
            labelFuse.TabIndex = 58;
            labelFuse.Text = "FUSE";
            labelFuse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTransport
            // 
            labelTransport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelTransport.ForeColor = System.Drawing.Color.DimGray;
            labelTransport.Location = new System.Drawing.Point(377, 56);
            labelTransport.Name = "labelTransport";
            labelTransport.Size = new System.Drawing.Size(90, 37);
            labelTransport.TabIndex = 59;
            labelTransport.Text = "TRANSPORT";
            labelTransport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelReaderStop
            // 
            labelReaderStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelReaderStop.ForeColor = System.Drawing.Color.DimGray;
            labelReaderStop.Location = new System.Drawing.Point(535, 106);
            labelReaderStop.Name = "labelReaderStop";
            labelReaderStop.Size = new System.Drawing.Size(65, 37);
            labelReaderStop.TabIndex = 60;
            labelReaderStop.Text = "READER STOP";
            labelReaderStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadButton
            // 
            loadButton.BackColor = System.Drawing.SystemColors.ControlLight;
            loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            loadButton.Location = new System.Drawing.Point(782, 108);
            loadButton.Name = "loadButton";
            loadButton.Size = new System.Drawing.Size(82, 43);
            loadButton.TabIndex = 61;
            loadButton.Text = "Load...";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // hoppersButton
            // 
            hoppersButton.BackColor = System.Drawing.SystemColors.ControlLight;
            hoppersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            hoppersButton.Location = new System.Drawing.Point(355, 108);
            hoppersButton.Name = "hoppersButton";
            hoppersButton.Size = new System.Drawing.Size(112, 43);
            hoppersButton.TabIndex = 62;
            hoppersButton.Text = "Hoppers...";
            hoppersButton.UseVisualStyleBackColor = false;
            // 
            // punch0PocketCountLabel
            // 
            punch0PocketCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            punch0PocketCountLabel.ForeColor = System.Drawing.Color.DimGray;
            punch0PocketCountLabel.Location = new System.Drawing.Point(12, 163);
            punch0PocketCountLabel.Name = "punch0PocketCountLabel";
            punch0PocketCountLabel.Size = new System.Drawing.Size(94, 37);
            punch0PocketCountLabel.TabIndex = 63;
            punch0PocketCountLabel.Text = "0: #####";
            punch0PocketCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // punch4PocketCountLabel
            // 
            punch4PocketCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            punch4PocketCountLabel.ForeColor = System.Drawing.Color.DimGray;
            punch4PocketCountLabel.Location = new System.Drawing.Point(201, 163);
            punch4PocketCountLabel.Name = "punch4PocketCountLabel";
            punch4PocketCountLabel.Size = new System.Drawing.Size(94, 37);
            punch4PocketCountLabel.TabIndex = 64;
            punch4PocketCountLabel.Text = "4: #####";
            punch4PocketCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pocket82CountLabel
            // 
            pocket82CountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            pocket82CountLabel.ForeColor = System.Drawing.Color.DimGray;
            pocket82CountLabel.Location = new System.Drawing.Point(390, 163);
            pocket82CountLabel.Name = "pocket82CountLabel";
            pocket82CountLabel.Size = new System.Drawing.Size(94, 37);
            pocket82CountLabel.TabIndex = 65;
            pocket82CountLabel.Text = "8/2: #####";
            pocket82CountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reader1PocketLabel
            // 
            reader1PocketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            reader1PocketLabel.ForeColor = System.Drawing.Color.DimGray;
            reader1PocketLabel.Location = new System.Drawing.Point(579, 163);
            reader1PocketLabel.Name = "reader1PocketLabel";
            reader1PocketLabel.Size = new System.Drawing.Size(94, 37);
            reader1PocketLabel.TabIndex = 66;
            reader1PocketLabel.Text = "1: #####";
            reader1PocketLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reader0PocketCountLabel
            // 
            reader0PocketCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            reader0PocketCountLabel.ForeColor = System.Drawing.Color.DimGray;
            reader0PocketCountLabel.Location = new System.Drawing.Point(768, 163);
            reader0PocketCountLabel.Name = "reader0PocketCountLabel";
            reader0PocketCountLabel.Size = new System.Drawing.Size(94, 37);
            reader0PocketCountLabel.TabIndex = 67;
            reader0PocketCountLabel.Text = "0: #####";
            reader0PocketCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // readerOpenFileDialog
            // 
            readerOpenFileDialog.FileName = "readerFile";
            // 
            // IBM1402Form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(876, 217);
            Controls.Add(reader0PocketCountLabel);
            Controls.Add(reader1PocketLabel);
            Controls.Add(pocket82CountLabel);
            Controls.Add(punch4PocketCountLabel);
            Controls.Add(punch0PocketCountLabel);
            Controls.Add(hoppersButton);
            Controls.Add(loadButton);
            Controls.Add(labelReaderStop);
            Controls.Add(labelTransport);
            Controls.Add(labelFuse);
            Controls.Add(labelReaderCheck);
            Controls.Add(labelReaderReady);
            Controls.Add(labelValidity);
            Controls.Add(labelPower);
            Controls.Add(labelStacker);
            Controls.Add(labelChips);
            Controls.Add(labelPunchStop);
            Controls.Add(labelPunchReady);
            Controls.Add(labelPunchCheck);
            Controls.Add(readerEOFButton);
            Controls.Add(readerStopButton);
            Controls.Add(readerStartButton);
            Controls.Add(punchStopButton);
            Controls.Add(punchStartButton);
            Name = "IBM1402Form";
            Text = "IBM1402Form";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button punchStartButton;
        private System.Windows.Forms.Button punchStopButton;
        private System.Windows.Forms.Button readerStartButton;
        private System.Windows.Forms.Button readerStopButton;
        private System.Windows.Forms.Button readerEOFButton;
        private System.Windows.Forms.Label labelPunchCheck;
        private System.Windows.Forms.Label labelPunchReady;
        private System.Windows.Forms.Label labelPunchStop;
        private System.Windows.Forms.Label labelChips;
        private System.Windows.Forms.Label labelStacker;
        private System.Windows.Forms.Label labelPower;
        private System.Windows.Forms.Label labelValidity;
        private System.Windows.Forms.Label labelReaderReady;
        private System.Windows.Forms.Label labelReaderCheck;
        private System.Windows.Forms.Label labelFuse;
        private System.Windows.Forms.Label labelTransport;
        private System.Windows.Forms.Label labelReaderStop;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button hoppersButton;
        private System.Windows.Forms.Label punch0PocketCountLabel;
        private System.Windows.Forms.Label punch4PocketCountLabel;
        private System.Windows.Forms.Label pocket82CountLabel;
        private System.Windows.Forms.Label reader1PocketLabel;
        private System.Windows.Forms.Label reader0PocketCountLabel;
        private System.Windows.Forms.OpenFileDialog readerOpenFileDialog;
    }
}