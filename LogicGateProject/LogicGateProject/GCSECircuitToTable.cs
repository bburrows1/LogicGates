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

        public void SetTable(int Inputs, int Outputs)
        {
            TableLayout.ColumnCount = Inputs + Outputs;
            for (int i = 0; i < Convert.ToInt32(Math.Pow(2.0, Inputs)); i++)
            {
                string Binary = Convert.ToString(i, 2);
                for (int j = Binary.Length - 1; j >= 0; j--)
                {
                    if (Binary[j] == '0')
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
