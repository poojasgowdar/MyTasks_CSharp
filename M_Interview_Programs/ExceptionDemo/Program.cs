using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 0;
            int c;
            Console.WriteLine("A value:" + a);
            Console.WriteLine("B value:" + b);
            c = a / b;
            Console.WriteLine("C value:" + c);
            Console.ReadKey();
        }
    }
}
