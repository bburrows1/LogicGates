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
    public partial class TruthTable : Form
    {
        public TruthTable()
        {
            InitializeComponent();
        }

        public void CreateTable()
        {

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PublicVariables.ReleaseCapture();
                PublicVariables.SendMessage(Handle, PublicVariables.WM_NCLBUTTONDOWN, PublicVariables.HT_CAPTION, 0);
                PublicVariables.Menu2.Location = this.Location;
            }
        }
    }
}
