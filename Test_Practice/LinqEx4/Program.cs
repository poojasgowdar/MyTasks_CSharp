using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx4
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<String> list = new List<String> { "alice", "amruth", "anucha", "Prem", "ramya" };
            var nameStartingWithA = list.Where(name => name.StartsWith("a"));
            foreach(var name in nameStartingWithA)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
    }
}
