using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    internal static class InputFixer
    {
        public static void fixInvalidInput(ref TextBox tagTextBox)
        {
            string text = tagTextBox.Text;

            text = text.Replace("(", "");
            text = text.Replace(")", "");

            text = text.Replace("&", "AND");

            int selectionStartIndex = tagTextBox.SelectionStart;

            tagTextBox.Text = text;

            tagTextBox.SelectionStart = selectionStartIndex;
        }
    }
}
