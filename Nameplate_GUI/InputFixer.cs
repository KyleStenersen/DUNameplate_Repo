using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    internal static class InputFixer
    {

        static List<InputFixingRule> inputFixingRules;

        public static void Initialize()
        {
            inputFixingRules = new List<InputFixingRule>();

            inputFixingRules.Add(new InputFixingRule("(", ""));
            inputFixingRules.Add(new InputFixingRule(")", ""));
            inputFixingRules.Add(new InputFixingRule("&", "AND"));
        }

        // Fixes invalid input, is run after text is changed in any of the text boxes
        public static void fixInvalidInput(ref TextBox tagTextBox)
        {
            string text = tagTextBox.Text;

            int selectionStartIndex = tagTextBox.SelectionStart;

            foreach (InputFixingRule rule in inputFixingRules)
            {
                if (text.Contains(rule.matchStr)) {
                    text = text.Replace(rule.matchStr, rule.replaceStr);
                    selectionStartIndex += rule.replaceStr.Length - rule.matchStr.Length;
                }
            }

            tagTextBox.Text = text;

            tagTextBox.SelectionStart = selectionStartIndex;
        }
    }

    internal struct InputFixingRule
    {
        public string matchStr;
        public string replaceStr;
        
        public InputFixingRule(string match, string replace)
        {
            matchStr = match;
            replaceStr = replace;
        }
    }
}
