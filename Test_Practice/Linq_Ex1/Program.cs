using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1,2,4,5,7,9,8,4};
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;

            foreach(var n in evenNumbers)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
