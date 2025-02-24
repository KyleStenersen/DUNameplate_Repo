namespace DUNameplateGUI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.settingsSaveCloseBtn = new System.Windows.Forms.Button();
            this.xOffsetBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xOffsetDefault = new System.Windows.Forms.Label();
            this.yOffsetBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yOffsetDefault = new System.Windows.Forms.Label();
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
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.resetDefaultsBtn = new System.Windows.Forms.Button();
            this.autoPrintQueueCheckBox = new System.Windows.Forms.CheckBox();
            this.resetJigAfterQueueCompleteCheckBox = new System.Windows.Forms.CheckBox();
            this.jigComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.resetJigAfterIdleCheckBox = new System.Windows.Forms.CheckBox();
            this.resetJigIdleTimeBox = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.changeInputFixingRulesBtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.clearSpeedDialPlatesButton = new System.Windows.Forms.Button();
            this.openJigEditorBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.stampDelayDefault = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.stampDelayBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resetJigIdleTimeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsSaveCloseBtn
            // 
            this.settingsSaveCloseBtn.Location = new System.Drawing.Point(32, 596);
            this.settingsSaveCloseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.settingsSaveCloseBtn.Name = "settingsSaveCloseBtn";
            this.settingsSaveCloseBtn.Size = new System.Drawing.Size(83, 24);
            this.settingsSaveCloseBtn.TabIndex = 0;
            this.settingsSaveCloseBtn.Text = "Save/Close";
            this.settingsSaveCloseBtn.UseVisualStyleBackColor = true;
            this.settingsSaveCloseBtn.Click += new System.EventHandler(this.settingsSaveCloseBtn_Click);
            // 
            // xOffsetBox
            // 
            this.xOffsetBox.Location = new System.Drawing.Point(18, 66);
            this.xOffsetBox.Margin = new System.Windows.Forms.Padding(2);
            this.xOffsetBox.Name = "xOffsetBox";
            this.xOffsetBox.Size = new System.Drawing.Size(76, 20);
            this.xOffsetBox.TabIndex = 1;
            this.xOffsetBox.Leave += new System.EventHandler(this.xOffsetBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X OFFSET (adjustment of text location on tag. [+=right])";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default:";
            // 
            // xOffsetDefault
            // 
            this.xOffsetDefault.AutoSize = true;
            this.xOffsetDefault.Location = new System.Drawing.Point(152, 71);
            this.xOffsetDefault.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xOffsetDefault.Name = "xOffsetDefault";
            this.xOffsetDefault.Size = new System.Drawing.Size(22, 13);
            this.xOffsetDefault.TabIndex = 2;
            this.xOffsetDefault.Text = "0.0";
            // 
            // yOffsetBox
            // 
            this.yOffsetBox.Location = new System.Drawing.Point(18, 114);
            this.yOffsetBox.Margin = new System.Windows.Forms.Padding(2);
            this.yOffsetBox.Name = "yOffsetBox";
            this.yOffsetBox.Size = new System.Drawing.Size(76, 20);
            this.yOffsetBox.TabIndex = 1;
            this.yOffsetBox.Leave += new System.EventHandler(this.yOffsetBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y OFFSET (adjustment of text location on tag. [+=down])";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Default:";
            // 
            // yOffsetDefault
            // 
            this.yOffsetDefault.AutoSize = true;
            this.yOffsetDefault.Location = new System.Drawing.Point(152, 119);
            this.yOffsetDefault.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yOffsetDefault.Name = "yOffsetDefault";
            this.yOffsetDefault.Size = new System.Drawing.Size(22, 13);
            this.yOffsetDefault.TabIndex = 2;
            this.yOffsetDefault.Text = "0.0";
            // 
            // lineSpaceingBox
            // 
            this.lineSpaceingBox.Location = new System.Drawing.Point(18, 156);
            this.lineSpaceingBox.Margin = new System.Windows.Forms.Padding(2);
            this.lineSpaceingBox.Name = "lineSpaceingBox";
            this.lineSpaceingBox.Size = new System.Drawing.Size(76, 20);
            this.lineSpaceingBox.TabIndex = 1;
            this.lineSpaceingBox.Leave += new System.EventHandler(this.lineSpaceingBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 141);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "LINE SPACING";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(106, 161);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Default:";
            // 
            // lineSpaceingDefault
            // 
            this.lineSpaceingDefault.AutoSize = true;
            this.lineSpaceingDefault.Location = new System.Drawing.Point(152, 161);
            this.lineSpaceingDefault.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineSpaceingDefault.Name = "lineSpaceingDefault";
            this.lineSpaceingDefault.Size = new System.Drawing.Size(34, 13);
            this.lineSpaceingDefault.TabIndex = 2;
            this.lineSpaceingDefault.Text = "0.145";
            // 
            // charSpaceingBox
            // 
            this.charSpaceingBox.Location = new System.Drawing.Point(18, 205);
            this.charSpaceingBox.Margin = new System.Windows.Forms.Padding(2);
            this.charSpaceingBox.Name = "charSpaceingBox";
            this.charSpaceingBox.Size = new System.Drawing.Size(76, 20);
            this.charSpaceingBox.TabIndex = 1;
            this.charSpaceingBox.Leave += new System.EventHandler(this.charSpaceingBox_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 190);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "CHARACTER SPACING";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(106, 210);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Default:";
            // 
            // charSpaceingDefault
            // 
            this.charSpaceingDefault.AutoSize = true;
            this.charSpaceingDefault.Location = new System.Drawing.Point(152, 210);
            this.charSpaceingDefault.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.charSpaceingDefault.Name = "charSpaceingDefault";
            this.charSpaceingDefault.Size = new System.Drawing.Size(34, 13);
            this.charSpaceingDefault.TabIndex = 2;
            this.charSpaceingDefault.Text = "0.105";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(193, 71);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "in.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 119);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "in.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(193, 161);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "in.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(193, 210);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "in.";
            // 
            // resetDefaultsBtn
            // 
            this.resetDefaultsBtn.Location = new System.Drawing.Point(132, 596);
            this.resetDefaultsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.resetDefaultsBtn.Name = "resetDefaultsBtn";
            this.resetDefaultsBtn.Size = new System.Drawing.Size(89, 24);
            this.resetDefaultsBtn.TabIndex = 0;
            this.resetDefaultsBtn.Text = "Reset Defaults";
            this.resetDefaultsBtn.UseVisualStyleBackColor = true;
            this.resetDefaultsBtn.Click += new System.EventHandler(this.resetDefaultsBtn_Click);
            // 
            // autoPrintQueueCheckBox
            // 
            this.autoPrintQueueCheckBox.AutoSize = true;
            this.autoPrintQueueCheckBox.Location = new System.Drawing.Point(11, 420);
            this.autoPrintQueueCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.autoPrintQueueCheckBox.Name = "autoPrintQueueCheckBox";
            this.autoPrintQueueCheckBox.Size = new System.Drawing.Size(133, 17);
            this.autoPrintQueueCheckBox.TabIndex = 4;
            this.autoPrintQueueCheckBox.Text = "AUTO PRINT QUEUE";
            this.autoPrintQueueCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetJigAfterQueueCompleteCheckBox
            // 
            this.resetJigAfterQueueCompleteCheckBox.AutoSize = true;
            this.resetJigAfterQueueCompleteCheckBox.Location = new System.Drawing.Point(11, 450);
            this.resetJigAfterQueueCompleteCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.resetJigAfterQueueCompleteCheckBox.Name = "resetJigAfterQueueCompleteCheckBox";
            this.resetJigAfterQueueCompleteCheckBox.Size = new System.Drawing.Size(228, 17);
            this.resetJigAfterQueueCompleteCheckBox.TabIndex = 5;
            this.resetJigAfterQueueCompleteCheckBox.Text = "RESET JIG AFTER QUEUE COMPLETES";
            this.resetJigAfterQueueCompleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // jigComboBox
            // 
            this.jigComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jigComboBox.FormattingEnabled = true;
            this.jigComboBox.Items.AddRange(new object[] {
            "1-Plate",
            "2-Plate",
            "4-Plate",
            "8-Plate"});
            this.jigComboBox.Location = new System.Drawing.Point(17, 303);
            this.jigComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.jigComboBox.Name = "jigComboBox";
            this.jigComboBox.Size = new System.Drawing.Size(92, 21);
            this.jigComboBox.TabIndex = 11;
            this.jigComboBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 288);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "JIG TYPE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 306);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Default: 8-Plate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 336);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "RESET JIG IDLE TIME (in seconds)";
            // 
            // resetJigAfterIdleCheckBox
            // 
            this.resetJigAfterIdleCheckBox.AutoSize = true;
            this.resetJigAfterIdleCheckBox.Location = new System.Drawing.Point(11, 390);
            this.resetJigAfterIdleCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.resetJigAfterIdleCheckBox.Name = "resetJigAfterIdleCheckBox";
            this.resetJigAfterIdleCheckBox.Size = new System.Drawing.Size(175, 17);
            this.resetJigAfterIdleCheckBox.TabIndex = 15;
            this.resetJigAfterIdleCheckBox.Text = "RESET JIG AFTER IDLE TIME";
            this.resetJigAfterIdleCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetJigIdleTimeBox
            // 
            this.resetJigIdleTimeBox.Location = new System.Drawing.Point(17, 352);
            this.resetJigIdleTimeBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.resetJigIdleTimeBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.resetJigIdleTimeBox.Name = "resetJigIdleTimeBox";
            this.resetJigIdleTimeBox.Size = new System.Drawing.Size(92, 20);
            this.resetJigIdleTimeBox.TabIndex = 16;
            this.resetJigIdleTimeBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(116, 355);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Default: 60 seconds";
            // 
            // changeInputFixingRulesBtn
            // 
            this.changeInputFixingRulesBtn.Location = new System.Drawing.Point(30, 520);
            this.changeInputFixingRulesBtn.Name = "changeInputFixingRulesBtn";
            this.changeInputFixingRulesBtn.Size = new System.Drawing.Size(189, 23);
            this.changeInputFixingRulesBtn.TabIndex = 18;
            this.changeInputFixingRulesBtn.Text = "Change Input Fixing Rules";
            this.changeInputFixingRulesBtn.UseVisualStyleBackColor = true;
            this.changeInputFixingRulesBtn.Click += new System.EventHandler(this.changeInputFixingRulesBtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "SERIAL PORT";
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(17, 24);
            this.serialPortComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(92, 21);
            this.serialPortComboBox.TabIndex = 19;
            this.serialPortComboBox.TabStop = false;
            // 
            // clearSpeedDialPlatesButton
            // 
            this.clearSpeedDialPlatesButton.Location = new System.Drawing.Point(30, 558);
            this.clearSpeedDialPlatesButton.Name = "clearSpeedDialPlatesButton";
            this.clearSpeedDialPlatesButton.Size = new System.Drawing.Size(189, 23);
            this.clearSpeedDialPlatesButton.TabIndex = 21;
            this.clearSpeedDialPlatesButton.Text = "Clear All Speed Dial Plates";
            this.clearSpeedDialPlatesButton.UseVisualStyleBackColor = true;
            this.clearSpeedDialPlatesButton.Click += new System.EventHandler(this.clearSpeedDialPlatesButton_Click);
            // 
            // openJigEditorBtn
            // 
            this.openJigEditorBtn.Location = new System.Drawing.Point(30, 482);
            this.openJigEditorBtn.Name = "openJigEditorBtn";
            this.openJigEditorBtn.Size = new System.Drawing.Size(189, 23);
            this.openJigEditorBtn.TabIndex = 22;
            this.openJigEditorBtn.Text = "Open Jig Editor";
            this.openJigEditorBtn.UseVisualStyleBackColor = true;
            this.openJigEditorBtn.Click += new System.EventHandler(this.openJigEditorBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 257);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "ms";
            // 
            // stampDelayDefault
            // 
            this.stampDelayDefault.AutoSize = true;
            this.stampDelayDefault.Location = new System.Drawing.Point(150, 257);
            this.stampDelayDefault.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stampDelayDefault.Name = "stampDelayDefault";
            this.stampDelayDefault.Size = new System.Drawing.Size(25, 13);
            this.stampDelayDefault.TabIndex = 25;
            this.stampDelayDefault.Text = "100";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(104, 257);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Default:";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 23);
            this.label21.TabIndex = 27;
            // 
            // stampDelayBox
            // 
            this.stampDelayBox.Location = new System.Drawing.Point(16, 252);
            this.stampDelayBox.Margin = new System.Windows.Forms.Padding(2);
            this.stampDelayBox.Name = "stampDelayBox";
            this.stampDelayBox.Size = new System.Drawing.Size(76, 20);
            this.stampDelayBox.TabIndex = 23;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 237);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "STAMP TIME";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "SERIAL PORT";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 636);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stampDelayDefault);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.stampDelayBox);
            this.Controls.Add(this.openJigEditorBtn);
            this.Controls.Add(this.clearSpeedDialPlatesButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.serialPortComboBox);
            this.Controls.Add(this.changeInputFixingRulesBtn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.resetJigIdleTimeBox);
            this.Controls.Add(this.resetJigAfterIdleCheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jigComboBox);
            this.Controls.Add(this.resetJigAfterQueueCompleteCheckBox);
            this.Controls.Add(this.autoPrintQueueCheckBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.charSpaceingDefault);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lineSpaceingDefault);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.yOffsetDefault);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.xOffsetDefault);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.charSpaceingBox);
            this.Controls.Add(this.lineSpaceingBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yOffsetBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xOffsetBox);
            this.Controls.Add(this.resetDefaultsBtn);
            this.Controls.Add(this.settingsSaveCloseBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resetJigIdleTimeBox)).EndInit();
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
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button resetDefaultsBtn;
        private System.Windows.Forms.CheckBox autoPrintQueueCheckBox;
        private System.Windows.Forms.CheckBox resetJigAfterQueueCompleteCheckBox;
        private System.Windows.Forms.ComboBox jigComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox resetJigAfterIdleCheckBox;
        private System.Windows.Forms.NumericUpDown resetJigIdleTimeBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button changeInputFixingRulesBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox serialPortComboBox;
        private System.Windows.Forms.Button clearSpeedDialPlatesButton;
        private System.Windows.Forms.Button openJigEditorBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label stampDelayDefault;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox stampDelayBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label8;
    }
}