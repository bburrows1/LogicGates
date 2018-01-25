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
        private int GateID;
        private LogicGates TopInConnection;
        private LogicGates BotInConnection;
        private List<LogicGates> OutConnection = new List<LogicGates>();
        private int TopInConnectionIndex = -1;
        private int BotInConnectionIndex = -1;
        protected Point TopInLocation;
        protected Point BotInLocation;
        protected Point OutLocation;
        private List<int> OutConnectionIndex = new List<int>();
        private Point MouseDownLocation;
        public bool Traversed;

        public void SetGateID()
        {
            GateID = PublicVariables.Gates.Count;
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
                    /*
                    if (TopInConnection != null)
                    {
                        Point Point = PublicVariables.InputPoints[TopInConnectionIndex];
                        Point.X += e.X - MouseDownLocation.X;
                        PublicVariables.InputPoints[TopInConnectionIndex] = Point;
                    }
                    if (BotInConnection != null)
                    {
                        Point Point = PublicVariables.InputPoints[BotInConnectionIndex];
                        Point.X += e.X - MouseDownLocation.X;
                        PublicVariables.InputPoints[BotInConnectionIndex] = Point;
                    }
                    if (OutConnection != null)
                    {
                        foreach (int Index in OutConnectionIndex)
                        {
                            Point Point = PublicVariables.OutputPoints[Index];
                            Point.X += e.X - MouseDownLocation.X;
                            PublicVariables.OutputPoints[Index] = Point;
                        }
                    }
                    */
                }
                if ((e.Y + this.Top - MouseDownLocation.Y) >= 0 && (e.Y + this.Top - MouseDownLocation.Y) <= 719)
                {
                    this.Top += e.Y - MouseDownLocation.Y;
                    /*
                    if (TopInConnection != null)
                    {
                        Point Point = PublicVariables.InputPoints[TopInConnectionIndex];
                        Point.Y += e.Y - MouseDownLocation.Y;
                        PublicVariables.InputPoints[TopInConnectionIndex] = Point;
                    }
                    if (BotInConnection != null)
                    {
                        Point Point = PublicVariables.InputPoints[BotInConnectionIndex];
                        Point.Y += e.Y - MouseDownLocation.Y;
                        PublicVariables.InputPoints[BotInConnectionIndex] = Point;
                    }
                    if (OutConnection != null)
                    {
                        foreach (int Index in OutConnectionIndex)
                        {
                            Point Point = PublicVariables.OutputPoints[Index];
                            Point.Y += e.Y - MouseDownLocation.Y;
                            PublicVariables.OutputPoints[Index] = Point;
                        }
                    }
                    */
                }
                PublicVariables.Simulator.Invalidate();
            }
        }

        public void UpdateLocations()
        {
            TopInLocation = new Point(this.Location.X + TopInLocation.X, this.Location.Y + TopInLocation.Y);
            BotInLocation = new Point(this.Location.X + BotInLocation.X, this.Location.Y + BotInLocation.Y);
            TopInLocation = new Point(this.Location.X + TopInLocation.X, this.Location.Y + TopInLocation.Y);
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

            /*
            if (thisclick)
            {
                if (PublicVariables.InputGate == this)
                {
                    PublicVariables.InputGate = null;
                    return;
                }
                else
                {
                    PublicVariables.InputPoint = new Point (Location.X + this.Location.X, Location.Y + this.Location.Y);
                    PublicVariables.InputGate = this;
                }
            }


            if (PublicVariables.OutputGate != null && PublicVariables.InputGate != PublicVariables.OutputGate)
            {
                //Delete old connection
                if (IsTop)
                {
                    if (TopInConnection != null)
                    {
                        TopInConnection.OutConnectionIndex.Remove(TopInConnectionIndex);
                        RemoveConnection(TopInConnectionIndex);
                        TopInConnection.OutConnection.Remove(this);
                        TopInConnection = null;
                    }
                }
                else
                {
                    if (BotInConnection != null)
                    {
                        BotInConnection.OutConnectionIndex.Remove(BotInConnectionIndex);
                        RemoveConnection(BotInConnectionIndex);
                        BotInConnection.OutConnection.Remove(this);
                        BotInConnection = null;
                    }
                }

                //Add new connection
                PublicVariables.InputPoints.Add(PublicVariables.InputPoint);
                PublicVariables.OutputPoints.Add(PublicVariables.OutputPoint);
                PublicVariables.IsTopList.Add(IsTop);
                if (IsTop)
                {
                    TopInConnection = PublicVariables.OutputGate;
                    TopInConnectionIndex = PublicVariables.InputPoints.Count - 1;
                }
                else
                {
                    BotInConnection = PublicVariables.OutputGate;
                    BotInConnectionIndex = PublicVariables.InputPoints.Count - 1;
                }
                PublicVariables.OutputGate.OutConnection.Add(this);
                PublicVariables.OutputGate.OutConnectionIndex.Add(PublicVariables.InputPoints.Count - 1);
                PublicVariables.InputGate = null;
                PublicVariables.OutputGate = null;
                PublicVariables.Simulator.Invalidate();
            }
            */
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

            /*
            if (PublicVariables.OutputGate == this)
            {
                PublicVariables.OutputGate = null;
                return;
            }
            else
            {
                PublicVariables.OutputPoint = new Point(Location.X + this.Location.X, Location.Y + this.Location.Y);
                PublicVariables.OutputGate = this;
            }

            if (PublicVariables.InputGate != null && PublicVariables.InputGate != PublicVariables.OutputGate)
            {
                //Delete old connection
                if (PublicVariables.InputGate.)
                {
                    if (PublicVariables.InputGate.TopInConnection != null)
                    {
                        RemoveConnection(PublicVariables.InputGate.TopInConnectionIndex);
                        PublicVariables.InputGate.TopInConnection.OutConnection.Remove(PublicVariables.InputGate);
                        PublicVariables.InputGate.TopInConnection = null;
                    }
                }
                else
                {
                    if (PublicVariables.InputGate.BotInConnection != null)
                    {
                        RemoveConnection(PublicVariables.InputGate.BotInConnectionIndex);
                        PublicVariables.InputGate.BotInConnection.OutConnection.Remove(PublicVariables.InputGate);
                        PublicVariables.InputGate.BotInConnection = null;
                    }
                }

                //Add new connection
                PublicVariables.InputPoints.Add(PublicVariables.InputPoint);
                PublicVariables.OutputPoints.Add(PublicVariables.OutputPoint);
                PublicVariables.IsTopList.Add(PublicVariables.IsTop);
                if (PublicVariables.IsTop)
                {
                    PublicVariables.InputGate.TopInConnection = this;
                    PublicVariables.InputGate.TopInConnectionIndex = PublicVariables.InputPoints.Count - 1;
                }
                else
                {
                    PublicVariables.InputGate.BotInConnection = this;
                    PublicVariables.InputGate.BotInConnectionIndex = PublicVariables.InputPoints.Count - 1;
                }
                OutConnection.Add(PublicVariables.InputGate);
                PublicVariables.InputGate = null;
                PublicVariables.OutputGate = null;
                PublicVariables.Simulator.Invalidate();
            }
            */
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
        }
        /*
        public void RemoveConnection(int Index)
        {
            PublicVariables.InputPoints.RemoveAt(Index);
            PublicVariables.OutputPoints.RemoveAt(Index);
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                for (int i = 0; i < Gate.OutConnectionIndex.Count; i++)
                {
                    if (Gate.OutConnectionIndex[i] > Index)
                        Gate.OutConnectionIndex[i]--;
                }
                if (Gate.TopInConnectionIndex > Index)
                    Gate.TopInConnectionIndex--;
                if (Gate.BotInConnectionIndex > Index)
                    Gate.BotInConnectionIndex--;
            }
        }
        */
        public void Traverse()
        {
            this.UpdateLocations();
            Traversed = true;
            if (TopInConnection != null)
            {
                if (!TopInConnection.Traversed)
                    TopInConnection.Traverse();
                PublicVariables.InputPoints.Add(TopInLocation);
            }
            if (BotInConnection != null)
            {
                if (!BotInConnection.Traversed)
                    BotInConnection.Traverse();
                PublicVariables.InputPoints.Add(BotInLocation);
            }
            foreach (LogicGates Output in OutConnection)
            {
                if (!Output.Traversed)
                    Output.Traverse();
                PublicVariables.OutputPoints.Add(OutLocation);
            }
        }
    }

    public partial class Input : LogicGates
    {
        public void SetLocations()
        {
            OutLocation = new Point(130, 37);
        }
    }

    public partial class Output : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 37);
        }
    }

    public partial class ANDGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 25);
            BotInLocation = new Point(5, 64);
            OutLocation = new Point(125, 45);
        }
    }

    public partial class ORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 25);
            BotInLocation = new Point(5, 64);
            OutLocation = new Point(125, 45);
        }
    }

    public partial class NOTGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 25);
            OutLocation = new Point(125, 45);
        }
    }

    public partial class XORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 24);
            BotInLocation = new Point(5, 62);
            OutLocation = new Point(125, 43);
        }
    }

    public partial class NANDGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 25);
            BotInLocation = new Point(5, 64);
            OutLocation = new Point(125, 45);
        }
    }

    public partial class NORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(5, 25);
            BotInLocation = new Point(5, 64);
            OutLocation = new Point(125, 45);
        }
    }
}
