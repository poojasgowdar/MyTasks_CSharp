using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap_No_Without_ThirdVar
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;
            Console.WriteLine($"Before Swap: a={a}, b={b}");
            a = a + b;
            b = a - b; 
            a = a - b;
            Console.WriteLine("After Swap: a={a},b={b}");
            Console.ReadKey();
        }
    }
}
