﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{
    internal static class SpeedDialManager
    {
        private static Nameplate[] speedDialPlates = new Nameplate[6];

        private static Label[] speedDialLabels;

        public static void Initialize(Label[] arrayOfSpeedDialLabels)
        {
            speedDialLabels = arrayOfSpeedDialLabels;

            LoadFromSettings();

            UpdateLabels();
        }

        public static void SaveCurrentPlateToSlot(int slotNumber, TextBox[] arrayOfTagTextBoxes)
        {
            try
            {
                // Quantity is not used in this case
                Nameplate currentPlate = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, 1);

                speedDialPlates[slotNumber] = currentPlate;

                SaveToSettings();

                UpdateLabels();
            }
            catch (ArgumentException)
            {
                // We don't need to show a message here, as FromTextBoxes will show a MessageBox

                Log.Debug("SaveSlotManager - Caught ArgumentException from FromTextBoxes");
            }
        }

        public static void LoadSlotToTextBoxes(int slotNumber, TextBox[] arrayOfTagTextBoxes)
        {
            Nameplate selectedPlate = speedDialPlates[slotNumber];

            if (selectedPlate != null)
            {
                selectedPlate.ToTextBoxes(arrayOfTagTextBoxes);
            }
        }

        public static void ClearAllSlots()
        {
            speedDialPlates = new Nameplate[6];

            SaveToSettings();

            UpdateLabels();
        }

        // This class is here so that we can serialize our savedPlates to a JSON string, and then
        // use this class to then deserialize the same JSON.
        public class SpeedDialPlatesContainer 
        {
            public Nameplate[] speedDialPlates { get; set; } // { get; set; } is required, unless it will be ignored when serializing to JSON
        }

        private static void SaveToSettings()
        {
            SpeedDialPlatesContainer speedDialPlatesContainer = new SpeedDialPlatesContainer();
            speedDialPlatesContainer.speedDialPlates = speedDialPlates;

            string serializedString = JsonSerializer.Serialize(speedDialPlatesContainer);

            Log.Debug("SpeedDialManager - SaveToSettings - Saving JSON: {SerializedString}", serializedString);

            Properties.Settings.Default.speedDialPlates = serializedString;
            Properties.Settings.Default.Save();
        }

        private static void LoadFromSettings()
        {
            string speedDialPlatesJSON = Properties.Settings.Default.speedDialPlates;

            Log.Debug("Loading speed dial plates from settings: {speedDialPlatesJSON}", speedDialPlatesJSON);

            try
            {
                SpeedDialPlatesContainer speedDialPlatesContainer = JsonSerializer.Deserialize<SpeedDialPlatesContainer>(speedDialPlatesJSON);

                speedDialPlates = speedDialPlatesContainer.speedDialPlates;
            }
            catch (ArgumentNullException ex)
            {
                Log.Error("speedDialPlates in settings is null, causing exception {ex}", ex);
            }
            catch (JsonException ex)
            {
                Log.Error("Invalid speedDialPlates JSON in settings: {ex}", ex);
            }
            catch (NotSupportedException ex)
            {
                Log.Error("Invalid speedDialPlates JSON in settings: {ex}", ex);
            }

        }

        private static void UpdateLabels()
        {
            for (int i = 0; i < speedDialLabels.Length; i++)
            {
                if (speedDialPlates[i] != null) 
                {
                    speedDialLabels[i].Text = speedDialPlates[i].Lines[0];
                }
                else
                {
                    speedDialLabels[i].Text = "";
                }
            }
        }
    }
}
