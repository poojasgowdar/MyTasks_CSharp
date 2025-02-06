using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Linq4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<(string Name, string Department)>
            {
                ("Alice", "HR"),
                ("Amogh","IT"),
                ("Chandru","HR"),
                ("David","IT")
            };
            var emp = employees.OrderBy(n => n.Department).ThenBy(m => m.Name);
            Console.WriteLine("Sorted Employees");
            foreach(var i in emp)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();



        }
    }
}


