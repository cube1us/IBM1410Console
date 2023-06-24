
namespace IBM1410Console
{
    partial class IBM1415ConsoleForm
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
            ConsoleOutput = new System.Windows.Forms.RichTextBox();
            keyboardLockLabel = new System.Windows.Forms.Label();
            InquiryRequestButton = new System.Windows.Forms.Button();
            inquiryReleaseButton = new System.Windows.Forms.Button();
            inquiryCancelButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ConsoleOutput
            // 
            ConsoleOutput.AcceptsTab = true;
            ConsoleOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ConsoleOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ConsoleOutput.Location = new System.Drawing.Point(12, 12);
            ConsoleOutput.Name = "ConsoleOutput";
            ConsoleOutput.Size = new System.Drawing.Size(776, 389);
            ConsoleOutput.TabIndex = 0;
            ConsoleOutput.Text = "";
            ConsoleOutput.KeyPress += ConsoleOutput_KeyPress;
            // 
            // keyboardLockLabel
            // 
            keyboardLockLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            keyboardLockLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            keyboardLockLabel.ForeColor = System.Drawing.Color.Crimson;
            keyboardLockLabel.Location = new System.Drawing.Point(27, 404);
            keyboardLockLabel.Name = "keyboardLockLabel";
            keyboardLockLabel.Size = new System.Drawing.Size(102, 24);
            keyboardLockLabel.TabIndex = 1;
            keyboardLockLabel.Text = "LOCKED";
            keyboardLockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InquiryRequestButton
            // 
            InquiryRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            InquiryRequestButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InquiryRequestButton.Location = new System.Drawing.Point(794, 201);
            InquiryRequestButton.Name = "InquiryRequestButton";
            InquiryRequestButton.Size = new System.Drawing.Size(89, 111);
            InquiryRequestButton.TabIndex = 2;
            InquiryRequestButton.Text = "Inquiry Request";
            InquiryRequestButton.UseVisualStyleBackColor = true;
            InquiryRequestButton.Click += InquiryRequestButton_Click;
            // 
            // inquiryReleaseButton
            // 
            inquiryReleaseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            inquiryReleaseButton.Location = new System.Drawing.Point(794, 115);
            inquiryReleaseButton.Name = "inquiryReleaseButton";
            inquiryReleaseButton.Size = new System.Drawing.Size(72, 47);
            inquiryReleaseButton.TabIndex = 3;
            inquiryReleaseButton.Text = "Inquiry Release";
            inquiryReleaseButton.UseVisualStyleBackColor = true;
            inquiryReleaseButton.Click += inquiryReleaseButton_Click;
            // 
            // inquiryCancelButton
            // 
            inquiryCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            inquiryCancelButton.Location = new System.Drawing.Point(893, 115);
            inquiryCancelButton.Name = "inquiryCancelButton";
            inquiryCancelButton.Size = new System.Drawing.Size(51, 47);
            inquiryCancelButton.TabIndex = 4;
            inquiryCancelButton.Text = "Inq. Cancel";
            inquiryCancelButton.UseVisualStyleBackColor = true;
            inquiryCancelButton.Click += inquiryCancelButton_Click;
            // 
            // IBM1415ConsoleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(969, 450);
            Controls.Add(inquiryCancelButton);
            Controls.Add(inquiryReleaseButton);
            Controls.Add(InquiryRequestButton);
            Controls.Add(keyboardLockLabel);
            Controls.Add(ConsoleOutput);
            Name = "IBM1415ConsoleForm";
            Text = "IBM1415ConsoleForm";
            FormClosing += IBM1415ConsoleForm_FormClosing;
            Load += IBM1415ConsoleForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleOutput;
        private System.Windows.Forms.Label keyboardLockLabel;
        private System.Windows.Forms.Button InquiryRequestButton;
        private System.Windows.Forms.Button inquiryReleaseButton;
        private System.Windows.Forms.Button inquiryCancelButton;
    }
}