using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 5, 10, 15, 20, 25 };
            var firstNumber = list.FirstOrDefault(n=>n>10);
            Console.WriteLine(firstNumber);
            Console.ReadKey();


        }
    }
}
