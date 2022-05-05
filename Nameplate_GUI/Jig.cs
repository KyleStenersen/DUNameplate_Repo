using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUNameplateGUI
{
    internal class Jig
    {
        public int Capacity { get; set; }
        public float YSpaceing { get; set; }
        public float XSpaceing { get; set; }
        public float YStart { get; set; }

        public void setValues(int jigNumber)
        {
            switch(jigNumber)
            {
                case 0:
                    Capacity = 1;
                    break;
                case 1:
                    Capacity = 2;
                    YSpaceing = 1.8f;
                    break;
                case 2:
                    Capacity = 4;
                    YSpaceing = 1.028f;
                    break;
                case 3:
                    Capacity = 8;
                    YSpaceing = 1.028f;
                    XSpaceing = 2.757f;
                    break;

            }
        }
    }
}
