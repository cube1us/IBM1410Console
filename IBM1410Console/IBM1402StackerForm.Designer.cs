namespace IBM1410Console
{
    partial class IBM1402StackerForm
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
            stackerRichTextBox1 = new System.Windows.Forms.RichTextBox();
            stackerClearButton = new System.Windows.Forms.Button();
            stackerSaveButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // stackerRichTextBox1
            // 
            stackerRichTextBox1.Location = new System.Drawing.Point(12, 30);
            stackerRichTextBox1.Name = "stackerRichTextBox1";
            stackerRichTextBox1.Size = new System.Drawing.Size(773, 328);
            stackerRichTextBox1.TabIndex = 0;
            stackerRichTextBox1.Text = "";
            // 
            // stackerClearButton
            // 
            stackerClearButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            stackerClearButton.Location = new System.Drawing.Point(12, 376);
            stackerClearButton.Name = "stackerClearButton";
            stackerClearButton.Size = new System.Drawing.Size(110, 48);
            stackerClearButton.TabIndex = 1;
            stackerClearButton.Text = "Clear";
            stackerClearButton.UseVisualStyleBackColor = false;
            stackerClearButton.Click += stackerClearButton_Click;
            // 
            // stackerSaveButton
            // 
            stackerSaveButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            stackerSaveButton.Location = new System.Drawing.Point(675, 376);
            stackerSaveButton.Name = "stackerSaveButton";
            stackerSaveButton.Size = new System.Drawing.Size(110, 48);
            stackerSaveButton.TabIndex = 2;
            stackerSaveButton.Text = "Save";
            stackerSaveButton.UseVisualStyleBackColor = false;
            stackerSaveButton.Click += stackerSaveButton_Click;
            // 
            // IBM1402StackerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(stackerSaveButton);
            Controls.Add(stackerClearButton);
            Controls.Add(stackerRichTextBox1);
            Name = "IBM1402StackerForm";
            Text = "IBM1402StackerForm";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox stackerRichTextBox1;
        private System.Windows.Forms.Button stackerClearButton;
        private System.Windows.Forms.Button stackerSaveButton;
    }
}