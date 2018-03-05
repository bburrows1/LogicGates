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
        private int ID;
        protected LogicGates TopInConnection;
        protected LogicGates BotInConnection;
        protected List<LogicGates> OutConnections = new List<LogicGates>();
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
            ID = PublicVariables.ID;
            PublicVariables.ID++;
            BackColor = System.Drawing.Color.Transparent;
            Location = new System.Drawing.Point(0, 0);
            Size = new System.Drawing.Size(131, 93);
        }

        public string GetID()
        {
            return ID.ToString();
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
                TopInConnection.OutConnections.Remove(this);
                TopInConnection.UpdateLogic();
                TopInConnection = null;
            }
            if (BotInConnection != null)
            {
                BotInConnection.OutConnections.Remove(this);
                BotInConnection.UpdateLogic();
                BotInConnection = null;
            }
            foreach(LogicGates Output in OutConnections)
            {
                if (Output.TopInConnection == this)
                {
                    Output.TopInConnection = null;
                }
                if (Output.BotInConnection == this)
                {
                    Output.BotInConnection = null;
                }
                Output.UpdateLogic();
            }
            OutConnections.Clear();
            PublicVariables.Delete = false;
            PublicVariables.Simulator.DeleteAllButton();
            PublicVariables.Gates.Remove(this);
            Hide();
            PublicVariables.Simulator.Invalidate();
            Dispose();
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
                if(!Output.OutConnections.Contains(Input))
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

        private void CreateConnection(LogicGates Input, LogicGates Output, bool IsTop)
        {
            if (IsTop)
            {
                Input.TopInConnection = Output;
            }
            else
            {
                Input.BotInConnection = Output;
            }
            Output.OutConnections.Add(Input);
            PublicVariables.InputGate = null;
            PublicVariables.OutputGate = null;
            Output.UpdateOutputs();
            PublicVariables.Simulator.Invalidate();
        }

        private void RemoveConnection(LogicGates Input, bool IsTop)
        {
            if (IsTop)
            {
                if (Input.TopInConnection != null)
                {
                    Input.TopInConnection.OutConnections.Remove(Input);
                    Input.TopInConnection = null;
                }
            }
            else
            {
                if (Input.BotInConnection != null)
                {
                    Input.BotInConnection.OutConnections.Remove(Input);
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
            foreach (LogicGates Output in OutConnections)
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
            foreach (LogicGates Output in OutConnections)
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

        public virtual int GetInputID()
        {
            return 0;
        }

        public virtual void UpdateStep()
        {

        }

        public virtual string GetSaveData()
        {
            string Data = "";
            Data += GetID() + ",";
            Data += Location.X.ToString() + " " + Location.Y.ToString() + ",";
            if (TopInConnection != null)
                Data += TopInConnection.GetID() + ",";
            else
                Data += "null,";
            if (BotInConnection != null)
                Data += BotInConnection.GetID() + ",";
            else
                Data += "null";
            return Data;
        }

        public void SetLocation (int X, int Y)
        {
            Point NewLocation = new Point(X, Y);
            Location = NewLocation;
            UpdateLocations();
        }

        public void SetID(int NewID)
        {
            ID = NewID;
        }

        public void SetTopInConnection(LogicGates Gate)
        {
            CreateConnection(this, Gate, true);
        }

        public LogicGates GetTopInConnection()
        {
            return TopInConnection;
        }

        public void SetBotInConnection(LogicGates Gate)
        {
            CreateConnection(this, Gate, false);
        }

        public LogicGates GetBotInConnection()
        {
            return BotInConnection;
        }

        public void SetOutConnections(Dictionary<LogicGates, bool> Gates)
        {
            foreach (KeyValuePair<LogicGates, bool> Gate in Gates)
            {
                CreateConnection(Gate.Key, this, Gate.Value);
            }
        }

        public Dictionary<LogicGates, bool> GetOutConnections()
        {
            Dictionary<LogicGates, bool> OutDictionary = new Dictionary<LogicGates, bool>();
            foreach (LogicGates Gate in OutConnections)
            {
                if (Gate.TopInConnection == this)
                    OutDictionary.Add(Gate, true);
                if (Gate.BotInConnection == this)
                    OutDictionary.Add(Gate, false);
            }
            return OutDictionary;
        }

        public virtual void SetWaitTime(float Time)
        {
        }

        public virtual void CreateExpression(ref string Expression)
        {
        }
        public virtual bool CheckForLoop()
        {
            if (OutConnections.Contains(TopInConnection) || OutConnections.Contains(BotInConnection))
                return true;
            return false;
        }

        public virtual int GetOutputID()
        {
            return 0;
        }

        public bool HasNoOutputs()
        {
            if (OutConnections.Count == 0)
                return true;
            else
                return false;
        }
    }


    public partial class Input : LogicGates
    {
        private int InputGateID;
        private float WaitTime;

        public void SetInputID()
        {
            InputGateID = PublicVariables.GetInputID();
            IDLabel.Text = PublicVariables.NumberToCharacter(InputGateID).ToString();
        }

        public override int GetInputID()
        {
            return InputGateID;
        }

        public void EditInputID(char InputID)
        {
            InputGateID = PublicVariables.CharacterToNumber(InputID);
            IDLabel.Text = PublicVariables.NumberToCharacter(InputGateID).ToString();
        }

        public void SetMarkers()
        {
            OutMarker = new Point(130, 37);
        }

        public override void UpdateLogic()
        {
            UpdateOutputs();
            UpdateStep();
        }

        public override bool CheckConnected()
        {
            return true;
        }

        public override void SetWaitTime(float Time)
        {
            WaitTime = Time;
            UpdateTimer(Time);
        }

        public float GetWaitTime()
        {
            return WaitTime;
        }

        public override string GetSaveData()
        {
            string Data = "";
            Data += GetID() + ",";
            Data += Location.X.ToString() + " " + Location.Y.ToString() + ",";
            if (TopInConnection != null)
                Data += TopInConnection.GetID() + ",";
            else
                Data += "null,";
            if (BotInConnection != null)
                Data += BotInConnection.GetID() + ",";
            else
                Data += "null,";
            Data += WaitTime.ToString();
            return Data;
        }

        public override void CreateExpression(ref string Expression)
        {
            Expression += PublicVariables.NumberToCharacter(InputGateID).ToString();
        }
    }

    public partial class Output : LogicGates
    {
        private int OutputGateID;

        public void SetOutputID()
        {
            OutputGateID = PublicVariables.GetOutputID();
            IDLabel.Text = OutputGateID.ToString();
        }

        public override int GetOutputID()
        {
            return OutputGateID;
        }

        public void SetMarkers()
        {
            TopInMarker = new Point(5, 37);
        }

        public override bool CheckConnected()
        {
            return (TopInConnection != null);
        }

        public override void UpdateLogic()
        {
            if (TopInConnection != null)
            {
                if (TopInConnection.GetResult())
                {
                    OutputBox.BackColor = Color.Green;
                    TrueResult();
                }
                else
                {
                    OutputBox.BackColor = Color.Red;
                    FalseResult();
                }
            }
            else
            {
                OutputBox.BackColor = Color.Red;
                FalseResult();
            }
            UpdateStep();
        }
        public override int GetInputID()
        {
            return OutputGateID;
        }

        public override void CreateExpression(ref string Expression)
        {
            TopInConnection.CreateExpression(ref Expression);
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
            else
                CheckUpdate(false);
            UpdateStep();
        }

        public override void UpdateStep()
        {
            if (PublicVariables.Step)
            {
                if (TopInConnection != null)
                {
                    if (TopInConnection.GetResult())
                        TopButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        TopButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (BotInConnection != null)
                {
                    if (BotInConnection.GetResult())
                        BottomButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        BottomButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (GetResult())
                    Out.BackColor = Color.FromArgb(100, Color.Green);
                else
                    Out.BackColor = Color.FromArgb(100, Color.Red);
            }
            else
            {
                TopButton.BackColor = Color.Transparent;
                BottomButton.BackColor = Color.Transparent;
                Out.BackColor = Color.Transparent;
            }
        }

        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                Expression += "(";
                TopInConnection.CreateExpression(ref Expression);
                Expression += ".";
                BotInConnection.CreateExpression(ref Expression);
                Expression += ")";
            }
            else
                Expression = "Invalid Circuit";
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
            else
                CheckUpdate(false);
            UpdateStep();
        }

        public override void UpdateStep()
        {
            if (PublicVariables.Step)
            {
                if (TopInConnection != null)
                {
                    if (TopInConnection.GetResult())
                        TopButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        TopButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (BotInConnection != null)
                {
                    if (BotInConnection.GetResult())
                        BottomButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        BottomButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (GetResult())
                    Out.BackColor = Color.FromArgb(100, Color.Green);
                else
                    Out.BackColor = Color.FromArgb(100, Color.Red);
            }
            else
            {
                TopButton.BackColor = Color.Transparent;
                BottomButton.BackColor = Color.Transparent;
                Out.BackColor = Color.Transparent;
            }
        }

        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                Expression += "(";
                TopInConnection.CreateExpression(ref Expression);
                Expression += "+";
                BotInConnection.CreateExpression(ref Expression);
                Expression += ")";
            }
            else
                Expression = "Invalid Circuit";
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
            else
                CheckUpdate(false);
            UpdateStep();
        }

        public override void UpdateStep()
        {
            if (PublicVariables.Step)
            {
                if (TopInConnection != null)
                {
                    if (TopInConnection.GetResult())
                        In.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        In.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (GetResult())
                    Out.BackColor = Color.FromArgb(100, Color.Green);
                else
                    Out.BackColor = Color.FromArgb(100, Color.Red);
            }
            else
            {
                In.BackColor = Color.Transparent;
                Out.BackColor = Color.Transparent;
            }
        }

        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                TopInConnection.CreateExpression(ref Expression);
                Expression += "'";
            }
            else
                Expression = "Invalid Circuit";
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
            else
                CheckUpdate(false);
            UpdateStep();
        }

        public override void UpdateStep()
        {
            if (PublicVariables.Step)
            {
                if (TopInConnection != null)
                {
                    if (TopInConnection.GetResult())
                        TopButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        TopButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (BotInConnection != null)
                {
                    if (BotInConnection.GetResult())
                        BottomButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        BottomButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (GetResult())
                    Out.BackColor = Color.FromArgb(100, Color.Green);
                else
                    Out.BackColor = Color.FromArgb(100, Color.Red);
            }
            else
            {
                TopButton.BackColor = Color.Transparent;
                BottomButton.BackColor = Color.Transparent;
                Out.BackColor = Color.Transparent;
            }
        }

        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                Expression += "(";
                TopInConnection.CreateExpression(ref Expression);
                Expression += "%";
                BotInConnection.CreateExpression(ref Expression);
                Expression += ")";
            }
            else
                Expression = "Invalid Circuit";
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
            else
                CheckUpdate(false);
            UpdateStep();
        }

        public override void UpdateStep()
        {
            if (PublicVariables.Step)
            {
                if (TopInConnection != null)
                {
                    if (TopInConnection.GetResult())
                        TopButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        TopButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (BotInConnection != null)
                {
                    if (BotInConnection.GetResult())
                        BottomButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        BottomButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (GetResult())
                    Out.BackColor = Color.FromArgb(100, Color.Green);
                else
                    Out.BackColor = Color.FromArgb(100, Color.Red);
            }
            else
            {
                TopButton.BackColor = Color.Transparent;
                BottomButton.BackColor = Color.Transparent;
                Out.BackColor = Color.Transparent;
            }
        }

        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                Expression += "(";
                TopInConnection.CreateExpression(ref Expression);
                Expression += ".";
                BotInConnection.CreateExpression(ref Expression);
                Expression += ")'";
            }
            else
                Expression = "Invalid Circuit";
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
            else
                CheckUpdate(false);
            UpdateStep();
        }

        public override void UpdateStep()
        {
            if (PublicVariables.Step)
            {
                if (TopInConnection != null)
                {
                    if (TopInConnection.GetResult())
                        TopButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        TopButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (BotInConnection != null)
                {
                    if (BotInConnection.GetResult())
                        BottomButton.BackColor = Color.FromArgb(100, Color.Green);
                    else
                        BottomButton.BackColor = Color.FromArgb(100, Color.Red);
                }
                if (GetResult())
                    Out.BackColor = Color.FromArgb(100, Color.Green);
                else
                    Out.BackColor = Color.FromArgb(100, Color.Red);
            }
            else
            {
                TopButton.BackColor = Color.Transparent;
                BottomButton.BackColor = Color.Transparent;
                Out.BackColor = Color.Transparent;
            }
        }

        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                Expression += "(";
                TopInConnection.CreateExpression(ref Expression);
                Expression += "+";
                BotInConnection.CreateExpression(ref Expression);
                Expression += ")'";
            }
            else
                Expression = "Invalid Circuit";
        }
    }
}
