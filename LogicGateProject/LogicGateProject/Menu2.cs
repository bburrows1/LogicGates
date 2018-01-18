using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGateProject
{
    public partial class Menu2 : Form
    {
        public Menu2()
        {
            InitializeComponent();
        }

        //Back
        private void Back_Click(object sender, EventArgs e)
        {
            PublicVariables.level = 0;
            this.Hide();
            PublicVariables.Menu1.Show();
        }

        //Quit
        private void Quit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really weant to close the program?\nUnsaved circuits will be lost.",
                "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Design
        private void Design_Click(object sender, EventArgs e)
        {
            this.Hide();
            PublicVariables.Simulator.Show();
        }

        //Allows Form to move
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PublicVariables.ReleaseCapture();
                PublicVariables.SendMessage(Handle, PublicVariables.WM_NCLBUTTONDOWN, PublicVariables.HT_CAPTION, 0);
                PublicVariables.Menu1.Location = this.Location;
            }
        }

        private void Quiz_Click(object sender, EventArgs e)
        {
            this.Hide();
            PublicVariables.Quiz.Show();
        }
    }
}
