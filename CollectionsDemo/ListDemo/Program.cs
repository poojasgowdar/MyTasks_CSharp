using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>();
            list.Add(50);
            list.Add(20);
            list.Add(100);
            Console.WriteLine("Before Sorting");
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
            list.Sort();
            Console.WriteLine("After Sorting");
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
            //Console.WriteLine(list);
            Console.ReadKey();

        }
    }
}
