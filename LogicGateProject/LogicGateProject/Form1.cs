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
            DialogResult dialog = MessageBox.Show("Do you really weant to close the program?\nUnsaved circuits will be lost.",
                "Exit", MessageBoxButtons.YesNo);
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

        private void AddInput_Click(object sender, EventArgs e)
        {
            Input Input = new Input();
            Input.SetGateID();
            Input.SetLocations();
            this.DesignerPanel.Controls.Add(Input);
            Input.UpdateLocations();
        }

        private void AddAND_Click(object sender, EventArgs e)
        {
            ANDGate ANDGate = new ANDGate();
            ANDGate.SetGateID();
            ANDGate.SetLocations();
            this.DesignerPanel.Controls.Add(ANDGate);
            ANDGate.UpdateLocations();
        }

        private void AddOR_Click(object sender, EventArgs e)
        {
            ORGate ORGate = new ORGate();
            ORGate.SetGateID();
            ORGate.SetLocations();
            this.DesignerPanel.Controls.Add(ORGate);
            ORGate.UpdateLocations();
        }

        private void AddNAND_Click(object sender, EventArgs e)
        {
            NANDGate NANDGate = new NANDGate();
            NANDGate.SetGateID();
            NANDGate.SetLocations();
            this.DesignerPanel.Controls.Add(NANDGate);
            NANDGate.UpdateLocations();
        }

        private void AddNOR_Click(object sender, EventArgs e)
        {
            NORGate NORGate = new NORGate();
            NORGate.SetGateID();
            NORGate.SetLocations();
            this.DesignerPanel.Controls.Add(NORGate);
            NORGate.UpdateLocations();
        }

        private void AddXOR_Click(object sender, EventArgs e)
        {
            XORGate XORGate = new XORGate();
            XORGate.SetGateID();
            XORGate.SetLocations();
            this.DesignerPanel.Controls.Add(XORGate);
            XORGate.UpdateLocations();
        }

        private void AddNOT_Click(object sender, EventArgs e)
        {
            NOTGate NOTGate = new NOTGate();
            NOTGate.SetGateID();
            NOTGate.SetLocations();
            this.DesignerPanel.Controls.Add(NOTGate);
            NOTGate.UpdateLocations();
        }

        private void AddOutput_Click(object sender, EventArgs e)
        {
            Output Output = new Output();
            Output.SetGateID();
            Output.SetLocations();
            this.DesignerPanel.Controls.Add(Output);
            Output.UpdateLocations();
        }

        private void DesignerPanel_Paint(object sender, PaintEventArgs e)
        {
            PublicVariables.InputPoints.Clear();
            PublicVariables.OutputPoints.Clear();

            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                if (!Gate.Traversed)
                    Gate.Traverse();
            }
            foreach (LogicGates Gate in PublicVariables.Gates)
            {
                Gate.Traversed = false;
            }

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
    }
}
