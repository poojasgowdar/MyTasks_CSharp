using System;
using System.Collections;
namespace ArrayListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arraylist = new ArrayList();
            arraylist.Add("Apple");
            arraylist.Add("Banana");
            arraylist.Add("Mango");
            arraylist.Add("Strawberry");

            foreach(string arr in arraylist)
            {
                Console.WriteLine(arr);
            }

            Console.WriteLine(arraylist);
            Console.ReadKey();

        }
    }
}
