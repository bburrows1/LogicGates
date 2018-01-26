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
    public class LogicGates : UserControl
    {
        protected LogicGates TopInConnection;
        protected LogicGates BotInConnection;
        protected List<LogicGates> OutConnection = new List<LogicGates>();
        private Point TopInLocation;
        private Point BotInLocation;
        private Point OutLocation;
        protected Point TopInMarker;
        protected Point BotInMarker;
        protected Point OutMarker;
        private Point MouseDownLocation;
        public bool Traversed;

        public void SetGateID()
        {
            PublicVariables.Gates.Add(this);
            BackColor = System.Drawing.Color.Transparent;
            Location = new System.Drawing.Point(0, 0);
            Size = new System.Drawing.Size(131, 93);
        }

        public void Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.X + this.Left - MouseDownLocation.X) >= 0 && (e.X + this.Left - MouseDownLocation.X) <= 1009)
                {
                    this.Left += e.X - MouseDownLocation.X;
                    this.UpdateLocations();
                }
                if ((e.Y + this.Top - MouseDownLocation.Y) >= 0 && (e.Y + this.Top - MouseDownLocation.Y) <= 719)
                {
                    this.Top += e.Y - MouseDownLocation.Y;
                    this.UpdateLocations();
                }
                PublicVariables.Simulator.Invalidate();
            }
        }

        public void UpdateLocations()
        {
            TopInLocation = new Point(this.Location.X + TopInMarker.X, this.Location.Y + TopInMarker.Y);
            BotInLocation = new Point(this.Location.X + BotInMarker.X, this.Location.Y + BotInMarker.Y);
            OutLocation = new Point(this.Location.X + OutMarker.X, this.Location.Y + OutMarker.Y);
        }

        public bool IsValidInput(LogicGates Input, LogicGates Output, bool IsTop)
        {
            if (Output != null && Input != Output)
            {
                if (IsTop)
                {
                    if (Input.TopInConnection != Output)
                    {
                        return true;
                    }
                }
                else
                {
                    if (Input.BotInConnection != Output)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void InputClick(object sender, EventArgs e)
        {
            if (PublicVariables.InputGate != this)
            {
                PublicVariables.InputGate = this;
            }
            else
            {
                PublicVariables.InputGate = null;
                return;
            }
            if (IsValidInput(PublicVariables.InputGate, PublicVariables.OutputGate, PublicVariables.IsTop))
            {
                PublicVariables.InputGate.RemoveConnection(PublicVariables.InputGate, PublicVariables.IsTop);
                PublicVariables.InputGate.CreateConnection(PublicVariables.InputGate, PublicVariables.OutputGate, PublicVariables.IsTop);
                PublicVariables.Simulator.Invalidate();
            }
        }

        public bool IsValidOutput(LogicGates Input, LogicGates Output)
        {
            if (Input != null && Input != Output)
            {
                if(!Output.OutConnection.Contains(Input))
                {
                    return true;
                }
            }
            return false;
        }

        public void OutputClick(object sender, EventArgs e)
        {
            if (PublicVariables.OutputGate != this)
            {
                PublicVariables.OutputGate = this;
            }
            else
            {
                PublicVariables.OutputGate = null;
                return;
            }
            if (IsValidOutput(PublicVariables.InputGate, PublicVariables.OutputGate))
            {
                PublicVariables.InputGate.RemoveConnection(PublicVariables.InputGate, PublicVariables.IsTop);
                PublicVariables.InputGate.CreateConnection(PublicVariables.InputGate, PublicVariables.OutputGate, PublicVariables.IsTop);
                PublicVariables.Simulator.Invalidate();
            }
        }

        public void CreateConnection(LogicGates Input, LogicGates Output, bool IsTop)
        {
            if (IsTop)
            {
                Input.TopInConnection = Output;
            }
            else
            {
                Input.BotInConnection = Output;
            }
            Output.OutConnection.Add(Input);
            PublicVariables.InputGate = null;
            PublicVariables.OutputGate = null;
        }

        public void RemoveConnection(LogicGates Input, bool IsTop)
        {
            if (IsTop)
            {
                if (Input.TopInConnection != null)
                {
                    Input.TopInConnection.OutConnection.Remove(Input);
                    Input.TopInConnection = null;
                }
            }
            else
            {
                if (Input.BotInConnection != null)
                {
                    Input.BotInConnection.OutConnection.Remove(Input);
                    Input.BotInConnection = null;
                }
            }
        }

        public void Traverse()
        {
            Traversed = true;
            if (TopInConnection != null)
            {
                if (!TopInConnection.Traversed)
                {
                    PublicVariables.InputPoints.Add(TopInLocation);
                    PublicVariables.OutputPoints.Add(TopInConnection.OutLocation);
                }
            }
            if (BotInConnection != null)
            {
                if (!BotInConnection.Traversed)
                {
                    PublicVariables.InputPoints.Add(BotInLocation);
                    PublicVariables.OutputPoints.Add(BotInConnection.OutLocation);
                }
            }
            foreach (LogicGates Output in OutConnection)
            {
                if (!Output.Traversed)
                {
                    if (Output.TopInConnection == this)
                    {
                        PublicVariables.InputPoints.Add(Output.TopInLocation);
                        PublicVariables.OutputPoints.Add(OutLocation);
                    }
                    if (Output.BotInConnection == this)
                    {
                        PublicVariables.InputPoints.Add(Output.BotInLocation);
                        PublicVariables.OutputPoints.Add(OutLocation);
                    }
                }
            }
        }
        public virtual void UpdateLogic(bool Input)
        {
        }
    }


    public partial class Input : LogicGates
    {
        public void SetLocations()
        {
            OutMarker = new Point(130, 37);
        }

        public override void UpdateLogic(bool Input)
        {
            foreach (LogicGates Gate in OutConnection)
            {
                Gate.UpdateLogic(Input);
            }
        }
    }

    public partial class Output : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 37);
        }

        public override void UpdateLogic(bool Input)
        {
            if(Input)
            {
                OutputBox.BackColor = Color.Green;
            }
            else if (!Input)
            {
                OutputBox.BackColor = Color.Red;
            }
        }
    }

    public partial class ANDGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 25);
            BotInMarker = new Point(5, 64);
            OutMarker = new Point(125, 45);
        }
        public override void UpdateLogic(bool Input)
        {

        }
    }

    public partial class ORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 25);
            BotInMarker = new Point(5, 64);
            OutMarker = new Point(125, 45);
        }
    }

    public partial class NOTGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 43);
            OutMarker = new Point(125, 43);
        }
    }

    public partial class XORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 24);
            BotInMarker = new Point(5, 62);
            OutMarker = new Point(125, 43);
        }
    }

    public partial class NANDGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 25);
            BotInMarker = new Point(5, 63);
            OutMarker = new Point(125, 44);
        }
    }

    public partial class NORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 24);
            BotInMarker = new Point(5, 63);
            OutMarker = new Point(125, 43);
        }
    }
}
