using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumofsquares = 0;
            int sum = 0;
            for (int number = 1; number <= 100; number++)
            {
                sumofsquares += number * number;
                sum += number;
            }
            Console.WriteLine(sum * sum - sumofsquares);
            Console.ReadKey();
        }
    }
}
