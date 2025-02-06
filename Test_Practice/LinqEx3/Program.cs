using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx3
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 2, 1, 3, 4, 5, 6, 7, 8 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            foreach(var n in evenNumbers)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
