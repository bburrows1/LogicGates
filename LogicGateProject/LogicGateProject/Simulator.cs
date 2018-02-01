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

        //Clear placholder when entered
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
            Input.CreateGate();
            Input.SetLocations();
            DesignerPanel.Controls.Add(Input);
            Input.UpdateLocations();
        }

        private void AddAND_Click(object sender, EventArgs e)
        {
            ANDGate ANDGate = new ANDGate();
            ANDGate.CreateGate();
            ANDGate.SetLocations();
            DesignerPanel.Controls.Add(ANDGate);
            ANDGate.UpdateLocations();
        }

        private void AddOR_Click(object sender, EventArgs e)
        {
            ORGate ORGate = new ORGate();
            ORGate.CreateGate();
            ORGate.SetLocations();
            DesignerPanel.Controls.Add(ORGate);
            ORGate.UpdateLocations();
        }

        private void AddNAND_Click(object sender, EventArgs e)
        {
            NANDGate NANDGate = new NANDGate();
            NANDGate.CreateGate();
            NANDGate.SetLocations();
            DesignerPanel.Controls.Add(NANDGate);
            NANDGate.UpdateLocations();
        }

        private void AddNOR_Click(object sender, EventArgs e)
        {
            NORGate NORGate = new NORGate();
            NORGate.CreateGate();
            NORGate.SetLocations();
            DesignerPanel.Controls.Add(NORGate);
            NORGate.UpdateLocations();
        }

        private void AddXOR_Click(object sender, EventArgs e)
        {
            XORGate XORGate = new XORGate();
            XORGate.CreateGate();
            XORGate.SetLocations();
            DesignerPanel.Controls.Add(XORGate);
            XORGate.UpdateLocations();
        }

        private void AddNOT_Click(object sender, EventArgs e)
        {
            NOTGate NOTGate = new NOTGate();
            NOTGate.CreateGate();
            NOTGate.SetLocations();
            DesignerPanel.Controls.Add(NOTGate);
            NOTGate.UpdateLocations();
        }

        private void AddOutput_Click(object sender, EventArgs e)
        {
            Output Output = new Output();
            Output.CreateGate();
            Output.SetLocations();
            this.DesignerPanel.Controls.Add(Output);
            Output.UpdateLocations();
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
            }
            Invalidate();
        }

        //Create data for truth table
        private void CreateTruthTable_Click(object sender, EventArgs e)
        {
            List<LogicGates> InputGates = new List<LogicGates>();
            List<LogicGates> OutputGates = new List<LogicGates>();
            List<bool> OriginalInputs = new List<bool>();
            List<bool> Inputs = new List<bool>();
            List<bool> Outputs = new List<bool>();
            PublicVariables.TruthTable.Show();
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

                }
            }
            if (InputGates.Count != 0)
            {
                GatesTruthTable(InputGates, 0);
            }
            PublicVariables.TruthTable.CreateTable();
        }

        private void GatesTruthTable(List<LogicGates> InputGates, int Start)
        {
            for (int i = Start; i < InputGates.Count; i++)
            {
                if (Start + 1 != InputGates.Count)
                    GatesTruthTable(InputGates, Start + 1);
                InputGates[Start].UpdateLogic();
                InputGates[Start].ToggleResult();
            }
        }
    }
}
