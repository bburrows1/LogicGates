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
    public partial class Simulator : Form
    {
        public Simulator()
        {
            InitializeComponent();
        }

        //Clear placeholder when entered
        private void AddExpression_Enter(object sender, EventArgs e)
        {
            if (AddExpression.Text == "INPUT BOOLEAN EXPRESSION")
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
                AddExpression.Text = "INPUT BOOLEAN EXPRESSION";
                AddExpression.ForeColor = Color.Gray;
            }
        }

        //Quit
        private void Quit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really weant to close the program?\nUnsaved circuits will be lost.", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void AddToDesignerPanel(LogicGates Gate)
        {
            DesignerPanel.Controls.Add(Gate);
        } 

        //Back
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (PublicVariables.level == 3)
                PublicVariables.Menu1.Show();
            else
                PublicVariables.Menu2.Show();
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
                int MidPoint = (PublicVariables.InputPoints[i].X + PublicVariables.OutputPoints[i].X) / 2;
                Point InputMidPoint = new Point(MidPoint, PublicVariables.InputPoints[i].Y);
                Point OutputMidPoint = new Point(MidPoint, PublicVariables.OutputPoints[i].Y);
                e.Graphics.DrawLine(PublicVariables.Linepen, PublicVariables.InputPoints[i], InputMidPoint);
                e.Graphics.DrawLine(PublicVariables.Linepen, InputMidPoint, OutputMidPoint);
                e.Graphics.DrawLine(PublicVariables.Linepen, OutputMidPoint, PublicVariables.OutputPoints[i]);
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

        //Delete all gates
        private void DeleteAll_Click(object sender, EventArgs e)
        {
            if (PublicVariables.Delete)
            {
                foreach (LogicGates Gate in PublicVariables.Gates)
                {
                    Gate.DeleteGate();
                }
                PublicVariables.Gates.Clear();
            }
            Invalidate();
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
    }
}
