using System;
using System.Drawing;
using System.Windows.Forms;

public class CheckSettings
{ 
    public Boolean textBoxEntryError(ref TextBox currentBox, float valueMax, float valueMin)
    {
        if (String.IsNullOrWhiteSpace(currentBox.Text))
        {
            currentBox.BackColor = Color.White;
            return false; //succeed out
        }

        float textBoxFloat;
        Boolean parseable = float.TryParse(currentBox.Text, out textBoxFloat);

        if (parseable == false)
        {
            currentBox.BackColor = Color.MistyRose;
            return true; //error out
        }

        if (valueMin > textBoxFloat || valueMax < textBoxFloat)
        {
            currentBox.BackColor = Color.MistyRose;
            return true; //error out
        }

        currentBox.BackColor = Color.White;
        return false;
    }
}
