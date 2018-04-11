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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Go to another form
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // If the form is closed the app stops
            Application.Exit(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // App stops
            Application.Exit();
        }
    }
}
