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
            this.printTagsBtn = new System.Windows.Forms.Button();
            this.tag1Line0Box = new System.Windows.Forms.TextBox();
            this.tag1Line1Box = new System.Windows.Forms.TextBox();
            this.tag1Line2Box = new System.Windows.Forms.TextBox();
            this.tag1Line3Box = new System.Windows.Forms.TextBox();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.clearTagBtn = new System.Windows.Forms.Button();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.JigComboBox = new System.Windows.Forms.ComboBox();
            this.JigLabel = new System.Windows.Forms.Label();
            this.homeButton = new System.Windows.Forms.Button();
            this.printQueueBtn = new System.Windows.Forms.Button();
            this.addToQueueBtn = new System.Windows.Forms.Button();
            this.tagQuantityBox = new System.Windows.Forms.NumericUpDown();
            this.queuedPlatesList = new System.Windows.Forms.ListView();
            this.TagContents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.queueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tagQuantityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // printTagsBtn
            // 
            this.printTagsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printTagsBtn.Location = new System.Drawing.Point(502, 158);
            this.printTagsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printTagsBtn.Name = "printTagsBtn";
            this.printTagsBtn.Size = new System.Drawing.Size(97, 28);
            this.printTagsBtn.TabIndex = 0;
            this.printTagsBtn.Text = "Print Tags";
            this.printTagsBtn.UseVisualStyleBackColor = true;
            this.printTagsBtn.Click += new System.EventHandler(this.printTagsBtn_Click);
            // 
            // tag1Line0Box
            // 
            this.tag1Line0Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line0Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line0Box.Location = new System.Drawing.Point(160, 24);
            this.tag1Line0Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line0Box.Name = "tag1Line0Box";
            this.tag1Line0Box.Size = new System.Drawing.Size(346, 26);
            this.tag1Line0Box.TabIndex = 2;
            this.tag1Line0Box.TextChanged += new System.EventHandler(this.tag1Line0Box_TextChanged);
            // 
            // tag1Line1Box
            // 
            this.tag1Line1Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line1Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line1Box.Location = new System.Drawing.Point(180, 54);
            this.tag1Line1Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line1Box.Name = "tag1Line1Box";
            this.tag1Line1Box.Size = new System.Drawing.Size(303, 26);
            this.tag1Line1Box.TabIndex = 3;
            this.tag1Line1Box.TextChanged += new System.EventHandler(this.tag1Line1Box_TextChanged);
            // 
            // tag1Line2Box
            // 
            this.tag1Line2Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line2Box.Location = new System.Drawing.Point(180, 83);
            this.tag1Line2Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line2Box.Name = "tag1Line2Box";
            this.tag1Line2Box.Size = new System.Drawing.Size(303, 26);
            this.tag1Line2Box.TabIndex = 4;
            this.tag1Line2Box.TextChanged += new System.EventHandler(this.tag1Line2Box_TextChanged);
            // 
            // tag1Line3Box
            // 
            this.tag1Line3Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line3Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line3Box.Location = new System.Drawing.Point(160, 112);
            this.tag1Line3Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line3Box.Name = "tag1Line3Box";
            this.tag1Line3Box.Size = new System.Drawing.Size(346, 26);
            this.tag1Line3Box.TabIndex = 5;
            this.tag1Line3Box.TextChanged += new System.EventHandler(this.tag1Line3Box_TextChanged);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.Location = new System.Drawing.Point(45, 158);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(77, 29);
            this.settingsBtn.TabIndex = 6;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // clearTagBtn
            // 
            this.clearTagBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTagBtn.Location = new System.Drawing.Point(405, 158);
            this.clearTagBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearTagBtn.Name = "clearTagBtn";
            this.clearTagBtn.Size = new System.Drawing.Size(77, 28);
            this.clearTagBtn.TabIndex = 7;
            this.clearTagBtn.Text = "Clear";
            this.clearTagBtn.UseVisualStyleBackColor = true;
            this.clearTagBtn.Click += new System.EventHandler(this.clearTagBtn_Click);
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(527, 41);
            this.quantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(72, 20);
            this.quantityLabel.TabIndex = 8;
            this.quantityLabel.Text = "Quantity:";
            // 
            // JigComboBox
            // 
            this.JigComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JigComboBox.FormattingEnabled = true;
            this.JigComboBox.Items.AddRange(new object[] {
            "1-Plate",
            "2-Plate",
            "4-Plate",
            "8-Plate"});
            this.JigComboBox.Location = new System.Drawing.Point(45, 64);
            this.JigComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.JigComboBox.Name = "JigComboBox";
            this.JigComboBox.Size = new System.Drawing.Size(92, 28);
            this.JigComboBox.TabIndex = 10;
            this.JigComboBox.DropDownClosed += new System.EventHandler(this.JigComboBox_DropDownClosed);
            // 
            // JigLabel
            // 
            this.JigLabel.AutoSize = true;
            this.JigLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JigLabel.Location = new System.Drawing.Point(76, 41);
            this.JigLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.JigLabel.Name = "JigLabel";
            this.JigLabel.Size = new System.Drawing.Size(33, 20);
            this.JigLabel.TabIndex = 8;
            this.JigLabel.Text = "Jig:";
            // 
            // homeButton
            // 
            this.homeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.Location = new System.Drawing.Point(307, 158);
            this.homeButton.Margin = new System.Windows.Forms.Padding(2);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(77, 28);
            this.homeButton.TabIndex = 7;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // printQueueBtn
            // 
            this.printQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printQueueBtn.Location = new System.Drawing.Point(487, 200);
            this.printQueueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printQueueBtn.Name = "printQueueBtn";
            this.printQueueBtn.Size = new System.Drawing.Size(112, 28);
            this.printQueueBtn.TabIndex = 11;
            this.printQueueBtn.Text = "Print Queue";
            this.printQueueBtn.UseVisualStyleBackColor = true;
            this.printQueueBtn.Click += new System.EventHandler(this.printQueueBtn_Click);
            // 
            // addToQueueBtn
            // 
            this.addToQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToQueueBtn.Location = new System.Drawing.Point(344, 200);
            this.addToQueueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addToQueueBtn.Name = "addToQueueBtn";
            this.addToQueueBtn.Size = new System.Drawing.Size(129, 28);
            this.addToQueueBtn.TabIndex = 12;
            this.addToQueueBtn.Text = "Add to Queue";
            this.addToQueueBtn.UseVisualStyleBackColor = true;
            this.addToQueueBtn.Click += new System.EventHandler(this.addToQueueBtn_Click);
            // 
            // tagQuantityBox
            // 
            this.tagQuantityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagQuantityBox.Location = new System.Drawing.Point(529, 66);
            this.tagQuantityBox.Name = "tagQuantityBox";
            this.tagQuantityBox.Size = new System.Drawing.Size(70, 26);
            this.tagQuantityBox.TabIndex = 13;
            this.tagQuantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // queuedPlatesList
            // 
            this.queuedPlatesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TagContents,
            this.Quantity});
            this.queuedPlatesList.FullRowSelect = true;
            this.queuedPlatesList.GridLines = true;
            this.queuedPlatesList.HideSelection = false;
            this.queuedPlatesList.Location = new System.Drawing.Point(637, 40);
            this.queuedPlatesList.Name = "queuedPlatesList";
            this.queuedPlatesList.Size = new System.Drawing.Size(206, 204);
            this.queuedPlatesList.TabIndex = 14;
            this.queuedPlatesList.UseCompatibleStateImageBehavior = false;
            this.queuedPlatesList.View = System.Windows.Forms.View.Details;
            // 
            // TagContents
            // 
            this.TagContents.Text = "Tag Contents";
            this.TagContents.Width = 137;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 57;
            // 
            // queueLabel
            // 
            this.queueLabel.AutoSize = true;
            this.queueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queueLabel.Location = new System.Drawing.Point(674, 17);
            this.queueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.queueLabel.Name = "queueLabel";
            this.queueLabel.Size = new System.Drawing.Size(137, 20);
            this.queueLabel.TabIndex = 15;
            this.queueLabel.Text = "Currently Queued:";
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 256);
            this.Controls.Add(this.queueLabel);
            this.Controls.Add(this.queuedPlatesList);
            this.Controls.Add(this.tagQuantityBox);
            this.Controls.Add(this.addToQueueBtn);
            this.Controls.Add(this.printQueueBtn);
            this.Controls.Add(this.JigComboBox);
            this.Controls.Add(this.JigLabel);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.clearTagBtn);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.tag1Line3Box);
            this.Controls.Add(this.tag1Line2Box);
            this.Controls.Add(this.tag1Line1Box);
            this.Controls.Add(this.tag1Line0Box);
            this.Controls.Add(this.printTagsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MAIN_FORM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " DU Nameplate GUI";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.tagQuantityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printTagsBtn;
        private System.Windows.Forms.TextBox tag1Line0Box;
        private System.Windows.Forms.TextBox tag1Line1Box;
        private System.Windows.Forms.TextBox tag1Line2Box;
        private System.Windows.Forms.TextBox tag1Line3Box;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button clearTagBtn;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.ComboBox JigComboBox;
        private System.Windows.Forms.Label JigLabel;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button printQueueBtn;
        private System.Windows.Forms.Button addToQueueBtn;
        private System.Windows.Forms.NumericUpDown tagQuantityBox;
        private System.Windows.Forms.ListView queuedPlatesList;
        private System.Windows.Forms.ColumnHeader TagContents;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Label queueLabel;
    }
}

