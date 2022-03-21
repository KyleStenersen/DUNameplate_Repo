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
        private string tag1Line2Str;
        private string tag1Line3Str;
        private string tag1Line4Str;

        public Form1()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void tag1Line1_TextChanged(object sender, EventArgs e)
        {
            tag1Line1Str = tag1Line1.Text;

            checkInvalidChars(ref tag1Line1Str);

            if (tag1Line1Str.Length > 23)
            {
                MessageBox.Show("Too many characters; 23 max", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void tag1Line2_TextChanged(object sender, EventArgs e)
        {
            tag1Line2Str = tag1Line2.Text;

            checkInvalidChars(ref tag1Line2Str);

            if (tag1Line2Str.Length > 19)
            {
                MessageBox.Show("Too many characters; 19 max", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tag1Line3_TextChanged(object sender, EventArgs e)
        {
            tag1Line3Str = tag1Line3.Text;

            checkInvalidChars(ref tag1Line3Str);

            if (tag1Line3Str.Length > 19)
            {
                MessageBox.Show("Too many characters; 19 max", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tag1Line4_TextChanged(object sender, EventArgs e)
        {
            tag1Line4Str = tag1Line4.Text;

            checkInvalidChars(ref tag1Line4Str);

            if (tag1Line4Str.Length > 23)
            {
                MessageBox.Show("Too many characters; 23 max", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void printTag1Btn_Click(object sender, EventArgs e)
        {           
            tag1Line1Str = tag1Line1Str.ToUpper();
            tag1Line1Str = tag1Line1Str.Replace("+","");

            tag1Line2Str = tag1Line2Str.ToUpper();
            tag1Line2Str = tag1Line2Str.Replace("+", "");
            tag1Line2Str = reverseLine(ref tag1Line2Str);

            tag1Line3Str = tag1Line3Str.ToUpper();
            tag1Line3Str = tag1Line3Str.Replace("+", "");

            tag1Line4Str = tag1Line4Str.ToUpper();
            tag1Line4Str = tag1Line4Str.Replace("+", "");
            tag1Line4Str = reverseLine(ref tag1Line4Str);

            string tag1Text = ("a" + tag1Line1Str + tag1Line2Str + tag1Line3Str + tag1Line4Str);

            if (checkInvalidChars(ref tag1Text) == true)
            {
                //fail
                return;
            }

            MessageBox.Show(tag1Text);
            //serialPort1.Write("a" + tag1Line1Str);
        }

        private void ledBtn_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("b");
        }

       
        // SUPPORT FUNCTIONS ------------------------------------

        private Boolean checkInvalidChars(ref string checkStr)
        {
            
            if (checkStr.Except("ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz 1234567890 ,/-.#").Any())
            {
                MessageBox.Show("Invalid character; Only A-Z, 1-9, and ,./-# available.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;            
            }
            
            return false;

        }
        private static string reverseLine(ref string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
