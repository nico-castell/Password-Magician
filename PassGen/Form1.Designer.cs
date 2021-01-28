
namespace PassMagician
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OutBox = new System.Windows.Forms.TextBox();
            this.StartGen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lengthSelector = new System.Windows.Forms.NumericUpDown();
            this.allowLetters = new System.Windows.Forms.CheckBox();
            this.allowNumbers = new System.Windows.Forms.CheckBox();
            this.allowSymbols = new System.Windows.Forms.CheckBox();
            this.showText = new System.Windows.Forms.CheckBox();
            this.copyToClipboard = new System.Windows.Forms.Button();
            this.modeSelector = new System.Windows.Forms.Button();
            this.insertPassLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lengthSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // OutBox
            // 
            this.OutBox.BackColor = System.Drawing.Color.White;
            this.OutBox.Location = new System.Drawing.Point(12, 24);
            this.OutBox.Name = "OutBox";
            this.OutBox.ReadOnly = true;
            this.OutBox.Size = new System.Drawing.Size(300, 23);
            this.OutBox.TabIndex = 0;
            this.OutBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OutBox.UseSystemPasswordChar = true;
            // 
            // StartGen
            // 
            this.StartGen.Location = new System.Drawing.Point(292, 59);
            this.StartGen.Name = "StartGen";
            this.StartGen.Size = new System.Drawing.Size(100, 48);
            this.StartGen.TabIndex = 1;
            this.StartGen.Text = "Generar contraseña";
            this.StartGen.UseVisualStyleBackColor = true;
            this.StartGen.Click += new System.EventHandler(this.StartGen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(269, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "3.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(133, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "2.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Largo:";
            // 
            // lengthSelector
            // 
            this.lengthSelector.Location = new System.Drawing.Point(35, 84);
            this.lengthSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lengthSelector.Name = "lengthSelector";
            this.lengthSelector.Size = new System.Drawing.Size(62, 23);
            this.lengthSelector.TabIndex = 5;
            this.lengthSelector.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // allowLetters
            // 
            this.allowLetters.AutoSize = true;
            this.allowLetters.Checked = true;
            this.allowLetters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowLetters.Location = new System.Drawing.Point(148, 80);
            this.allowLetters.Name = "allowLetters";
            this.allowLetters.Size = new System.Drawing.Size(99, 19);
            this.allowLetters.TabIndex = 7;
            this.allowLetters.Text = "Permitir letras";
            this.allowLetters.UseVisualStyleBackColor = true;
            this.allowLetters.Click += new System.EventHandler(this.CheckAllowances);
            // 
            // allowNumbers
            // 
            this.allowNumbers.AutoSize = true;
            this.allowNumbers.Checked = true;
            this.allowNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowNumbers.Location = new System.Drawing.Point(148, 105);
            this.allowNumbers.Name = "allowNumbers";
            this.allowNumbers.Size = new System.Drawing.Size(118, 19);
            this.allowNumbers.TabIndex = 8;
            this.allowNumbers.Text = "Permitir números";
            this.allowNumbers.UseVisualStyleBackColor = true;
            this.allowNumbers.Click += new System.EventHandler(this.CheckAllowances);
            // 
            // allowSymbols
            // 
            this.allowSymbols.AutoSize = true;
            this.allowSymbols.Checked = true;
            this.allowSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowSymbols.Location = new System.Drawing.Point(148, 130);
            this.allowSymbols.Name = "allowSymbols";
            this.allowSymbols.Size = new System.Drawing.Size(119, 19);
            this.allowSymbols.TabIndex = 9;
            this.allowSymbols.Text = "Permitir símbolos";
            this.allowSymbols.UseVisualStyleBackColor = true;
            this.allowSymbols.Click += new System.EventHandler(this.CheckAllowances);
            // 
            // showText
            // 
            this.showText.AutoSize = true;
            this.showText.Location = new System.Drawing.Point(318, 26);
            this.showText.Name = "showText";
            this.showText.Size = new System.Drawing.Size(67, 19);
            this.showText.TabIndex = 10;
            this.showText.Text = "Mostrar";
            this.showText.UseVisualStyleBackColor = true;
            this.showText.Click += new System.EventHandler(this.SetShowText);
            // 
            // copyToClipboard
            // 
            this.copyToClipboard.Location = new System.Drawing.Point(292, 109);
            this.copyToClipboard.Name = "copyToClipboard";
            this.copyToClipboard.Size = new System.Drawing.Size(100, 48);
            this.copyToClipboard.TabIndex = 11;
            this.copyToClipboard.Text = "Copiar al portapaleles";
            this.copyToClipboard.UseVisualStyleBackColor = true;
            this.copyToClipboard.Click += new System.EventHandler(this.CopyToClipboard);
            // 
            // modeSelector
            // 
            this.modeSelector.Location = new System.Drawing.Point(23, 114);
            this.modeSelector.Name = "modeSelector";
            this.modeSelector.Size = new System.Drawing.Size(98, 35);
            this.modeSelector.TabIndex = 12;
            this.modeSelector.Text = "Obfuscar";
            this.modeSelector.UseVisualStyleBackColor = true;
            this.modeSelector.Click += new System.EventHandler(this.ModeSelector_Click);
            // 
            // insertPassLabel
            // 
            this.insertPassLabel.AutoSize = true;
            this.insertPassLabel.Location = new System.Drawing.Point(12, 9);
            this.insertPassLabel.Name = "insertPassLabel";
            this.insertPassLabel.Size = new System.Drawing.Size(121, 15);
            this.insertPassLabel.TabIndex = 13;
            this.insertPassLabel.Text = "Inserte su contraseña:";
            this.insertPassLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 171);
            this.Controls.Add(this.insertPassLabel);
            this.Controls.Add(this.modeSelector);
            this.Controls.Add(this.copyToClipboard);
            this.Controls.Add(this.showText);
            this.Controls.Add(this.allowSymbols);
            this.Controls.Add(this.allowNumbers);
            this.Controls.Add(this.allowLetters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lengthSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartGen);
            this.Controls.Add(this.OutBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar contraseñas";
            ((System.ComponentModel.ISupportInitialize)(this.lengthSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutBox;
        private System.Windows.Forms.Button StartGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown lengthSelector;
        private System.Windows.Forms.CheckBox allowLetters;
        private System.Windows.Forms.CheckBox allowNumbers;
        private System.Windows.Forms.CheckBox allowSymbols;
        private System.Windows.Forms.CheckBox showText;
        private System.Windows.Forms.Button copyToClipboard;
        private System.Windows.Forms.Button modeSelector;
        private System.Windows.Forms.Label insertPassLabel;
    }
}

