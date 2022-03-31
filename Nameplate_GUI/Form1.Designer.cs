namespace DUNameplateGUI
{
    partial class MAIN_FORM
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
            this.components = new System.ComponentModel.Container();
            this.printTagsBtn = new System.Windows.Forms.Button();
            this.tag1Line0Box = new System.Windows.Forms.TextBox();
            this.tag1Line1Box = new System.Windows.Forms.TextBox();
            this.tag1Line2Box = new System.Windows.Forms.TextBox();
            this.tag1Line3Box = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.settingsBtn = new System.Windows.Forms.Button();
            this.clearTagBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printTagsBtn
            // 
            this.printTagsBtn.Location = new System.Drawing.Point(78, 77);
            this.printTagsBtn.Name = "printTagsBtn";
            this.printTagsBtn.Size = new System.Drawing.Size(103, 28);
            this.printTagsBtn.TabIndex = 0;
            this.printTagsBtn.Text = "Print Tags";
            this.printTagsBtn.UseVisualStyleBackColor = true;
            this.printTagsBtn.Click += new System.EventHandler(this.printTagsBtn_Click);
            // 
            // tag1Line0Box
            // 
            this.tag1Line0Box.Location = new System.Drawing.Point(214, 38);
            this.tag1Line0Box.Name = "tag1Line0Box";
            this.tag1Line0Box.Size = new System.Drawing.Size(349, 22);
            this.tag1Line0Box.TabIndex = 2;
            this.tag1Line0Box.TextChanged += new System.EventHandler(this.tag1Line0Box_TextChanged);
            // 
            // tag1Line1Box
            // 
            this.tag1Line1Box.Location = new System.Drawing.Point(240, 66);
            this.tag1Line1Box.Name = "tag1Line1Box";
            this.tag1Line1Box.Size = new System.Drawing.Size(281, 22);
            this.tag1Line1Box.TabIndex = 3;
            this.tag1Line1Box.TextChanged += new System.EventHandler(this.tag1Line1Box_TextChanged);
            // 
            // tag1Line2Box
            // 
            this.tag1Line2Box.Location = new System.Drawing.Point(240, 94);
            this.tag1Line2Box.Name = "tag1Line2Box";
            this.tag1Line2Box.Size = new System.Drawing.Size(281, 22);
            this.tag1Line2Box.TabIndex = 4;
            this.tag1Line2Box.TextChanged += new System.EventHandler(this.tag1Line2Box_TextChanged);
            // 
            // tag1Line3Box
            // 
            this.tag1Line3Box.Location = new System.Drawing.Point(214, 122);
            this.tag1Line3Box.Name = "tag1Line3Box";
            this.tag1Line3Box.Size = new System.Drawing.Size(349, 22);
            this.tag1Line3Box.TabIndex = 5;
            this.tag1Line3Box.TextChanged += new System.EventHandler(this.tag1Line3Box_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM9";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(78, 228);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(103, 28);
            this.settingsBtn.TabIndex = 6;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // clearTagBtn
            // 
            this.clearTagBtn.Location = new System.Drawing.Point(585, 77);
            this.clearTagBtn.Name = "clearTagBtn";
            this.clearTagBtn.Size = new System.Drawing.Size(103, 28);
            this.clearTagBtn.TabIndex = 7;
            this.clearTagBtn.Text = "Clear";
            this.clearTagBtn.UseVisualStyleBackColor = true;
            this.clearTagBtn.Click += new System.EventHandler(this.clearTagBtn_Click);
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 321);
            this.Controls.Add(this.clearTagBtn);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.tag1Line3Box);
            this.Controls.Add(this.tag1Line2Box);
            this.Controls.Add(this.tag1Line1Box);
            this.Controls.Add(this.tag1Line0Box);
            this.Controls.Add(this.printTagsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "MAIN_FORM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " DU Nameplate GUI";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printTagsBtn;
        private System.Windows.Forms.TextBox tag1Line0Box;
        private System.Windows.Forms.TextBox tag1Line1Box;
        private System.Windows.Forms.TextBox tag1Line2Box;
        private System.Windows.Forms.TextBox tag1Line3Box;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button clearTagBtn;
    }
}

