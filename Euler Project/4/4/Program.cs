using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = 999;
            int second = 999;
            int max = 0;
            string number = "";
            for (first = 999; first >= 0; first--)
            {
                for (second = 999; second >= 0; second--)
                {
                    number = (first * second).ToString();
                    string left = number.Substring(0, (number.Length) / 2);
                    char[] charArray = number.ToCharArray();
                    Array.Reverse(charArray);
                    string rightreverse = new string(charArray);
                    string right = rightreverse.Substring(0, (number.Length) / 2);
                    if (left == right)
                        if (first * second > max)
                            max = first * second;
                }
            }
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
