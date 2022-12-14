using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class JigEditorForm : Form
    {
        NumericUpDown[] XCoordinateBoxes = new NumericUpDown[8];
        NumericUpDown[] YCoordinateBoxes = new NumericUpDown[8];

        Jig[] JigsToEdit = new Jig[4];

        bool FirstSelection = true; // This bool is here so that the first time a user selects a jig, it does not save a bunch of zeros to that jig
        int IndexOfCurrentlyEditedJig;

        public JigEditorForm()
        {
            InitializeComponent();
        }

        private void JigEditorForm_Load(object sender, EventArgs e)
        {
            XCoordinateBoxes = new NumericUpDown[8] { xCoordinate1, xCoordinate2, xCoordinate3, xCoordinate4, xCoordinate5, xCoordinate6, xCoordinate7, xCoordinate8 };
            YCoordinateBoxes = new NumericUpDown[8] { yCoordinate1, yCoordinate2, yCoordinate3, yCoordinate4, yCoordinate5, yCoordinate6, yCoordinate7, yCoordinate8 };

            JigsToEdit = JigManager.Jigs.Select(jig => jig.DeepCopy()).ToArray();
        }

        private void LoadJigToEdit(Jig jigToEdit)
        {
            ResetAllToZeroAndEnableAll();

            for (int i = 0; i < jigToEdit.Capacity; i++) // Set the values of the coordinate boxes to the jig start locations
            {
                XCoordinateBoxes[i].Value = (decimal)jigToEdit.XStartLocations[i];
                YCoordinateBoxes[i].Value = (decimal)jigToEdit.YStartLocations[i];
            }

            for (int i = jigToEdit.Capacity; i < 8; i++) // Disable all of the other unneeded coordinate boxes according to the current jigs capacity
            {
                XCoordinateBoxes[i].Enabled = false;
                YCoordinateBoxes[i].Enabled = false;
            }
        }

        private void ResetAllToZeroAndEnableAll()
        {
            for (int i = 0; i < XCoordinateBoxes.Length; i++)
            {
                XCoordinateBoxes[i].Value = 0;
                XCoordinateBoxes[i].Enabled = true;
                YCoordinateBoxes[i].Value = 0;
                YCoordinateBoxes[i].Enabled = true;
            }
        }
        private void SaveCurrentJigToJigsToEdit()
        {
            Jig currentlyEditedJig = JigsToEdit[IndexOfCurrentlyEditedJig];

            for (int i = 0; i < currentlyEditedJig.Capacity; i++)
            {
                currentlyEditedJig.XStartLocations[i] = (float)XCoordinateBoxes[i].Value;
                currentlyEditedJig.YStartLocations[i] = (float)YCoordinateBoxes[i].Value;
            }
        }

        private void saveAndCloseBtn_Click(object sender, EventArgs e)
        {
            if (!FirstSelection) // If FirstSelection is true, we do not want to save, as the user has not selected any jig.
            {
                SaveCurrentJigToJigsToEdit();
            }

            JigManager.Jigs = JigsToEdit;

            JigManager.SaveToSettings();
            Close();
        }

        private void exitWithoutSavingBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void jigComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstSelection) // If FirstSelection is true, then it is the first time a jig has been selected, so we do not want to save (otherwise we'd save zeros into the currently selected jig)
            {
                SaveCurrentJigToJigsToEdit();
            }
            FirstSelection = false;

            IndexOfCurrentlyEditedJig = jigComboBox.SelectedIndex;
            LoadJigToEdit(JigsToEdit[IndexOfCurrentlyEditedJig]);
        }

        private void resetCurrentJigToDefaultBtn_Click(object sender, EventArgs e)
        {
            LoadJigToEdit(Jig.CreateDefaultJig(IndexOfCurrentlyEditedJig));
        }
    }
}
