using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxVox
{
    public partial class MetronomeForm : Form
    {
        public MetronomeForm()
        {
            InitializeComponent();
        }

        private void MetrCancelBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Octave11CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 11 checked then 12 unchecked
            if (Octave11CheckBox.Checked)
            {
                Octave12CheckBox.Checked = false;
            }
        }

        private void Octave12CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 12 checked then 11 unchecked
            if (Octave12CheckBox.Checked)
            {
                Octave11CheckBox.Checked = false;
            }
        }

        private void Octave21CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 21 checked then 22 unchecked
            if (Octave21CheckBox.Checked)
            {
                Octave22CheckBox.Checked = false;
            }
        }

        private void Octave22CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 22 checked then 21 unchecked
            if (Octave22CheckBox.Checked)
            {
                Octave21CheckBox.Checked = false;
            }
        }

        private void Octave31CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 31 checked then 32 unchecked
            if (Octave31CheckBox.Checked)
            {
                Octave32CheckBox.Checked = false;
            }
        }

        private void Octave32CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 32 checked then 31 unchecked
            if (Octave32CheckBox.Checked)
            {
                Octave31CheckBox.Checked = false;
            }
        }

        private void Octave41CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 41 checked then 42 unchecked
            if (Octave41CheckBox.Checked)
            {
                Octave42CheckBox.Checked = false;
            }
        }

        private void Octave42CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 42 checked then 41 unchecked
            if (Octave42CheckBox.Checked)
            {
                Octave41CheckBox.Checked = false;
            }
        }

        private void MetrResetBut_Click(object sender, EventArgs e)
        {
            // Initial octave for each is 1
            Octave11CheckBox.Checked = true;
            Octave21CheckBox.Checked = true;
            Octave31CheckBox.Checked = true;
            Octave41CheckBox.Checked = true;

            // Initial frequency is 0
            MetrFrequencyTextBox.Text = "0";

            // No note is initial
            DrumM1NoteComboBox.Text = "";
            DrumM2NoteComboBox.Text = "";
            DrumM3NoteComboBox.Text = "";
            DrumM4NoteComboBox.Text = "";
        }
    }
}
