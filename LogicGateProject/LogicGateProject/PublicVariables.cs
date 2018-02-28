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
    class PublicVariables
    {
        //Allows moving the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Indicates what level has been chosen
        public static int level = 0;

        //So that forms can be returned to
        public static Menu1 Menu1 = null;
        public static Menu2 Menu2 = new Menu2();
        public static Simulator Simulator = new Simulator();
        public static Quiz Quiz = new Quiz();
        public static TruthTable TruthTable = new TruthTable();
        public static ExpressionsTable ExpressionsTable = new ExpressionsTable();

        //Ensures each gate has a unique ID
        public static List<LogicGates> Gates = new List<LogicGates>();
        public static int ID = 1;
        public static int GetInputID()
        {
            List<int> Ids = new List<int>();
            int NewID = 1;
            foreach (LogicGates Gate in Gates)
            {
                if (Gate is Input)
                    Ids.Add(Gate.GetInputID());
            }
            while (Ids.Contains(NewID))
            {
                NewID++;
            }
            return NewID;
        }

        public static int GetOutputID()
        {
            List<int> Ids = new List<int>();
            int NewID = 1;
            foreach (LogicGates Gate in Gates)
            {
                if (Gate is Output)
                    Ids.Add(Gate.GetOutputID());
            }
            while (Ids.Contains(NewID))
            {
                NewID++;
            }
            return NewID;
        }

        //Stores connections between gates
        public static LogicGates InputGate = null;
        public static LogicGates OutputGate = null;
        public static bool IsTop;

        //Stores points for joining lines and Pen
        public static Pen Linepen = new Pen(Color.Black, 4);
        public static List<Point> InputPoints = new List<Point>();
        public static List<Point> OutputPoints = new List<Point>();

        //Tells gates to delete
        public static bool Delete;

        //Tells gates to work step by step
        public static bool Step;

        //Convert a number to a letter
        public static char NumberToCharacter(int Input)
        {
            if (64 + Input < 91)
                return (char)(64 + Input);
            else if (96 + (Input - 26) < 123)
                return (char)(96 + (Input - 26));
            else
                return '#';
        }

        //Convert a letter to a number
        public static int CharacterToNumber(char Character)
        {
            if ((int)Character < 91)
                return ((int)Character - 64);
            else if ((int)Character < 123)
                return ((int)Character - 96);
            else
                return (0);
        }
    }
}
