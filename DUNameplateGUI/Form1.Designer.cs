namespace DUNameplateGUI
{
    partial class Form1
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
            this.printTag1Btn = new System.Windows.Forms.Button();
            this.ledBtn = new System.Windows.Forms.Button();
            this.tag1Line1 = new System.Windows.Forms.TextBox();
            this.tag1Line2 = new System.Windows.Forms.TextBox();
            this.tag1Line3 = new System.Windows.Forms.TextBox();
            this.tag1Line4 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // printTag1Btn
            // 
            this.printTag1Btn.Location = new System.Drawing.Point(78, 77);
            this.printTag1Btn.Name = "printTag1Btn";
            this.printTag1Btn.Size = new System.Drawing.Size(103, 28);
            this.printTag1Btn.TabIndex = 0;
            this.printTag1Btn.Text = "Print Tag #1";
            this.printTag1Btn.UseVisualStyleBackColor = true;
            this.printTag1Btn.Click += new System.EventHandler(this.printTag1Btn_Click);
            // 
            // ledBtn
            // 
            this.ledBtn.Location = new System.Drawing.Point(80, 222);
            this.ledBtn.Name = "ledBtn";
            this.ledBtn.Size = new System.Drawing.Size(101, 28);
            this.ledBtn.TabIndex = 1;
            this.ledBtn.Text = "Toggle LED";
            this.ledBtn.UseVisualStyleBackColor = true;
            this.ledBtn.Click += new System.EventHandler(this.ledBtn_Click);
            // 
            // tag1Line1
            // 
            this.tag1Line1.Location = new System.Drawing.Point(214, 38);
            this.tag1Line1.Name = "tag1Line1";
            this.tag1Line1.Size = new System.Drawing.Size(167, 22);
            this.tag1Line1.TabIndex = 2;
            this.tag1Line1.TextChanged += new System.EventHandler(this.tag1Line1_TextChanged);
            // 
            // tag1Line2
            // 
            this.tag1Line2.Location = new System.Drawing.Point(230, 66);
            this.tag1Line2.Name = "tag1Line2";
            this.tag1Line2.Size = new System.Drawing.Size(141, 22);
            this.tag1Line2.TabIndex = 3;
            this.tag1Line2.TextChanged += new System.EventHandler(this.tag1Line2_TextChanged);
            // 
            // tag1Line3
            // 
            this.tag1Line3.Location = new System.Drawing.Point(230, 94);
            this.tag1Line3.Name = "tag1Line3";
            this.tag1Line3.Size = new System.Drawing.Size(141, 22);
            this.tag1Line3.TabIndex = 4;
            this.tag1Line3.TextChanged += new System.EventHandler(this.tag1Line3_TextChanged);
            // 
            // tag1Line4
            // 
            this.tag1Line4.Location = new System.Drawing.Point(214, 122);
            this.tag1Line4.Name = "tag1Line4";
            this.tag1Line4.Size = new System.Drawing.Size(167, 22);
            this.tag1Line4.TabIndex = 5;
            this.tag1Line4.TextChanged += new System.EventHandler(this.tag1Line4_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tag1Line4);
            this.Controls.Add(this.tag1Line3);
            this.Controls.Add(this.tag1Line2);
            this.Controls.Add(this.tag1Line1);
            this.Controls.Add(this.ledBtn);
            this.Controls.Add(this.printTag1Btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printTag1Btn;
        private System.Windows.Forms.Button ledBtn;
        private System.Windows.Forms.TextBox tag1Line1;
        private System.Windows.Forms.TextBox tag1Line2;
        private System.Windows.Forms.TextBox tag1Line3;
        private System.Windows.Forms.TextBox tag1Line4;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

