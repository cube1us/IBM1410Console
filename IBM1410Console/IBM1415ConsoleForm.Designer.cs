
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
            this.SuspendLayout();
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleOutput.Location = new System.Drawing.Point(12, 224);
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.Size = new System.Drawing.Size(607, 214);
            this.ConsoleOutput.TabIndex = 0;
            this.ConsoleOutput.Text = "";
            // 
            // IBM1415ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConsoleOutput);
            this.Name = "IBM1415ConsoleForm";
            this.Text = "IBM1415ConsoleForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleOutput;
    }
}