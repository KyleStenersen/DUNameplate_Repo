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

        public Nameplate (TextBox[] textBoxes, int quantity)
        {
            Quantity = quantity;

            Lines = new string[4];

            for (int i = 0; i < textBoxes.Length; i++)
                Lines[i] = textBoxes[i].Text;

            if (CheckTextBox.allLinesOfTagForErrors(Lines))
            {
                
            }
        }
    }
}
