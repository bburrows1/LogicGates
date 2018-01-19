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
        /// <summary>
        /// test
        /// </summary>
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
                }
                if ((e.Y + this.Top - MouseDownLocation.Y) >= 0 && (e.Y + this.Top - MouseDownLocation.Y) <= 719)
                {
                    this.Top += e.Y - MouseDownLocation.Y;
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
                }
                PublicVariables.Simulator.Invalidate();
            }
        }

        public void InputClick(object sender, EventArgs e, Point Location, bool IsTop)
        {
            if (PublicVariables.InputGate == this)
            {
                PublicVariables.InputGate = null;
                return;
            }
            else
            {
                PublicVariables.InputPoint = Location;
                PublicVariables.InputGate = this;
            }

            if (PublicVariables.OutputGate != null && PublicVariables.InputGate != PublicVariables.OutputGate)
            {
                //Delete old connection
                if (IsTop)
                {
                    if (TopInConnection != null)
                    {
                        RemoveConnection(TopInConnectionIndex);
                        TopInConnection.OutConnection.Remove(this);
                        TopInConnection = null;
                    }
                }
                else
                {
                    if (BotInConnection != null)
                    {
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
        }

        public void OutputClick(object sender, EventArgs e, Point Location)
        {
            if (PublicVariables.OutputGate == this)
            {
                PublicVariables.OutputGate = null;
                return;
            }
            else
            {
                PublicVariables.OutputPoint = Location;
                PublicVariables.OutputGate = this;
            }

            if (PublicVariables.InputGate != null && PublicVariables.InputGate != PublicVariables.OutputGate)
            {
                //Delete old connection
                if (PublicVariables.IsTop)
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
        }

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
    }

    public partial class Input : LogicGates
    {
        public void SetLocations()
        {
            OutLocation = new Point(this.Location.X + 130, this.Location.Y + 37);
        }
    }

    public partial class Output : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 37);
        }
    }

    public partial class ANDGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 25);
            BotInLocation = new Point(this.Location.X + 5, this.Location.Y + 64);
            OutLocation = new Point(this.Location.X + 125, this.Location.Y + 45);
        }
    }

    public partial class ORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 25);
            BotInLocation = new Point(this.Location.X + 5, this.Location.Y + 64);
            OutLocation = new Point(this.Location.X + 125, this.Location.Y + 45);
        }
    }

    public partial class NOTGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 25);
            OutLocation = new Point(this.Location.X + 125, this.Location.Y + 45);
        }
    }

    public partial class XORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 24);
            BotInLocation = new Point(this.Location.X + 5, this.Location.Y + 62);
            OutLocation = new Point(this.Location.X + 125, this.Location.Y + 43);
        }
    }

    public partial class NANDGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 25);
            BotInLocation = new Point(this.Location.X + 5, this.Location.Y + 64);
            OutLocation = new Point(this.Location.X + 125, this.Location.Y + 45);
        }
    }

    public partial class NORGate : LogicGates
    {
        public void SetLocations()
        {
            TopInLocation = new Point(this.Location.X + 5, this.Location.Y + 25);
            BotInLocation = new Point(this.Location.X + 5, this.Location.Y + 64);
            OutLocation = new Point(this.Location.X + 125, this.Location.Y + 45);
        }
    }
}
