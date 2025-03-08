using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any Number:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (IsPerfectNumber(num))
            {
                Console.WriteLine($"{num} is an perfect Number ");
            }
            else
            {
                Console.WriteLine($"{num} is not an  perfect Number ");
            }
            Console.ReadKey();
        }

            static bool IsPerfectNumber(int num)
            {
                     if (num <= 1)
                        return false;
                     int sum = 0;

                for (int i = 1;  i <= num / 2; i++)
                 {
                    if (num % i == 0)
                    {
                        sum += i;
                    }
                }
                 return sum == num;
            }
    }
}

