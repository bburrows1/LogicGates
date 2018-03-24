﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGateProject
{
    public partial class GCSECircuitToTable : UserControl
    {
        private List<LogicGates> Inputs;
        private List<LogicGates> Outputs;
        public GCSECircuitToTable()
        {
            InitializeComponent();
        }

        public void SetTable(List<LogicGates> PassedInputs, List<LogicGates> PassedOutputs)
        {
            Inputs = PassedInputs;
            Outputs = PassedOutputs;
            DataGridView.ColumnCount = Inputs.Count + Outputs.Count;
            for (int i = 0; i < Inputs.Count; i++)
            {
                DataGridView.Columns[i].Name = PublicVariables.NumberToCharacter(Inputs[i].GetInputID()).ToString();
                DataGridView.Columns[i].Width = 25;
                DataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < Outputs.Count; i++)
            {
                DataGridView.Columns[i + Inputs.Count].Name = Outputs[i].GetOutputID().ToString();
                DataGridView.Columns[i + Inputs.Count].Width = 30;
            }
            for (int i = 0; i < Convert.ToInt32(Math.Pow(2.0, Inputs.Count)); i++)
            {
                List<string> Row = new List<string>();
                string Binary = Convert.ToString(i, 2);
                while (Binary.Length < Inputs.Count)
                {
                    Binary = "0" + Binary;
                }
                foreach (char Letter in Binary)
                {
                    Row.Add(Letter.ToString());
                }
                DataGridView.Rows.Add(Row.ToArray());
                for (int j = Inputs.Count; j < Outputs.Count + Inputs.Count; j++)
                {
                    DataGridView.Rows[i].Cells[j].Style.BackColor = Color.Red;
                }
            }
            SubmitButton.Location = new Point(75, (Convert.ToInt32(Math.Pow(2.0, Inputs.Count))) * 22 + DataGridView.Location.Y + 26);
            SubmitButton.BringToFront();
            Width = 165;
            Height = Question.Height + (Convert.ToInt32(Math.Pow(2.0, Inputs.Count))) * 22 + 26 + SubmitButton.Height;
            Location = new Point(PublicVariables.Simulator.GetDesignerPanelSize().X - Width, PublicVariables.Simulator.GetDesignerPanelSize().Y - Height);
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= Inputs.Count)
            {
                if (DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
                    DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                else
                    DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView.ClearSelection();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (SubmitButton.Text == "Submit")
            {
                bool Correct = true;
                for (int i = 0; i < Convert.ToInt32(Math.Pow(2.0, Inputs.Count)); i++)
                {
                    string Binary = Convert.ToString(i, 2);
                    for (int j = Binary.Length - 1; j >= 0; j--)
                    {
                        if (Binary[j] == '0')
                        {
                            Inputs[Inputs.Count - Binary.Length + j].FalseResult();
                        }
                        else
                        {
                            Inputs[Inputs.Count - Binary.Length + j].TrueResult();
                        }
                    }
                    for (int x = 0; x < Outputs.Count; x++)
                    {
                        if (DataGridView.Rows[i].Cells[x + Inputs.Count].Style.BackColor == Color.Green && !Outputs[x].GetResult())
                        {
                            Correct = false;
                            DataGridView.Rows[i].Cells[x + Inputs.Count].Style.BackColor = Color.Red;
                        }
                        else if (DataGridView.Rows[i].Cells[x + Inputs.Count].Style.BackColor == Color.Red && Outputs[x].GetResult())
                        {
                            Correct = false;
                            DataGridView.Rows[i].Cells[x + Inputs.Count].Style.BackColor = Color.Green;
                        }
                    }
                }
                ResultLabel.Location = new Point(0, (Convert.ToInt32(Math.Pow(2.0, Inputs.Count))) * 22 + DataGridView.Location.Y + 26);
                if (Correct)
                    ResultLabel.Text = "Correct!";
                else
                    ResultLabel.Text = "Incorrect";
                SubmitButton.Text = "Next";
                LogicGates.SetDisabled(false);
            }
            else
            {
                Hide();
                PublicVariables.Simulator.SetUpQuiz(true, true);
                Dispose();
            }
        }
    }
}
