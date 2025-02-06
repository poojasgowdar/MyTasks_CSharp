using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>{ "Pooja","Akash","Prajwal","Kiran","Megha","Meena","Mira"};
            var a = list.Where(x => x.StartsWith("M")).ToList();
            foreach(var x in a)
            {
                Console.WriteLine(x);
            }
            var b = list.Where(x => x.EndsWith("a")).ToList();
            foreach (var x in b)
            {
                Console.WriteLine(x);
            }
            var firstA = list.FirstOrDefault(x => x.StartsWith("A"));
            Console.WriteLine(firstA);

            var containsA = list.Where(x => x.Contains("a")).ToList();
            Console.WriteLine("\nStrings that contain the letter 'a':");
            foreach (var x in containsA)
            {
                Console.WriteLine(x);
            }

            var c = list.Any(x => x.StartsWith("A"));
            Console.WriteLine(c);

            var d = list.All(x => x.Length > 3);
            Console.WriteLine(d);

            var e = list.FindAll(x => x.Length > 4);
            Console.WriteLine("Strings with length greater than 3:");
            foreach (var x in e)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }
    }
}
