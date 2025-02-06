using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing_Unboxing
{
    internal class Program
    {
        //Example for Boxing to Unboxing
        static void Main(string[] args)
        {
            int number = 100;
            object boxedNumber = number;
            Console.WriteLine("Value Type: "+number);
            Console.WriteLine("Reference Type: "+boxedNumber);
            Console.ReadKey();
        }
    }
}
