﻿using System;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class MAIN_FORM : Form
    {
        TextBox[] arrayOfTagTextBoxes;
        string[] arrayOfTagLines;
        private int TAG_LINE_NUMBER;


        CheckTextBox checkTextBox = new CheckTextBox();
        EditTextBox editTextBox = new EditTextBox();
        SerialCom serialComF1 = new SerialCom();
        Jig jig = new Jig();
        Queue queue = new Queue();


        public MAIN_FORM()
        {
            //Running these once on startup

            InitializeComponent();

            arrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };
            arrayOfTagLines = new string[4];

            serialComF1.setupPort();
            serialComF1.sendSettings();
        }

// USER INPUT RESPONSE FUNCTIONS ============================================

        private void tag1Line0Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 0;
            checkTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 1;
            checkTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SETTINGS_FORM settings_form = new SETTINGS_FORM();
            settings_form.ShowDialog();
        }

        private void clearTagBtn_Click(object sender, EventArgs e)
        {
            editTextBox.emptyTag(ref arrayOfTagLines, ref arrayOfTagTextBoxes);
            
            tag1QuantityBox.Text = null;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            serialComF1.sendString("<h>");
        }

        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 2;
            checkTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            TAG_LINE_NUMBER = 3;
            checkTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }
        
        private void JigComboBox_DropDownClosed(object sender, EventArgs e)
        {
            jig.setValues(JigComboBox.SelectedIndex);
        }

        private void printTagsBtn_Click(object sender, EventArgs e)
        {
            int jigPosition = 0;

            int currentTagQuantity;
            Boolean parseable = int.TryParse(tag1QuantityBox.Text, out currentTagQuantity);

            if (String.IsNullOrWhiteSpace(tag1QuantityBox.Text))
            {
                printCurrentTag(jigPosition);
                jigPosition++;
                return;
            }

            if (parseable == false)
            {
                MessageBox.Show("Invalid quanity", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //error out
            }

            for (int i = 0; i < currentTagQuantity; i++)
            {
                serialComF1.clearInputBuffer();

                printCurrentTag(jigPosition);

                jigPosition++;

                //waitPlateDone();

                serialComF1.clearInputBuffer();

                if (jigPosition == jig.Capacity)
                {
                    MessageBox.Show("Please reload, press OK when done");
                    jigPosition = 0;
                }
            }

        }
        private void printQueueBtn_Click(object sender, EventArgs e)
        {

        }

        //  PRIVATE FUNCTIONS=======================================================


        private void printCurrentTag(int jigPosition)
        {
            serialComF1.sendSettings();

            for (int i = 0; i < arrayOfTagTextBoxes.Length; i++)
                arrayOfTagLines[i] = arrayOfTagTextBoxes[i].Text;

            if (checkTextBox.allLinesOfTagForErrors(ref arrayOfTagLines) == true) return;

            editTextBox.addNewLineCharsAndReverseOddLinesAll(ref arrayOfTagLines);

            string tag1Text = (arrayOfTagLines[0] + arrayOfTagLines[1] + arrayOfTagLines[2] + arrayOfTagLines[3]);

            tag1Text = tag1Text.ToUpper();
            tag1Text = ("<" + "a" + jig.XStartLocation[jigPosition]+ "," + jig.YStartLocation[jigPosition] + "," + tag1Text + ">");

            serialComF1.sendString(tag1Text);
        }

        private void waitPlateDone()
        {
            bool plateIsDone = false;

            while (plateIsDone == false)
            {
                serialComF1.checkIfPlateDone(ref plateIsDone);
            }
        }

    }
}
