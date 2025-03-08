using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Interview_Programs
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Console.WriteLine($"Before Swap: a={a} ,b={b}");
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"After Swap: a={a}, b={b}");
            Console.ReadKey();
        }
    }
}
