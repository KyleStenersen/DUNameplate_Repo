using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class Form1 : Form
    {
        private string tag1Line1Str;

        public Form1()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void tag1Line1_TextChanged(object sender, EventArgs e)
        {
            tag1Line1Str = tag1Line1.Text;

            if (tag1Line1Str.Except("ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz 1234567890 ,/-.#").Any())
            {
                MessageBox.Show("Invalid character; Only A-Z, 1-9, and ,./-# available.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (tag1Line1.TextLength > 23)
            {
                MessageBox.Show("Too many characters; 23 max for line 1", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void printTag1Btn_Click(object sender, EventArgs e)
        {
            tag1Line1Str = tag1Line1Str.ToUpper();
            tag1Line1Str = tag1Line1Str.Replace("+","");
            MessageBox.Show("a" + tag1Line1Str);
            //serialPort1.Write("a" + tag1Line1Str);
        }

        private void ledBtn_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("b");
        }

    }
}
