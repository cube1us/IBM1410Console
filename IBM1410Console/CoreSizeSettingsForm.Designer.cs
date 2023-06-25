namespace IBM1410Console
{
    partial class CoreSizeSettingsForm
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
            coreSizeComboBox = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // coreSizeComboBox
            // 
            coreSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            coreSizeComboBox.FormattingEnabled = true;
            coreSizeComboBox.Items.AddRange(new object[] { "10000", "20000", "40000", "60000", "80000", "100000" });
            coreSizeComboBox.Location = new System.Drawing.Point(59, 40);
            coreSizeComboBox.MaxDropDownItems = 10;
            coreSizeComboBox.Name = "coreSizeComboBox";
            coreSizeComboBox.Size = new System.Drawing.Size(152, 23);
            coreSizeComboBox.TabIndex = 0;
            coreSizeComboBox.SelectedIndexChanged += coreSizeComboBox_SelectedIndexChanged;
            // 
            // CoreSizeSettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(267, 107);
            Controls.Add(coreSizeComboBox);
            Name = "CoreSizeSettingsForm";
            Text = "IBM 1410 FPGA Core Size";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox coreSizeComboBox;
    }
}