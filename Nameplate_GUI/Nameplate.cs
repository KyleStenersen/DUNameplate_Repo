using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUNameplateGUI
{
    public class Nameplate
    {
        public string Text { get; set; }
        public int YLocation { get; set; }
        public int XLocation { get; set; }
        public int Quantity { get; set; }

        public Nameplate (string text, int yLocation, int xLocation, int quantity)
        {
            Text = text;
            YLocation = yLocation;
            XLocation = xLocation;
            Quantity = quantity;
        }
    }
}
