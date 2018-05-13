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

        // Previous note.
        public int prevNote1 = 0;
        // Current note;
        public int currNote1 = 0;
        // Previous octave.
        public int prevOctave1 = 0;
        // Current octave.
        public int currOctave1 = 0;

        // Previous note.
        public int prevNote2 = 0;
        // Current note;
        public int currNote2 = 0;
        // Previous octave.
        public int prevOctave2 = 0;
        // Current octave.
        public int currOctave2 = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Getting messages from arduino
                if (serialPort1.BytesToRead != 0)
                {
                    // Message (serial.println())
                    string message = serialPort1.ReadLine();
                    if (message.Length > 6 && message.Length < 9)
                    {
                        // Array of the 1st sensor note labels.
                        Label[] s1Notes = { C1, Cd1, D1, Dd1, E1, F1, Fd1, G1, Gd1, A1, B1, H1, CC1 };
                        // Array of the 2nd sensor note labels.
                        Label[] s2Notes = { C2, Cd2, D2, Dd2, E2, F2, Fd2, G2, Gd2, A2, B2, H2, CC2 };

                        // Array of the 1st sensor octave labels.
                        Label[] s1Octaves = { Octave11Label, Octave12Label };
                        // Array of the 2nd sensor octave labels.
                        Label[] s2Octaves = { Octave21Label, Octave22Label };


                        // Decomposing the message 
                        string[] decMessage = message.Split('.');


                        // The 1st hand.
                        if (decMessage[0] == "1")
                        {
                            currNote1 = Convert.ToInt32(decMessage[1]);
                            currOctave1 = Convert.ToInt32(decMessage[2]);

                            // Note changed.
                            if (currNote1 != prevNote1)
                            {
                                // Previous label has casual backcolor.
                                s1Notes[prevNote1].BackColor = Color.FromArgb(64, 64, 64);
                                // Current label has black backcolor.
                                s1Notes[currNote1].BackColor = Color.Black;

                                // Textbox shows the name of the current note.
                                CurrentNote1TextBox.Text = s1Notes[currNote1].Text;

                                // Current becomes previous.
                                prevNote1 = currNote1;
                            }


                            // Octave changed.
                            if (currOctave1 != prevOctave1)
                            {
                                // Previous label has casual backcolor.
                                s1Octaves[prevOctave1].BackColor = Color.FromArgb(64, 64, 64);
                                // Current lable has black backcolor.
                                s1Octaves[currOctave1].BackColor = Color.Black;

                                // Current becomes previous.
                                prevOctave1 = currOctave1;
                            }
                        }

                        // The 2d hand.
                        if (decMessage[0] == "2")
                        {
                            currNote2 = Convert.ToInt32(decMessage[1]);
                            currOctave2 = Convert.ToInt32(decMessage[2]);

                            // Note changed.
                            if (currNote2 != prevNote2)
                            {
                                // Previous label has casual backcolor.
                                s2Notes[prevNote2].BackColor = Color.FromArgb(64, 64, 64);
                                // Current label has black backcolor.
                                s2Notes[currNote2].BackColor = Color.Black;

                                // Textbox shows the name of the current note.
                                CurrentNote2TextBox.Text = s2Notes[currNote2].Text;

                                // Current becomes previous.
                                prevNote2 = currNote2;
                            }

                            // Octave changed.
                            if (currOctave2 != prevOctave2)
                            {
                                // Previous label has casual backcolor.
                                s2Octaves[prevOctave2].BackColor = Color.FromArgb(64, 64, 64);
                                // Current lable has black backcolor.
                                s2Octaves[currOctave2].BackColor = Color.Black;

                                // Current becomes previous.
                                prevOctave2 = currOctave2;
                            }
                        }

                    }
                }
            }
            catch { }
        }

    }
}
