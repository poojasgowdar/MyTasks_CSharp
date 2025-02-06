using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListGenericDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Mysore");
            list.Add("Gulbarga");
            list.Add("Mandya");
            list.Add("Dvg");

            Console.WriteLine("Inserting an Item");
            list.Insert(2, "Shivamogga");
            foreach(string s in list)
            {
                Console.WriteLine(s);

            }

            Console.WriteLine("\nCreating a new list");
            List<string> newlist = new List<string>();
            newlist.Add("Jayanagar");
            newlist.Add("JP Nagar");

            Console.WriteLine("\nInserting an another List");
            list.InsertRange(2, newlist);

            foreach (string s in list)
            {
                Console.WriteLine(s);

            }
            Console.ReadKey();
        }
    }
}
