using System;
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
        public GCSECircuitToTable()
        {
            InitializeComponent();
            Location = new Point(803, 519);
        }

        public void SetTable(List<LogicGates> Inputs, List<LogicGates> Outputs)
        {
            DataGridView.ColumnCount = Inputs.Count + Outputs.Count;
            for (int i = 0; i < Inputs.Count; i++)
            {
                DataGridView.Columns[i].Name = PublicVariables.NumberToCharacter(Inputs[i].GetInputID()).ToString();
                DataGridView.Columns[i].Width = 25;
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
            }
        }
    }
}
