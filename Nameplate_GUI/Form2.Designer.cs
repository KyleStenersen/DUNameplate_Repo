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
            this.plateSpacingDefault = new System.Windows.Forms.Label();
            this.lineSpaceingBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lineSpacingDefault = new System.Windows.Forms.Label();
            this.charSpacingBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.charSpacingDefault = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsCloseBtn
            // 
            this.settingsCloseBtn.Location = new System.Drawing.Point(12, 337);
            this.settingsCloseBtn.Name = "settingsCloseBtn";
            this.settingsCloseBtn.Size = new System.Drawing.Size(105, 29);
            this.settingsCloseBtn.TabIndex = 0;
            this.settingsCloseBtn.Text = "Save/Close";
            this.settingsCloseBtn.UseVisualStyleBackColor = true;
            this.settingsCloseBtn.Click += new System.EventHandler(this.settingsCloseBtn_Click);
            // 
            // xOffsetBox
            // 
            this.xOffsetBox.Location = new System.Drawing.Point(40, 44);
            this.xOffsetBox.Name = "xOffsetBox";
            this.xOffsetBox.Size = new System.Drawing.Size(100, 22);
            this.xOffsetBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "X OFFSET (home to center of tag #1)";
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
            this.xOffsetDefault.Location = new System.Drawing.Point(228, 50);
            this.xOffsetDefault.Name = "xOffsetDefault";
            this.xOffsetDefault.Size = new System.Drawing.Size(24, 16);
            this.xOffsetDefault.TabIndex = 2;
            this.xOffsetDefault.Text = "1.8";
            // 
            // yOffsetBox
            // 
            this.yOffsetBox.Location = new System.Drawing.Point(40, 103);
            this.yOffsetBox.Name = "yOffsetBox";
            this.yOffsetBox.Size = new System.Drawing.Size(100, 22);
            this.yOffsetBox.TabIndex = 1;
            this.yOffsetBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y OFFSET (home to top of tag #1)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Default:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // yOffsetDefault
            // 
            this.yOffsetDefault.AutoSize = true;
            this.yOffsetDefault.Location = new System.Drawing.Point(228, 109);
            this.yOffsetDefault.Name = "yOffsetDefault";
            this.yOffsetDefault.Size = new System.Drawing.Size(24, 16);
            this.yOffsetDefault.TabIndex = 2;
            this.yOffsetDefault.Text = "0.6";
            this.yOffsetDefault.Click += new System.EventHandler(this.label6_Click);
            // 
            // plateSpaceingBox
            // 
            this.plateSpaceingBox.Location = new System.Drawing.Point(40, 160);
            this.plateSpaceingBox.Name = "plateSpaceingBox";
            this.plateSpaceingBox.Size = new System.Drawing.Size(100, 22);
            this.plateSpaceingBox.TabIndex = 1;
            this.plateSpaceingBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.label8.Click += new System.EventHandler(this.label5_Click);
            // 
            // plateSpacingDefault
            // 
            this.plateSpacingDefault.AutoSize = true;
            this.plateSpacingDefault.Location = new System.Drawing.Point(228, 166);
            this.plateSpacingDefault.Name = "plateSpacingDefault";
            this.plateSpacingDefault.Size = new System.Drawing.Size(24, 16);
            this.plateSpacingDefault.TabIndex = 2;
            this.plateSpacingDefault.Text = "0.9";
            this.plateSpacingDefault.Click += new System.EventHandler(this.label6_Click);
            // 
            // lineSpaceingBox
            // 
            this.lineSpaceingBox.Location = new System.Drawing.Point(40, 222);
            this.lineSpaceingBox.Name = "lineSpaceingBox";
            this.lineSpaceingBox.Size = new System.Drawing.Size(100, 22);
            this.lineSpaceingBox.TabIndex = 1;
            this.lineSpaceingBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.label11.Click += new System.EventHandler(this.label5_Click);
            // 
            // lineSpacingDefault
            // 
            this.lineSpacingDefault.AutoSize = true;
            this.lineSpacingDefault.Location = new System.Drawing.Point(228, 228);
            this.lineSpacingDefault.Name = "lineSpacingDefault";
            this.lineSpacingDefault.Size = new System.Drawing.Size(31, 16);
            this.lineSpacingDefault.TabIndex = 2;
            this.lineSpacingDefault.Text = "0.14";
            this.lineSpacingDefault.Click += new System.EventHandler(this.label6_Click);
            // 
            // charSpacingBox
            // 
            this.charSpacingBox.Location = new System.Drawing.Point(40, 282);
            this.charSpacingBox.Name = "charSpacingBox";
            this.charSpacingBox.Size = new System.Drawing.Size(100, 22);
            this.charSpacingBox.TabIndex = 1;
            this.charSpacingBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.label14.Click += new System.EventHandler(this.label5_Click);
            // 
            // charSpacingDefault
            // 
            this.charSpacingDefault.AutoSize = true;
            this.charSpacingDefault.Location = new System.Drawing.Point(228, 288);
            this.charSpacingDefault.Name = "charSpacingDefault";
            this.charSpacingDefault.Size = new System.Drawing.Size(31, 16);
            this.charSpacingDefault.TabIndex = 2;
            this.charSpacingDefault.Text = "0.11";
            this.charSpacingDefault.Click += new System.EventHandler(this.label6_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(282, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "in.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(282, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 16);
            this.label17.TabIndex = 2;
            this.label17.Text = "in.";
            this.label17.Click += new System.EventHandler(this.label6_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(282, 166);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "in.";
            this.label18.Click += new System.EventHandler(this.label6_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(282, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "in.";
            this.label19.Click += new System.EventHandler(this.label6_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(282, 288);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 16);
            this.label20.TabIndex = 2;
            this.label20.Text = "in.";
            this.label20.Click += new System.EventHandler(this.label6_Click);
            // 
            // SETTINGS_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 383);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.charSpacingDefault);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lineSpacingDefault);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.plateSpacingDefault);
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
            this.Controls.Add(this.charSpacingBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lineSpaceingBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.plateSpaceingBox);
            this.Controls.Add(this.yOffsetBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xOffsetBox);
            this.Controls.Add(this.settingsCloseBtn);
            this.Name = "SETTINGS_FORM";
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button settingsCloseBtn;
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
        private System.Windows.Forms.Label plateSpacingDefault;
        private System.Windows.Forms.TextBox lineSpaceingBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lineSpacingDefault;
        private System.Windows.Forms.TextBox charSpacingBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label charSpacingDefault;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}