using System;
using System.Net;
namespace Delegates_Calculator
{
    internal class Program
    {
        //Define Delegate
        public delegate int Calculator(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");
            bool found = true;
            while (found)
            {
                Console.WriteLine("Select an Operation:");
                Console.WriteLine(" 1.Addition\n 2.Subtraction\n 3.Multiplication\n 4.Division\n 5.Exit");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a Number1:");
                int Number1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter a Number2:");
                int Number2 = int.Parse(Console.ReadLine());
                

                Calculator calculator = null;

                switch (choice)
                {
                    case 1:
                        calculator = add;
                        break;
                    case 2:
                        calculator = sub;
                        break;
                    case 3:
                        calculator = mul;
                        break;
                    case 4:
                        calculator = div;
                        break;
                    case 5:
                        Console.WriteLine("Exit");
                        found = false;
                        break;
                      
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                int result = calculator(Number1, Number2);
                Console.WriteLine("Result:" + result);
                Console.ReadKey();
            }
        }
        static int add(int a, int b)
        {
            return a + b;
        }
        static int sub(int a, int b)
        {
            return a - b;
        }
        static int mul(int a, int b)
        {
            return a * b;
        }
        static int div(int a, int b)
        {
            return a / b;
        }

    }
}
