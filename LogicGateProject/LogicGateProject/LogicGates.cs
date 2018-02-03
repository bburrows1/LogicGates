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
        private bool Traversed;
        private bool Result;

        public void CreateGate()
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
                if (PublicVariables.Delete)
                {
                    DeleteGate();
                }
                else 
                    MouseDownLocation = e.Location;
            }
        }

        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.X + Left - MouseDownLocation.X) >= 0 && (e.X + Left - MouseDownLocation.X) <= 1009)
                {
                    Left += e.X - MouseDownLocation.X;
                    UpdateLocations();
                }
                if ((e.Y + Top - MouseDownLocation.Y) >= 0 && (e.Y + Top - MouseDownLocation.Y) <= 719)
                {
                    Top += e.Y - MouseDownLocation.Y;
                    UpdateLocations();
                }
                PublicVariables.Simulator.Invalidate();
            }
        }

        public void UpdateLocations()
        {
            TopInLocation = new Point(Location.X + TopInMarker.X, Location.Y + TopInMarker.Y);
            BotInLocation = new Point(Location.X + BotInMarker.X, Location.Y + BotInMarker.Y);
            OutLocation = new Point(Location.X + OutMarker.X, Location.Y + OutMarker.Y);
        }

        public void DeleteGate()
        {
            if (TopInConnection != null)
            {
                TopInConnection.OutConnection.Remove(this);
                TopInConnection = null;
            }
            if (BotInConnection != null)
            {
                BotInConnection.OutConnection.Remove(this);
                BotInConnection = null;
            }
            foreach(LogicGates Output in OutConnection)
            {
                if (Output.TopInConnection == this)
                {
                    Output.TopInConnection = null;
                }
                if (Output.BotInConnection == this)
                {
                    Output.BotInConnection = null;
                }
            }
            OutConnection.Clear();
            PublicVariables.Delete = false;
            PublicVariables.Simulator.DeleteAllButton();
            Hide();
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
            UpdateLogic();
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

        public bool IsTraversed()
        {
            return Traversed;
        }

        public void ResetTraversed()
        {
            Traversed = false;
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

        public virtual void UpdateLogic()
        {
        }

        public bool GetResult()
        {
            return Result;
        }

        public void ToggleResult()
        {
            Result = !Result;
            UpdateOutputs();
        }

        public void TrueResult()
        {
            Result = true;
            UpdateOutputs();
        }

        public void FalseResult()
        {
            Result = false;
            UpdateOutputs();
        }

        public virtual bool CheckConnected()
        {
            return (TopInConnection != null && BotInConnection != null);
        }

        public void UpdateOutputs()
        {
            foreach (LogicGates Output in OutConnection)
            {
                Output.UpdateLogic();
            }
        }

        public void CheckUpdate(bool Result)
        {
            if (Result != GetResult())
            {
                if (Result)
                    TrueResult();
                else
                    FalseResult();
            }
        }

        public virtual int GetID()
        {
            return 0;
        }
    }


    public partial class Input : LogicGates
    {
        private int GateID;

        public void SetID()
        {
            GateID = PublicVariables.InputID;
            PublicVariables.InputID++;
            IDLabel.Text = GateID.ToString();
        }
        public void SetLocations()
        {
            OutMarker = new Point(130, 37);
        }

        public override void UpdateLogic()
        {
            UpdateOutputs();
        }

        public override bool CheckConnected()
        {
            return true;
        }

        public override int GetID()
        {
            return GateID;
        }
    }

    public partial class Output : LogicGates
    {
        private int GateID;

        public void SetID()
        {
            GateID = PublicVariables.OutputID;
            PublicVariables.OutputID++;
            IDLabel.Text = GateID.ToString();
        }

        public void SetLocations()
        {
            TopInMarker = new Point(5, 37);
        }

        public override bool CheckConnected()
        {
            return (TopInConnection != null);
        }

        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                OutputBox.BackColor = Color.Gray;
            }
            if(TopInConnection.GetResult())
            {
                OutputBox.BackColor = Color.Green;
            }
            else 
            {
                OutputBox.BackColor = Color.Red;
            }
        }
        public override int GetID()
        {
            return GateID;
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

        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                bool LocalResult = TopInConnection.GetResult() && BotInConnection.GetResult();
                CheckUpdate(LocalResult);
            }
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

        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                bool LocalResult = TopInConnection.GetResult() || BotInConnection.GetResult();
                CheckUpdate(LocalResult);
            }
        }
    }

    public partial class NOTGate : LogicGates
    {
        public void SetLocations()
        {
            TopInMarker = new Point(5, 43);
            OutMarker = new Point(125, 43);
        }

        public override bool CheckConnected()
        {
            return (TopInConnection != null);
        }
        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                bool LocalResult = !TopInConnection.GetResult();
                CheckUpdate(LocalResult);
            }
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

        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                bool LocalResult = TopInConnection.GetResult() != BotInConnection.GetResult();
                CheckUpdate(LocalResult);
            }
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

        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                bool LocalResult = !(TopInConnection.GetResult() && BotInConnection.GetResult());
                CheckUpdate(LocalResult);
            }
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

        public override void UpdateLogic()
        {
            if (CheckConnected())
            {
                bool LocalResult = !(TopInConnection.GetResult() || BotInConnection.GetResult());
                CheckUpdate(LocalResult);
            }
        }
    }
}
