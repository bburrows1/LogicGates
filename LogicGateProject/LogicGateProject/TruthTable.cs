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

        //Clears the table then adds correct columns and rows
        public void ResetTable(List<LogicGates> Inputs, List<LogicGates> Outputs)
        {
            ListView.Clear();
            foreach (LogicGates Input in Inputs)
            {
                ListView.Columns.Add(PublicVariables.NumberToCharacter(Input.GetInputID()).ToString(), 25);
            }
            foreach (LogicGates Output in Outputs)
            {
                ListView.Columns.Add(Output.GetInputID().ToString(), 25);
            }
        }

        //Adds new item to table
        public void AddToTable(List<string> Inputs)
        {
            ListView.Items.Add(new ListViewItem(Inputs.ToArray()));
        }

        //Quit
        private void Quit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //Move Form
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
