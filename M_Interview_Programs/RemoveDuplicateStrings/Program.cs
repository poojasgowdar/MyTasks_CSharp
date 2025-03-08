using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicateStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "pooja";
            string res = new string(input.Distinct().ToArray());
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
