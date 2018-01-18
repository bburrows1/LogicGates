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
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
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

        //Back
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            PublicVariables.Menu2.Show();
        }

        //Allows form to move
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PublicVariables.ReleaseCapture();
                PublicVariables.SendMessage(Handle, PublicVariables.WM_NCLBUTTONDOWN, PublicVariables.HT_CAPTION, 0);
                PublicVariables.Menu1.Location = this.Location;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            ConvertButton.BackColor = Color.FromArgb(22, 58, 122);
            CreateButton.BackColor = Color.FromArgb(28, 66, 130);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateButton.BackColor = Color.FromArgb(22, 58, 122);
            ConvertButton.BackColor = Color.FromArgb(28, 66, 130);
        }
    }
}
