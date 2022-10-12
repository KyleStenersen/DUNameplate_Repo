using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public class Nameplate
    {
        public string[] Lines { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
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
        
        // This constructor was meant to be a private constructor, so that no other classes would be able to
        // create Nameplates in any way other than by using the text boxes, but
        // it is now public because we need to deserialize JSON with Nameplates in it
        public Nameplate ()
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

        public void ToTextBoxes(TextBox[] textBoxes)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = Lines[i];
            }
        }
    }
}
