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

        public int Position { get; set; }

        private float[] YStartLocations { get; set; } = new float[8];

        private float[] XStartLocations { get; set; } = new float[8];

        // This variable will always return the YStartLocation for the current position
        public float YStartLocation {
            get
            {
                return YStartLocations[Position];
            }
        }

        // This variable will always return the XStartLocation for the current position
        public float XStartLocation
        {
            get
            {
                return XStartLocations[Position];
            }
        }

        public float YStart { get; set; }

        public void setValues(int jigNumber)
        {

            Array.Clear(YStartLocations,0,8);
            Array.Clear(XStartLocations,0,8);

            switch (jigNumber)
            {                
                case 0: //JIG Settings #1 (1 @ a time on old jig)
                    YStartLocations[0] = 0.46f;
                    XStartLocations[0] = 1.86f;
                    Capacity = 1;
                    break;
                case 1: //JIG Settings #2 (2 @ a time on old jig)
                    YStartLocations[0] = 0.46f;
                    XStartLocations[0] = 1.86f;
                    YStartLocations[1] = 2.26f;
                    XStartLocations[1] = 1.86f;
                    Capacity = 2;
                    break;
                case 2: //JIG Settings #3 (4 @ a time on new jig) 
                    YStartLocations[0] = 0.108f;
                    XStartLocations[0] = 1.86f;
                    YStartLocations[1] = 1.136f;
                    XStartLocations[1] = 1.86f;
                    YStartLocations[2] = 2.164f;
                    XStartLocations[2] = 1.86f;
                    YStartLocations[3] = 3.192f;
                    XStartLocations[3] = 1.86f;
                    Capacity = 4;
                    break;
                case 3: //JIG Settings #4 (8 @ a time with new jigs)
                    YStartLocations[0] = 0.108f;
                    XStartLocations[0] = 1.86f;
                    YStartLocations[1] = 1.136f;
                    XStartLocations[1] = 1.86f;
                    YStartLocations[2] = 2.164f;
                    XStartLocations[2] = 1.86f;
                    YStartLocations[3] = 3.192f;
                    XStartLocations[3] = 1.86f;

                    YStartLocations[4] = 0.108f;
                    XStartLocations[4] = 4.617f;
                    YStartLocations[5] = 1.136f;
                    XStartLocations[5] = 4.617f;
                    YStartLocations[6] = 2.164f;
                    XStartLocations[6] = 4.617f;
                    YStartLocations[7] = 3.192f;
                    XStartLocations[7] = 4.617f;
                    Capacity = 8;
                    break;

            }
        }
    }
}
