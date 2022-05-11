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
            this.settingsSaveCloseBtn = new System.Windows.Forms.Button();
            this.xOffsetBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xOffsetDefault = new System.Windows.Forms.Label();
            this.yOffsetBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yOffsetDefault = new System.Windows.Forms.Label();
            this.plateSpaceingBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.plateSpaceingDefault = new System.Windows.Forms.Label();
            this.lineSpaceingBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lineSpaceingDefault = new System.Windows.Forms.Label();
            this.charSpaceingBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.charSpaceingDefault = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.resetDefaultsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settingsSaveCloseBtn
            // 
            this.settingsSaveCloseBtn.Location = new System.Drawing.Point(40, 332);
            this.settingsSaveCloseBtn.Name = "settingsSaveCloseBtn";
            this.settingsSaveCloseBtn.Size = new System.Drawing.Size(111, 29);
            this.settingsSaveCloseBtn.TabIndex = 0;
            this.settingsSaveCloseBtn.Text = "Save/Close";
            this.settingsSaveCloseBtn.UseVisualStyleBackColor = true;
            this.settingsSaveCloseBtn.Click += new System.EventHandler(this.settingsSaveCloseBtn_Click);
            // 
            // xOffsetBox
            // 
            this.xOffsetBox.Location = new System.Drawing.Point(40, 44);
            this.xOffsetBox.Name = "xOffsetBox";
            this.xOffsetBox.Size = new System.Drawing.Size(100, 22);
            this.xOffsetBox.TabIndex = 1;
            this.xOffsetBox.Leave += new System.EventHandler(this.xOffsetBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "X OFFSET (adjustment of text location on tag)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default:";
            // 
            // xOffsetDefault
            // 
            this.xOffsetDefault.AutoSize = true;
            this.xOffsetDefault.Location = new System.Drawing.Point(219, 50);
            this.xOffsetDefault.Name = "xOffsetDefault";
            this.xOffsetDefault.Size = new System.Drawing.Size(24, 16);
            this.xOffsetDefault.TabIndex = 2;
            this.xOffsetDefault.Text = "0.0";
            // 
            // yOffsetBox
            // 
            this.yOffsetBox.Location = new System.Drawing.Point(40, 103);
            this.yOffsetBox.Name = "yOffsetBox";
            this.yOffsetBox.Size = new System.Drawing.Size(100, 22);
            this.yOffsetBox.TabIndex = 1;
            this.yOffsetBox.Leave += new System.EventHandler(this.yOffsetBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y OFFSET (adjustment of text location on tag)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Default:";
            // 
            // yOffsetDefault
            // 
            this.yOffsetDefault.AutoSize = true;
            this.yOffsetDefault.Location = new System.Drawing.Point(219, 109);
            this.yOffsetDefault.Name = "yOffsetDefault";
            this.yOffsetDefault.Size = new System.Drawing.Size(24, 16);
            this.yOffsetDefault.TabIndex = 2;
            this.yOffsetDefault.Text = "0.0";
            // 
            // plateSpaceingBox
            // 
            this.plateSpaceingBox.Location = new System.Drawing.Point(40, 160);
            this.plateSpaceingBox.Name = "plateSpaceingBox";
            this.plateSpaceingBox.Size = new System.Drawing.Size(100, 22);
            this.plateSpaceingBox.TabIndex = 1;
            this.plateSpaceingBox.Leave += new System.EventHandler(this.plateSpaceingBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "NAMEPLATE SPACING";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Default:";
            // 
            // plateSpaceingDefault
            // 
            this.plateSpaceingDefault.AutoSize = true;
            this.plateSpaceingDefault.Location = new System.Drawing.Point(219, 166);
            this.plateSpaceingDefault.Name = "plateSpaceingDefault";
            this.plateSpaceingDefault.Size = new System.Drawing.Size(24, 16);
            this.plateSpaceingDefault.TabIndex = 2;
            this.plateSpaceingDefault.Text = "0.9";
            // 
            // lineSpaceingBox
            // 
            this.lineSpaceingBox.Location = new System.Drawing.Point(40, 222);
            this.lineSpaceingBox.Name = "lineSpaceingBox";
            this.lineSpaceingBox.Size = new System.Drawing.Size(100, 22);
            this.lineSpaceingBox.TabIndex = 1;
            this.lineSpaceingBox.Leave += new System.EventHandler(this.lineSpaceingBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "LINE SPACING";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Default:";
            // 
            // lineSpaceingDefault
            // 
            this.lineSpaceingDefault.AutoSize = true;
            this.lineSpaceingDefault.Location = new System.Drawing.Point(219, 228);
            this.lineSpaceingDefault.Name = "lineSpaceingDefault";
            this.lineSpaceingDefault.Size = new System.Drawing.Size(38, 16);
            this.lineSpaceingDefault.TabIndex = 2;
            this.lineSpaceingDefault.Text = "0.145";
            // 
            // charSpaceingBox
            // 
            this.charSpaceingBox.Location = new System.Drawing.Point(40, 282);
            this.charSpaceingBox.Name = "charSpaceingBox";
            this.charSpaceingBox.Size = new System.Drawing.Size(100, 22);
            this.charSpaceingBox.TabIndex = 1;
            this.charSpaceingBox.Leave += new System.EventHandler(this.charSpaceingBox_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 263);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 16);
            this.label13.TabIndex = 2;
            this.label13.Text = "CHARACTER SPACING";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(157, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 16);
            this.label14.TabIndex = 2;
            this.label14.Text = "Default:";
            // 
            // charSpaceingDefault
            // 
            this.charSpaceingDefault.AutoSize = true;
            this.charSpaceingDefault.Location = new System.Drawing.Point(219, 288);
            this.charSpaceingDefault.Name = "charSpaceingDefault";
            this.charSpaceingDefault.Size = new System.Drawing.Size(38, 16);
            this.charSpaceingDefault.TabIndex = 2;
            this.charSpaceingDefault.Text = "0.095";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(273, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "in.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(273, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "in.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(273, 166);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "in.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(273, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "in.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(273, 288);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 16);
            this.label20.TabIndex = 2;
            this.label20.Text = "in.";
            // 
            // resetDefaultsBtn
            // 
            this.resetDefaultsBtn.Location = new System.Drawing.Point(174, 332);
            this.resetDefaultsBtn.Name = "resetDefaultsBtn";
            this.resetDefaultsBtn.Size = new System.Drawing.Size(119, 29);
            this.resetDefaultsBtn.TabIndex = 0;
            this.resetDefaultsBtn.Text = "Reset Defaults";
            this.resetDefaultsBtn.UseVisualStyleBackColor = true;
            this.resetDefaultsBtn.Click += new System.EventHandler(this.resetDefaultsBtn_Click);
            // 
            // SETTINGS_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 383);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.charSpaceingDefault);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lineSpaceingDefault);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.plateSpaceingDefault);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.yOffsetDefault);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.xOffsetDefault);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.charSpaceingBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lineSpaceingBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.plateSpaceingBox);
            this.Controls.Add(this.yOffsetBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xOffsetBox);
            this.Controls.Add(this.resetDefaultsBtn);
            this.Controls.Add(this.settingsSaveCloseBtn);
            this.Name = "SETTINGS_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SETTINGS_FORM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button settingsSaveCloseBtn;
        private System.Windows.Forms.TextBox xOffsetBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label xOffsetDefault;
        private System.Windows.Forms.TextBox yOffsetBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label yOffsetDefault;
        private System.Windows.Forms.TextBox plateSpaceingBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label plateSpaceingDefault;
        private System.Windows.Forms.TextBox lineSpaceingBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lineSpaceingDefault;
        private System.Windows.Forms.TextBox charSpaceingBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label charSpaceingDefault;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button resetDefaultsBtn;
    }
}