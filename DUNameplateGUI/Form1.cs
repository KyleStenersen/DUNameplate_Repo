using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class GUI_MAIN_FORM : Form
    {
        private string tag1Line0String;
        private string tag1Line1String;
        private string tag1Line2String;
        private string tag1Line3String;
        string[] arrayOfTag1Lines;
        private int TAG_LINE_NUMBER;


        CheckTagText checkTagText = new CheckTagText();
        EditTagText editTagText = new EditTagText();

        public GUI_MAIN_FORM()
        {
            InitializeComponent();
            //serialPort1.Open();

            tag1Line0String = tag1Line0Box.Text;
            tag1Line1String = tag1Line1Box.Text;
            tag1Line2String = tag1Line2Box.Text;
            tag1Line3String = tag1Line3Box.Text;

            arrayOfTag1Lines = new string[4] { tag1Line0String, tag1Line1String, tag1Line2String, tag1Line3String };
        }

        private void tag1Line0Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 0;
            checkTagText.redTextBoxIfInputError(ref arrayOfTag1Lines[TAG_LINE_NUMBER], ref tag1Line0Box, TAG_LINE_NUMBER);
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 1;
            checkTagText.redTextBoxIfInputError(ref arrayOfTag1Lines[TAG_LINE_NUMBER], ref tag1Line1Box, TAG_LINE_NUMBER);
        }

        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 2;
            checkTagText.redTextBoxIfInputError(ref arrayOfTag1Lines[TAG_LINE_NUMBER], ref tag1Line2Box, TAG_LINE_NUMBER);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 3;
            checkTagText.redTextBoxIfInputError(ref arrayOfTag1Lines[TAG_LINE_NUMBER], ref tag1Line3Box, TAG_LINE_NUMBER);
        }

        private void printTagsBtn_Click(object sender, EventArgs e)
        {

            if (checkTagText.allLinesOfTagForErrors(ref arrayOfTag1Lines) == true) return;           

            editTagText.addNewLineCharsAndReverseOddLinesAll(ref arrayOfTag1Lines);

            string tag1Text = (arrayOfTag1Lines[0] + arrayOfTag1Lines[1] + arrayOfTag1Lines[2] + arrayOfTag1Lines[3]);

            tag1Text = tag1Text.ToUpper();
            tag1Text = ("<" + "a" + tag1Text + ">");


            MessageBox.Show(tag1Text);
            //serialPort1.Write(tag1Text);

            tag1Line0String = null;
            tag1Line1String = null;
            tag1Line2String = null;
            tag1Line3String = null;
        }

        private void ledBtn_Click(object sender, EventArgs e)
        {
            //serialPort1.Write("b");
        }
    }
}
