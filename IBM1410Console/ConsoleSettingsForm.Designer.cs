
namespace IBM1410Console
{
    partial class ComPortSettingsForm
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
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speedComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // portsComboBox
            // 
            this.portsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(78, 21);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(88, 23);
            this.portsComboBox.TabIndex = 0;
            this.portsComboBox.SelectedIndexChanged += new System.EventHandler(this.portsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Speed";
            // 
            // speedComboBox
            // 
            this.speedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedComboBox.FormattingEnabled = true;
            this.speedComboBox.Location = new System.Drawing.Point(78, 56);
            this.speedComboBox.Name = "speedComboBox";
            this.speedComboBox.Size = new System.Drawing.Size(88, 23);
            this.speedComboBox.TabIndex = 3;
            this.speedComboBox.SelectedIndexChanged += new System.EventHandler(this.speedComboBox_SelectedIndexChanged);
            // 
            // ComPortSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 119);
            this.Controls.Add(this.speedComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portsComboBox);
            this.Name = "ComPortSettingsForm";
            this.Text = "COM Port Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox speedComboBox;
    }
}