﻿using System;
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
    public partial class InputRuleForm : Form
    {
        public InputRuleForm()
        {
            InitializeComponent();
        }

        private void InputRuleForm_Load(object sender, EventArgs e)
        {
            foreach (InputFixingRule rule in InputFixer.inputFixingRules)
            {
                // Create a new row, and add the default cells into it
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(inputRulesDataGridView);

                // Set our values from our input rule into the row
                row.Cells[0].Value = rule.matchStr;
                row.Cells[1].Value = rule.replaceStr;

                // Finally, add the row to our DataGridView
                inputRulesDataGridView.Rows.Add(row);
            }
        }

        private void saveCloseBtn_Click(object sender, EventArgs e)
        {
            // Clear the rules that are already stored, as we are going to re-add everything
            InputFixer.inputFixingRules.Clear();

            foreach (DataGridViewRow row in inputRulesDataGridView.Rows) {
                // Cells[0] is our matchStr column
                if (row.Cells[0].Value == null) {
                    continue;
                }

                string matchStr = row.Cells[0].Value.ToString();

                // Default to an empty string, unless there is a non-null value in the cell
                string replaceStr = "";

                if (row.Cells[1].Value != null)
                {
                    replaceStr = row.Cells[1].Value.ToString();
                }

                // Create and add our new rule into the InputFixer
                InputFixingRule newRule = new InputFixingRule(matchStr, replaceStr);
                InputFixer.inputFixingRules.Add(newRule);

                Console.WriteLine("matchStr: " + matchStr + " " + "replaceStr: " + replaceStr);
            }

            // TODO: Make input rules persist between restarts
            InputFixer.saveToSettings();
        }

        // Currently doesn't actually set the values of the cells, so the real value is still lowercase
        // while it looks like it's uppercase
        private void inputRulesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }
    }
}
