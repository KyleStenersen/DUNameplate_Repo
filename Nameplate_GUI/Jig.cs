using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUNameplateGUI
{
    // Not quite sure if this should be static, maybe it should be contained inside MachineControl instead?
    internal static class Jig
    {
        public static int Capacity { get; set; }

        private static int _position { get; set; }
        public static int Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value; // value is a special keyword for whatever it is being set to

                // null is set as the sender here, as we don't need it, and we can't use the this keyword from a static class
                PositionChanged?.Invoke(null, new PositionChangedEventArgs(value)); 
            }
        }

        // This is used to update the UI whenever the Position of the jig is changed
        // The PositionChangedArgs class is declared below this class in this file
        public static event EventHandler<PositionChangedEventArgs> PositionChanged;

        private static float[] YStartLocations { get; set; } = new float[8];

        private static float[] XStartLocations { get; set; } = new float[8];

        // This variable will always return the YStartLocation for the current position
        public static float YStartLocation {
            get
            {
                return YStartLocations[Position];
            }
        }

        // This variable will always return the XStartLocation for the current position
        public static float XStartLocation
        {
            get
            {
                return XStartLocations[Position];
            }
        }

        public static float YStart { get; set; }

        // This is used for other classes to be able to get the currently selected jig (currently UIControl)
        public static int currentlySelectedJig;

        public static void setValues(int jigNumber)
        {
            // Set Position to 0 to prevent bugs
            Position = 0;

            currentlySelectedJig = jigNumber;

            // Update the jig on the main form
            UIControl.updateJigDisplay();

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
                    YStartLocations[1] = 2.24f;
                    XStartLocations[1] = 1.86f;
                    Capacity = 2;
                    break;
                case 2: //JIG Settings #3 (4 @ a time on new jig) 
                    YStartLocations[0] = 0.128f;
                    XStartLocations[0] = 1.91f;
                    YStartLocations[1] = 1.14f;
                    XStartLocations[1] = 1.91f;
                    YStartLocations[2] = 2.15f;
                    XStartLocations[2] = 1.91f;
                    YStartLocations[3] = 3.166f;
                    XStartLocations[3] = 1.91f;
                    Capacity = 4;
                    break;
                case 3: //JIG Settings #4 (8 @ a time with new jigs)
                    YStartLocations[0] = 0.128f;
                    XStartLocations[0] = 1.91f;
                    YStartLocations[1] = 1.14f;
                    XStartLocations[1] = 1.91f;
                    YStartLocations[2] = 2.15f;
                    XStartLocations[2] = 1.91f;
                    YStartLocations[3] = 3.166f;
                    XStartLocations[3] = 1.91f;

                    YStartLocations[4] = 0.143f;
                    XStartLocations[4] = 4.717f;
                    YStartLocations[5] = 1.17f;
                    XStartLocations[5] = 4.717f;
                    YStartLocations[6] = 2.1835f;
                    XStartLocations[6] = 4.717f;
                    YStartLocations[7] = 3.134f;
                    XStartLocations[7] = 4.717f;
                    Capacity = 8;
                    break;

            }
        }
    }

    public class PositionChangedEventArgs : EventArgs
    {
        public PositionChangedEventArgs(int position)
        {
            Position = position;
        }

        public int Position { get; }
    }
}
