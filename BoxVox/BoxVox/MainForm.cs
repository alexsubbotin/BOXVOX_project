using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // To work with ports

namespace BoxVox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BackToMenuBut_Click(object sender, EventArgs e)
        {
            // Going back to the main menu
            serialPort1.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If the form is closed the app stops
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Getting arduino port to read/write information
            try
            {
                // The list of available ports
                string[] ports = SerialPort.GetPortNames();

                // Writing the list of ports to the combobox
                PortComboBox.DataSource = ports;

                // Timer is on
                timer1.Enabled = true;
            }
            catch { }

            // Block delay 1 set button
            SetDelay1But.Enabled = false;

            // Block delay 2 set button
            SetDelay2But.Enabled = false;

            // Initial back color is black becuase they're checked 
            Octave11CheckBox.BackColor = Color.Black;
            Octave22CheckBox.BackColor = Color.Black;

        }

        private void PortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (serialPort1 != null)
            {
                serialPort1 = new SerialPort(PortComboBox.SelectedItem.ToString());
                serialPort1.PortName = PortComboBox.SelectedItem.ToString();
                serialPort1.BaudRate = 9600;
                serialPort1.DtrEnable = true;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.ReadTimeout = 1000;
                serialPort1.WriteTimeout = 1000;
            }

            try
            {
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("Can not open port");
            }
        }

        private void MertonomeBut_Click(object sender, EventArgs e)
        {
            // Open metronome settings
            MetronomeForm metronomeForm = new MetronomeForm();
            metronomeForm.Show();
        }

        private void Octave11CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 1 oct checked then 2 - unchecked
            if (Octave11CheckBox.Checked)
            {
                Octave12CheckBox.Checked = false;
                Octave12CheckBox.BackColor = Color.FromArgb(64, 64, 64);

                Octave11CheckBox.BackColor = Color.Black;


                // SEND ARDUINO NEW OCTAVE
            }
        }

        private void Octave12CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 2 oc checked then 1 - unchecked
            if (Octave12CheckBox.Checked)
            {
                Octave11CheckBox.Checked = false;
                Octave11CheckBox.BackColor = Color.FromArgb(64, 64, 64);

                Octave12CheckBox.BackColor = Color.Black;

                // SEND ARDUINO NEW OCTAVE
            }
        }

        private void Octave21CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 1 oct checked then 2 - unchecked
            if (Octave21CheckBox.Checked)
            {
                Octave22CheckBox.Checked = false;
                Octave22CheckBox.BackColor = Color.FromArgb(64, 64, 64);

                Octave21CheckBox.BackColor = Color.Black;

                // SEND ARDUINO NEW OCTAVE
            }
        }

        private void Octave22CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If 2 oc checked then 1 - unchecked
            if (Octave22CheckBox.Checked)
            {
                Octave21CheckBox.Checked = false;
                Octave21CheckBox.BackColor = Color.FromArgb(64, 64, 64);

                Octave22CheckBox.BackColor = Color.Black;

                // SEND ARDUINO NEW OCTAVE
            }
        }

        private void Delay1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Digits only
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Backspace
            if (e.KeyChar == (char)Keys.Back && NoteLength1TextBox.Text != "" &&
                NoteLength1TextBox.SelectionStart != 0)
            {
                NoteLength1TextBox.Text = NoteLength1TextBox.Text.Substring(0, NoteLength1TextBox.Text.Length - 1);
                NoteLength1TextBox.SelectionStart = NoteLength1TextBox.Text.Length;
            }
        }

        private void Delay2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Digits only
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Backspace
            if (e.KeyChar == (char)Keys.Back && NoteLength2TextBox.Text != "" &&
                NoteLength2TextBox.SelectionStart != 0)
            {
                NoteLength2TextBox.Text = NoteLength2TextBox.Text.Substring(0, NoteLength2TextBox.Text.Length - 1);
                NoteLength2TextBox.SelectionStart = NoteLength2TextBox.Text.Length;
            }
        }

        private void Delay1TextBox_TextChanged(object sender, EventArgs e)
        {
            // New delay set enabled
            SetDelay1But.Enabled = true;
        }

        private void Delay2TextBox_TextChanged(object sender, EventArgs e)
        {
            // New delay set enabled
            SetDelay2But.Enabled = true;
        }

        private void SetDelay1But_Click(object sender, EventArgs e)
        {
            if (NoteLength1TextBox.Text == "")
                NoteLength1TextBox.Text = "0";

            // SENDING ARDUINO DELAY

            SetDelay1But.Enabled = false;
        }

        private void SetDelay2But_Click(object sender, EventArgs e)
        {
            if (NoteLength2TextBox.Text == "")
                NoteLength2TextBox.Text = "0";

            // SENDING ARDUINO DELAY

            SetDelay2But.Enabled = false;
        }

        private void ResetBut_Click(object sender, EventArgs e)
        {
            // 1-1 2-2
            Octave11CheckBox.Checked = true;
            Octave22CheckBox.Checked = true;

            // Both initial delays are 0
            NoteLength1TextBox.Text = "no limit";
            NoteLength2TextBox.Text = "no limit";

            // SEND ARDUINO INFO
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Getting messages from arduino
                if (serialPort1.BytesToRead != 0) 
                {
                    // Message (serial.println())
                    string message = serialPort1.ReadLine();

                    // Array of the 1st sensor labels 
                    Label[] s1Notes = { C1, Cd1, D1, Dd1, E1, F1, Fd1, G1, Gd1, A1, B1, H1, CC1 };
                    // Array of the 2nd sensor labels
                    Label[] s2Notes = { C2, Cd2, D2, Dd2, E2, F2, Fd2, G2, Gd2, A2, B2, H2, CC2 };

                    if (message != "_\r") 
                    // If the message is not empty (some note)
                    {
                        // Decomposing the message 
                        string[] decMessage = message.Split('.');

                        if (decMessage[0] == "s1")
                        // If it's the 1st sensor
                        {
                            if (decMessage[1] == "currN")
                            // If current note changed
                            {
                                // Each label has casual back color
                                foreach (Label l in s1Notes)
                                    l.BackColor = Color.FromArgb(64, 64, 64);

                                int pos = Convert.ToInt32(decMessage[2]);
                                // Current note label has black back color
                                s1Notes[pos].BackColor = Color.Black;

                                // Textbox shows the current note name
                                CurrentNote1TextBox.Text = s1Notes[pos].Text;
                            }
                            else
                            // Current octave changed
                            {
                                if (decMessage[2] == "0")
                                    //Octave11CheckBox_CheckedChanged(null, null);
                                    Octave11CheckBox.BackColor = Color.White;
                                else
                                    Octave12CheckBox_CheckedChanged(null, null);
                            }
                        }
                        else
                        // It's the 2nd sensor
                        {
                            if (decMessage[1] == "currN")
                            // If current note changed
                            {
                                // Each label has casual back color
                                foreach (Label l in s2Notes)
                                    l.BackColor = Color.FromArgb(64, 64, 64);

                                int pos = Convert.ToInt32(decMessage[2]);
                                // Current note label has black back color
                                s2Notes[pos].BackColor = Color.Black;

                                // Textbox shows the current note name
                                CurrentNote1TextBox.Text = s2Notes[pos].Text;
                            }
                            else
                            // Current octave changed
                            {
                                if (decMessage[2] == "0")
                                    Octave21CheckBox_CheckedChanged(null, null);
                                else
                                    Octave22CheckBox_CheckedChanged(null, null);
                            }
                        }
                    }
                    else
                    {
                        // Textbox shows empty message
                        CurrentNote1TextBox.Text = "_";

                        // Each label has casual back color
                        foreach (Label l in s1Notes)
                            l.BackColor = Color.FromArgb(64, 64, 64);
                    }
                }
            }
            catch { }
        }

    }
}
