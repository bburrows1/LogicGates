using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGateProject
{
    partial class NOTGate : LogicGates
    {
        public NOTGate()
        {
            InitializeComponent();
            In.Parent = Gate;
            Out.Parent = Gate;
            In.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Gray);
            Out.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Gray);
            In.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.DarkGray);
            Out.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.DarkGray);
        }

        public void DragBox_MouseDown(object sender, MouseEventArgs e)
        {
            Down(sender, e);
        }

        public void DragBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoved(sender, e);
        }

        private void Out_Click(object sender, EventArgs e)
        {
            OutputClick(sender, e);
        }

        private void In_Click(object sender, EventArgs e)
        {
            PublicVariables.IsTop = true;
            InputClick(sender, e);
        }
    }
}
