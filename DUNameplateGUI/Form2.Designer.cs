namespace DUNameplateGUI
{
    partial class SETTINGS_FORM
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
            this.settingsCloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settingsCloseBtn
            // 
            this.settingsCloseBtn.Location = new System.Drawing.Point(38, 394);
            this.settingsCloseBtn.Name = "settingsCloseBtn";
            this.settingsCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsCloseBtn.TabIndex = 0;
            this.settingsCloseBtn.Text = "Close";
            this.settingsCloseBtn.UseVisualStyleBackColor = true;
            this.settingsCloseBtn.Click += new System.EventHandler(this.settingsCloseBtn_Click);
            // 
            // SETTINGS_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingsCloseBtn);
            this.Name = "SETTINGS_FORM";
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button settingsCloseBtn;
    }
}