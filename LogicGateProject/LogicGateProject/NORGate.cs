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
    partial class NORGate : LogicGates
    {
        public NORGate()
        {
            InitializeComponent();
            TopButton.Parent = Gate;
            BottomButton.Parent = Gate;
            Out.Parent = Gate;
            TopButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Gray);
            BottomButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Gray);
            Out.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Gray);
            TopButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.DarkGray);
            BottomButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.DarkGray);
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
    }
}
