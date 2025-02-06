using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndOutParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example for out keyword
            //It is generally used when a method returns multiple values.
            int G;
            Sum(out G);
            Console.WriteLine("The sum of the Value is {0} ", G);


            Console.ReadKey();
        }
        public static void Sum(out int G)
        {
            G = 80;
            G += G;
        }
    }  
}

