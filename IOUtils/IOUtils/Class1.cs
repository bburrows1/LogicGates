using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUtils
{
    public class IOUtils
    {
        public static string readString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }
        public static int readInt(string prompt, int low, int high)
        {
            int number, tmpNumber;
            do
            {
                string intString = readString(prompt);
                bool result = int.TryParse(intString, out tmpNumber);
                if (result)
                {
                    number = tmpNumber;
                }
                else
                {
                    number = low - 1;
                }
            } while ((number < low) || (number > high));
            return number;
        }

    }
}
