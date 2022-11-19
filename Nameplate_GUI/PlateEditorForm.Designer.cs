namespace DUNameplateGUI
{
    partial class PlateEditorForm
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
            this.tag1Line0Box = new System.Windows.Forms.TextBox();
            this.tag1Line1Box = new System.Windows.Forms.TextBox();
            this.tag1Line2Box = new System.Windows.Forms.TextBox();
            this.tag1Line3Box = new System.Windows.Forms.TextBox();
            this.tagQuantityBox = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tagQuantityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tag1Line0Box
            // 
            this.tag1Line0Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line0Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line0Box.Location = new System.Drawing.Point(11, 11);
            this.tag1Line0Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line0Box.Name = "tag1Line0Box";
            this.tag1Line0Box.Size = new System.Drawing.Size(346, 31);
            this.tag1Line0Box.TabIndex = 14;
            // 
            // tag1Line1Box
            // 
            this.tag1Line1Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line1Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line1Box.Location = new System.Drawing.Point(31, 46);
            this.tag1Line1Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line1Box.Name = "tag1Line1Box";
            this.tag1Line1Box.Size = new System.Drawing.Size(303, 31);
            this.tag1Line1Box.TabIndex = 15;
            // 
            // tag1Line2Box
            // 
            this.tag1Line2Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line2Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line2Box.Location = new System.Drawing.Point(31, 81);
            this.tag1Line2Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line2Box.Name = "tag1Line2Box";
            this.tag1Line2Box.Size = new System.Drawing.Size(303, 31);
            this.tag1Line2Box.TabIndex = 16;
            // 
            // tag1Line3Box
            // 
            this.tag1Line3Box.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tag1Line3Box.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tag1Line3Box.Location = new System.Drawing.Point(11, 116);
            this.tag1Line3Box.Margin = new System.Windows.Forms.Padding(2);
            this.tag1Line3Box.Name = "tag1Line3Box";
            this.tag1Line3Box.Size = new System.Drawing.Size(346, 31);
            this.tag1Line3Box.TabIndex = 17;
            // 
            // tagQuantityBox
            // 
            this.tagQuantityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagQuantityBox.Location = new System.Drawing.Point(386, 61);
            this.tagQuantityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagQuantityBox.Name = "tagQuantityBox";
            this.tagQuantityBox.Size = new System.Drawing.Size(70, 31);
            this.tagQuantityBox.TabIndex = 19;
            this.tagQuantityBox.TabStop = false;
            this.tagQuantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(372, 31);
            this.quantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(98, 25);
            this.quantityLabel.TabIndex = 18;
            this.quantityLabel.Text = "Quantity:";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(169, 152);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(129, 32);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(85, 152);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 32);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // PlateEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 192);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tag1Line0Box);
            this.Controls.Add(this.tag1Line1Box);
            this.Controls.Add(this.tag1Line2Box);
            this.Controls.Add(this.tag1Line3Box);
            this.Controls.Add(this.tagQuantityBox);
            this.Controls.Add(this.quantityLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlateEditorForm";
            this.Load += new System.EventHandler(this.ModifyTagForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagQuantityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tag1Line0Box;
        private System.Windows.Forms.TextBox tag1Line1Box;
        private System.Windows.Forms.TextBox tag1Line2Box;
        private System.Windows.Forms.TextBox tag1Line3Box;
        private System.Windows.Forms.NumericUpDown tagQuantityBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}