using System;
using System.Collections.Generic;
using System.Linq;
namespace Lambda_Exp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 3, 4, 5, 6, 7, 8 };
            //foreach(var i in list)
            //{
            //    Console.WriteLine(i);
            //}

            var Square = list.FindAll(x => (x%2) ==0);
            foreach(var i in Square)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();

        }
    }
}
