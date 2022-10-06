using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{
    internal static class InputFixer
    {

        public static List<InputFixingRule> inputFixingRules;

        public static void Initialize()
        {
            inputFixingRules = new List<InputFixingRule>();

            loadFromSettings();
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

        // This function will save (to disk) all of the current inputFixingRules by turning all of
        // the inputFixingRules into a specially delimited string that will be stored in
        // Properties.Settings
        public static void saveToSettings()
        {
            string stringToSave = "";

            foreach (InputFixingRule rule in inputFixingRules)
            {
                stringToSave += rule.matchStr;
                stringToSave += "±"; // was |
                stringToSave += rule.replaceStr;
                stringToSave += "§"; // was +
            }

            // TODO: Check if the replaceStr contains invalid characters for the tag,
            // and make sure that both have no § or ± in them

            Properties.Settings.Default.inputFixingRules = stringToSave;

            Properties.Settings.Default.Save();

            Log.Debug("Saving input fixing rules to settings: {string}", stringToSave);
        }

        public static void loadFromSettings()
        {
            string stringToLoad = Properties.Settings.Default.inputFixingRules;

            Log.Debug("Loading input fixing rules from settings: {stringToLoad}", stringToLoad);

            // If there are no rules set, reset to the default rules
            if (stringToLoad == "")
            {
                resetToDefaultRules();
                Log.Warning("Input fixing rules have been reset to default, as they were empty");
            }

            // This needs to be an array, because there is no version of String.Split function that takes in
            // one character and lets you set StringSplitOptions.
            char[] delimiter = new char[] { '§' }; // was +

            foreach (string decodedRule in stringToLoad.Split(delimiter, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] decodedSegments = decodedRule.Split('±'); // was |

                // If there is only one decoded segment, this means the rule is corrupted somehow, or our delimiter characters were put in an invalid spot
                // so we are going to reset to our default rules
                if (decodedSegments.Length == 1)
                {
                    Log.Error("Input fixing rules were corrupted, resetting to defaults, previous rules were {stringToLoad}", stringToLoad);
                    resetToDefaultRules();
                    MessageBox.Show("Input fixing rules have been reset to default due to invalid/corrupted rules", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }

                string matchStr = decodedSegments[0];
                string replaceStr = decodedSegments[1];

                InputFixingRule loadedRule = new InputFixingRule(matchStr, replaceStr);
                inputFixingRules.Add(loadedRule);
            }
        }

        public static void resetToDefaultRules()
        {
            Log.Debug("Resetting to default input fixing rules");

            inputFixingRules.Clear();

            inputFixingRules.Add(new InputFixingRule("(", ""));
            inputFixingRules.Add(new InputFixingRule(")", ""));
            inputFixingRules.Add(new InputFixingRule("&", "AND"));

            saveToSettings(); // Save to settings right away, otherwise these changes will go away once the program is restarted
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
