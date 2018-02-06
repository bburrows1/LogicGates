using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LogicGateProject
{
    partial class Input : LogicGates
    {
        public Input()
        {
            InitializeComponent();
            Out.Parent = Gate;
            Out.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, Color.Gray);
            Out.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.DarkGray);
            CreateGate();
            SetMarkers();
            PublicVariables.Simulator.AddToDesignerPanel(this);
            UpdateLocations();
            SetInputID();
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

        private void InputButton_Click(object sender, EventArgs e)
        {
            ToggleResult();
            if (GetResult())
                InputButton.BackColor = Color.Green;
            else
                InputButton.BackColor = Color.Red;
            UpdateLogic();
        }

        private void ClockButton_Click(object sender, EventArgs e)
        {
            string NewTimeString;
            float NewTime;
            do
            {
                NewTimeString = Interaction.InputBox("Select Interval (0 - 1000 Seconds)", "Timer Interval", GetWaitTime().ToString());
            } while (!(float.TryParse(NewTimeString, out NewTime) && NewTime >= 0 && NewTime <= 1000));
            SetWaitTime(NewTime);
        }

        private void UpdateTimer(float NewTime)
        {
            if (NewTime == 0)
                Timer.Enabled = false;
            else
            {
                Timer.Interval = (int)((GetWaitTime() * 1000));
                Timer.Enabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            InputButton_Click(sender, e);
        }
    }
}
