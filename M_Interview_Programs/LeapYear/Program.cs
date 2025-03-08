using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYear
{
    class Program
    {
            static bool IsLeapYear(int year)
            {
                 return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            }
        static void Main()
        {
            Console.WriteLine("Enter a Year");
            int year = Convert.ToInt32(Console.ReadLine());
            if (IsLeapYear(year))
            {
                Console.WriteLine($"{year} is a Leap Year");
            }
            else
            {
                Console.WriteLine($"{year} is not a Leap Year");
            }
            Console.ReadKey();
        }
        
    }
}
