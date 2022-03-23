﻿using System;
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
        private string tag1L1;
        private string tag1L2;
        private string tag1L3;
        private string tag1L4;

        public Form1()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void tag1Line1_TextChanged(object sender, EventArgs e)
        {
            tag1L1 = tag1Line1.Text;

            if (checkInvalidChars(ref tag1L1) == true || errorIfTooLong(ref tag1L1, 1) == true)
            {
                tag1Line1.BackColor = Color.MistyRose;
            }
            else
            {
                tag1Line1.BackColor = Color.White;
            }
        }


        private void tag1Line2_TextChanged(object sender, EventArgs e)
        {
            tag1L2 = tag1Line2.Text;

            if (checkInvalidChars(ref tag1L2) == true || errorIfTooLong(ref tag1L2, 2) == true)
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
            tag1L3 = tag1Line3.Text;

            if (checkInvalidChars(ref tag1L3) == true || errorIfTooLong(ref tag1L3, 3) == true)
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
            tag1L4 = tag1Line4.Text;

            if (checkInvalidChars(ref tag1L4) == true || errorIfTooLong(ref tag1L4, 4) == true)
            {
                tag1Line4.BackColor = Color.MistyRose;
            }
            else
            {
                tag1Line4.BackColor = Color.White;
            }
        }

        private void printTag1Btn_Click(object sender, EventArgs e)
        {

            tag1L1 = tag1Line1.Text;
            tag1L2 = tag1Line2.Text;
            tag1L3 = tag1Line3.Text;
            tag1L4 = tag1Line4.Text;

            if (String.IsNullOrWhiteSpace(tag1L1) && String.IsNullOrWhiteSpace(tag1L2) && String.IsNullOrWhiteSpace(tag1L3) && String.IsNullOrWhiteSpace(tag1L4))
            {
                //error out
                return;
            }

            string tag1TextTester = (tag1L1 + tag1L2 + tag1L3 + tag1L4);
            if (checkInvalidChars(ref tag1TextTester) == true)
            {
                //error out
                MessageBox.Show("Invalid character; Only A-Z, 1-9, and ,./-# available.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (errorIfTooLong(ref tag1L1, 1) == true || errorIfTooLong(ref tag1L2, 2) == true || errorIfTooLong(ref tag1L3, 3) == true || errorIfTooLong(ref tag1L4, 4) == true)
            {
                //error out
                MessageBox.Show("Tag line too long", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tag1L1 != null)
            {
                tag1L1 = (tag1L1 + "!");
            }
            else
            {
                tag1L1 = "!";
            }

                if (tag1L2 != null)
            {
                reverseLine(ref tag1L2);
                tag1L2 = (tag1L2 + "!");
            }
            else
            {
                tag1L2 = "!";
            }

            if (tag1L3 != null)
            {
                tag1L3 = (tag1L3 + "!");
            }
            else
            {
                tag1L3 = "!";
            }

            if (tag1L4 != null)
            { 
                reverseLine(ref tag1L4);
            }

            string tag1Text = (tag1L1 + tag1L2 + tag1L3 + tag1L4);

            tag1Text = tag1Text.ToUpper();
            tag1Text = ( "<" + "a" + tag1Text + ">");


            MessageBox.Show(tag1Text);
            //serialPort1.Write("a" + tag1Line1Str);

            tag1L1 = null;
            tag1L2 = null;
            tag1L3 = null;
            tag1L4 = null;
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
    }
}
