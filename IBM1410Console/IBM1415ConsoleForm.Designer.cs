
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
            this.SuspendLayout();
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleOutput.Location = new System.Drawing.Point(12, 12);
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.Size = new System.Drawing.Size(607, 389);
            this.ConsoleOutput.TabIndex = 0;
            this.ConsoleOutput.Text = "";
            this.ConsoleOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConsoleOutput_KeyPress);
            // 
            // keyboardLockLabel
            // 
            this.keyboardLockLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.keyboardLockLabel.ForeColor = System.Drawing.Color.Crimson;
            this.keyboardLockLabel.Location = new System.Drawing.Point(34, 414);
            this.keyboardLockLabel.Name = "keyboardLockLabel";
            this.keyboardLockLabel.Size = new System.Drawing.Size(102, 24);
            this.keyboardLockLabel.TabIndex = 1;
            this.keyboardLockLabel.Text = "LOCKED";
            this.keyboardLockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IBM1415ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}