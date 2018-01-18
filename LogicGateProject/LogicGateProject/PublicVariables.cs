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

        //Ensures each gate has a unique ID
        public static List<LogicGates> Gates = new List<LogicGates>();

        //Stores connections between gates
        public static LogicGates InputGate = null;
        public static LogicGates OutputGate = null;
        public static List<bool> IsTopList = new List<bool>();
        public static bool IsTop;

        //Stores points for joining lines and Pen
        public static Point InputPoint;
        public static Point OutputPoint;
        public static Pen Linepen = new Pen(Color.Black, 4);
        public static List<Point> InputPoints = new List<Point>();
        public static List<Point> OutputPoints = new List<Point>();
    }
}
