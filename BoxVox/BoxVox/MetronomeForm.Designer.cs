namespace BoxVox
{
    partial class MetronomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrumMachineLabel = new System.Windows.Forms.Label();
            this.DrumM1NoteComboBox = new System.Windows.Forms.ComboBox();
            this.DrumM2NoteComboBox = new System.Windows.Forms.ComboBox();
            this.DrumM3NoteComboBox = new System.Windows.Forms.ComboBox();
            this.DrumM4NoteComboBox = new System.Windows.Forms.ComboBox();
            this.Octave12CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave11CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave22CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave21CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave32CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave31CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave42CheckBox = new System.Windows.Forms.CheckBox();
            this.Octave41CheckBox = new System.Windows.Forms.CheckBox();
            this.MetrOKBut = new System.Windows.Forms.Button();
            this.MetrCancelBut = new System.Windows.Forms.Button();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.MetrBPMLabel = new System.Windows.Forms.Label();
            this.MetrFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.MetrResetBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrumMachineLabel
            // 
            this.DrumMachineLabel.AutoSize = true;
            this.DrumMachineLabel.Font = new System.Drawing.Font("Kid A", 19.8F);
            this.DrumMachineLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DrumMachineLabel.Location = new System.Drawing.Point(12, 9);
            this.DrumMachineLabel.Name = "DrumMachineLabel";
            this.DrumMachineLabel.Size = new System.Drawing.Size(415, 33);
            this.DrumMachineLabel.TabIndex = 2;
            this.DrumMachineLabel.Text = "Drum-machine (sort of)";
            // 
            // DrumM1NoteComboBox
            // 
            this.DrumM1NoteComboBox.Font = new System.Drawing.Font("Kid A", 48F);
            this.DrumM1NoteComboBox.FormattingEnabled = true;
            this.DrumM1NoteComboBox.Items.AddRange(new object[] {
            "H",
            "B",
            "A",
            "G#",
            "G",
            "F#",
            "F",
            "E",
            "D#",
            "C#",
            "C"});
            this.DrumM1NoteComboBox.Location = new System.Drawing.Point(18, 56);
            this.DrumM1NoteComboBox.Name = "DrumM1NoteComboBox";
            this.DrumM1NoteComboBox.Size = new System.Drawing.Size(173, 88);
            this.DrumM1NoteComboBox.TabIndex = 3;
            // 
            // DrumM2NoteComboBox
            // 
            this.DrumM2NoteComboBox.Font = new System.Drawing.Font("Kid A", 48F);
            this.DrumM2NoteComboBox.FormattingEnabled = true;
            this.DrumM2NoteComboBox.Items.AddRange(new object[] {
            "H",
            "B",
            "A",
            "G#",
            "G",
            "F#",
            "F",
            "E",
            "D#",
            "C#",
            "C"});
            this.DrumM2NoteComboBox.Location = new System.Drawing.Point(197, 56);
            this.DrumM2NoteComboBox.Name = "DrumM2NoteComboBox";
            this.DrumM2NoteComboBox.Size = new System.Drawing.Size(173, 88);
            this.DrumM2NoteComboBox.TabIndex = 4;
            // 
            // DrumM3NoteComboBox
            // 
            this.DrumM3NoteComboBox.Font = new System.Drawing.Font("Kid A", 48F);
            this.DrumM3NoteComboBox.FormattingEnabled = true;
            this.DrumM3NoteComboBox.Items.AddRange(new object[] {
            "H",
            "B",
            "A",
            "G#",
            "G",
            "F#",
            "F",
            "E",
            "D#",
            "C#",
            "C"});
            this.DrumM3NoteComboBox.Location = new System.Drawing.Point(376, 56);
            this.DrumM3NoteComboBox.Name = "DrumM3NoteComboBox";
            this.DrumM3NoteComboBox.Size = new System.Drawing.Size(173, 88);
            this.DrumM3NoteComboBox.TabIndex = 5;
            // 
            // DrumM4NoteComboBox
            // 
            this.DrumM4NoteComboBox.Font = new System.Drawing.Font("Kid A", 48F);
            this.DrumM4NoteComboBox.FormattingEnabled = true;
            this.DrumM4NoteComboBox.Items.AddRange(new object[] {
            "H",
            "B",
            "A",
            "G#",
            "G",
            "F#",
            "F",
            "E",
            "D#",
            "C#",
            "C"});
            this.DrumM4NoteComboBox.Location = new System.Drawing.Point(555, 56);
            this.DrumM4NoteComboBox.Name = "DrumM4NoteComboBox";
            this.DrumM4NoteComboBox.Size = new System.Drawing.Size(173, 88);
            this.DrumM4NoteComboBox.TabIndex = 6;
            // 
            // Octave12CheckBox
            // 
            this.Octave12CheckBox.AutoSize = true;
            this.Octave12CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave12CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave12CheckBox.Location = new System.Drawing.Point(18, 191);
            this.Octave12CheckBox.Name = "Octave12CheckBox";
            this.Octave12CheckBox.Size = new System.Drawing.Size(149, 24);
            this.Octave12CheckBox.TabIndex = 32;
            this.Octave12CheckBox.Text = "2nd octave";
            this.Octave12CheckBox.UseVisualStyleBackColor = true;
            this.Octave12CheckBox.CheckedChanged += new System.EventHandler(this.Octave12CheckBox_CheckedChanged);
            // 
            // Octave11CheckBox
            // 
            this.Octave11CheckBox.AutoSize = true;
            this.Octave11CheckBox.Checked = true;
            this.Octave11CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Octave11CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave11CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave11CheckBox.Location = new System.Drawing.Point(18, 161);
            this.Octave11CheckBox.Name = "Octave11CheckBox";
            this.Octave11CheckBox.Size = new System.Drawing.Size(135, 24);
            this.Octave11CheckBox.TabIndex = 31;
            this.Octave11CheckBox.Text = "1st octave";
            this.Octave11CheckBox.UseVisualStyleBackColor = true;
            this.Octave11CheckBox.CheckedChanged += new System.EventHandler(this.Octave11CheckBox_CheckedChanged);
            // 
            // Octave22CheckBox
            // 
            this.Octave22CheckBox.AutoSize = true;
            this.Octave22CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave22CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave22CheckBox.Location = new System.Drawing.Point(197, 191);
            this.Octave22CheckBox.Name = "Octave22CheckBox";
            this.Octave22CheckBox.Size = new System.Drawing.Size(149, 24);
            this.Octave22CheckBox.TabIndex = 34;
            this.Octave22CheckBox.Text = "2nd octave";
            this.Octave22CheckBox.UseVisualStyleBackColor = true;
            this.Octave22CheckBox.CheckedChanged += new System.EventHandler(this.Octave22CheckBox_CheckedChanged);
            // 
            // Octave21CheckBox
            // 
            this.Octave21CheckBox.AutoSize = true;
            this.Octave21CheckBox.Checked = true;
            this.Octave21CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Octave21CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave21CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave21CheckBox.Location = new System.Drawing.Point(197, 161);
            this.Octave21CheckBox.Name = "Octave21CheckBox";
            this.Octave21CheckBox.Size = new System.Drawing.Size(135, 24);
            this.Octave21CheckBox.TabIndex = 33;
            this.Octave21CheckBox.Text = "1st octave";
            this.Octave21CheckBox.UseVisualStyleBackColor = true;
            this.Octave21CheckBox.CheckedChanged += new System.EventHandler(this.Octave21CheckBox_CheckedChanged);
            // 
            // Octave32CheckBox
            // 
            this.Octave32CheckBox.AutoSize = true;
            this.Octave32CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave32CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave32CheckBox.Location = new System.Drawing.Point(376, 191);
            this.Octave32CheckBox.Name = "Octave32CheckBox";
            this.Octave32CheckBox.Size = new System.Drawing.Size(149, 24);
            this.Octave32CheckBox.TabIndex = 36;
            this.Octave32CheckBox.Text = "2nd octave";
            this.Octave32CheckBox.UseVisualStyleBackColor = true;
            this.Octave32CheckBox.CheckedChanged += new System.EventHandler(this.Octave32CheckBox_CheckedChanged);
            // 
            // Octave31CheckBox
            // 
            this.Octave31CheckBox.AutoSize = true;
            this.Octave31CheckBox.Checked = true;
            this.Octave31CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Octave31CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave31CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave31CheckBox.Location = new System.Drawing.Point(376, 161);
            this.Octave31CheckBox.Name = "Octave31CheckBox";
            this.Octave31CheckBox.Size = new System.Drawing.Size(135, 24);
            this.Octave31CheckBox.TabIndex = 35;
            this.Octave31CheckBox.Text = "1st octave";
            this.Octave31CheckBox.UseVisualStyleBackColor = true;
            this.Octave31CheckBox.CheckedChanged += new System.EventHandler(this.Octave31CheckBox_CheckedChanged);
            // 
            // Octave42CheckBox
            // 
            this.Octave42CheckBox.AutoSize = true;
            this.Octave42CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave42CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave42CheckBox.Location = new System.Drawing.Point(555, 191);
            this.Octave42CheckBox.Name = "Octave42CheckBox";
            this.Octave42CheckBox.Size = new System.Drawing.Size(149, 24);
            this.Octave42CheckBox.TabIndex = 38;
            this.Octave42CheckBox.Text = "2nd octave";
            this.Octave42CheckBox.UseVisualStyleBackColor = true;
            this.Octave42CheckBox.CheckedChanged += new System.EventHandler(this.Octave42CheckBox_CheckedChanged);
            // 
            // Octave41CheckBox
            // 
            this.Octave41CheckBox.AutoSize = true;
            this.Octave41CheckBox.Checked = true;
            this.Octave41CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Octave41CheckBox.Font = new System.Drawing.Font("Kid A", 12F);
            this.Octave41CheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Octave41CheckBox.Location = new System.Drawing.Point(555, 161);
            this.Octave41CheckBox.Name = "Octave41CheckBox";
            this.Octave41CheckBox.Size = new System.Drawing.Size(135, 24);
            this.Octave41CheckBox.TabIndex = 37;
            this.Octave41CheckBox.Text = "1st octave";
            this.Octave41CheckBox.UseVisualStyleBackColor = true;
            this.Octave41CheckBox.CheckedChanged += new System.EventHandler(this.Octave41CheckBox_CheckedChanged);
            // 
            // MetrOKBut
            // 
            this.MetrOKBut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MetrOKBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MetrOKBut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MetrOKBut.Font = new System.Drawing.Font("Kid A", 10.2F);
            this.MetrOKBut.Location = new System.Drawing.Point(12, 420);
            this.MetrOKBut.Name = "MetrOKBut";
            this.MetrOKBut.Size = new System.Drawing.Size(106, 42);
            this.MetrOKBut.TabIndex = 39;
            this.MetrOKBut.Text = "Set";
            this.MetrOKBut.UseVisualStyleBackColor = false;
            // 
            // MetrCancelBut
            // 
            this.MetrCancelBut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MetrCancelBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MetrCancelBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MetrCancelBut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MetrCancelBut.Font = new System.Drawing.Font("Kid A", 10.2F);
            this.MetrCancelBut.Location = new System.Drawing.Point(646, 420);
            this.MetrCancelBut.Name = "MetrCancelBut";
            this.MetrCancelBut.Size = new System.Drawing.Size(106, 42);
            this.MetrCancelBut.TabIndex = 40;
            this.MetrCancelBut.Text = "Cancel";
            this.MetrCancelBut.UseVisualStyleBackColor = false;
            this.MetrCancelBut.Click += new System.EventHandler(this.MetrCancelBut_Click);
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Font = new System.Drawing.Font("Kid A", 19.8F);
            this.FrequencyLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FrequencyLabel.Location = new System.Drawing.Point(12, 261);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(208, 33);
            this.FrequencyLabel.TabIndex = 41;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // MetrBPMLabel
            // 
            this.MetrBPMLabel.AutoSize = true;
            this.MetrBPMLabel.Font = new System.Drawing.Font("Kid A", 12F);
            this.MetrBPMLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MetrBPMLabel.Location = new System.Drawing.Point(153, 332);
            this.MetrBPMLabel.Name = "MetrBPMLabel";
            this.MetrBPMLabel.Size = new System.Drawing.Size(51, 20);
            this.MetrBPMLabel.TabIndex = 43;
            this.MetrBPMLabel.Text = "bpm";
            // 
            // MetrFrequencyTextBox
            // 
            this.MetrFrequencyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MetrFrequencyTextBox.Location = new System.Drawing.Point(18, 321);
            this.MetrFrequencyTextBox.Name = "MetrFrequencyTextBox";
            this.MetrFrequencyTextBox.Size = new System.Drawing.Size(129, 32);
            this.MetrFrequencyTextBox.TabIndex = 42;
            this.MetrFrequencyTextBox.Text = "0";
            // 
            // MetrResetBut
            // 
            this.MetrResetBut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MetrResetBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MetrResetBut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MetrResetBut.Font = new System.Drawing.Font("Kid A", 10.2F);
            this.MetrResetBut.Location = new System.Drawing.Point(330, 420);
            this.MetrResetBut.Name = "MetrResetBut";
            this.MetrResetBut.Size = new System.Drawing.Size(106, 42);
            this.MetrResetBut.TabIndex = 44;
            this.MetrResetBut.Text = "Reset";
            this.MetrResetBut.UseVisualStyleBackColor = false;
            this.MetrResetBut.Click += new System.EventHandler(this.MetrResetBut_Click);
            // 
            // MetronomeForm
            // 
            this.AcceptButton = this.MetrOKBut;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.MetrCancelBut;
            this.ClientSize = new System.Drawing.Size(764, 474);
            this.ControlBox = false;
            this.Controls.Add(this.MetrResetBut);
            this.Controls.Add(this.MetrBPMLabel);
            this.Controls.Add(this.MetrFrequencyTextBox);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.MetrCancelBut);
            this.Controls.Add(this.MetrOKBut);
            this.Controls.Add(this.Octave42CheckBox);
            this.Controls.Add(this.Octave41CheckBox);
            this.Controls.Add(this.Octave32CheckBox);
            this.Controls.Add(this.Octave31CheckBox);
            this.Controls.Add(this.Octave22CheckBox);
            this.Controls.Add(this.Octave21CheckBox);
            this.Controls.Add(this.Octave12CheckBox);
            this.Controls.Add(this.Octave11CheckBox);
            this.Controls.Add(this.DrumM4NoteComboBox);
            this.Controls.Add(this.DrumM3NoteComboBox);
            this.Controls.Add(this.DrumM2NoteComboBox);
            this.Controls.Add(this.DrumM1NoteComboBox);
            this.Controls.Add(this.DrumMachineLabel);
            this.Name = "MetronomeForm";
            this.Text = "Metronome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DrumMachineLabel;
        private System.Windows.Forms.ComboBox DrumM1NoteComboBox;
        private System.Windows.Forms.ComboBox DrumM2NoteComboBox;
        private System.Windows.Forms.ComboBox DrumM3NoteComboBox;
        private System.Windows.Forms.ComboBox DrumM4NoteComboBox;
        private System.Windows.Forms.CheckBox Octave12CheckBox;
        private System.Windows.Forms.CheckBox Octave11CheckBox;
        private System.Windows.Forms.CheckBox Octave22CheckBox;
        private System.Windows.Forms.CheckBox Octave21CheckBox;
        private System.Windows.Forms.CheckBox Octave32CheckBox;
        private System.Windows.Forms.CheckBox Octave31CheckBox;
        private System.Windows.Forms.CheckBox Octave42CheckBox;
        private System.Windows.Forms.CheckBox Octave41CheckBox;
        private System.Windows.Forms.Button MetrOKBut;
        private System.Windows.Forms.Button MetrCancelBut;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.Label MetrBPMLabel;
        private System.Windows.Forms.TextBox MetrFrequencyTextBox;
        private System.Windows.Forms.Button MetrResetBut;
    }
}