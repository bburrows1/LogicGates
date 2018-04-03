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
    public partial class Menu2 : Form
    {
        public Menu2()
        {
            InitializeComponent();
        }

        //Back
        private void Back_Click(object sender, EventArgs e)
        {
            Quiz.BringToFront();
            Hide();
            PublicVariables.Menu1.Show();
            PublicVariables.Menu1.BringToFront();
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

        //Design mode
        private void Design_Click(object sender, EventArgs e)
        {
            Hide();
            PublicVariables.Simulator.AdjustLevel(PublicVariables.Menu1.GetLevel());
            PublicVariables.Simulator.Show();
        }

        //Allows form to move
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PublicVariables.ReleaseCapture();
                PublicVariables.SendMessage(Handle, PublicVariables.WM_NCLBUTTONDOWN, PublicVariables.HT_CAPTION, 0);
                PublicVariables.Menu1.Location = Location;
            }
        }

        //Choose Quiz Mode
        private void Quiz_Click(object sender, EventArgs e)
        {
            if (PublicVariables.Menu1.GetLevel() == 1)
            {
                TableToCircuit.BringToFront();
                CircuitToTable.BringToFront();
            }
            else
            {
                CircuitToExpression.BringToFront();
                ExpressionToCircuit.BringToFront();
            }
        }

        //Shows expression to circuit button
        private void ExpressionToCircuit_Click(object sender, EventArgs e)
        {
            PublicVariables.Simulator.SetUpQuiz(true, false);
            Hide();
            PublicVariables.Simulator.Show();
        }

        //Shows circuit to expression button
        private void CircuitToExpression_Click(object sender, EventArgs e)
        {
            PublicVariables.Simulator.SetUpQuiz(true, true);
            Hide();
            PublicVariables.Simulator.Show();
        }

        //Shows circuit to truth table button
        private void CircuitToTable_Click(object sender, EventArgs e)
        {
            PublicVariables.Simulator.SetUpQuiz(true, true);
            Hide();
            PublicVariables.Simulator.Show();
        }

        //Shows truth table to circuit button
        private void TableToCircuit_Click(object sender, EventArgs e)
        {
            PublicVariables.Simulator.SetUpQuiz(true, false);
            Hide();
            PublicVariables.Simulator.Show();
        }
    }
}
