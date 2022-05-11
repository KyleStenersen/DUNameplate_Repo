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

        public float[] YStartLocation { get; set; } = new float[8];

        public float[] XStartLocation { get; set; } = new float[8];

        public float YStart { get; set; }

        public void setValues(int jigNumber)
        {

            Array.Clear(YStartLocation,0,8);
            Array.Clear(XStartLocation,0,8);

            switch (jigNumber)
            {                
                case 0: //JIG Settings #1 (1 @ a time on old jig)
                    YStartLocation[0] = 0.46f;
                    XStartLocation[0] = 1.86f;
                    Capacity = 1;
                    break;
                case 1: //JIG Settings #2 (2 @ a time on old jig)
                    YStartLocation[0] = 0.46f;
                    XStartLocation[0] = 1.86f;
                    YStartLocation[1] = 2.26f;
                    XStartLocation[1] = 1.86f;
                    Capacity = 2;
                    break;
                case 2: //JIG Settings #3 (4 @ a time on new jig) 
                    YStartLocation[0] = 0.108f;
                    XStartLocation[0] = 1.86f;
                    YStartLocation[1] = 1.136f;
                    XStartLocation[1] = 1.86f;
                    YStartLocation[2] = 2.164f;
                    XStartLocation[2] = 1.86f;
                    YStartLocation[3] = 3.192f;
                    XStartLocation[3] = 1.86f;
                    Capacity = 4;
                    break;
                case 3: //JIG Settings #4 (8 @ a time with new jigs)
                    YStartLocation[0] = 0.108f;
                    XStartLocation[0] = 1.86f;
                    YStartLocation[1] = 1.136f;
                    XStartLocation[1] = 1.86f;
                    YStartLocation[2] = 2.164f;
                    XStartLocation[2] = 1.86f;
                    YStartLocation[3] = 3.192f;
                    XStartLocation[3] = 1.86f;

                    YStartLocation[4] = 0.108f;
                    XStartLocation[4] = 4.617f;
                    YStartLocation[5] = 1.136f;
                    XStartLocation[5] = 4.617f;
                    YStartLocation[6] = 2.164f;
                    XStartLocation[6] = 4.617f;
                    YStartLocation[7] = 3.192f;
                    XStartLocation[7] = 4.617f;
                    Capacity = 8;
                    break;

            }
        }
    }
}
