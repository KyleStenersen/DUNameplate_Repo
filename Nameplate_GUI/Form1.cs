using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class MAIN_FORM : Form
    {
        TextBox[] arrayOfTagTextBoxes;
        string[] arrayOfTagLines;
        private int TAG_LINE_NUMBER;


        CheckTagText checkTagText = new CheckTagText();
        EditTagText editTagText = new EditTagText();
        SerialCom serialComF1 = new SerialCom();


        public MAIN_FORM()
        {
            //Running these once on startup

            InitializeComponent();

            arrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };
            arrayOfTagLines = new string[4];

            serialComF1.setupPort();
            serialComF1.sendSettings();
        }

        private void tag1Line0Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 0;
            checkTagText.redTextBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 1;
            checkTagText.redTextBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 2;
            checkTagText.redTextBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 3;
            checkTagText.redTextBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void printTagsBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arrayOfTagTextBoxes.Length; i++)
                arrayOfTagLines[i] = arrayOfTagTextBoxes[i].Text;

            if (checkTagText.allLinesOfTagForErrors(ref arrayOfTagLines) == true) return;           

            editTagText.addNewLineCharsAndReverseOddLinesAll(ref arrayOfTagLines);

            string tag1Text = (arrayOfTagLines[0] + arrayOfTagLines[1] + arrayOfTagLines[2] + arrayOfTagLines[3]);

            tag1Text = tag1Text.ToUpper();
            tag1Text = ("<" + "a" + tag1Text + ">");

            serialComF1.sendString(tag1Text);
            
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SETTINGS_FORM settings_form = new SETTINGS_FORM();
            settings_form.ShowDialog();
        }

        private void clearTagBtn_Click(object sender, EventArgs e)
        {
            editTagText.emptyTag(ref arrayOfTagLines, ref arrayOfTagTextBoxes);
        }

        private void ledBtn_Click(object sender, EventArgs e)
        {
            serialComF1.sendString("<b>");
        }
    }
}
