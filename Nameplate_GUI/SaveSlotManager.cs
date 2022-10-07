using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{
    internal static class SaveSlotManager
    {
        private static Nameplate[] savedPlates = new Nameplate[5];

        public static void Initialize()
        {
            LoadFromSettings();
        }

        public static void SaveCurrentPlateToSlot(int slotNumber, TextBox[] arrayOfTagTextBoxes)
        {
            try
            {
                // Quantity is not used in this case
                Nameplate currentPlate = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, 1);

                savedPlates[slotNumber] = currentPlate;
            }
            catch (ArgumentException)
            {
                // We don't need to show a message here, as FromTextBoxes will show a MessageBox

                Log.Debug("SaveSlotManager - Caught ArgumentException from FromTextBoxes");
            }
        }

        public static void LoadSlotToTextBoxes(int slotNumber, TextBox[] arrayOfTagTextBoxes)
        {
            Nameplate selectedPlate = savedPlates[slotNumber];

            if (selectedPlate != null)
            {
                selectedPlate.ToTextBoxes(arrayOfTagTextBoxes); 
            }
        }

        private static void SaveToSettings()
        {

        }

        private static void LoadFromSettings()
        {

        }
    }
}
