using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arraylist = new ArrayList();
            arraylist.Add(1);
            arraylist.Add(2);
            arraylist.Add(3);
            arraylist.Add("One");
            foreach(var i in arraylist)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
