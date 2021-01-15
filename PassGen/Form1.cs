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

        // Instantiate the class that generates the key.
        readonly Generator generator = new Generator();

        // User controls allowance of numbers, letters, and symbols.
        private void CheckAllowances(object sender, EventArgs e)
        {
            // Count the ammount of checkBoxes that are on (At least one must be on)
            List<CheckBox> checkBoxes = new List<CheckBox>() { allowLeters, allowNumbers, allowSymbols };
            int boxesAreOn = 0;
            foreach (CheckBox checkBox in checkBoxes)
                boxesAreOn += checkBox.Checked ? 1 : 0;

            // If only one box is one, disable it, else, enable all boxes.
            if (boxesAreOn == 1)
            {
                if (allowLeters.Checked) allowLeters.Enabled = false;
                if (allowNumbers.Checked) allowNumbers.Enabled = false;
                if (allowSymbols.Checked) allowSymbols.Enabled = false;
            }
            else
            {
                allowLeters.Enabled = true;
                allowNumbers.Enabled = true;
                allowSymbols.Enabled = true;
            }

            // Store values in the object.
            generator.AllowLetters = allowLeters.Checked;
            generator.AllowNumbers = allowNumbers.Checked;
            generator.AllowSymbols = allowSymbols.Checked;
        }

        // Users controls wether the password is shown or not.
        private void SetShowText(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            OutBox.UseSystemPasswordChar = !checkBox.Checked;
        }

        // Generate the key.
        private void StartGen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Use the password length from the lengthSelector to generate the password
            OutBox.Text = generator.GeneratePass((int)lengthSelector.Value);
            Cursor.Current = Cursors.Default;
        }

        // Copy the password to the clipboard
        private void CopyToClipboard(object sender, EventArgs e)
        {
            if (OutBox.Text != "")
                Clipboard.SetText(OutBox.Text);
        }
    }
}
