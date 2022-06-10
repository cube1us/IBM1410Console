
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.keyboardLockLabel = new System.Windows.Forms.Label();
            this.InquiryRequestButton = new System.Windows.Forms.Button();
            this.inquiryReleaseButton = new System.Windows.Forms.Button();
            this.inquiryCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.AcceptsTab = true;
            this.ConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleOutput.Location = new System.Drawing.Point(12, 12);
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.Size = new System.Drawing.Size(776, 389);
            this.ConsoleOutput.TabIndex = 0;
            this.ConsoleOutput.Text = "";
            this.ConsoleOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConsoleOutput_KeyPress);
            // 
            // keyboardLockLabel
            // 
            this.keyboardLockLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.keyboardLockLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.keyboardLockLabel.ForeColor = System.Drawing.Color.Crimson;
            this.keyboardLockLabel.Location = new System.Drawing.Point(27, 404);
            this.keyboardLockLabel.Name = "keyboardLockLabel";
            this.keyboardLockLabel.Size = new System.Drawing.Size(102, 24);
            this.keyboardLockLabel.TabIndex = 1;
            this.keyboardLockLabel.Text = "LOCKED";
            this.keyboardLockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InquiryRequestButton
            // 
            this.InquiryRequestButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InquiryRequestButton.Location = new System.Drawing.Point(794, 201);
            this.InquiryRequestButton.Name = "InquiryRequestButton";
            this.InquiryRequestButton.Size = new System.Drawing.Size(89, 111);
            this.InquiryRequestButton.TabIndex = 2;
            this.InquiryRequestButton.Text = "Inquiry Request";
            this.InquiryRequestButton.UseVisualStyleBackColor = true;
            this.InquiryRequestButton.Click += new System.EventHandler(this.InquiryRequestButton_Click);
            // 
            // inquiryReleaseButton
            // 
            this.inquiryReleaseButton.Location = new System.Drawing.Point(794, 115);
            this.inquiryReleaseButton.Name = "inquiryReleaseButton";
            this.inquiryReleaseButton.Size = new System.Drawing.Size(72, 47);
            this.inquiryReleaseButton.TabIndex = 3;
            this.inquiryReleaseButton.Text = "Inquiry Release";
            this.inquiryReleaseButton.UseVisualStyleBackColor = true;
            this.inquiryReleaseButton.Click += new System.EventHandler(this.inquiryReleaseButton_Click);
            // 
            // inquiryCancelButton
            // 
            this.inquiryCancelButton.Location = new System.Drawing.Point(893, 115);
            this.inquiryCancelButton.Name = "inquiryCancelButton";
            this.inquiryCancelButton.Size = new System.Drawing.Size(51, 47);
            this.inquiryCancelButton.TabIndex = 4;
            this.inquiryCancelButton.Text = "Inq. Cancel";
            this.inquiryCancelButton.UseVisualStyleBackColor = true;
            this.inquiryCancelButton.Click += new System.EventHandler(this.inquiryCancelButton_Click);
            // 
            // IBM1415ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 450);
            this.Controls.Add(this.inquiryCancelButton);
            this.Controls.Add(this.inquiryReleaseButton);
            this.Controls.Add(this.InquiryRequestButton);
            this.Controls.Add(this.keyboardLockLabel);
            this.Controls.Add(this.ConsoleOutput);
            this.Name = "IBM1415ConsoleForm";
            this.Text = "IBM1415ConsoleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IBM1415ConsoleForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleOutput;
        private System.Windows.Forms.Label keyboardLockLabel;
        private System.Windows.Forms.Button InquiryRequestButton;
        private System.Windows.Forms.Button inquiryReleaseButton;
        private System.Windows.Forms.Button inquiryCancelButton;
    }
}