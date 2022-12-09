namespace DUNameplateGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tag1Line0Box = new System.Windows.Forms.TextBox();
            this.tag1Line1Box = new System.Windows.Forms.TextBox();
            this.tag1Line2Box = new System.Windows.Forms.TextBox();
            this.tag1Line3Box = new System.Windows.Forms.TextBox();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.clearTagBtn = new System.Windows.Forms.Button();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.labelAboveJig = new System.Windows.Forms.Label();
            this.homeButton = new System.Windows.Forms.Button();
            this.printQueueBtn = new System.Windows.Forms.Button();
            this.addToQueueBtn = new System.Windows.Forms.Button();
            this.tagQuantityBox = new System.Windows.Forms.NumericUpDown();
            this.queuedPlatesListView = new System.Windows.Forms.ListView();
            this.TagContents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.queueLabel = new System.Windows.Forms.Label();
            this.clearQueueBtn = new System.Windows.Forms.Button();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.jigIndicator0 = new System.Windows.Forms.Panel();
            this.jigIndicatorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.jigIndicator7 = new System.Windows.Forms.Panel();
            this.jigIndicator6 = new System.Windows.Forms.Panel();
            this.jigIndicator5 = new System.Windows.Forms.Panel();
            this.jigIndicator4 = new System.Windows.Forms.Panel();
            this.jigIndicator1 = new System.Windows.Forms.Panel();
            this.jigIndicator2 = new System.Windows.Forms.Panel();
            this.jigIndicator3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputFixingRulesEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.speedDialLabel6 = new System.Windows.Forms.Label();
            this.speedDialLabel5 = new System.Windows.Forms.Label();
            this.speedDialLabel4 = new System.Windows.Forms.Label();
            this.speedDialLabel3 = new System.Windows.Forms.Label();
            this.speedDialLabel2 = new System.Windows.Forms.Label();
            this.speedDialLabel1 = new System.Windows.Forms.Label();
            this.loadSlot6Button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.saveSlot6Button = new System.Windows.Forms.Button();
            this.loadSlot5Button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.saveSlot5Button = new System.Windows.Forms.Button();
            this.loadSlot4Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.saveSlot4Button = new System.Windows.Forms.Button();
            this.loadSlot3Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.saveSlot3Button = new System.Windows.Forms.Button();
            this.loadSlot2Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.saveSlot2Button = new System.Windows.Forms.Button();
            this.loadSlot1Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.saveSlot1Button = new System.Windows.Forms.Button();
            this.resetConnectionButton = new System.Windows.Forms.Button();
            this.deleteSelectedBtn = new System.Windows.Forms.Button();
            this.addToTopOfQueueBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.jigLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tagQuantityBox)).BeginInit();
            this.statusPanel.SuspendLayout();
            this.jigIndicatorTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tag1Line0Box
            // 
            this.tag1Line0Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line0Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line0Box.Location = new System.Drawing.Point(520, 120);
            this.tag1Line0Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line0Box.Name = "tag1Line0Box";
            this.tag1Line0Box.Size = new System.Drawing.Size(346, 31);
            this.tag1Line0Box.TabIndex = 2;
            this.tag1Line0Box.TextChanged += new System.EventHandler(this.tag1Line0Box_TextChanged);
            this.tag1Line0Box.DoubleClick += new System.EventHandler(this.tag1Line0Box_DoubleClicked);
            this.tag1Line0Box.Leave += new System.EventHandler(this.textBox_FocusLeave);
            // 
            // tag1Line1Box
            // 
            this.tag1Line1Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line1Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line1Box.Location = new System.Drawing.Point(540, 155);
            this.tag1Line1Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line1Box.Name = "tag1Line1Box";
            this.tag1Line1Box.Size = new System.Drawing.Size(303, 31);
            this.tag1Line1Box.TabIndex = 3;
            this.tag1Line1Box.TextChanged += new System.EventHandler(this.tag1Line1Box_TextChanged);
            this.tag1Line1Box.DoubleClick += new System.EventHandler(this.tag1Line1Box_DoubleClicked);
            this.tag1Line1Box.Leave += new System.EventHandler(this.textBox_FocusLeave);
            // 
            // tag1Line2Box
            // 
            this.tag1Line2Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line2Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line2Box.Location = new System.Drawing.Point(540, 190);
            this.tag1Line2Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line2Box.Name = "tag1Line2Box";
            this.tag1Line2Box.Size = new System.Drawing.Size(303, 31);
            this.tag1Line2Box.TabIndex = 4;
            this.tag1Line2Box.TextChanged += new System.EventHandler(this.tag1Line2Box_TextChanged);
            this.tag1Line2Box.DoubleClick += new System.EventHandler(this.tag1Line2Box_DoubleClicked);
            this.tag1Line2Box.Leave += new System.EventHandler(this.textBox_FocusLeave);
            // 
            // tag1Line3Box
            // 
            this.tag1Line3Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line3Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line3Box.Location = new System.Drawing.Point(520, 225);
            this.tag1Line3Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line3Box.Name = "tag1Line3Box";
            this.tag1Line3Box.Size = new System.Drawing.Size(346, 31);
            this.tag1Line3Box.TabIndex = 5;
            this.tag1Line3Box.TextChanged += new System.EventHandler(this.tag1Line3Box_TextChanged);
            this.tag1Line3Box.DoubleClick += new System.EventHandler(this.tag1Line3Box_DoubleClicked);
            this.tag1Line3Box.Leave += new System.EventHandler(this.textBox_FocusLeave);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.Location = new System.Drawing.Point(438, 267);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(102, 38);
            this.settingsBtn.TabIndex = 6;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // clearTagBtn
            // 
            this.clearTagBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTagBtn.Location = new System.Drawing.Point(553, 267);
            this.clearTagBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearTagBtn.Name = "clearTagBtn";
            this.clearTagBtn.Size = new System.Drawing.Size(77, 38);
            this.clearTagBtn.TabIndex = 7;
            this.clearTagBtn.TabStop = false;
            this.clearTagBtn.Text = "Clear";
            this.clearTagBtn.UseVisualStyleBackColor = true;
            this.clearTagBtn.Click += new System.EventHandler(this.clearTagBtn_Click);
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(881, 140);
            this.quantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(98, 25);
            this.quantityLabel.TabIndex = 8;
            this.quantityLabel.Text = "Quantity:";
            // 
            // labelAboveJig
            // 
            this.labelAboveJig.AutoSize = true;
            this.labelAboveJig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboveJig.Location = new System.Drawing.Point(453, 155);
            this.labelAboveJig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAboveJig.Name = "labelAboveJig";
            this.labelAboveJig.Size = new System.Drawing.Size(46, 25);
            this.labelAboveJig.TabIndex = 8;
            this.labelAboveJig.Text = "Jig:";
            // 
            // homeButton
            // 
            this.homeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.Location = new System.Drawing.Point(822, 267);
            this.homeButton.Margin = new System.Windows.Forms.Padding(2);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(79, 38);
            this.homeButton.TabIndex = 7;
            this.homeButton.TabStop = false;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // printQueueBtn
            // 
            this.printQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printQueueBtn.Location = new System.Drawing.Point(992, 639);
            this.printQueueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printQueueBtn.Name = "printQueueBtn";
            this.printQueueBtn.Size = new System.Drawing.Size(154, 61);
            this.printQueueBtn.TabIndex = 11;
            this.printQueueBtn.TabStop = false;
            this.printQueueBtn.Text = "Print Queue";
            this.printQueueBtn.UseVisualStyleBackColor = true;
            this.printQueueBtn.Click += new System.EventHandler(this.printQueueBtn_Click);
            // 
            // addToQueueBtn
            // 
            this.addToQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToQueueBtn.Location = new System.Drawing.Point(438, 639);
            this.addToQueueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addToQueueBtn.Name = "addToQueueBtn";
            this.addToQueueBtn.Size = new System.Drawing.Size(158, 59);
            this.addToQueueBtn.TabIndex = 12;
            this.addToQueueBtn.TabStop = false;
            this.addToQueueBtn.Text = "Add to Queue";
            this.addToQueueBtn.UseVisualStyleBackColor = true;
            this.addToQueueBtn.Click += new System.EventHandler(this.addToQueueBtn_Click);
            // 
            // tagQuantityBox
            // 
            this.tagQuantityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagQuantityBox.Location = new System.Drawing.Point(895, 170);
            this.tagQuantityBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.tagQuantityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagQuantityBox.Name = "tagQuantityBox";
            this.tagQuantityBox.Size = new System.Drawing.Size(70, 31);
            this.tagQuantityBox.TabIndex = 13;
            this.tagQuantityBox.TabStop = false;
            this.tagQuantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // queuedPlatesListView
            // 
            this.queuedPlatesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TagContents,
            this.Quantity});
            this.queuedPlatesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queuedPlatesListView.FullRowSelect = true;
            this.queuedPlatesListView.GridLines = true;
            this.queuedPlatesListView.HideSelection = false;
            this.queuedPlatesListView.Location = new System.Drawing.Point(224, 354);
            this.queuedPlatesListView.Name = "queuedPlatesListView";
            this.queuedPlatesListView.Size = new System.Drawing.Size(1233, 280);
            this.queuedPlatesListView.TabIndex = 14;
            this.queuedPlatesListView.TabStop = false;
            this.queuedPlatesListView.UseCompatibleStateImageBehavior = false;
            this.queuedPlatesListView.View = System.Windows.Forms.View.Details;
            this.queuedPlatesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.queuedPlatesListView_DoubleClicked);
            // 
            // TagContents
            // 
            this.TagContents.Text = "Tag Contents";
            this.TagContents.Width = 1100;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 110;
            // 
            // queueLabel
            // 
            this.queueLabel.AutoSize = true;
            this.queueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queueLabel.Location = new System.Drawing.Point(230, 326);
            this.queueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.queueLabel.Name = "queueLabel";
            this.queueLabel.Size = new System.Drawing.Size(187, 25);
            this.queueLabel.TabIndex = 15;
            this.queueLabel.Text = "Currently Queued:";
            // 
            // clearQueueBtn
            // 
            this.clearQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearQueueBtn.Location = new System.Drawing.Point(830, 650);
            this.clearQueueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearQueueBtn.Name = "clearQueueBtn";
            this.clearQueueBtn.Size = new System.Drawing.Size(158, 36);
            this.clearQueueBtn.TabIndex = 16;
            this.clearQueueBtn.TabStop = false;
            this.clearQueueBtn.Text = "Clear Queue";
            this.clearQueueBtn.UseVisualStyleBackColor = true;
            this.clearQueueBtn.Click += new System.EventHandler(this.clearQueueBtn_Click);
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.LimeGreen;
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Location = new System.Drawing.Point(1016, 120);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(382, 199);
            this.statusPanel.TabIndex = 17;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(382, 199);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "READY";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // jigIndicator0
            // 
            this.jigIndicator0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator0.BackColor = System.Drawing.Color.LimeGreen;
            this.jigIndicator0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator0.Location = new System.Drawing.Point(4, 4);
            this.jigIndicator0.Name = "jigIndicator0";
            this.jigIndicator0.Size = new System.Drawing.Size(92, 55);
            this.jigIndicator0.TabIndex = 20;
            this.jigIndicator0.Click += new System.EventHandler(this.jigIndicator0_Click);
            // 
            // jigIndicatorTableLayoutPanel
            // 
            this.jigIndicatorTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.jigIndicatorTableLayoutPanel.ColumnCount = 2;
            this.jigIndicatorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.jigIndicatorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator7, 1, 3);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator6, 1, 2);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator5, 1, 1);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator4, 1, 0);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator0, 0, 0);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator1, 0, 1);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator2, 0, 2);
            this.jigIndicatorTableLayoutPanel.Controls.Add(this.jigIndicator3, 0, 3);
            this.jigIndicatorTableLayoutPanel.Location = new System.Drawing.Point(216, 74);
            this.jigIndicatorTableLayoutPanel.Name = "jigIndicatorTableLayoutPanel";
            this.jigIndicatorTableLayoutPanel.RowCount = 4;
            this.jigIndicatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.jigIndicatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.jigIndicatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.jigIndicatorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.jigIndicatorTableLayoutPanel.Size = new System.Drawing.Size(200, 250);
            this.jigIndicatorTableLayoutPanel.TabIndex = 24;
            // 
            // jigIndicator7
            // 
            this.jigIndicator7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator7.Location = new System.Drawing.Point(103, 190);
            this.jigIndicator7.Name = "jigIndicator7";
            this.jigIndicator7.Size = new System.Drawing.Size(93, 56);
            this.jigIndicator7.TabIndex = 25;
            this.jigIndicator7.Click += new System.EventHandler(this.jigIndicator7_Click);
            // 
            // jigIndicator6
            // 
            this.jigIndicator6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator6.Location = new System.Drawing.Point(103, 128);
            this.jigIndicator6.Name = "jigIndicator6";
            this.jigIndicator6.Size = new System.Drawing.Size(93, 55);
            this.jigIndicator6.TabIndex = 24;
            this.jigIndicator6.Click += new System.EventHandler(this.jigIndicator6_Click);
            // 
            // jigIndicator5
            // 
            this.jigIndicator5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator5.Location = new System.Drawing.Point(103, 66);
            this.jigIndicator5.Name = "jigIndicator5";
            this.jigIndicator5.Size = new System.Drawing.Size(93, 55);
            this.jigIndicator5.TabIndex = 23;
            this.jigIndicator5.Click += new System.EventHandler(this.jigIndicator5_Click);
            // 
            // jigIndicator4
            // 
            this.jigIndicator4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator4.Location = new System.Drawing.Point(103, 4);
            this.jigIndicator4.Name = "jigIndicator4";
            this.jigIndicator4.Size = new System.Drawing.Size(93, 55);
            this.jigIndicator4.TabIndex = 22;
            this.jigIndicator4.Click += new System.EventHandler(this.jigIndicator4_Click);
            // 
            // jigIndicator1
            // 
            this.jigIndicator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator1.Location = new System.Drawing.Point(4, 66);
            this.jigIndicator1.Name = "jigIndicator1";
            this.jigIndicator1.Size = new System.Drawing.Size(92, 55);
            this.jigIndicator1.TabIndex = 21;
            this.jigIndicator1.Click += new System.EventHandler(this.jigIndicator1_Click);
            // 
            // jigIndicator2
            // 
            this.jigIndicator2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator2.Location = new System.Drawing.Point(4, 128);
            this.jigIndicator2.Name = "jigIndicator2";
            this.jigIndicator2.Size = new System.Drawing.Size(92, 55);
            this.jigIndicator2.TabIndex = 22;
            this.jigIndicator2.Click += new System.EventHandler(this.jigIndicator2_Click);
            // 
            // jigIndicator3
            // 
            this.jigIndicator3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jigIndicator3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jigIndicator3.Location = new System.Drawing.Point(4, 190);
            this.jigIndicator3.Name = "jigIndicator3";
            this.jigIndicator3.Size = new System.Drawing.Size(92, 56);
            this.jigIndicator3.TabIndex = 23;
            this.jigIndicator3.Click += new System.EventHandler(this.jigIndicator3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Current Jig Position:";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.inputFixingRulesEnabledCheckBox);
            this.panel1.Controls.Add(this.speedDialLabel6);
            this.panel1.Controls.Add(this.speedDialLabel5);
            this.panel1.Controls.Add(this.speedDialLabel4);
            this.panel1.Controls.Add(this.speedDialLabel3);
            this.panel1.Controls.Add(this.speedDialLabel2);
            this.panel1.Controls.Add(this.speedDialLabel1);
            this.panel1.Controls.Add(this.loadSlot6Button);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.saveSlot6Button);
            this.panel1.Controls.Add(this.loadSlot5Button);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.saveSlot5Button);
            this.panel1.Controls.Add(this.loadSlot4Button);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.saveSlot4Button);
            this.panel1.Controls.Add(this.loadSlot3Button);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.saveSlot3Button);
            this.panel1.Controls.Add(this.loadSlot2Button);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.saveSlot2Button);
            this.panel1.Controls.Add(this.loadSlot1Button);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.saveSlot1Button);
            this.panel1.Controls.Add(this.resetConnectionButton);
            this.panel1.Controls.Add(this.deleteSelectedBtn);
            this.panel1.Controls.Add(this.addToTopOfQueueBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.queueLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.statusPanel);
            this.panel1.Controls.Add(this.tag1Line0Box);
            this.panel1.Controls.Add(this.jigIndicatorTableLayoutPanel);
            this.panel1.Controls.Add(this.tag1Line1Box);
            this.panel1.Controls.Add(this.tag1Line2Box);
            this.panel1.Controls.Add(this.tag1Line3Box);
            this.panel1.Controls.Add(this.clearQueueBtn);
            this.panel1.Controls.Add(this.settingsBtn);
            this.panel1.Controls.Add(this.clearTagBtn);
            this.panel1.Controls.Add(this.queuedPlatesListView);
            this.panel1.Controls.Add(this.homeButton);
            this.panel1.Controls.Add(this.tagQuantityBox);
            this.panel1.Controls.Add(this.quantityLabel);
            this.panel1.Controls.Add(this.addToQueueBtn);
            this.panel1.Controls.Add(this.labelAboveJig);
            this.panel1.Controls.Add(this.printQueueBtn);
            this.panel1.Controls.Add(this.jigLabel);
            this.panel1.Location = new System.Drawing.Point(118, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1668, 700);
            this.panel1.TabIndex = 26;
            // 
            // inputFixingRulesEnabledCheckBox
            // 
            this.inputFixingRulesEnabledCheckBox.AutoSize = true;
            this.inputFixingRulesEnabledCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputFixingRulesEnabledCheckBox.Checked = true;
            this.inputFixingRulesEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inputFixingRulesEnabledCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFixingRulesEnabledCheckBox.Location = new System.Drawing.Point(592, 78);
            this.inputFixingRulesEnabledCheckBox.Name = "inputFixingRulesEnabledCheckBox";
            this.inputFixingRulesEnabledCheckBox.Size = new System.Drawing.Size(203, 28);
            this.inputFixingRulesEnabledCheckBox.TabIndex = 65;
            this.inputFixingRulesEnabledCheckBox.Text = "Input Fixing Enabled";
            this.inputFixingRulesEnabledCheckBox.UseVisualStyleBackColor = false;
            this.inputFixingRulesEnabledCheckBox.CheckedChanged += new System.EventHandler(this.inputFixingRulesEnabledCheckBox_CheckedChanged);
            // 
            // speedDialLabel6
            // 
            this.speedDialLabel6.AutoSize = true;
            this.speedDialLabel6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDialLabel6.Location = new System.Drawing.Point(4, 370);
            this.speedDialLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedDialLabel6.Name = "speedDialLabel6";
            this.speedDialLabel6.Size = new System.Drawing.Size(16, 18);
            this.speedDialLabel6.TabIndex = 64;
            this.speedDialLabel6.Text = ".";
            // 
            // speedDialLabel5
            // 
            this.speedDialLabel5.AutoSize = true;
            this.speedDialLabel5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDialLabel5.Location = new System.Drawing.Point(4, 310);
            this.speedDialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedDialLabel5.Name = "speedDialLabel5";
            this.speedDialLabel5.Size = new System.Drawing.Size(16, 18);
            this.speedDialLabel5.TabIndex = 63;
            this.speedDialLabel5.Text = ".";
            // 
            // speedDialLabel4
            // 
            this.speedDialLabel4.AutoSize = true;
            this.speedDialLabel4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDialLabel4.Location = new System.Drawing.Point(4, 251);
            this.speedDialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedDialLabel4.Name = "speedDialLabel4";
            this.speedDialLabel4.Size = new System.Drawing.Size(16, 18);
            this.speedDialLabel4.TabIndex = 62;
            this.speedDialLabel4.Text = ".";
            // 
            // speedDialLabel3
            // 
            this.speedDialLabel3.AutoSize = true;
            this.speedDialLabel3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDialLabel3.Location = new System.Drawing.Point(4, 191);
            this.speedDialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedDialLabel3.Name = "speedDialLabel3";
            this.speedDialLabel3.Size = new System.Drawing.Size(16, 18);
            this.speedDialLabel3.TabIndex = 61;
            this.speedDialLabel3.Text = ".";
            // 
            // speedDialLabel2
            // 
            this.speedDialLabel2.AutoSize = true;
            this.speedDialLabel2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDialLabel2.Location = new System.Drawing.Point(4, 131);
            this.speedDialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedDialLabel2.Name = "speedDialLabel2";
            this.speedDialLabel2.Size = new System.Drawing.Size(16, 18);
            this.speedDialLabel2.TabIndex = 60;
            this.speedDialLabel2.Text = ".";
            // 
            // speedDialLabel1
            // 
            this.speedDialLabel1.AutoSize = true;
            this.speedDialLabel1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDialLabel1.Location = new System.Drawing.Point(4, 72);
            this.speedDialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedDialLabel1.Name = "speedDialLabel1";
            this.speedDialLabel1.Size = new System.Drawing.Size(16, 18);
            this.speedDialLabel1.TabIndex = 59;
            this.speedDialLabel1.Text = ".";
            // 
            // loadSlot6Button
            // 
            this.loadSlot6Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSlot6Button.Location = new System.Drawing.Point(110, 390);
            this.loadSlot6Button.Margin = new System.Windows.Forms.Padding(2);
            this.loadSlot6Button.Name = "loadSlot6Button";
            this.loadSlot6Button.Size = new System.Drawing.Size(70, 38);
            this.loadSlot6Button.TabIndex = 49;
            this.loadSlot6Button.TabStop = false;
            this.loadSlot6Button.Text = "Load";
            this.loadSlot6Button.UseVisualStyleBackColor = true;
            this.loadSlot6Button.Click += new System.EventHandler(this.loadSlot6Button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 397);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 25);
            this.label8.TabIndex = 48;
            this.label8.Text = "6:";
            // 
            // saveSlot6Button
            // 
            this.saveSlot6Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlot6Button.Location = new System.Drawing.Point(36, 390);
            this.saveSlot6Button.Margin = new System.Windows.Forms.Padding(2);
            this.saveSlot6Button.Name = "saveSlot6Button";
            this.saveSlot6Button.Size = new System.Drawing.Size(70, 38);
            this.saveSlot6Button.TabIndex = 47;
            this.saveSlot6Button.TabStop = false;
            this.saveSlot6Button.Text = "Save";
            this.saveSlot6Button.UseVisualStyleBackColor = true;
            this.saveSlot6Button.Click += new System.EventHandler(this.saveSlot6Button_Click);
            // 
            // loadSlot5Button
            // 
            this.loadSlot5Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSlot5Button.Location = new System.Drawing.Point(110, 330);
            this.loadSlot5Button.Margin = new System.Windows.Forms.Padding(2);
            this.loadSlot5Button.Name = "loadSlot5Button";
            this.loadSlot5Button.Size = new System.Drawing.Size(70, 38);
            this.loadSlot5Button.TabIndex = 46;
            this.loadSlot5Button.TabStop = false;
            this.loadSlot5Button.Text = "Load";
            this.loadSlot5Button.UseVisualStyleBackColor = true;
            this.loadSlot5Button.Click += new System.EventHandler(this.loadSlot5Button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 337);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 25);
            this.label7.TabIndex = 45;
            this.label7.Text = "5:";
            // 
            // saveSlot5Button
            // 
            this.saveSlot5Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlot5Button.Location = new System.Drawing.Point(36, 330);
            this.saveSlot5Button.Margin = new System.Windows.Forms.Padding(2);
            this.saveSlot5Button.Name = "saveSlot5Button";
            this.saveSlot5Button.Size = new System.Drawing.Size(70, 38);
            this.saveSlot5Button.TabIndex = 44;
            this.saveSlot5Button.TabStop = false;
            this.saveSlot5Button.Text = "Save";
            this.saveSlot5Button.UseVisualStyleBackColor = true;
            this.saveSlot5Button.Click += new System.EventHandler(this.saveSlot5Button_Click);
            // 
            // loadSlot4Button
            // 
            this.loadSlot4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSlot4Button.Location = new System.Drawing.Point(110, 271);
            this.loadSlot4Button.Margin = new System.Windows.Forms.Padding(2);
            this.loadSlot4Button.Name = "loadSlot4Button";
            this.loadSlot4Button.Size = new System.Drawing.Size(70, 38);
            this.loadSlot4Button.TabIndex = 43;
            this.loadSlot4Button.TabStop = false;
            this.loadSlot4Button.Text = "Load";
            this.loadSlot4Button.UseVisualStyleBackColor = true;
            this.loadSlot4Button.Click += new System.EventHandler(this.loadSlot4Button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 25);
            this.label6.TabIndex = 42;
            this.label6.Text = "4:";
            // 
            // saveSlot4Button
            // 
            this.saveSlot4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlot4Button.Location = new System.Drawing.Point(36, 271);
            this.saveSlot4Button.Margin = new System.Windows.Forms.Padding(2);
            this.saveSlot4Button.Name = "saveSlot4Button";
            this.saveSlot4Button.Size = new System.Drawing.Size(70, 38);
            this.saveSlot4Button.TabIndex = 41;
            this.saveSlot4Button.TabStop = false;
            this.saveSlot4Button.Text = "Save";
            this.saveSlot4Button.UseVisualStyleBackColor = true;
            this.saveSlot4Button.Click += new System.EventHandler(this.saveSlot4Button_Click);
            // 
            // loadSlot3Button
            // 
            this.loadSlot3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSlot3Button.Location = new System.Drawing.Point(110, 211);
            this.loadSlot3Button.Margin = new System.Windows.Forms.Padding(2);
            this.loadSlot3Button.Name = "loadSlot3Button";
            this.loadSlot3Button.Size = new System.Drawing.Size(70, 38);
            this.loadSlot3Button.TabIndex = 40;
            this.loadSlot3Button.TabStop = false;
            this.loadSlot3Button.Text = "Load";
            this.loadSlot3Button.UseVisualStyleBackColor = true;
            this.loadSlot3Button.Click += new System.EventHandler(this.loadSlot3Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 25);
            this.label5.TabIndex = 39;
            this.label5.Text = "3:";
            // 
            // saveSlot3Button
            // 
            this.saveSlot3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlot3Button.Location = new System.Drawing.Point(36, 211);
            this.saveSlot3Button.Margin = new System.Windows.Forms.Padding(2);
            this.saveSlot3Button.Name = "saveSlot3Button";
            this.saveSlot3Button.Size = new System.Drawing.Size(70, 38);
            this.saveSlot3Button.TabIndex = 38;
            this.saveSlot3Button.TabStop = false;
            this.saveSlot3Button.Text = "Save";
            this.saveSlot3Button.UseVisualStyleBackColor = true;
            this.saveSlot3Button.Click += new System.EventHandler(this.saveSlot3Button_Click);
            // 
            // loadSlot2Button
            // 
            this.loadSlot2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSlot2Button.Location = new System.Drawing.Point(110, 151);
            this.loadSlot2Button.Margin = new System.Windows.Forms.Padding(2);
            this.loadSlot2Button.Name = "loadSlot2Button";
            this.loadSlot2Button.Size = new System.Drawing.Size(70, 38);
            this.loadSlot2Button.TabIndex = 37;
            this.loadSlot2Button.TabStop = false;
            this.loadSlot2Button.Text = "Load";
            this.loadSlot2Button.UseVisualStyleBackColor = true;
            this.loadSlot2Button.Click += new System.EventHandler(this.loadSlot2Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "2:";
            // 
            // saveSlot2Button
            // 
            this.saveSlot2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlot2Button.Location = new System.Drawing.Point(36, 151);
            this.saveSlot2Button.Margin = new System.Windows.Forms.Padding(2);
            this.saveSlot2Button.Name = "saveSlot2Button";
            this.saveSlot2Button.Size = new System.Drawing.Size(70, 38);
            this.saveSlot2Button.TabIndex = 35;
            this.saveSlot2Button.TabStop = false;
            this.saveSlot2Button.Text = "Save";
            this.saveSlot2Button.UseVisualStyleBackColor = true;
            this.saveSlot2Button.Click += new System.EventHandler(this.saveSlot2Button_Click);
            // 
            // loadSlot1Button
            // 
            this.loadSlot1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSlot1Button.Location = new System.Drawing.Point(110, 92);
            this.loadSlot1Button.Margin = new System.Windows.Forms.Padding(2);
            this.loadSlot1Button.Name = "loadSlot1Button";
            this.loadSlot1Button.Size = new System.Drawing.Size(70, 38);
            this.loadSlot1Button.TabIndex = 34;
            this.loadSlot1Button.TabStop = false;
            this.loadSlot1Button.Text = "Load";
            this.loadSlot1Button.UseVisualStyleBackColor = true;
            this.loadSlot1Button.Click += new System.EventHandler(this.loadSlot1Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 33;
            this.label3.Text = "1:";
            // 
            // saveSlot1Button
            // 
            this.saveSlot1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlot1Button.Location = new System.Drawing.Point(36, 92);
            this.saveSlot1Button.Margin = new System.Windows.Forms.Padding(2);
            this.saveSlot1Button.Name = "saveSlot1Button";
            this.saveSlot1Button.Size = new System.Drawing.Size(70, 38);
            this.saveSlot1Button.TabIndex = 32;
            this.saveSlot1Button.TabStop = false;
            this.saveSlot1Button.Text = "Save";
            this.saveSlot1Button.UseVisualStyleBackColor = true;
            this.saveSlot1Button.Click += new System.EventHandler(this.saveSlot1Button_Click);
            // 
            // resetConnectionButton
            // 
            this.resetConnectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetConnectionButton.Location = new System.Drawing.Point(716, 309);
            this.resetConnectionButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetConnectionButton.Name = "resetConnectionButton";
            this.resetConnectionButton.Size = new System.Drawing.Size(282, 38);
            this.resetConnectionButton.TabIndex = 31;
            this.resetConnectionButton.TabStop = false;
            this.resetConnectionButton.Text = "Reset Machine Connection";
            this.resetConnectionButton.UseVisualStyleBackColor = true;
            this.resetConnectionButton.Click += new System.EventHandler(this.resetConnectionButton_Click);
            // 
            // deleteSelectedBtn
            // 
            this.deleteSelectedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSelectedBtn.Location = new System.Drawing.Point(1150, 650);
            this.deleteSelectedBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteSelectedBtn.Name = "deleteSelectedBtn";
            this.deleteSelectedBtn.Size = new System.Drawing.Size(173, 36);
            this.deleteSelectedBtn.TabIndex = 30;
            this.deleteSelectedBtn.TabStop = false;
            this.deleteSelectedBtn.Text = "Delete Selected";
            this.deleteSelectedBtn.UseVisualStyleBackColor = true;
            this.deleteSelectedBtn.Click += new System.EventHandler(this.deleteSelectedBtn_Click);
            // 
            // addToTopOfQueueBtn
            // 
            this.addToTopOfQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToTopOfQueueBtn.Location = new System.Drawing.Point(600, 650);
            this.addToTopOfQueueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addToTopOfQueueBtn.Name = "addToTopOfQueueBtn";
            this.addToTopOfQueueBtn.Size = new System.Drawing.Size(226, 36);
            this.addToTopOfQueueBtn.TabIndex = 29;
            this.addToTopOfQueueBtn.TabStop = false;
            this.addToTopOfQueueBtn.Text = "Add to Top of Queue";
            this.addToTopOfQueueBtn.UseVisualStyleBackColor = true;
            this.addToTopOfQueueBtn.Click += new System.EventHandler(this.addToTopOfQueueBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1124, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Current Status:";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(905, 267);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 38);
            this.cancelButton.TabIndex = 26;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // jigLabel
            // 
            this.jigLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jigLabel.Location = new System.Drawing.Point(413, 180);
            this.jigLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.jigLabel.Name = "jigLabel";
            this.jigLabel.Size = new System.Drawing.Size(127, 25);
            this.jigLabel.TabIndex = 28;
            this.jigLabel.Text = "8-Plate";
            this.jigLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1200, 500);
            this.Name = "MAIN_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DU Nameplate GUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagQuantityBox)).EndInit();
            this.statusPanel.ResumeLayout(false);
            this.jigIndicatorTableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tag1Line0Box;
        private System.Windows.Forms.TextBox tag1Line1Box;
        private System.Windows.Forms.TextBox tag1Line2Box;
        private System.Windows.Forms.TextBox tag1Line3Box;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button clearTagBtn;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label labelAboveJig;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button printQueueBtn;
        private System.Windows.Forms.Button addToQueueBtn;
        private System.Windows.Forms.NumericUpDown tagQuantityBox;
        private System.Windows.Forms.ListView queuedPlatesListView;
        private System.Windows.Forms.ColumnHeader TagContents;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Label queueLabel;
        private System.Windows.Forms.Button clearQueueBtn;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Panel jigIndicator0;
        private System.Windows.Forms.TableLayoutPanel jigIndicatorTableLayoutPanel;
        private System.Windows.Forms.Panel jigIndicator1;
        private System.Windows.Forms.Panel jigIndicator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label jigLabel;
        private System.Windows.Forms.Button addToTopOfQueueBtn;
        private System.Windows.Forms.Panel jigIndicator3;
        private System.Windows.Forms.Panel jigIndicator7;
        private System.Windows.Forms.Panel jigIndicator6;
        private System.Windows.Forms.Panel jigIndicator5;
        private System.Windows.Forms.Panel jigIndicator4;
        private System.Windows.Forms.Button deleteSelectedBtn;
        private System.Windows.Forms.Button resetConnectionButton;
        private System.Windows.Forms.Button saveSlot1Button;
        private System.Windows.Forms.Button loadSlot2Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveSlot2Button;
        private System.Windows.Forms.Button loadSlot1Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadSlot6Button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button saveSlot6Button;
        private System.Windows.Forms.Button loadSlot5Button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveSlot5Button;
        private System.Windows.Forms.Button loadSlot4Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveSlot4Button;
        private System.Windows.Forms.Button loadSlot3Button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveSlot3Button;
        private System.Windows.Forms.Label speedDialLabel1;
        private System.Windows.Forms.Label speedDialLabel2;
        private System.Windows.Forms.Label speedDialLabel4;
        private System.Windows.Forms.Label speedDialLabel3;
        private System.Windows.Forms.Label speedDialLabel6;
        private System.Windows.Forms.Label speedDialLabel5;
        private System.Windows.Forms.CheckBox inputFixingRulesEnabledCheckBox;
    }
}

