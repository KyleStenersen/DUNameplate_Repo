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
    public partial class PlateEditorForm : Form
    {
        TextBox[] ArrayOfTagTextBoxes;
        Nameplate NameplateToModify;

        public PlateEditorForm(Nameplate nameplateToModify)
        {
            InitializeComponent();
            NameplateToModify = nameplateToModify;
        }

        private void ModifyTagForm_Load(object sender, EventArgs e)
        {
            ArrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };

            NameplateToModify.ToTextBoxes(ArrayOfTagTextBoxes);

            tagQuantityBox.Value = NameplateToModify.Quantity;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Nameplate editedNameplate = Nameplate.FromTextBoxes(ArrayOfTagTextBoxes, (int)tagQuantityBox.Value); // Casted to an int, as the value is decimal

            PlateQueue.EditSpecificPlate(NameplateToModify, editedNameplate); // Edit the plate from the queue

            Close();
        }

        private void pasteToMainScreenBtn_Click(object sender, EventArgs e)
        {
            Nameplate nameplate = Nameplate.FromTextBoxes(ArrayOfTagTextBoxes, (int)tagQuantityBox.Value);

            UIControl.nameplateToTextBoxes(nameplate);

            Close();
        }
    }
}
