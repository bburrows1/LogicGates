using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List <int> binary = new List<int>(); 
            Console.WriteLine("Decimal to convert: ");
            int number = int.Parse(Console.ReadLine());
            while (number > 0)
            {
                binary.Add(number % 2);
                number = number / 2;
            }
            binary.Reverse();
            foreach (int bit in binary)
                Console.Write(bit);
            Console.ReadKey();
        }
    }
}
