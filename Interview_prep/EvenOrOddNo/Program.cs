using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOrOddNo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any Element");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine("The Number is Even");
            }
            else
            {
                Console.WriteLine("The Number is Odd");
            }
            Console.ReadKey();
        }
    }
}
