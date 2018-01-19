using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz_Buzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How far to count?");
            int HowFar = int.Parse(Console.ReadLine());
            while (HowFar < 1)
            {
                Console.WriteLine("Not a valid number, please try again.");
                HowFar = int.Parse(Console.ReadLine());
            }
            for (int MyLoop = 1; MyLoop <= HowFar; MyLoop++)
            {
                if ((MyLoop % 3 == 0) && (MyLoop % 5 == 0))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    if (MyLoop % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else
                    {
                        if (MyLoop % 5 == 0)
                        {
                            Console.WriteLine("Buzz");
                        }
                        else
                        {
                            Console.WriteLine(MyLoop);
                        }
                    }

                }
            }
            Console.ReadKey();
        }
    }
}
