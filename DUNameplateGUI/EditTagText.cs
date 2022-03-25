using System;

public class EditTagText
{
    public void addNewLineCharsAndReverseOddLinesAll(ref string[] arrayOfCurrentTagLines)
    {
        addNewLineChar(ref arrayOfCurrentTagLines[0]);

        addNewLineCharAndReverse(ref arrayOfCurrentTagLines[1]);

        addNewLineChar(ref arrayOfCurrentTagLines[2]);

        addNewLineCharAndReverse(ref arrayOfCurrentTagLines[3]);
    }

    //SUPPORT FUNCTIONS ---------------------

    private void reverseLine(ref string tagLineStr)
    {
        char[] charArray = tagLineStr.ToCharArray();
        Array.Reverse(charArray);
        tagLineStr = new string(charArray);
    }

    private void addNewLineChar(ref string tagLineStr)
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

    private void addNewLineCharAndReverse(ref string tagLineStr)
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
