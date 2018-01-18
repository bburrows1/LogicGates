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
    partial class ORGate : LogicGates
    {
        public ORGate()
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

        private void Out_Click(object sender, EventArgs e)
        {
            OutputClick(sender, e, OutLocation);
        }

        private void TopButton_Click(object sender, EventArgs e)
        {
            PublicVariables.IsTop = true;
            InputClick(sender, e, TopInLocation, true);
        }

        private void BottomButton_Click(object sender, EventArgs e)
        {
            PublicVariables.IsTop = false;
            InputClick(sender, e, BotInLocation, false);
        }
    }
}
