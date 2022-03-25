namespace DUNameplateGUI
{
    partial class GUI_MAIN_FORM
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
            this.tag1Line1Box = new System.Windows.Forms.TextBox();
            this.tag1Line2Box = new System.Windows.Forms.TextBox();
            this.tag1Line3Box = new System.Windows.Forms.TextBox();
            this.tag1Line4Box = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ledBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // tag1Line1Box
            // 
            this.tag1Line1Box.Location = new System.Drawing.Point(214, 38);
            this.tag1Line1Box.Name = "tag1Line1Box";
            this.tag1Line1Box.Size = new System.Drawing.Size(307, 22);
            this.tag1Line1Box.TabIndex = 2;
            this.tag1Line1Box.TextChanged += new System.EventHandler(this.tag1Line1Box_TextChanged);
            // 
            // tag1Line2Box
            // 
            this.tag1Line2Box.Location = new System.Drawing.Point(240, 66);
            this.tag1Line2Box.Name = "tag1Line2Box";
            this.tag1Line2Box.Size = new System.Drawing.Size(257, 22);
            this.tag1Line2Box.TabIndex = 3;
            this.tag1Line2Box.TextChanged += new System.EventHandler(this.tag1Line2Box_TextChanged);
            // 
            // tag1Line3Box
            // 
            this.tag1Line3Box.Location = new System.Drawing.Point(240, 94);
            this.tag1Line3Box.Name = "tag1Line3Box";
            this.tag1Line3Box.Size = new System.Drawing.Size(257, 22);
            this.tag1Line3Box.TabIndex = 4;
            this.tag1Line3Box.TextChanged += new System.EventHandler(this.tag1Line3Box_TextChanged);
            // 
            // tag1Line4Box
            // 
            this.tag1Line4Box.Location = new System.Drawing.Point(214, 122);
            this.tag1Line4Box.Name = "tag1Line4Box";
            this.tag1Line4Box.Size = new System.Drawing.Size(307, 22);
            this.tag1Line4Box.TabIndex = 5;
            this.tag1Line4Box.TextChanged += new System.EventHandler(this.tag1Line4Box_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM9";
            // 
            // ledBtn
            // 
            this.ledBtn.Location = new System.Drawing.Point(78, 220);
            this.ledBtn.Name = "ledBtn";
            this.ledBtn.Size = new System.Drawing.Size(101, 28);
            this.ledBtn.TabIndex = 1;
            this.ledBtn.Text = "Toggle LED";
            this.ledBtn.UseVisualStyleBackColor = true;
            this.ledBtn.Click += new System.EventHandler(this.ledBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Toggle LED";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 644);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tag1Line4Box);
            this.Controls.Add(this.tag1Line3Box);
            this.Controls.Add(this.tag1Line2Box);
            this.Controls.Add(this.tag1Line1Box);
            this.Controls.Add(this.ledBtn);
            this.Controls.Add(this.printTagsBtn);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printTagsBtn;
        private System.Windows.Forms.TextBox tag1Line1Box;
        private System.Windows.Forms.TextBox tag1Line2Box;
        private System.Windows.Forms.TextBox tag1Line3Box;
        private System.Windows.Forms.TextBox tag1Line4Box;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button ledBtn;
        private System.Windows.Forms.Button button1;
    }
}

