using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DUNameplateGUI
{
    internal class Jig
    {  
        public int Capacity { get; set; }

        public float[] YStartLocations { get; set; }

        public float[] XStartLocations { get; set; }

        // Empty constructor used in CreateDefaultJig and possibly in System.Text.JSON when deserializing and serializing
        public Jig() 
        {
            YStartLocations = new float[8];
            XStartLocations = new float[8];
        }

        public Jig(int capacity, float[] yStartLocations, float[] xStartLocations)
        {
            Capacity = capacity;
            YStartLocations = yStartLocations;
            XStartLocations = xStartLocations;
        }

        public static Jig CreateDefaultJig(int jigNumber)
        {
            Jig newJig = new Jig();

            switch (jigNumber)
            {
                case 0: //JIG Settings #1 (1 @ a time on old jig)
                    newJig.YStartLocations[0] = 0.46f;
                    newJig.XStartLocations[0] = 1.86f;
                    newJig.Capacity = 1;
                    break;
                case 1: //JIG Settings #2 (2 @ a time on old jig)
                    newJig.YStartLocations[0] = 0.46f;
                    newJig.XStartLocations[0] = 1.86f;
                    newJig.YStartLocations[1] = 2.24f;
                    newJig.XStartLocations[1] = 1.86f;
                    newJig.Capacity = 2;
                    break;
                case 2: //JIG Settings #3 (4 @ a time on new jig) 
                    newJig.YStartLocations[0] = 0.115f;
                    newJig.XStartLocations[0] = 1.897f;
                    newJig.YStartLocations[1] = 1.129f;
                    newJig.XStartLocations[1] = 1.897f;
                    newJig.YStartLocations[2] = 2.137f;
                    newJig.XStartLocations[2] = 1.897f;
                    newJig.YStartLocations[3] = 3.138f;
                    newJig.XStartLocations[3] = 1.897f;
                    newJig.Capacity = 4;
                    break;
                case 3: //JIG Settings #4 (8 @ a time with new jigs)
                    newJig.YStartLocations[0] = 0.115f;
                    newJig.XStartLocations[0] = 1.897f;
                    newJig.YStartLocations[1] = 1.129f;
                    newJig.XStartLocations[1] = 1.897f;
                    newJig.YStartLocations[2] = 2.137f;
                    newJig.XStartLocations[2] = 1.897f;
                    newJig.YStartLocations[3] = 3.138f;
                    newJig.XStartLocations[3] = 1.897f;

                    newJig.YStartLocations[4] = 0.094f;
                    newJig.XStartLocations[4] = 4.6865f;
                    newJig.YStartLocations[5] = 1.1125f;
                    newJig.XStartLocations[5] = 4.6865f;
                    newJig.YStartLocations[6] = 2.115f;
                    newJig.XStartLocations[6] = 4.6865f;
                    newJig.YStartLocations[7] = 3.1145f;
                    newJig.XStartLocations[7] = 4.6865f;
                    newJig.Capacity = 8;
                    break;
            }

            return newJig;
        }

        // Deep copies the jig by copying the arrays, integers are not reference types so they don't need to be copied.
        // This is only needed in the jig editor, as we want a deep copy of each of jigs
        // so that we can modify them without modifying the existing array of jigs
        public Jig DeepCopy()
        {
            Jig newJig = new Jig();
            Array.Copy(this.XStartLocations, newJig.XStartLocations, this.XStartLocations.Length);
            Array.Copy(this.YStartLocations, newJig.YStartLocations, this.YStartLocations.Length);
            newJig.Capacity = this.Capacity;

            return newJig;
        }
    }

    internal static class JigManager
    {
        public static Jig[] Jigs = new Jig[4];

        // This is used for selecting the current jig from Jigs, as well as letting other classes get the currently selected jig (currently UIControl)
        public static int CurrentlySelectedJig { get; set; }

        public static Jig CurrentJig
        {
            get
            {
                return Jigs[CurrentlySelectedJig];
            }
        }

        public static int Capacity
        {
            get
            {
                return CurrentJig.Capacity;
            }
        }

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

        //private static float[] YStartLocations { get; set; } = new float[8];

        //private static float[] XStartLocations { get; set; } = new float[8];

        // This variable will always return the YStartLocation for the current position
        public static float YStartLocation {
            get
            {
                return CurrentJig.YStartLocations[Position];
            }
        }

        // This variable will always return the XStartLocation for the current position
        public static float XStartLocation
        {
            get
            {
                return CurrentJig.XStartLocations[Position];
            }
        }

        // This should be called at the start of the program, so that it can load the previously saved jigs, or otherwise set them to default
        public static void Initialize()
        {
            LoadFromSettings();
        }

        public static void SetJig(int jigNumber)
        {
            // Set Position to 0 to prevent bugs
            Position = 0;

            CurrentlySelectedJig = jigNumber;

            // Update the jig on the main form
            UIControl.updateJigDisplay();
        }

        private static void SetJigToDefault(int jigNumber)
        {
            Jigs[jigNumber] = Jig.CreateDefaultJig(jigNumber);
        }

        private static void SetAllJigsToDefault()
        {
            for (int i = 0; i < Jigs.Length; i++)
            {
                SetJigToDefault(i);
            }
        }

        class JigsContainer
        {
            public Jig[] Jigs { get; set; } // { get; set; } is required, unless it will be ignored when serializing to JSON
        }

        public static void SaveToSettings()
        {
            JigsContainer jigsContainer = new JigsContainer();
            jigsContainer.Jigs = Jigs;

            string serializedString = JsonSerializer.Serialize(jigsContainer);

            Log.Debug("JigManager - SaveToSettings - Saving JSON: {SerializedString}", serializedString);

            Properties.Settings.Default.savedJigs = serializedString;
            Properties.Settings.Default.Save();
        }

        public static void LoadFromSettings()
        {
            string jigContainerJSON = Properties.Settings.Default.savedJigs;

            Log.Debug("Loading jigs from settings: {jigContainerJSON}", jigContainerJSON);

            try
            {
                JigsContainer jigsContainer = JsonSerializer.Deserialize<JigsContainer>(jigContainerJSON);

                Jigs = jigsContainer.Jigs;
            }
            catch (ArgumentNullException ex) // If the JSON is invalid or missing, reset to defaults
            {
                Log.Error("savedJigs in settings is null, causing exception {ex}", ex); 
                SetAllJigsToDefault();
                SaveToSettings();
            }
            catch (JsonException ex)
            {
                Log.Error("Invalid savedJigs JSON in settings: {ex}", ex);
                SetAllJigsToDefault();
                SaveToSettings();
            }
            catch (NotSupportedException ex)
            {
                Log.Error("Invalid savedJigs JSON in settings: {ex}", ex);
                SetAllJigsToDefault();
                SaveToSettings();
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
