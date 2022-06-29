using System;
using System.Windows.Forms;

public static class EditTextBox
{
    public static void addNewLineCharsAndReverseOddLinesAll(ref string[] arrayOfCurrentTagLines)
    {
        addNewLineChar(ref arrayOfCurrentTagLines[0]);

        addNewLineCharAndReverse(ref arrayOfCurrentTagLines[1]);

        addNewLineChar(ref arrayOfCurrentTagLines[2]);

        addNewLineCharAndReverse(ref arrayOfCurrentTagLines[3]);
    }

    ////public static void emptyTag(ref string[] arrayOfCurrentTagLines, ref TextBox[] arrayOfCurrentTextboxes)
    //public static void emptyTag(ref TextBox[] arrayOfCurrentTextboxes)
    //{
    //    //for (int i = 0; i < arrayOfCurrentTagLines.Length; i++)
    //    for (int i = 0; i < arrayOfCurrentTextboxes.Length; i++)
    //    {
    //        //arrayOfCurrentTagLines[i] = null;
    //        arrayOfCurrentTextboxes[i].Text = null;
    //    }
    //}

    //SUPPORT FUNCTIONS ---------------------

    private static void reverseLine(ref string tagLineStr)
    {
        char[] charArray = tagLineStr.ToCharArray();
        Array.Reverse(charArray);
        tagLineStr = new string(charArray);
    }

    private static void addNewLineChar(ref string tagLineStr)
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

    private static void addNewLineCharAndReverse(ref string tagLineStr)
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
}
