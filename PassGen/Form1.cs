using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PassGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //
        // Instantiate the classes that generate/obfuscate the key.
        readonly Generator generator = new Generator();
        readonly Obfuscator obfuscator = new Obfuscator();
        //
        // Swith between 'generate' mode and 'obfuscate' mode, Changing the UI to fit the purpose.
        private void modeSelector_Click(object sender, EventArgs e)
        {
            // The button contains the text of the mode to choose (not the chosen mode).
            Button button = (Button)sender;
            List<CheckBox> checkBoxes = new List<CheckBox>() { allowLeters, allowNumbers, allowSymbols };
            //
            // Use the button text to know the mode to switch to.
            if (button.Text == "Obfuscar")
            {
                // Set the UI to 'obfuscate' mode.
                button.Text = "Generar";
                lengthSelector.Enabled = false;
                StartGen.Text = "Obfuscar contraseña";
                insertPassLabel.Visible = true;
                OutBox.ReadOnly = false;
                foreach (CheckBox checkBox in checkBoxes)
                {
                    checkBox.Enabled = false;
                    checkBox.Checked = true;
                }
            }
            else
            {
                // Set the UI to 'generate' mode.
                button.Text = "Obfuscar";
                lengthSelector.Enabled = true;
                StartGen.Text = "Generar contraseña";
                insertPassLabel.Visible = false;
                OutBox.ReadOnly = true;
                foreach (CheckBox checkBox in checkBoxes)
                    checkBox.Enabled = true;
            }
            //
            // Things that happen anyways.
            OutBox.Text = "";
        }
        //
        // User controls wether the password is shown or not.
        private void SetShowText(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            OutBox.UseSystemPasswordChar = !checkBox.Checked;
        }
        //
        // Copy the password to the clipboard
        private void CopyToClipboard(object sender, EventArgs e)
        {
            if (OutBox.Text != "")
                Clipboard.SetText(OutBox.Text);
        }
        //
        // User controls allowance of numbers, letters, and symbols.
        private void CheckAllowances(object sender, EventArgs e)
        {
            // Count the ammount of checkBoxes that are on (At least one must be on)
            List<CheckBox> checkBoxes = new List<CheckBox>() { allowLeters, allowNumbers, allowSymbols };
            int boxesAreOn = 0;
            foreach (CheckBox checkBox in checkBoxes)
                boxesAreOn += checkBox.Checked ? 1 : 0;
            //
            // If only one box is one, disable it, else, enable all boxes.
            if (boxesAreOn == 1)
            {
                foreach (CheckBox checkBox in checkBoxes)
                    checkBox.Enabled = checkBox.Checked ? false : true;
            }
            else
            {
                foreach (CheckBox checkBox in checkBoxes)
                    checkBox.Enabled = true;
            }
            //
            // Store values in the objects.
            generator.AllowLetters = allowLeters.Checked;
            generator.AllowNumbers = allowNumbers.Checked;
            generator.AllowSymbols = allowSymbols.Checked;
            //
            obfuscator.AllowLetters = allowLeters.Checked;
            obfuscator.AllowNumbers = allowNumbers.Checked;
            obfuscator.AllowSymbols = allowSymbols.Checked;
        }
        //
        // Generate the key.
        private void StartGen_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Cursor.Current = Cursors.WaitCursor;
            if (button.Text == "Generar contraseña")
            {
                // Use the password length from the lengthSelector to generate the password.
                OutBox.Text = generator.GeneratePass((int)lengthSelector.Value);
            }
            else
            {
                if (OutBox.Text != "")
                {
                    obfuscator.Key = OutBox.Text;
                    // Use the OutBox text to obfuscate the password.
                    OutBox.Text = obfuscator.ObfuscatePass(OutBox.Text);
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
