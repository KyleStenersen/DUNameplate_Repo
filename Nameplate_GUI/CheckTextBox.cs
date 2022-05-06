using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class CheckTextBox
{
// PUBLIC FUNCTIONS ===========================================

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

    public Boolean invalidTagChars(ref string checkStr)
    {

        if (checkStr.Except("ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz 1234567890 ,/-.#").Any())
        {
            return true;
        }

        return false;
    }

    public void redTagBoxIfInputError(ref string currentTagLineStr, ref TextBox currentTextBox, int currentLineNumber)
    {
        currentTagLineStr = currentTextBox.Text;
        bool isError = false;

        if (invalidTagChars(ref currentTagLineStr) == true || errorIfTooLong(ref currentTagLineStr, currentLineNumber) == true)
        {
            isError = true;
            redBoxIfErrorWhiteIfNot(ref currentTextBox, isError);
        }
        else
        {
            isError = false;
            redBoxIfErrorWhiteIfNot(ref currentTextBox, isError);
        }
    }


    Boolean checkAllLinesForTooLong(ref string[] arrayOfCurrentTagLines)
    {
        for (int i = 0; i < arrayOfCurrentTagLines.Length; i++)
        {
            if (errorIfTooLong(ref arrayOfCurrentTagLines[i], i) == true)
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
        if (invalidTagChars(ref tag1TextTester) == true)
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

// PRIVATE FUNCTIONS ==================================================

    private void redBoxIfErrorWhiteIfNot(ref TextBox currentTextBox, bool isError)
    {
        if (isError == true)
        {
            currentTextBox.BackColor = Color.MistyRose;
        }
        else
        {
            currentTextBox.BackColor = Color.White;
        }
    }

    private Boolean errorIfTooLong(ref string tagLineString, int lineNum)
    {

        if (lineNum == 0 || lineNum == 3)
        {

            if (tagLineString != null && tagLineString.Length > 23)
            {
                return true;
            }
        }

        if (lineNum == 1 || lineNum == 2)
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
