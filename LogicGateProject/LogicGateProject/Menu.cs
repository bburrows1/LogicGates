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
    public partial class Menu1 : Form
    {
        private int Level = 0;
        public Menu1()
        {
            InitializeComponent();
        }

        //Quit
        private void Quit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program?\nUnsaved circuits will be lost.", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //GCSE
        private void GCSEButton_Click(object sender, EventArgs e)
        {
            Level = 1;
            PublicVariables.Menu1 = this;
            this.Hide();
            PublicVariables.Menu2.Location = this.Location;
            PublicVariables.Menu2.Show();
        }

        //A-Level
        private void AlevelButton_Click(object sender, EventArgs e)
        {
            Level = 2;
            PublicVariables.Menu1 = this;
            this.Hide();
            PublicVariables.Menu2.Location = this.Location;
            PublicVariables.Menu2.Show();
        }

        //Further Learning
        private void FurtherButton_Click(object sender, EventArgs e)
        {
            Level = 3;
            PublicVariables.Menu1 = this;
            this.Hide();
            PublicVariables.Simulator.AdjustLevel(Level);
            PublicVariables.Simulator.Show();
        }

        //Allows moving the form
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PublicVariables.ReleaseCapture();
                PublicVariables.SendMessage(Handle, PublicVariables.WM_NCLBUTTONDOWN, PublicVariables.HT_CAPTION, 0);
                PublicVariables.Menu2.Location = this.Location;
            }
        }

        //Return difficulty level
        public int GetLevel()
        {
            return Level;
        }
    }
}
