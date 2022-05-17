using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public class Nameplate
    {
        public string[] Lines { get; set; }
        public int Quantity { get; set; }

        public string PrintableLines {
            get
            {
                // Create a copy of the lines, as we do not want to modify the original lines
                string[] copyOfLines = (string[])Lines.Clone();

                // Turn these lines into the format for printing
                EditTextBox.addNewLineCharsAndReverseOddLinesAll(ref copyOfLines);

                return String.Concat(copyOfLines);
            }
        }
        // Private constructor, cannot be used from elsewhere, is only used inside helper functions to create Nameplates
        // in this class.
        private Nameplate ()
        {
            Quantity = 0;
            Lines = new string[4];
        }

        // Create a new Nameplate from the text typed into the textBoxes
        public static Nameplate FromTextBoxes(TextBox[] textBoxes, int quantity)
        {
            Nameplate newPlate = new Nameplate();

            newPlate.Quantity = quantity;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                newPlate.Lines[i] = textBoxes[i].Text;
            }

            if (CheckTextBox.allLinesOfTagForErrors(newPlate.Lines))
            {
                throw new ArgumentException("Invalid text inside of textBoxes");
            }

            return newPlate;
        }
    }
}
