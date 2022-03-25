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
    public partial class GUI_MAIN_FORM : Form
    {
        private string tag1Line1String;
        private string tag1Line2String;
        private string tag1Line3String;
        private string tag1Line4String;
        private int TAG_LINE_NUMBER;

        CheckText checkText = new CheckText();

        public GUI_MAIN_FORM()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 1;
            checkText.redTextBoxIfInputError(ref tag1Line1String, ref tag1Line1Box, TAG_LINE_NUMBER);
        }

        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 2;
            checkText.redTextBoxIfInputError(ref tag1Line2String, ref tag1Line2Box, TAG_LINE_NUMBER);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 3;
            checkText.redTextBoxIfInputError(ref tag1Line3String, ref tag1Line3Box, TAG_LINE_NUMBER);
        }

        private void tag1Line4Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 4;
            checkText.redTextBoxIfInputError(ref tag1Line4String, ref tag1Line4Box, TAG_LINE_NUMBER);
        }

        private void printTagsBtn_Click(object sender, EventArgs e)
        {

            tag1Line1String = tag1Line1Box.Text;
            tag1Line2String = tag1Line2Box.Text;
            tag1Line3String = tag1Line3Box.Text;
            tag1Line4String = tag1Line4Box.Text;

            string[] arrayOfTag1Lines;
            arrayOfTag1Lines = new string[4] { tag1Line1String, tag1Line2String, tag1Line3String, tag1Line4String };

            if (checkText.allLinesOfTagForErrors(ref arrayOfTag1Lines) == true)
            {
                return;
            }

            addNewLineCharsAndReverseOddLinesAll();

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


        private void reverseLine(ref string tagLineStr)
        {
            char[] charArray = tagLineStr.ToCharArray();
            Array.Reverse(charArray);
            tagLineStr = new string(charArray);
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


        void addNewLineCharsAndReverseOddLinesAll()
        {
            addNewLineChar(ref tag1Line1String);

            addNewLineCharAndReverse(ref tag1Line2String);

            addNewLineChar(ref tag1Line3String);

            addNewLineCharAndReverse(ref tag1Line4String);
        }
    }
}

public class CheckText
{
    public Boolean allLinesOfTagForErrors(ref string[] arrayOfCurrentTagLines)
    {
        if (checkForAllLinesEmpty(ref arrayOfCurrentTagLines) == true)
        {
            return true;
        }

        if (checkAllLinesForInvalidChars(ref arrayOfCurrentTagLines) == true)
        {
            return true;
        }

        if (checkAllLinesForTooLong(ref arrayOfCurrentTagLines) == true)
        {
            return true;
        }

        return false;
    }

    public Boolean invalidChars(ref string checkStr)
    {

        if (checkStr.Except("ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz 1234567890 ,/-.#").Any())
        {
            return true;
        }

        return false;
    }

    public void redTextBoxIfInputError(ref string currentTagLineStr, ref TextBox currentTextBox, int currentLineNumber)
    {
        currentTagLineStr = currentTextBox.Text;

        if (invalidChars(ref currentTagLineStr) == true || errorIfTooLong(ref currentTagLineStr, currentLineNumber) == true)
        {
            currentTextBox.BackColor = Color.MistyRose;
        }
        else
        {
            currentTextBox.BackColor = Color.White;
        }
    }

    Boolean checkAllLinesForTooLong(ref string[] arrayOfCurrentTagLines)
    {
        for (int i = 0; i < arrayOfCurrentTagLines.Length; i++)
        {
            if (errorIfTooLong(ref arrayOfCurrentTagLines[i], i+1) == true)
            {
                //error out
                MessageBox.Show("Tag line too long", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
        }

        return false;
    }

    Boolean checkAllLinesForInvalidChars(ref string[] arrayOfCurrentTagLines)
    {
        string tag1TextTester = (arrayOfCurrentTagLines[0] + arrayOfCurrentTagLines[1] + arrayOfCurrentTagLines[2] + arrayOfCurrentTagLines[3]);
        if (invalidChars(ref tag1TextTester) == true)
        {
            //error out
            MessageBox.Show("Invalid character; Only A-Z, 1-9, and ,./-# available.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }

        return false;
    }

    Boolean checkForAllLinesEmpty(ref string[] arrayOfCurrentTagLines)
    {
        if (String.IsNullOrWhiteSpace(arrayOfCurrentTagLines[0]) && String.IsNullOrWhiteSpace(arrayOfCurrentTagLines[1]) && String.IsNullOrWhiteSpace(arrayOfCurrentTagLines[2]) && String.IsNullOrWhiteSpace(arrayOfCurrentTagLines[3]))
        {
            //error out
            return true;
        }

        return false;
    }

    private Boolean errorIfTooLong(ref string tagLineString, int lineNum)
    {

        if (lineNum == 1 || lineNum == 4)
        {

            if (tagLineString != null && tagLineString.Length > 23)
            {
                return true;
            }
        }

        if (lineNum == 2 || lineNum == 3)
        {
            if (tagLineString != null && tagLineString.Length > 19)
            {
                //MessageBox.Show("Too many characters in line# " + lineNum + "; 19 max", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
        }

        return false;

    }
}
