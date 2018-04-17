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
        private static bool DisableEdit; //Prevents user editting circuit
        private int ID; //Unique ID for each gate
        protected LogicGates TopInConnection; //Input for top connection
        protected LogicGates BotInConnection; //Input for bottom connection
        protected List<LogicGates> OutConnections = new List<LogicGates>(); //List of all outputs
        //Location of origins for lines within designer
        private Point TopInLocation;
        private Point BotInLocation;
        private Point OutLocation;
        //Location of origins for lines within gate
        protected Point TopInMarker;
        protected Point BotInMarker;
        protected Point OutMarker;
        private Point MouseDownLocation; //Position Gate is moved from
        private bool Traversed; //Checks if lines for this gate have been drawn
        private bool Result; //Logic result of the gate

        public static void SetDisabled(bool Disabled)
        {
            DisableEdit = Disabled;
        }

        public static bool GetDisabled()
        {
            return DisableEdit;
        }

        //Sets ID and default values
        public void CreateGate()
        {
            PublicVariables.Gates.Add(this);
            ID = PublicVariables.ID;
            PublicVariables.ID++;
            BackColor = Color.Transparent;
            Location = new Point(0, 0);
            Size = new Size(131, 93);
        }

        public string GetID()
        {
            return ID.ToString();
        }

        //Deletes or moves gate
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

        //Moves gate
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !DisableEdit)
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

        //Keeps locations syncronised
        public void UpdateLocations()
        {
            TopInLocation = new Point(Location.X + TopInMarker.X, Location.Y + TopInMarker.Y);
            BotInLocation = new Point(Location.X + BotInMarker.X, Location.Y + BotInMarker.Y);
            OutLocation = new Point(Location.X + OutMarker.X, Location.Y + OutMarker.Y);
        }

        //Deletes Gate
        public void DeleteGate()
        {
            //Removes gates connections
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
            //Deletes gate
            PublicVariables.Delete = false;
            PublicVariables.Simulator.DeleteAllButton();
            PublicVariables.Gates.Remove(this);
            if (PublicVariables.InputGate == this)
                PublicVariables.InputGate = null;
            if (PublicVariables.OutputGate == this)
                PublicVariables.OutputGate = null;
            Hide();
            PublicVariables.Simulator.Invalidate();
            Dispose();
        }

        //Checks two gates can be connected for input
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

        //Input connection button clicked
        public void InputClick(object sender, EventArgs e)
        {
            if (!DisableEdit)
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
        }

        //Checks if two gates can be connected for output
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

        //Output connection button clicked
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

        //Creates a connection between two gates
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

        //Removes connection between two gates
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

        //Adds gate's connections to be drawn
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

        //Gate reevaluates its logic, different for every gate
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

        //Checks if gate is completly connected
        public virtual bool CheckConnected()
        {
            return (TopInConnection != null && BotInConnection != null);
        }

        //Gate tells its outputs to update their logic
        public void UpdateOutputs()
        {
            foreach (LogicGates Output in OutConnections)
            {
                Output.UpdateLogic();
            }
        }

        //Checks if there has been an update to the result
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

        //Gets the properties of the gate so they can be saved
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
                Data += BotInConnection.GetID();
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

        //Creates a dictionary of outputs, Key: Output Gate, Value: 0 = Top Input, 1 = Bot Input, 2 = Both Inputs
        public void SetOutConnections(Dictionary<LogicGates, int> Gates)
        {
            foreach (KeyValuePair<LogicGates, int> Gate in Gates)
            {
                if (Gate.Value == 2)
                {
                    CreateConnection(Gate.Key, this, true);
                    CreateConnection(Gate.Key, this, false);
                }
                else if (Gate.Value == 0)
                    CreateConnection(Gate.Key, this, true);
                else
                    CreateConnection(Gate.Key, this, false);
            }
        }

        public Dictionary<LogicGates, int> GetOutConnections()
        {
            Dictionary<LogicGates, int> OutDictionary = new Dictionary<LogicGates, int>();
            foreach (LogicGates Gate in OutConnections)
            {
                int Result;
                if (Gate.TopInConnection == this && Gate.BotInConnection == this && !(OutDictionary.TryGetValue(Gate, out Result) && Result == 2))
                    OutDictionary.Add(Gate, 2);
                else
                {
                    if (Gate.TopInConnection == this && !(OutDictionary.TryGetValue(Gate, out Result)))
                        OutDictionary.Add(Gate, 0);
                    if (Gate.BotInConnection == this && !(OutDictionary.TryGetValue(Gate, out Result)))
                        OutDictionary.Add(Gate, 1);
                }
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

        //Checks if a gate has no outputs
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
        private int InputGateID; //Used to identify each input gate
        private float WaitTime; //Stores the time interval between switching on a clock

        public void SetInputID()
        {
            InputGateID = PublicVariables.GetInputID();
            IDLabel.Text = PublicVariables.NumberToCharacter(InputGateID).ToString(); //Uses letter as ID to distinguish from outputs
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

        //Locations for lines
        public void SetMarkers()
        {
            OutMarker = new Point(130, 37);
        }

        //Tells all outputs to update
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

        //Adds gate's InputID as a letter to the expression
        public override void CreateExpression(ref string Expression)
        {
            Expression += PublicVariables.NumberToCharacter(InputGateID).ToString();
        }
    }

    public partial class Output : LogicGates
    {
        private int OutputGateID; //Used to identify all output gates

        public void SetOutputID()
        {
            OutputGateID = PublicVariables.GetOutputID();
            IDLabel.Text = OutputGateID.ToString();
        }

        public override int GetOutputID()
        {
            return OutputGateID;
        }

        //Locations for Lines
        public void SetMarkers()
        {
            TopInMarker = new Point(5, 37);
        }

        public override bool CheckConnected()
        {
            return (TopInConnection != null);
        }

        //Gets output from input gate
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

        //Gets the expression from its input gate
        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected())
            {
                TopInConnection.CreateExpression(ref Expression);
            }
            else
                Expression = "Invalid Circuit";
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

        //Checks logic with AND
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

        //Colours connection buttons with their result
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

        //Adds to Expression
        public override void CreateExpression(ref string Expression)
        {
            if (CheckConnected() && !CheckForLoop())
            {
                Expression += "(";
                TopInConnection.CreateExpression(ref Expression);
                Expression += ".";
                BotInConnection.CreateExpression(ref Expression);
                Expression += ")";
                if (Expression.StartsWith("Invalid Circuit"))
                    Expression = "Invalid Circuit";
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
                if (Expression.StartsWith("Invalid Circuit"))
                    Expression = "Invalid Circuit";
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
                if (Expression.StartsWith("Invalid Circuit"))
                    Expression = "Invalid Circuit";
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
                if (Expression.StartsWith("Invalid Circuit"))
                    Expression = "Invalid Circuit";
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
                if (Expression.StartsWith("Invalid Circuit"))
                    Expression = "Invalid Circuit";
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
                if (Expression.StartsWith("Invalid Circuit"))
                    Expression = "Invalid Circuit";
            }
            else
                Expression = "Invalid Circuit";
        }
    }
}
