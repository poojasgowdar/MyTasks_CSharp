using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "Adarsh","Pooja","Amogha",
            };
            var name = names.Where(x => x.StartsWith("A"));
            foreach(var i in name)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
            
        }
    }
}
