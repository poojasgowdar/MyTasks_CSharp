using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        public int Add(int a, int b) => a + b;
        public int Sub(int a, int b) => a - b;
        public int Mul(int a, int b) => a * b;
        public int Div(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot Divide By Zero");
            return a / b;

        }
    }

    public class Calculator 
    { 
        static void Main(String[] args)
        {
            Program p = new Program();

            Console.WriteLine("=== Simple Calculator ===");

            Console.WriteLine("Add: 10 + 5 = " + p.Add(10, 5));
            Console.WriteLine("Subtract: 10 - 5 = " + p.Sub(10, 5));
            Console.WriteLine("Multiply: 10 * 5 = " + p.Mul(10, 5));
            Console.WriteLine("Divide: 10 / 5 = " + p.Div(10, 5));
            Console.ReadLine();
        }
    }
}
