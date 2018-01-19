using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 1; number >= 0; number++)
            {
                int divisions = 0;
                for (int divisor = 1; divisor <= 20; divisor++)
                {
                    if (number % divisor == 0)
                        divisions++;
                    else
                        break;
                }
                if (divisions == 20)
                {
                    Console.WriteLine(number);
                    Console.ReadKey();
                }
            }
        }
    }
}
