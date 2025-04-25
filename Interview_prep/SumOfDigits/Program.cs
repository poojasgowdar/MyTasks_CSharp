using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number");
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine($"Sum of digits: {sum}");
            Console.ReadKey();
        }
    }
}

//Today I implemented test cases for Repeat Oder feature and also add to basket using playwright and alos validated test cases
