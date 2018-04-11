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
            SetFrequency1But.Enabled = false;

            // Block delay 2 set button
            SetFrequency2But.Enabled = false;

            // Initial back color is black becuase they're checked 
            Octave11Label.BackColor = Color.Black;
            Octave22Label.BackColor = Color.Black;

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






        private void Delay1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Digits only
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Backspace
            if (e.KeyChar == (char)Keys.Back && NoteFrequency1TextBox.Text != "" &&
                NoteFrequency1TextBox.SelectionStart != 0)
            {
                NoteFrequency1TextBox.Text = NoteFrequency1TextBox.Text.Substring(0, NoteFrequency1TextBox.Text.Length - 1);
                NoteFrequency1TextBox.SelectionStart = NoteFrequency1TextBox.Text.Length;
            }
        }

        private void Delay2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Digits only
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;

            // Backspace
            if (e.KeyChar == (char)Keys.Back && NoteFrequency2TextBox.Text != "" &&
                NoteFrequency2TextBox.SelectionStart != 0)
            {
                NoteFrequency2TextBox.Text = NoteFrequency2TextBox.Text.Substring(0, NoteFrequency2TextBox.Text.Length - 1);
                NoteFrequency2TextBox.SelectionStart = NoteFrequency2TextBox.Text.Length;
            }
        }

        private void Delay1TextBox_TextChanged(object sender, EventArgs e)
        {
            // New delay set enabled
            SetFrequency1But.Enabled = true;
        }

        private void Delay2TextBox_TextChanged(object sender, EventArgs e)
        {
            // New delay set enabled
            SetFrequency2But.Enabled = true;
        }

        private void SetDelay1But_Click(object sender, EventArgs e)
        {
            if (NoteFrequency1TextBox.Text == "")
                NoteFrequency1TextBox.Text = "0";

            // SENDING ARDUINO FREQUENCY
            //string freq = "1." + NoteFrequency1TextBox.Text;
            //string freq = NoteFrequency1TextBox.Text;

            byte freq = Convert.ToByte(NoteFrequency1TextBox.Text);
            byte[] buf = { freq };
            serialPort1.Write(buf, 0 , 1);



            SetFrequency1But.Enabled = false;
        }

        private void SetDelay2But_Click(object sender, EventArgs e)
        {
            if (NoteFrequency2TextBox.Text == "")
                NoteFrequency2TextBox.Text = "0";

            // SENDING ARDUINO DELAY

            SetFrequency2But.Enabled = false;
        }

        private void ResetBut_Click(object sender, EventArgs e)
        {
            // 1-1 2-2
            Octave11Label.BackColor = Color.Black;
            Octave22Label.BackColor = Color.Black;

            // Both initial delays are 0
            NoteFrequency1TextBox.Text = "no limit";
            NoteFrequency2TextBox.Text = "no limit";

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

                            if (decMessage[3] == "currOc")
                            // Current octave changed
                            {
                                if (decMessage[4] == "0")
                                {
                                    Octave11Label.BackColor = Color.Black;
                                    Octave12Label.BackColor = Color.FromArgb(64, 64, 64);
                                }
                                else
                                {
                                    Octave12Label.BackColor = Color.Black;
                                    Octave11Label.BackColor = Color.FromArgb(64, 64, 64);
                                }
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

                            if (decMessage[3] == "currOc")
                            // Current octave changed
                            {
                                if (decMessage[4] == "0")
                                {
                                    Octave21Label.BackColor = Color.Black;
                                    Octave22Label.BackColor = Color.FromArgb(64, 64, 64);
                                }
                                else
                                {
                                    Octave22Label.BackColor = Color.Black;
                                    Octave21Label.BackColor = Color.FromArgb(64, 64, 64);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Textbox shows empty message
                        CurrentNote1TextBox.Text = "no";

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
