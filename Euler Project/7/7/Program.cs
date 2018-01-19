using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int primecount = 0;
            for (int prime = 3; prime >= 0; prime+= 2)
            {
                bool isprime = true;
                for (int check = 3; check <= Math.Sqrt(prime); check += 2)
                {
                    if (prime % check == 0)
                    {
                        isprime = false;
                        break;
                    }
                }
                if (isprime)
                {
                    primecount++;
                    Console.WriteLine(prime);
                }
                if (primecount == 10000)
                {
                    Console.WriteLine(prime);
                    Console.ReadKey();
                } 
            }
        }
    }
}
