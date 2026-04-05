namespace IBM1410Console
{
    partial class IBM1403Form
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
            printerStartButton = new System.Windows.Forms.Button();
            printerCheckResetButton = new System.Windows.Forms.Button();
            printerStopButton = new System.Windows.Forms.Button();
            printerCarriageSpaceButton = new System.Windows.Forms.Button();
            printerCarriageRestoreButton = new System.Windows.Forms.Button();
            printerSingleCycleButton = new System.Windows.Forms.Button();
            labelPrintReady = new System.Windows.Forms.Label();
            labelPrintCheck = new System.Windows.Forms.Label();
            labelEndOfForms = new System.Windows.Forms.Label();
            labelFormsCheck = new System.Windows.Forms.Label();
            labelSyncCheck = new System.Windows.Forms.Label();
            carriageStopButton = new System.Windows.Forms.Button();
            printerRichTextBox1 = new System.Windows.Forms.RichTextBox();
            carriageTapeButton = new System.Windows.Forms.Button();
            printerClearButton = new System.Windows.Forms.Button();
            printerSaveButton = new System.Windows.Forms.Button();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            SuspendLayout();
            // 
            // printerStartButton
            // 
            printerStartButton.BackColor = System.Drawing.Color.SeaGreen;
            printerStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerStartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            printerStartButton.Location = new System.Drawing.Point(12, 12);
            printerStartButton.Name = "printerStartButton";
            printerStartButton.Size = new System.Drawing.Size(82, 53);
            printerStartButton.TabIndex = 45;
            printerStartButton.Text = "PRINT START";
            printerStartButton.UseVisualStyleBackColor = false;
            printerStartButton.Click += printerStartButton_Click;
            // 
            // printerCheckResetButton
            // 
            printerCheckResetButton.BackColor = System.Drawing.Color.LemonChiffon;
            printerCheckResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerCheckResetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            printerCheckResetButton.Location = new System.Drawing.Point(100, 12);
            printerCheckResetButton.Name = "printerCheckResetButton";
            printerCheckResetButton.Size = new System.Drawing.Size(82, 53);
            printerCheckResetButton.TabIndex = 49;
            printerCheckResetButton.Text = "CHECK RESET";
            printerCheckResetButton.UseVisualStyleBackColor = false;
            // 
            // printerStopButton
            // 
            printerStopButton.BackColor = System.Drawing.Color.Crimson;
            printerStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerStopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            printerStopButton.Location = new System.Drawing.Point(188, 12);
            printerStopButton.Name = "printerStopButton";
            printerStopButton.Size = new System.Drawing.Size(82, 53);
            printerStopButton.TabIndex = 50;
            printerStopButton.Text = "PRINT STOP";
            printerStopButton.UseVisualStyleBackColor = false;
            printerStopButton.Click += printerStopButton_Click;
            // 
            // printerCarriageSpaceButton
            // 
            printerCarriageSpaceButton.BackColor = System.Drawing.Color.Ivory;
            printerCarriageSpaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerCarriageSpaceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            printerCarriageSpaceButton.Location = new System.Drawing.Point(12, 71);
            printerCarriageSpaceButton.Name = "printerCarriageSpaceButton";
            printerCarriageSpaceButton.Size = new System.Drawing.Size(82, 53);
            printerCarriageSpaceButton.TabIndex = 51;
            printerCarriageSpaceButton.Text = "CARRIAGE SPACE";
            printerCarriageSpaceButton.UseVisualStyleBackColor = false;
            // 
            // printerCarriageRestoreButton
            // 
            printerCarriageRestoreButton.BackColor = System.Drawing.Color.Ivory;
            printerCarriageRestoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerCarriageRestoreButton.ForeColor = System.Drawing.SystemColors.ControlText;
            printerCarriageRestoreButton.Location = new System.Drawing.Point(100, 71);
            printerCarriageRestoreButton.Name = "printerCarriageRestoreButton";
            printerCarriageRestoreButton.Size = new System.Drawing.Size(82, 53);
            printerCarriageRestoreButton.TabIndex = 52;
            printerCarriageRestoreButton.Text = "CARRIAGE RESTORE";
            printerCarriageRestoreButton.UseVisualStyleBackColor = false;
            // 
            // printerSingleCycleButton
            // 
            printerSingleCycleButton.BackColor = System.Drawing.Color.Ivory;
            printerSingleCycleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerSingleCycleButton.ForeColor = System.Drawing.SystemColors.ControlText;
            printerSingleCycleButton.Location = new System.Drawing.Point(188, 71);
            printerSingleCycleButton.Name = "printerSingleCycleButton";
            printerSingleCycleButton.Size = new System.Drawing.Size(82, 53);
            printerSingleCycleButton.TabIndex = 53;
            printerSingleCycleButton.Text = "SINGLE CYCLE";
            printerSingleCycleButton.UseVisualStyleBackColor = false;
            // 
            // labelPrintReady
            // 
            labelPrintReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelPrintReady.ForeColor = System.Drawing.Color.DimGray;
            labelPrintReady.Location = new System.Drawing.Point(294, 20);
            labelPrintReady.Name = "labelPrintReady";
            labelPrintReady.Size = new System.Drawing.Size(57, 37);
            labelPrintReady.TabIndex = 54;
            labelPrintReady.Text = "PRINT READY";
            labelPrintReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrintCheck
            // 
            labelPrintCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelPrintCheck.ForeColor = System.Drawing.Color.DimGray;
            labelPrintCheck.Location = new System.Drawing.Point(370, 20);
            labelPrintCheck.Name = "labelPrintCheck";
            labelPrintCheck.Size = new System.Drawing.Size(57, 37);
            labelPrintCheck.TabIndex = 55;
            labelPrintCheck.Text = "PRINT CHECK";
            labelPrintCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEndOfForms
            // 
            labelEndOfForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelEndOfForms.ForeColor = System.Drawing.Color.DimGray;
            labelEndOfForms.Location = new System.Drawing.Point(294, 78);
            labelEndOfForms.Name = "labelEndOfForms";
            labelEndOfForms.Size = new System.Drawing.Size(67, 37);
            labelEndOfForms.TabIndex = 56;
            labelEndOfForms.Text = "END OF FORMS";
            labelEndOfForms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFormsCheck
            // 
            labelFormsCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelFormsCheck.ForeColor = System.Drawing.Color.DimGray;
            labelFormsCheck.Location = new System.Drawing.Point(294, 138);
            labelFormsCheck.Name = "labelFormsCheck";
            labelFormsCheck.Size = new System.Drawing.Size(57, 37);
            labelFormsCheck.TabIndex = 57;
            labelFormsCheck.Text = "PRINT READY";
            labelFormsCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSyncCheck
            // 
            labelSyncCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            labelSyncCheck.ForeColor = System.Drawing.Color.DimGray;
            labelSyncCheck.Location = new System.Drawing.Point(370, 138);
            labelSyncCheck.Name = "labelSyncCheck";
            labelSyncCheck.Size = new System.Drawing.Size(57, 37);
            labelSyncCheck.TabIndex = 58;
            labelSyncCheck.Text = "SYNC CHECK";
            labelSyncCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // carriageStopButton
            // 
            carriageStopButton.BackColor = System.Drawing.Color.Crimson;
            carriageStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            carriageStopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            carriageStopButton.Location = new System.Drawing.Point(370, 225);
            carriageStopButton.Name = "carriageStopButton";
            carriageStopButton.Size = new System.Drawing.Size(83, 53);
            carriageStopButton.TabIndex = 59;
            carriageStopButton.Text = "CARRIAGE STOP";
            carriageStopButton.UseVisualStyleBackColor = false;
            carriageStopButton.Click += carriageStopButton_Click;
            // 
            // printerRichTextBox1
            // 
            printerRichTextBox1.Location = new System.Drawing.Point(472, 29);
            printerRichTextBox1.Name = "printerRichTextBox1";
            printerRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            printerRichTextBox1.Size = new System.Drawing.Size(773, 426);
            printerRichTextBox1.TabIndex = 60;
            printerRichTextBox1.Text = "";
            printerRichTextBox1.WordWrap = false;
            // 
            // carriageTapeButton
            // 
            carriageTapeButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            carriageTapeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            carriageTapeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            carriageTapeButton.Location = new System.Drawing.Point(12, 390);
            carriageTapeButton.Name = "carriageTapeButton";
            carriageTapeButton.Size = new System.Drawing.Size(123, 48);
            carriageTapeButton.TabIndex = 61;
            carriageTapeButton.Text = "Carriage Tape...";
            carriageTapeButton.UseVisualStyleBackColor = false;
            // 
            // printerClearButton
            // 
            printerClearButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            printerClearButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerClearButton.Location = new System.Drawing.Point(141, 390);
            printerClearButton.Name = "printerClearButton";
            printerClearButton.Size = new System.Drawing.Size(110, 48);
            printerClearButton.TabIndex = 62;
            printerClearButton.Text = "Clear";
            printerClearButton.UseVisualStyleBackColor = false;
            printerClearButton.Click += printerClearButton_Click;
            // 
            // printerSaveButton
            // 
            printerSaveButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            printerSaveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            printerSaveButton.Location = new System.Drawing.Point(257, 390);
            printerSaveButton.Name = "printerSaveButton";
            printerSaveButton.Size = new System.Drawing.Size(110, 48);
            printerSaveButton.TabIndex = 63;
            printerSaveButton.Text = "Save...";
            printerSaveButton.UseVisualStyleBackColor = false;
            printerSaveButton.Click += printerSaveButton_Click;
            // 
            // IBM1403Form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1257, 510);
            Controls.Add(printerSaveButton);
            Controls.Add(printerClearButton);
            Controls.Add(carriageTapeButton);
            Controls.Add(printerRichTextBox1);
            Controls.Add(carriageStopButton);
            Controls.Add(labelSyncCheck);
            Controls.Add(labelFormsCheck);
            Controls.Add(labelEndOfForms);
            Controls.Add(labelPrintCheck);
            Controls.Add(labelPrintReady);
            Controls.Add(printerSingleCycleButton);
            Controls.Add(printerCarriageRestoreButton);
            Controls.Add(printerCarriageSpaceButton);
            Controls.Add(printerStopButton);
            Controls.Add(printerCheckResetButton);
            Controls.Add(printerStartButton);
            Name = "IBM1403Form";
            Text = "IBM1403Form";
            FormClosing += IBM1403Form_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button printerStartButton;
        private System.Windows.Forms.Button printerCheckResetButton;
        private System.Windows.Forms.Button printerStopButton;
        private System.Windows.Forms.Button printerCarriageSpaceButton;
        private System.Windows.Forms.Button printerCarriageRestoreButton;
        private System.Windows.Forms.Button printerSingleCycleButton;
        private System.Windows.Forms.Label labelPrintReady;
        private System.Windows.Forms.Label labelPrintCheck;
        private System.Windows.Forms.Label labelEndOfForms;
        private System.Windows.Forms.Label labelFormsCheck;
        private System.Windows.Forms.Label labelSyncCheck;
        private System.Windows.Forms.Button carriageStopButton;
        private System.Windows.Forms.RichTextBox printerRichTextBox1;
        private System.Windows.Forms.Button carriageTapeButton;
        private System.Windows.Forms.Button printerClearButton;
        private System.Windows.Forms.Button printerSaveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}