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
        private string tag1Line1String;
        private string tag1Line2String;
        private string tag1Line3String;
        private string tag1Line4String;

        public Form1()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            redTextBoxIfInputError(ref tag1Line1String, ref tag1Line1Box);
        }

        private void tag1Line2_TextChanged(object sender, EventArgs e)
        {
            tag1Line2String = tag1Line2.Text;

            if (checkInvalidChars(ref tag1Line2String) == true || errorIfTooLong(ref tag1Line2String, 2) == true)
            {
                tag1Line2.BackColor = Color.MistyRose;
            }
            else
            {
                tag1Line2.BackColor = Color.White;
            }
        }

        private void tag1Line3_TextChanged(object sender, EventArgs e)
        {
            tag1Line3String = tag1Line3.Text;

            if (checkInvalidChars(ref tag1Line3String) == true || errorIfTooLong(ref tag1Line3String, 3) == true)
            {
                tag1Line3.BackColor = Color.MistyRose;
            }
            else
            {
                tag1Line3.BackColor = Color.White;
            }
        }

        private void tag1Line4_TextChanged(object sender, EventArgs e)
        {
            tag1Line4String = tag1Line4.Text;

            if (checkInvalidChars(ref tag1Line4String) == true || errorIfTooLong(ref tag1Line4String, 4) == true)
            {
                tag1Line4.BackColor = Color.MistyRose;
            }
            else
            {
                tag1Line4.BackColor = Color.White;
            }
        }

        private void printTagsBtn_Click(object sender, EventArgs e)
        {

            tag1Line1String = tag1Line1Box.Text;
            tag1Line2String = tag1Line2.Text;
            tag1Line3String = tag1Line3.Text;
            tag1Line4String = tag1Line4.Text;

            if (checkAllLinesForErrors() == true)
            {
                return;
            }

            addNewLineChar(ref tag1Line1String);

            addNewLineCharAndReverse(ref tag1Line2String);

            addNewLineChar(ref tag1Line3String);

            addNewLineCharAndReverse(ref tag1Line4String);

            string tag1Text = (tag1Line1String + tag1Line2String + tag1Line3String + tag1Line4String);

            tag1Text = tag1Text.ToUpper();
            tag1Text = ("<" + "a" + tag1Text + ">");


            MessageBox.Show(tag1Text);
            //serialPort1.Write(tag1Text);

            tag1Line1String = null;
            tag1Line2String = null;
            tag1Line3String = null;
            tag1Line4String = null;
        }

        private void ledBtn_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("b");
        }

       
        // SUPPORT FUNCTIONS ------------------------------------

        void redTextBoxIfInputError(ref string currentTagLineStr, ref TextBox currentTextBox)
        {
            currentTagLineStr = currentTextBox.Text;

            if (checkInvalidChars(ref currentTagLineStr) == true || errorIfTooLong(ref currentTagLineStr, 1) == true)
            {
                currentTextBox.BackColor = Color.MistyRose;
            }
            else
            {
                currentTextBox.BackColor = Color.White;
            }
        }

        private Boolean checkInvalidChars(ref string checkStr)
        {
            
            if (checkStr.Except("ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz 1234567890 ,/-.#").Any())
            {
                return true;            
            }
            
            return false;

        }
        private void reverseLine(ref string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            s = new string(charArray);
        }

        private Boolean errorIfTooLong(ref string s, int lineNum)
        {

            if (lineNum == 1 || lineNum == 4)
            {

                if (s != null && s.Length > 23)
                {
                    return true;
                }
            }

            if (lineNum == 2 || lineNum == 3)
            {
                if (s != null && s.Length > 19)
                {
                    //MessageBox.Show("Too many characters in line# " + lineNum + "; 19 max", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            return false;

        }

        Boolean checkAllLinesForTooLong()
        {
            if (errorIfTooLong(ref tag1Line1String, 1) == true || errorIfTooLong(ref tag1Line2String, 2) == true || errorIfTooLong(ref tag1Line3String, 3) == true || errorIfTooLong(ref tag1Line4String, 4) == true)
            {
                //error out
                MessageBox.Show("Tag line too long", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        Boolean checkAllLinesForInvalidChars()
        {
            string tag1TextTester = (tag1Line1String + tag1Line2String + tag1Line3String + tag1Line4String);
            if (checkInvalidChars(ref tag1TextTester) == true)
            {
                //error out
                MessageBox.Show("Invalid character; Only A-Z, 1-9, and ,./-# available.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
     
            return false; 
        }

        Boolean checkForAllLinesEmpty()
        {
            if (String.IsNullOrWhiteSpace(tag1Line1String) && String.IsNullOrWhiteSpace(tag1Line2String) && String.IsNullOrWhiteSpace(tag1Line3String) && String.IsNullOrWhiteSpace(tag1Line4String))
            {
                //error out
                return true;
            }

            return false;
        }

        void addNewLineChar(ref string tagLineStr)
        {
            if (tagLineStr != null)
            {
                tagLineStr = (tagLineStr + "!");
            }
            else
            {
                tagLineStr = "!";
            }
        }

        void addNewLineCharAndReverse(ref string tagLineStr)
        {
            if (tagLineStr != null)
            {
                reverseLine(ref tagLineStr);
                tagLineStr = (tagLineStr + "!");
            }
            else
            {
                tagLineStr = "!";
            }
        }

        Boolean checkAllLinesForErrors()
        {
            if (checkForAllLinesEmpty() == true)
            {
                return true;
            }
       
            if (checkAllLinesForInvalidChars() == true)
            {
                return true;
            }

            if (checkAllLinesForTooLong() == true)
            {
                return true;
            }

            return false;
        }

    }
}
