﻿using System;
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
    public partial class ExpressionsTable : Form
    {
        public ExpressionsTable()
        {
            InitializeComponent();
        }

        //Empties Table
        public void ResetTable()
        {
            ListView.Clear();
            ListView.Columns.Add("Output", 60);
            ListView.Columns.Add("Expression", 400);
        }

        //Adds a new expression to table
        public void AddToTable(string GateID, string Expression)
        {
            string[] Items = { GateID, Expression };
            ListView.Items.Add(new ListViewItem(Items));
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
