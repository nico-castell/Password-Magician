using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PassMagician
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Instantiate the classes that generate/obfuscate the key.
        readonly Generator _generator = new Generator();
        readonly Obfuscator _obfuscator = new Obfuscator();
        readonly Crypter _crypter = new Crypter();

        #region Changing modes
        // Swith between modes, Changing the UI to fit the purpose.
        private void ModeSelector_Click(object sender, EventArgs e)
        {
            // The button contains the text of the next mode to choose (not the current mode).
            Button button = (Button)sender;

            // Use the button text to know the mode to switch to.
            switch (button.Text)
            {
            case "Generar":
                // Set the UI to 'generate' mode.
                button.Text = "Obfuscar";
                lengthSelector.Enabled = true;
                StartGen.Text = "Generar contraseña";
                insertPassLabel.Visible = false;
                OutBox.ReadOnly = true;
                this.Text = "Generar contraseñas";
                ChangeEnablingOfCheckboxes(true);
                break;
            case "Obfuscar":
                // Set the UI to 'obfuscate' mode.
                button.Text = "Encriptar";
                lengthSelector.Enabled = false;
                StartGen.Text = "Obfuscar contraseña";
                insertPassLabel.Visible = true;
                OutBox.ReadOnly = false;
                this.Text = "Obfuscar contraseñas";
                ChangeEnablingOfCheckboxes(true);
                break;
            case "Encriptar":
                // Set the UI to 'encrypt' mode.
                button.Text = "Generar";
                lengthSelector.Enabled = false;
                StartGen.Text = "Ingresar contraseña";
                insertPassLabel.Visible = true;
                OutBox.ReadOnly = false;
                this.Text = "Encryptar contraseña";
                ChangeEnablingOfCheckboxes(false);
                break;
            }

            // These happen every time the mode is changed.
            OutBox.Text = "";
            UpdateConditions(allowLetters.Checked, allowNumbers.Checked, allowSymbols.Checked);
        }
        #endregion

        #region Controlling the checkboxes
        /// <summary>
        /// Change wether the checkboxes to allow Letters, Numbers, and/or Symbols are enabled.
        /// </summary>
        /// <param name="newState">Their new state</param>
        void ChangeEnablingOfCheckboxes(in bool newState)
        {
            // Modify the three checkboxes
            List<CheckBox> boxes = new List<CheckBox>() { allowLetters, allowNumbers, allowSymbols };
            foreach (CheckBox box in boxes)
                box.Enabled = newState;
        }

        /// <summary>
        /// Update the modifiers in all clases that use the 3 checkboxes.
        /// </summary>
        /// <param name="AllowLetters">The allowLetters checkbox</param>
        /// <param name="AllowNumbers">The allowNumbers checkbox</param>
        /// <param name="AllowSymbols">The allowSymbols checkbox</param>
        void UpdateConditions(in bool AllowLetters, in bool AllowNumbers, in bool AllowSymbols)
        {
            // Access both clases by their parent class and update the settings.
            List<Modifier> modes = new List<Modifier>() { _generator, _obfuscator, _crypter };
            foreach (Modifier mode in modes)
            {
                mode.AllowLetters = AllowLetters;
                mode.AllowNumbers = AllowNumbers;
                mode.AllowSymbols = AllowSymbols;
            }
        }
        #endregion

        #region Main user interaction
        // User controls wether the password is shown or not.
        private void SetShowText(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            OutBox.UseSystemPasswordChar = !checkBox.Checked;
        }

        // Copy the password to the clipboard
        private void CopyToClipboard(object sender, EventArgs e)
        {
            if (OutBox.Text != "")
                Clipboard.SetText(OutBox.Text);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // User controls allowance of numbers, letters, and symbols.
        private void CheckAllowances(object sender, EventArgs e)
        {
            // Count the ammount of checkBoxes that are on (At least one must be on)
            List<CheckBox> checkBoxes = new List<CheckBox>() { allowLetters, allowNumbers, allowSymbols };
            int boxesAreOn = 0;
            foreach (CheckBox checkBox in checkBoxes)
                boxesAreOn += checkBox.Checked ? 1 : 0;
            //
            // If only one box is one, disable it, else, enable all boxes.
            if (boxesAreOn == 1)
                foreach (CheckBox checkBox in checkBoxes)
                    checkBox.Enabled = !checkBox.Checked;
            else
                foreach (CheckBox checkBox in checkBoxes)
                    checkBox.Enabled = true;
            //
            // Store values in the objects.
            UpdateConditions(allowLetters.Checked, allowNumbers.Checked, allowSymbols.Checked);
        }

        // Generate the key.
        private void StartGen_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Text)
            {
            // 'generate' mode.
            case "Generar contraseña":
                Cursor.Current = Cursors.WaitCursor;
                // Use the password length from the lengthSelector to generate the password.
                OutBox.Text = _generator.GeneratePass((int)lengthSelector.Value);
                Cursor.Current = Cursors.Default;
                break;
            // 'obfuscate' mode.
            case "Obfuscar contraseña":
                if (OutBox.Text != "") // If it's empty, the program crashes.
                {
                    Cursor.Current = Cursors.WaitCursor;
                    // Use the OutBox text to obfuscate the password.
                    _obfuscator.Key = OutBox.Text;
                    OutBox.Text = _obfuscator.ObfuscatePass(OutBox.Text);
                    Cursor.Current = Cursors.Default;
                }
                break;
            // 'encrypt' mode.
            case "Ingresar contraseña":
                // Store phrase to encrypt.
                _crypter.Pass = OutBox.Text;
                // Set UI to receive key (disable switching modes).
                modeSelector.Enabled = false;
                OutBox.Text = "";
                button.Text = "Encriptar";
                insertPassLabel.Text = "Inserte su clave:";
                break;
            case "Encriptar":
                // Pass the key and encrypt.
                Cursor.Current = Cursors.WaitCursor;
                OutBox.Text = _crypter.Encrypt(OutBox.Text);
                Cursor.Current = Cursors.Default;
                // Set the UI back to receive pass.
                modeSelector.Enabled = true;
                button.Text = "Ingresar contraseña";
                insertPassLabel.Text = "Inserte su contraseña:";
                break;
            }
            #endregion
        }
    }
}
