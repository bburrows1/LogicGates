using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LogicGateProject
{
    public partial class Simulator : Form
    {
        public Simulator()
        {
            InitializeComponent();
        }

        //Clear placeholder when entered
        private void AddExpression_Enter(object sender, EventArgs e)
        {
            if (AddExpression.Text == "INPUT BOOLEAN EXPRESSION E.G. A.(B + C)' (USE % FOR XOR)")
            {
                AddExpression.Text = "";
                AddExpression.ForeColor = Color.Black;
            }
        }

        //Add placeholder if empty
        private void AddExpression_Leave(object sender, EventArgs e)
        {
            if (AddExpression.Text == "")
            {
                AddExpression.Text = "INPUT BOOLEAN EXPRESSION E.G. A.(B + C)' (USE % FOR XOR)";
                AddExpression.ForeColor = Color.Gray;
            }
        }

        //Quit
        private void Quit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program?\nUnsaved circuits will be lost.", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Adds a gate to display
        public void AddToDesignerPanel(LogicGates Gate)
        {
            DesignerPanel.Controls.Add(Gate);
        } 

        //Back
        private void Back_Click(object sender, EventArgs e)
        {
            Hide();
            SetUpQuiz(false, false);
            if (PublicVariables.Menu1.GetLevel() == 3)
            {
                PublicVariables.Menu1.Show();
                PublicVariables.Menu1.BringToFront();
            }
            else
            {
                PublicVariables.Menu2.Show();
                PublicVariables.Menu2.BringToFront();
            }

        }

        //Allow form to move
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PublicVariables.ReleaseCapture();
                PublicVariables.SendMessage(Handle, PublicVariables.WM_NCLBUTTONDOWN, PublicVariables.HT_CAPTION, 0);
            }
        }

        //Add new gates
        private void AddInput_Click(object sender, EventArgs e)
        {
            Input Input = new Input();
        }

        private void AddAND_Click(object sender, EventArgs e)
        {
            ANDGate ANDGate = new ANDGate();
        }

        private void AddOR_Click(object sender, EventArgs e)
        {
            ORGate ORGate = new ORGate();
        }

        private void AddNAND_Click(object sender, EventArgs e)
        {
            NANDGate NANDGate = new NANDGate();
        }

        private void AddNOR_Click(object sender, EventArgs e)
        {
            NORGate NORGate = new NORGate();
        }

        private void AddXOR_Click(object sender, EventArgs e)
        {
            XORGate XORGate = new XORGate();
        }

        private void AddNOT_Click(object sender, EventArgs e)
        {
            NOTGate NOTGate = new NOTGate();
        }

        private void AddOutput_Click(object sender, EventArgs e)
        {
            Output Output = new Output();
        }

        //Redraws the designer
        private void DesignerPanel_Paint(object sender, PaintEventArgs e)
        {
            //Create a list of lines to be drawn
            PublicVariables.InputPoints.Clear();
            PublicVariables.OutputPoints.Clear();
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (!Gate.IsTraversed())
                    Gate.Traverse();
            }
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                Gate.ResetTraversed();
            }
            //Draw lines
            for (int i = 0; i < PublicVariables.InputPoints.Count; i++)
            {
                int MidPoint;
                Point InputMidPoint;
                Point OutputMidPoint;
                if (PublicVariables.InputPoints[i].X > PublicVariables.OutputPoints[i].X)
                {
                    MidPoint = (PublicVariables.InputPoints[i].X + PublicVariables.OutputPoints[i].X) / 2;
                    InputMidPoint = new Point(MidPoint, PublicVariables.InputPoints[i].Y);
                    OutputMidPoint = new Point(MidPoint, PublicVariables.OutputPoints[i].Y);
                }
                else
                {
                    MidPoint = (PublicVariables.InputPoints[i].Y + PublicVariables.OutputPoints[i].Y) / 2;
                    InputMidPoint = new Point(PublicVariables.InputPoints[i].X, MidPoint);
                    OutputMidPoint = new Point(PublicVariables.OutputPoints[i].X, MidPoint);
                }
                e.Graphics.DrawLine(PublicVariables.Linepen, PublicVariables.InputPoints[i], InputMidPoint);
                e.Graphics.DrawLine(PublicVariables.Linepen, InputMidPoint, OutputMidPoint);
                e.Graphics.DrawLine(PublicVariables.Linepen, OutputMidPoint, PublicVariables.OutputPoints[i]);
            }
        }

        //Toggles Step-By-Step mode
        private void StepByStep_Click(object sender, EventArgs e)
        {
            PublicVariables.Step = !PublicVariables.Step;
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                Gate.UpdateStep();
            }
        }

        //Reveal delete all button
        public void DeleteAllButton()
        {
            if (PublicVariables.Delete)
                DeleteAll.Show();
            else
                DeleteAll.Hide();
        }

        //Change to delete mode
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            PublicVariables.Delete = !PublicVariables.Delete;
            DeleteAllButton();
        }

        //Delete all gates button
        private void DeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAllGates();
        }

        //Delete all gates
        private void DeleteAllGates()
        {
            while (PublicVariables.Gates.Count != 0)
            {
                PublicVariables.Gates[0].DeleteGate();
            }
            PublicVariables.ID = 1;
        }

        //Create data for truth table
        private void CreateTruthTable_Click(object sender, EventArgs e)
        {
            List<LogicGates> InputGates = new List<LogicGates>();
            List<LogicGates> OutputGates = new List<LogicGates>();
            List<bool> OriginalInputs = new List<bool>();
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (Gate.GetType() == typeof(Input))
                {
                    InputGates.Add(Gate);
                    OriginalInputs.Add(Gate.GetResult());
                    Gate.FalseResult();
                }
                else if (Gate.GetType() == typeof(Output))
                {
                    OutputGates.Add(Gate);
                }
            }
            PublicVariables.TruthTable.ResetTable(InputGates, OutputGates);
            if (InputGates.Count != 0)
            {
                for (int i = 0; i < Convert.ToInt32(Math.Pow(2.0, InputGates.Count)); i++)
                {
                    string Binary = Convert.ToString(i, 2);
                    for (int j = Binary.Length - 1; j >= 0; j--)
                    {
                        if (Binary[j] == '0')
                        {
                            InputGates[InputGates.Count - Binary.Length + j].FalseResult();
                        }
                        else
                        {
                            InputGates[InputGates.Count - Binary.Length + j].TrueResult();
                        }
                    }
                    OutputGates.Clear();
                    foreach (LogicGates Gate in PublicVariables.Gates)
                    {
                        if (Gate.GetType() == typeof(Output))
                            OutputGates.Add(Gate);
                    }
                    AddToList(InputGates, OutputGates);
                }
                for (int i = 0; i < InputGates.Count; i++)
                {
                    if (OriginalInputs[i])
                        InputGates[i].TrueResult();
                    else
                        InputGates[i].FalseResult();
                }
                PublicVariables.TruthTable.Show();
                PublicVariables.TruthTable.BringToFront();
            }
        }

        //Adds the data to the truth table form
        private void AddToList(List<LogicGates> InputGates, List<LogicGates> OutputGates)
        {
            List<string> Results = new List<string>();
            foreach (LogicGates Gate in InputGates)
            {
                if (Gate.GetResult())
                    Results.Add("1");
                else
                    Results.Add("0");
            }
            foreach (LogicGates Gate in OutputGates)
            {
                if (Gate.GetResult())
                    Results.Add("1");
                else
                    Results.Add("0");
            }
            PublicVariables.TruthTable.AddToTable(Results);
        }

        //Save button
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.InitialDirectory = Application.StartupPath + "\\Saves";
            SaveFileDialog.DefaultExt = "txt";
            SaveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile(SaveFileDialog.OpenFile());
            }
        }

        //Saves the current circuit
        public void SaveFile(Stream SaveLocation)
        {
            string Data = "";
            StreamWriter Writer = new StreamWriter(SaveLocation);
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                Data += Gate.GetID() + ":" + Gate.GetType().ToString() + " ";
            }
            Data.TrimEnd(' ');
            Writer.WriteLine(Data);
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                string temp = Gate.GetSaveData();
                Writer.WriteLine(Gate.GetSaveData());
            }
            Writer.Close();
            Writer.Dispose();
        }

        //Load button
        private void LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Application.StartupPath + "\\Saves";
            OpenFileDialog.DefaultExt = "txt";
            OpenFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(OpenFileDialog.OpenFile());
            }
        }

        //Loads a choosen text file
        public void LoadFile(Stream LoadLocation)
        {
            try
            {
                Dictionary<int, LogicGates> Gates = new Dictionary<int, LogicGates>();
                DeleteAllGates();
                StreamReader Reader = new StreamReader(LoadLocation);
                string Data = Reader.ReadLine();
                string[] FirstLine = Data.Split(' ');
                Array.Resize(ref FirstLine, FirstLine.Length - 1);
                foreach (string Line in FirstLine)
                {
                    string[] Info = Line.Split(':');
                    switch (Info[1])
                    {
                        case "LogicGateProject.Input":
                            Input Input = new Input();
                            Input.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(Input.GetID()), Input);
                            break;
                        case "LogicGateProject.Output":
                            Output Output = new Output();
                            Output.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(Output.GetID()), Output);
                            break;
                        case "LogicGateProject.ANDGate":
                            ANDGate ANDGate = new ANDGate();
                            ANDGate.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(ANDGate.GetID()), ANDGate);
                            break;
                        case "LogicGateProject.ORGate":
                            ORGate ORGate = new ORGate();
                            ORGate.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(ORGate.GetID()), ORGate);
                            break;
                        case "LogicGateProject.NOTGate":
                            NOTGate NOTGate = new NOTGate();
                            NOTGate.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(NOTGate.GetID()), NOTGate);
                            break;
                        case "LogicGateProject.XORGate":
                            XORGate XORGate = new XORGate();
                            XORGate.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(XORGate.GetID()), XORGate);
                            break;
                        case "LogicGateProject.NANDGate":
                            NANDGate NANDGate = new NANDGate();
                            NANDGate.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(NANDGate.GetID()), NANDGate);
                            break;
                        case "LogicGateProject.NORGate":
                            NORGate NORGate = new NORGate();
                            NORGate.SetID(int.Parse(Info[0]));
                            Gates.Add(int.Parse(NORGate.GetID()), NORGate);
                            break;
                    }
                }
                while ((Data = Reader.ReadLine()) != null)
                {
                    string[] Line = Data.Split(',');
                    string[] Location = Line[1].Split(' ');
                    Gates[int.Parse(Line[0])].SetLocation(int.Parse(Location[0]), int.Parse(Location[1]));
                    if (Line[2] != "null")
                        Gates[int.Parse(Line[0])].SetTopInConnection(Gates[int.Parse(Line[2])]);
                    if (Line[3] != "null")
                        Gates[int.Parse(Line[0])].SetBotInConnection(Gates[int.Parse(Line[3])]);
                    if (Gates[int.Parse(Line[0])] is Input)
                        Gates[int.Parse(Line[0])].SetWaitTime(float.Parse(Line[4]));
                }
                Reader.Dispose();
                Invalidate();
            }
            catch
            {
                MessageBox.Show("Invalid File", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Records if enter button was pressed
        private bool IsEnter;

        //Checks if circuit should be created
        private void AddExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsEnter && AddExpression.Text != "" && !LogicGates.GetDisabled() && !Quiz)
            {
                CreateCircuitFromExpression();
            }
        }

        //Creates a circuit from an expression
        public void CreateCircuitFromExpression()
        {
            Dictionary<string, LogicGates> Gates = new Dictionary<string, LogicGates>();
            string Input = AddExpression.Text.Replace(" ", string.Empty);
            if (CheckValidExpression(Input))
            {
                DeleteAllGates();
                for (int i = 0; i < Input.Length; i++)
                {
                    if (char.IsLetter(Input[i]) && !Gates.ContainsKey(Input[i].ToString()))
                    {
                        Gates.Add(Input[i].ToString(), CreateGate(Gates, Input[i].ToString()));
                    }
                }
                if (Input.Length > 1)
                {
                    for (int Back = 0; Back < Input.Length; Back++)
                    {
                        if (Back + 1 < Input.Length)
                        {
                            if (char.IsLetter(Input[Back]) && Input[Back + 1] == '\'')
                            {
                                Gates.Add(PublicVariables.ID.ToString(), CreateGate(Gates, Input.Substring(Back, 2)));
                                Input = Input.Remove(Back, 2);
                                Input = Input.Insert(Back, (PublicVariables.ID - 1).ToString());
                                Back--;
                                continue;
                            }
                            if (char.IsDigit(Input[Back]) && Input[Back + 1] == '\'')
                            {
                                string Number = GetNumber(Input, Back);
                                Back = Back + 1 - Number.Length;
                                Gates.Add(PublicVariables.ID.ToString(), CreateGate(Gates, Input.Substring(Back, Number.Length + 1)));
                                Input = Input.Remove(Back, Number.Length + 1);
                                Input = Input.Insert(Back, (PublicVariables.ID - 1).ToString());
                                Back--;
                                continue;
                            }
                        }
                        if (Input[Back] == ')')
                        {
                            int Front = Back;
                            while (Input[Front] != '(')
                            {
                                Front--;
                            }
                            Input = Input.Remove(Back, 1);
                            Input = Input.Remove(Front, 1);
                            string Expression = CompleteExpression(ref Gates, Input.Substring(Front, Back - Front - 1));
                            Input = Input.Remove(Front, Back - Front - 1);
                            Input = Input.Insert(Front, Expression);
                            Back = Front - 1;
                            continue;
                        }
                    }
                    Input = CompleteExpression(ref Gates, Input);
                }
                List<LogicGates> ListOfGates = new List<LogicGates>();
                foreach (LogicGates Gate in PublicVariables.Gates)
                    ListOfGates.Add(Gate);
                foreach (LogicGates Gate in ListOfGates)
                {
                    if (Gate.HasNoOutputs())
                    {
                        Output Output = new Output();
                        Output.SetTopInConnection(Gate);
                    }
                    if (Gate.GetType() == typeof(NOTGate))
                    {
                        if (Gate.GetTopInConnection().GetType() == typeof(ANDGate))
                        {
                            NANDGate NewGate = new NANDGate();
                            NewGate.SetTopInConnection(Gate.GetTopInConnection().GetTopInConnection());
                            NewGate.SetBotInConnection(Gate.GetTopInConnection().GetBotInConnection());
                            NewGate.SetOutConnections(Gate.GetOutConnections());
                            Gate.GetTopInConnection().DeleteGate();
                            Gate.DeleteGate();
                        }
                        else if (Gate.GetTopInConnection().GetType() == typeof(ORGate))
                        {
                            NORGate NewGate = new NORGate();
                            NewGate.SetTopInConnection(Gate.GetTopInConnection().GetTopInConnection());
                            NewGate.SetBotInConnection(Gate.GetTopInConnection().GetBotInConnection());
                            NewGate.SetOutConnections(Gate.GetOutConnections());
                            Gate.GetTopInConnection().DeleteGate();
                            Gate.DeleteGate();
                        }
                    }
                }
                SetGateLocations();
                AddExpression.Text = "INPUT BOOLEAN EXPRESSION E.G. A.(B + C)' (USE % FOR XOR)";
                AddExpression.ForeColor = Color.Gray;
                DesignerPanel.Focus();
            }
            else
                MessageBox.Show("Invalid Input\nPlease use the form A.(B + C)' (Use % for XOR)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Creates circuit using correct order of operation
        public string CompleteExpression(ref Dictionary<string, LogicGates> Gates, string Input)
        {
            char[] Signs = { '.', '%', '+' };
            int SignsCount = 0;
            for (int Sign = 0; Sign < Input.Length; Sign++)
            {
                if (Input[Sign] == Signs[SignsCount])
                {
                    int Back = 0;
                    string Expression = GetExpression(Input, Sign, Signs[SignsCount].ToString());
                    Gates.Add(PublicVariables.ID.ToString(), CreateGate(Gates, Expression));
                    if (char.IsDigit(Input[Sign - 1]))
                    {
                        Back = Sign - GetNumber(Input, Sign - 1).Length;
                        Input = Input.Remove(Back, Expression.Length);
                    }
                    else
                    {
                        Back = Sign - 1;
                        Input = Input.Remove(Back, Expression.Length);
                    }
                    Input = Input.Insert(Back, (PublicVariables.ID - 1).ToString());
                    Sign--;
                }
                if (Sign == Input.Length - 1 && SignsCount < 2)
                {
                    Sign = 0;
                    SignsCount++;
                }
            }
            return Input;
        }

        //Gets an individual expression
        public string GetExpression(string Input, int SignIndex, string SignValue)
        {
            string Left = "";
            string Right = "";
            if (char.IsDigit(Input[SignIndex - 1]))
                Left = GetNumber(Input, SignIndex - 1);
            else
                Left = Input[SignIndex - 1].ToString();
            if (char.IsDigit(Input[Input.Length - 1]))
                Right = GetNumber(Input, Input.Length - 1);
            else
                Right = Input[SignIndex + 1].ToString();
            return Left + SignValue + Right;
        }

        //Creates the gate for individual expressions
        public LogicGates CreateGate(Dictionary<string, LogicGates> InputGates, string Expression)
        {
            if (Expression.Length == 1)
            {
                Input Input = new Input();
                Input.EditInputID(Expression[0]);
                return Input;
            }
            if (char.IsLetterOrDigit(Expression[0]) && Expression[Expression.Length - 1] == '\'')
            {
                Expression = Expression.Remove(Expression.Length - 1, 1);
                NOTGate NOTGate = new NOTGate();
                NOTGate.SetTopInConnection(InputGates[Expression]);
                return NOTGate;
            }
            if (Expression.Contains('.'))
            {
                string[] Inputs = Expression.Split('.');
                ANDGate ANDGate = new ANDGate();
                ANDGate.SetTopInConnection(InputGates[Inputs[0]]);
                ANDGate.SetBotInConnection(InputGates[Inputs[1]]);
                return ANDGate;
            }
            if (Expression.Contains('+'))
            {
                string[] Inputs = Expression.Split('+');
                ORGate ORGate = new ORGate();
                ORGate.SetTopInConnection(InputGates[Inputs[0]]);
                ORGate.SetBotInConnection(InputGates[Inputs[1]]);
                return ORGate;
            }
            if (Expression.Contains('%'))
            {
                string[] Inputs = Expression.Split('%');
                XORGate XORGate = new XORGate();
                XORGate.SetTopInConnection(InputGates[Inputs[0]]);
                XORGate.SetBotInConnection(InputGates[Inputs[1]]);
                return XORGate;
            }
            return null;
        }

        //Gets the number for a gate
        public string GetNumber(string Input, int Back)
        {
            string Number = "";
            int Start = Back;
            while (char.IsDigit(Input[Back]))
            {
                if (Back == 0)
                {
                    Back--;
                    break;
                }
                Back--;
            }
            Back++;
            for (int i = Back; i <= Start; i++)
            {
                Number += Input[i];
            }
            return Number;
        }

        //Records if Enter was pressed
        private void AddExpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IsEnter = true;
            }
            else
                IsEnter = false;
        }

        //Checks an input expression is valid
        private bool CheckValidExpression(string Input)
        {
            bool IsInput = false;
            int BracketsOpen = 0;
            foreach (char Letter in Input)
            {
                if (char.IsLetter(Letter))
                {
                    if (IsInput)
                        return false;
                    IsInput = true;
                }
                else if (Letter == '.' || Letter == '+' || Letter == '%')
                {
                    if (!IsInput)
                        return false;
                    IsInput = false;
                }
                else if (Letter == '\'')
                {
                    if (!IsInput)
                        return false;
                }
                else if (Letter == '(')
                {
                    BracketsOpen++;
                }
                else if (Letter == ')')
                {
                    if (BracketsOpen == 0)
                        return false;
                    if (!IsInput)
                        return false;
                    BracketsOpen--;
                }
                else
                {
                    return false;
                }
            }
            if (!IsInput)
                return false;
            if (BracketsOpen != 0)
                return false;
            return true;
        }

        //Brings focus to designer so expression bar clears when empty
        private void DesignerPanel_MouseClick(object sender, MouseEventArgs e)
        {
            DesignerPanel.Focus();
        }

        //Spreads all gates out on the designer
        public void SetGateLocations()
        {
            List<LogicGates> InputGates = new List<LogicGates>();
            List<LogicGates> Gates = new List<LogicGates>();
            const int PanelWidth = 1009;
            const int PanelHeight = 813;
            int InputX = 0;
            int GatesX = PanelWidth / 2;
            int Y;
            int YInc;

            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (Gate.GetType() == typeof(Input))
                {
                    InputGates.Add(Gate);
                }
                else if (Gate.GetType() == typeof(Output))
                {
                    Gate.SetLocation(PanelWidth, PanelHeight / 2 - Gate.Height / 2);
                }
                else
                {
                    Gates.Add(Gate);
                }
            }
            Y = PanelHeight / (InputGates.Count + 1);
            YInc = PanelHeight / (InputGates.Count + 1);
            foreach (LogicGates Gate in InputGates)
            {
                Gate.SetLocation(InputX, Y - Gate.Height / 2);
                Y += YInc;
            }
            Y = PanelHeight / (Gates.Count + 1);
            YInc = PanelHeight / (Gates.Count + 1);
            foreach (LogicGates Gate in Gates)
            {
                Gate.SetLocation(GatesX, Y - Gate.Height / 2);
                Y += YInc;
            }
        }

        //Create Expression button
        private void CreateExpression_Click(object sender, EventArgs e)
        {
            List<LogicGates> OutputGates = new List<LogicGates>();
            string Expression = "";
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (Gate.GetType() == typeof(Output))
                {
                    OutputGates.Add(Gate);
                }
            }
            PublicVariables.ExpressionsTable.ResetTable();
            foreach (LogicGates Output in OutputGates)
            {
                Output.CreateExpression(ref Expression);
                if (Expression[0] == '(' && Expression[Expression.Length - 1] == ')')
                {
                    Expression = Expression.Remove(Expression.Length - 1, 1);
                    Expression = Expression.Remove(0, 1);
                }
                PublicVariables.ExpressionsTable.AddToTable(Output.GetOutputID().ToString(), Expression);
                Expression = "";
            }
            PublicVariables.ExpressionsTable.Show();
            PublicVariables.ExpressionsTable.BringToFront();
        }

        //Changes button visibilty on level
        public void AdjustLevel(int Level)
        {
            if (Level == 1)
            {
                NANDSimplifcation.Hide();
                CreateExpression.Hide();
                AddXOR.Hide();
                AddNAND.Hide();
                AddNOR.Hide();
                AddExpression.Hide();
            }
            if (Level == 2)
            {
                NANDSimplifcation.Hide();
                CreateExpression.Show();
                AddNAND.Show();
                AddNOR.Show();
                AddXOR.Show();
                AddExpression.Show();
            }
            if (Level == 3)
            {
                NANDSimplifcation.Show();
                CreateExpression.Show();
                AddNAND.Show();
                AddNOR.Show();
                AddXOR.Show();
                AddExpression.Show();
            }
        }

        //NAND Simplifcation button
        private void NANDSimplifcation_Click(object sender, EventArgs e)
        {
            List<LogicGates> Gates = new List<LogicGates>();
            LogicGates TopInConnection;
            LogicGates BotInConnection;
            Point GateLocation;
            Dictionary<LogicGates, int> OutConnections;
            foreach (LogicGates Gate in PublicVariables.Gates)
                Gates.Add(Gate);
            foreach (LogicGates Gate in Gates)
            {
                if (Gate.GetType() == typeof(ANDGate))
                {
                    TopInConnection = Gate.GetTopInConnection();
                    BotInConnection = Gate.GetBotInConnection();
                    OutConnections = Gate.GetOutConnections();
                    GateLocation = Gate.Location;
                    Gate.DeleteGate();

                    NANDGate Gate1 = new NANDGate();
                    NANDGate Gate2 = new NANDGate();
                    if (TopInConnection != null)
                        Gate1.SetTopInConnection(TopInConnection);
                    if (BotInConnection != null)
                        Gate1.SetBotInConnection(BotInConnection);
                    Gate2.SetTopInConnection(Gate1);
                    Gate2.SetBotInConnection(Gate1);
                    Gate2.SetOutConnections(OutConnections);
                    Gate1.SetLocation(GateLocation.X, GateLocation.Y);
                    Gate2.SetLocation(GateLocation.X + 130, GateLocation.Y);
                }
                else if (Gate.GetType() == typeof(ORGate))
                {
                    TopInConnection = Gate.GetTopInConnection();
                    BotInConnection = Gate.GetBotInConnection();
                    OutConnections = Gate.GetOutConnections();
                    GateLocation = Gate.Location;
                    Gate.DeleteGate();
                    NANDGate Gate1 = new NANDGate();
                    NANDGate Gate2 = new NANDGate();
                    NANDGate Gate3 = new NANDGate();
                    if (TopInConnection != null)
                    {
                        Gate1.SetTopInConnection(TopInConnection);
                        Gate1.SetBotInConnection(TopInConnection);
                    }
                    if (BotInConnection != null)
                    {
                        Gate2.SetTopInConnection(BotInConnection);
                        Gate2.SetBotInConnection(BotInConnection);
                    }
                    Gate3.SetTopInConnection(Gate1);
                    Gate3.SetBotInConnection(Gate2);
                    Gate3.SetOutConnections(OutConnections);
                    Gate1.SetLocation(GateLocation.X, GateLocation.Y - 50);
                    Gate2.SetLocation(GateLocation.X, GateLocation.Y + 50);
                    Gate3.SetLocation(GateLocation.X + 130, GateLocation.Y);
                }
                else if (Gate.GetType() == typeof(NOTGate))
                {
                    TopInConnection = Gate.GetTopInConnection();
                    OutConnections = Gate.GetOutConnections();
                    GateLocation = Gate.Location;
                    Gate.DeleteGate();
                    NANDGate Gate1 = new NANDGate();
                    if (TopInConnection != null)
                    {
                        Gate1.SetTopInConnection(TopInConnection);
                        Gate1.SetBotInConnection(TopInConnection);
                    }
                    Gate1.SetOutConnections(OutConnections);
                    Gate1.SetLocation(GateLocation.X, GateLocation.Y);
                }
                else if (Gate.GetType() == typeof(XORGate))
                {
                    TopInConnection = Gate.GetTopInConnection();
                    BotInConnection = Gate.GetBotInConnection();
                    OutConnections = Gate.GetOutConnections();
                    GateLocation = Gate.Location;
                    Gate.DeleteGate();
                    NANDGate Gate1 = new NANDGate();
                    NANDGate Gate2 = new NANDGate();
                    NANDGate Gate3 = new NANDGate();
                    NANDGate Gate4 = new NANDGate();
                    if (TopInConnection != null)
                    {
                        Gate1.SetTopInConnection(TopInConnection);
                        Gate2.SetTopInConnection(TopInConnection);
                    }
                    if (BotInConnection != null)
                    {
                        Gate1.SetBotInConnection(BotInConnection);
                        Gate3.SetBotInConnection(BotInConnection);
                    }
                    Gate2.SetBotInConnection(Gate1);
                    Gate3.SetTopInConnection(Gate1);
                    Gate4.SetTopInConnection(Gate2);
                    Gate4.SetBotInConnection(Gate3);
                    Gate4.SetOutConnections(OutConnections);
                    Gate1.SetLocation(GateLocation.X, GateLocation.Y);
                    Gate2.SetLocation(GateLocation.X + 130, GateLocation.Y - 50);
                    Gate3.SetLocation(GateLocation.X + 130, GateLocation.Y + 50);
                    Gate4.SetLocation(GateLocation.X + 260, GateLocation.Y);
                }
                else if (Gate.GetType() == typeof(NORGate))
                {
                    TopInConnection = Gate.GetTopInConnection();
                    BotInConnection = Gate.GetBotInConnection();
                    OutConnections = Gate.GetOutConnections();
                    GateLocation = Gate.Location;
                    Gate.DeleteGate();
                    NANDGate Gate1 = new NANDGate();
                    NANDGate Gate2 = new NANDGate();
                    NANDGate Gate3 = new NANDGate();
                    NANDGate Gate4 = new NANDGate();
                    if (TopInConnection != null)
                    {
                        Gate1.SetTopInConnection(TopInConnection);
                        Gate1.SetBotInConnection(TopInConnection);
                    }
                    if (BotInConnection != null)
                    {
                        Gate2.SetTopInConnection(BotInConnection);
                        Gate2.SetBotInConnection(BotInConnection);
                    }
                    Gate3.SetTopInConnection(Gate1);
                    Gate3.SetBotInConnection(Gate2);
                    Gate4.SetTopInConnection(Gate3);
                    Gate4.SetBotInConnection(Gate3);
                    Gate4.SetOutConnections(OutConnections);
                    Gate1.SetLocation(GateLocation.X, GateLocation.Y - 50);
                    Gate2.SetLocation(GateLocation.X, GateLocation.Y + 50);
                    Gate3.SetLocation(GateLocation.X + 130, GateLocation.Y);
                    Gate4.SetLocation(GateLocation.X + 260, GateLocation.Y);
                }
            }
            Invalidate();
        }

        
        public GCSEQuiz Question; //Identifies user control for GCSE questions
        private List<Type> OriginalConnections; //Records all connections in a circuit to make sure that a recreated circuit is the same
        private bool Quiz; //Shows if the form is in Quiz Mode
        private string Expression; //The expression for the random circuit
        //Sets up the quiz to the chosen level
        public void SetUpQuiz(bool IsQuiz, bool CircuitTo)
        {
            Quiz = IsQuiz;
            if (IsQuiz)
            {
                LoadButton.Hide();
                SaveButton.Hide();
                NANDSimplifcation.Hide();
                CreateExpression.Hide();
                StepByStep.Hide();
                CreateTruthTable.Hide();

                //GCSE
                if (PublicVariables.Menu1.GetLevel() == 1)
                {
                    CreateCircuit();
                    Question = new GCSEQuiz(GetInputList(), GetOutputList());
                    //Circuit to Truth Table
                    if (CircuitTo)
                    {
                        DeleteButton.Hide();
                        LogicGates.SetDisabled(true);
                    }
                    //Truth Table to Circuit
                    else
                    {
                        Stream Save = File.Open("Quiz.txt", FileMode.OpenOrCreate);
                        Save.SetLength(0);
                        SaveFile(Save);
                        Save.Dispose();
                        Question.CompleteTable(false);
                        Question.SetTableToCircuit();
                        DeleteAllGates();
                    }
                    DesignerPanel.Controls.Add(Question);
                }

                //A-Level
                else if (PublicVariables.Menu1.GetLevel() == 2)
                {
                    QuestionLabel.Show();
                    SubmitButton.Show();
                    SubmitButton.Text = "Submit";
                    ResultLabel.Hide();
                    //Circuit to Expression
                    if (CircuitTo) 
                    {
                        QuestionLabel.Text = "Enter the expression of the circuit";
                        AddExpression.Text = "INPUT BOOLEAN EXPRESSION E.G. A.(B + C)' (USE % FOR XOR)";
                        AddExpression.ForeColor = Color.Gray;
                        DeleteButton.Hide();
                        CreateCircuit();
                        LogicGates.SetDisabled(true);
                        Stream Save = File.Open("Quiz.txt", FileMode.OpenOrCreate);
                        Save.SetLength(0);
                        SaveFile(Save);
                        Save.Dispose();
                        string LocalExpression = "";
                        foreach (LogicGates Output in GetOutputList())
                        {
                            Output.CreateExpression(ref LocalExpression);
                            if (LocalExpression[0] == '(' && LocalExpression[LocalExpression.Length - 1] == ')')
                            {
                                LocalExpression = LocalExpression.Remove(LocalExpression.Length - 1, 1);
                                LocalExpression = LocalExpression.Remove(0, 1);
                            }
                        }
                        Expression = LocalExpression;
                        OriginalConnections = GetCircuitConnections();
                    }
                    //Expression to Circuit
                    else
                    {
                        QuestionLabel.Text = "Create a circuit for this expression";
                        string Expression = "";
                        CreateCircuit();
                        foreach (LogicGates Output in GetOutputList())
                        {
                            Output.CreateExpression(ref Expression);
                            if (Expression[0] == '(' && Expression[Expression.Length - 1] == ')')
                            {
                                Expression = Expression.Remove(Expression.Length - 1, 1);
                                Expression = Expression.Remove(0, 1);
                            }
                        }
                        AddExpression.Text = Expression;
                        AddExpression.ForeColor = Color.Black;
                        AddExpression.ReadOnly = true;
                        Stream Save = File.Open("Quiz.txt", FileMode.OpenOrCreate);
                        Save.SetLength(0);
                        SaveFile(Save);
                        Save.Dispose();
                        DeleteAllGates();
                    }
                }
            }
            //Reset the form to design mode
            else
            {
                if (Question != null)
                    Question.Dispose();
                QuestionLabel.Hide();
                SubmitButton.Hide();
                ResultLabel.Hide();
                LoadButton.Show();
                SaveButton.Show();
                DeleteButton.Show();
                NANDSimplifcation.Show();
                CreateExpression.Show();
                StepByStep.Show();
                CreateTruthTable.Show();
                AddExpression.ReadOnly = false;
                LogicGates.SetDisabled(false);
            }
        }

        //A-Level quiz submit button clicked
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Circuit to Expression
            if (QuestionLabel.Text == "Enter the expression of the circuit") 
            {
                if (SubmitButton.Text == "Submit")
                {
                    string Input = AddExpression.Text.Replace(" ", string.Empty);
                    if (CheckValidExpression(Input))
                    {
                        CreateCircuitFromExpression();
                        if (IsCorrectExpression())
                            ResultLabel.Text = "Correct!";
                        else
                            ResultLabel.Text = "Incorrect";
                        ResultLabel.Show();
                        SubmitButton.Text = "Next";
                        Stream Load = File.Open("Quiz.txt", FileMode.Open);
                        LoadFile(Load);
                        Load.Dispose();
                        AddExpression.Text = Expression;
                        LogicGates.SetDisabled(false);
                    }
                    else
                        MessageBox.Show("Invalid Input\nPlease use the form A.(B + C)' (Use % for XOR)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SubmitButton.Text = "Submit";
                    SetUpQuiz(true, true);
                }
            }
            //Expression to Circuit
            else
            {
                if (SubmitButton.Text == "Submit")
                {
                    string Expression = "";
                    foreach (LogicGates Output in GetOutputList())
                    {
                        Output.CreateExpression(ref Expression);
                        if (Expression[0] == '(' && Expression[Expression.Length - 1] == ')')
                        {
                            Expression = Expression.Remove(Expression.Length - 1, 1);
                            Expression = Expression.Remove(0, 1);
                        }
                    }
                    if (Expression == AddExpression.Text)
                        ResultLabel.Text = "Correct!";
                    else
                        ResultLabel.Text = "Incorrect";
                    ResultLabel.Show();
                    SubmitButton.Text = "Next";
                    Stream Load = File.Open("Quiz.txt", FileMode.Open);
                    LoadFile(Load);
                    Load.Dispose();
                }
                else
                {
                    SubmitButton.Text = "Submit";
                    SetUpQuiz(true, false);
                }
            }
        }

        //Checks if the expression input is correct
        public bool IsCorrectExpression()
        {
            List<Type> CreatedConnections = GetCircuitConnections();
            for (int i = 0; i < CreatedConnections.Count; i += 2)
            {
                for (int j = 0; j < OriginalConnections.Count - 1; j += 2)
                {
                    if (OriginalConnections[j] == CreatedConnections[i] && OriginalConnections[j + 1] == CreatedConnections[i + 1])
                    {
                        OriginalConnections.RemoveRange(j, 2);
                        break;
                    }
                    else if (OriginalConnections[j] == CreatedConnections[i + 1] && OriginalConnections[j + 1] == CreatedConnections[i])
                    {
                        OriginalConnections.RemoveRange(j, 2);
                        break;
                    }
                    else if (j == OriginalConnections.Count - 2)
                        return false;
                }
            }
            if (OriginalConnections.Count == 0)
                return true;
            else
                return false;
        }

        //Creates a List of the circuit connections
        public List<Type> GetCircuitConnections()
        {
            List<Type> ConnectionList = new List<Type>();
            foreach(LogicGates Gate in PublicVariables.Gates)
            {
                if (Gate.GetTopInConnection() != null)
                    ConnectionList.Add(Gate.GetTopInConnection().GetType());
                else
                    ConnectionList.Add(null);
                if (Gate.GetBotInConnection() != null)
                    ConnectionList.Add(Gate.GetBotInConnection().GetType());
                else
                    ConnectionList.Add(null);
            }
            return ConnectionList;
        }

        //Gets a list of all the inputs in the designer
        public List<LogicGates> GetInputList()
        {
            List<LogicGates> InputGates = new List<LogicGates>();
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (Gate.GetType() == typeof(Input))
                    InputGates.Add(Gate);
            }
            return InputGates;
        }

        //Gets a list of all the outputs in the designer
        public List<LogicGates> GetOutputList()
        {
            List<LogicGates> OutputGates = new List<LogicGates>();
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (Gate.GetType() == typeof(Output))
                    OutputGates.Add(Gate);
            }
            return OutputGates;
        }

        //Gets the designer size
        public Point GetDesignerPanelSize()
        {
            return new Point(DesignerPanel.Width, DesignerPanel.Height);
        }

        //Creates a random circuit
        Random Random = new Random();
        public void CreateCircuit()
        {
            Point[] GatePoints = { new Point(200, 200), new Point(200, 400), new Point(400, 200), new Point(400, 500) }; //Positions for gates
            List<LogicGates> InputGates = new List<LogicGates>();
            List<LogicGates> Gates = new List<LogicGates>();
            int NoGates;
            DeleteAllGates();
            if (PublicVariables.Menu1.GetLevel() == 1)
                NoGates = Random.Next(2, 5);
            else 
                NoGates = Random.Next(3, 5);
            Input Input1 = new Input();
            InputGates.Add(Input1);
            Input Input2 = new Input();
            InputGates.Add(Input2);
            Input Input3 = new Input();
            InputGates.Add(Input3);
            SetGateLocations();
            for (int i = 0; i < NoGates; i++)
            {
                Gates.Add(CreateRandomGate());
                Gates[i].SetLocation(GatePoints[i].X, GatePoints[i].Y);
                if (i == 0 && Gates[i].GetType() == typeof(NOTGate))
                {
                    Gates[i].SetTopInConnection(Input1);
                }
                else if (i == 0)
                {
                    Gates[i].SetTopInConnection(Input1);
                    Gates[i].SetBotInConnection(Input2);
                }
                else if (i == 1 && Gates[i].GetType() == typeof(NOTGate))
                {
                    Gates[i].SetTopInConnection(Input2);
                }
                else if (i == 1)
                {
                    Gates[i].SetTopInConnection(Input2);
                    Gates[i].SetBotInConnection(Input3);
                }
                else if (i == 2 && Gates[i].GetType() == typeof(NOTGate))
                {
                    Gates[i].SetTopInConnection(Gates[0]);
                }
                else if (i == 2)
                {
                    Gates[i].SetTopInConnection(Gates[0]);
                    Gates[i].SetBotInConnection(Gates[1]);
                }
                else if (i == 3 && Gates[i].GetType() == typeof(NOTGate))
                {
                    Gates[i].SetTopInConnection(Gates[1]);
                }
                else if (i == 3)
                {
                    Gates[i].SetTopInConnection(Gates[1]);
                    Gates[i].SetBotInConnection(Input3);
                }
            }
            for (int i = 0; i < InputGates.Count; i++)
            {
                if (InputGates[i].HasNoOutputs())
                {
                    InputGates[i].DeleteGate();
                    InputGates.RemoveAt(i);
                    i--;
                }
            }

            //Adds outputs to all gates with no outputs
            List<LogicGates> ListOfGates = new List<LogicGates>();
            foreach (LogicGates Gate in PublicVariables.Gates)
                ListOfGates.Add(Gate);
            List<LogicGates> NoOutputs = new List<LogicGates>();
            foreach (LogicGates Gate in ListOfGates)
            {
                if (Gate.HasNoOutputs())
                {
                    if (PublicVariables.Menu1.GetLevel() == 1)
                    {
                        Output Output = new Output();
                        Output.SetTopInConnection(Gate);
                        Output.SetLocation(Gate.Location.X + 130, Gate.Location.Y);
                    }
                    else
                    {
                        NoOutputs.Add(Gate);
                    }

                }
            }
            //Makes sure all circuits have only one output so they are valid expressions
            if (PublicVariables.Menu1.GetLevel() == 2 && Quiz) 
            {
                if (NoOutputs.Count == 2)
                {
                    LogicGates FinalGate = CreateRandomGate();
                    while (FinalGate.GetType() == typeof(NOTGate))
                    {
                        FinalGate.DeleteGate();
                        FinalGate = CreateRandomGate();
                    }
                    FinalGate.SetTopInConnection(NoOutputs[0]);
                    FinalGate.SetBotInConnection(NoOutputs[1]);
                    FinalGate.SetLocation(600, 400);
                    Output Output = new Output();
                    Output.SetTopInConnection(FinalGate);
                    Output.SetLocation(FinalGate.Location.X + 130, FinalGate.Location.Y);
                }
                else
                {
                    Output Output = new Output();
                    Output.SetTopInConnection(NoOutputs[0]);
                    Output.SetLocation(NoOutputs[0].Location.X + 130, NoOutputs[0].Location.Y);
                }
            }
            //Replaces all AND or OR gates followed by a not with a NAND or NOR gate
            if (PublicVariables.Menu1.GetLevel() == 2)
            {
                ListOfGates.Clear();
                foreach (LogicGates Gate in PublicVariables.Gates)
                    ListOfGates.Add(Gate);
                foreach (LogicGates Gate in ListOfGates)
                {
                    if (Gate.GetType() == typeof(NOTGate))
                    {
                        if (Gate.GetTopInConnection().GetType() == typeof(ANDGate))
                        {
                            NANDGate NewGate = new NANDGate();
                            NewGate.SetTopInConnection(Gate.GetTopInConnection().GetTopInConnection());
                            NewGate.SetBotInConnection(Gate.GetTopInConnection().GetBotInConnection());
                            Dictionary<LogicGates, int> GateConnections = Gate.GetTopInConnection().GetOutConnections();
                            Dictionary<LogicGates, int> NotConnections = Gate.GetOutConnections();
                            foreach (KeyValuePair<LogicGates, int> Output in GateConnections)
                            {
                                if (!(Output.Key == Gate))
                                    NotConnections.Add(Output.Key, Output.Value);
                            }
                            NewGate.SetOutConnections(NotConnections);
                            NewGate.SetLocation((Gate.Location.X + Gate.GetTopInConnection().Location.X) / 2, (Gate.Location.Y + Gate.GetTopInConnection().Location.Y) / 2);
                            Gate.GetTopInConnection().DeleteGate();
                            Gate.DeleteGate();
                        }
                        else if (Gate.GetTopInConnection().GetType() == typeof(ORGate))
                        {
                            NORGate NewGate = new NORGate();
                            NewGate.SetTopInConnection(Gate.GetTopInConnection().GetTopInConnection());
                            NewGate.SetBotInConnection(Gate.GetTopInConnection().GetBotInConnection());
                            Dictionary<LogicGates, int> GateConnections = Gate.GetTopInConnection().GetOutConnections();
                            Dictionary<LogicGates, int> NotConnections = Gate.GetOutConnections();
                            foreach (KeyValuePair<LogicGates, int> Output in GateConnections)
                            {
                                if (!(Output.Key == Gate))
                                    NotConnections.Add(Output.Key, Output.Value);
                            }
                            NewGate.SetOutConnections(NotConnections);
                            NewGate.SetLocation((Gate.Location.X + Gate.GetTopInConnection().Location.X) / 2, (Gate.Location.Y + Gate.GetTopInConnection().Location.Y) / 2);
                            Gate.GetTopInConnection().DeleteGate();
                            Gate.DeleteGate();
                        }
                    }
                }
            }
            Invalidate();
        }

        //Creates a random gate
        public LogicGates CreateRandomGate()
        {
            int GateType;
            if (PublicVariables.Menu1.GetLevel() == 1)
            {
                GateType = Random.Next(1, 4);
            }
            else
            {
                GateType = Random.Next(1, 7);
            }
            switch(GateType)
            {
                case 1:
                    ANDGate ANDGate = new ANDGate();
                    return ANDGate;
                case 2:
                    ORGate ORGate = new ORGate();
                    return ORGate;
                case 3:
                    NOTGate NOTGate = new NOTGate();
                    return NOTGate;
                case 4:
                    XORGate XORGate = new XORGate();
                    return XORGate;
                case 5:
                    NANDGate NANDGate = new NANDGate();
                    return NANDGate;
                case 6:
                    NORGate NORGate = new NORGate();
                    return NORGate;
            }
            return null;
        }
    }
}
