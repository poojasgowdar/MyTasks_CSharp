using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            var evenNumbers=list.Where(x=>x%2==0)
                            .OrderByDescending(x=>x)
                            .ToList();
            Console.WriteLine("Even Numbers are:");
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------");

            var first = list.First(x => x < 4);
            Console.WriteLine(first);
            Console.WriteLine("--------------------");

            var numbers = list.OrderByDescending(x => x).ToList();
            foreach(int i in numbers) 
            {
               Console.WriteLine(i);
            }

            var num = list.Average();
            Console.WriteLine(num);

            var a = list.Contains(1);
            Console.WriteLine(a);

            var b = list.FirstOrDefault(x => x < 4);
            Console.WriteLine(b);


            var squares = list.Select(n => n * n);
            foreach (int i in squares)
            {
                Console.WriteLine(i);
            }

            var max = numbers.Max();
            Console.WriteLine(max);

            var min = numbers.Min();
            Console.WriteLine(min);


            Console.ReadKey();
        }
    }
}
