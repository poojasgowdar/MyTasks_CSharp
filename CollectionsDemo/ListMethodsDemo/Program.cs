using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMethodsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(20);
            list.Add(40);
            list.Add(10);
            list.Add(80);


            List<int> newlist = new List<int>();
            list.Add(200);
            list.Add(400);
            list.Add(500);

            //list.Insert(2, 100);
            //list.Insert(3, 200);

            //list.Remove(100);
           

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }



            Console.ReadKey();
        }

       


    }
}
