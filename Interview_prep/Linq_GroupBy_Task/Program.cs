using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_GroupBy_Task
{
    public class Employee
    {
        public int No { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Req { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee { No = 123, Name = "Abc", Qty = 5, Req = -1 },
                new Employee { No = 123, Name = "Abc", Qty = 10, Req = 0 },
                new Employee { No = 345, Name = "Def", Qty = 5, Req = -5 },
                new Employee { No = 345, Name = "Def", Qty = 15, Req = 0 },
                new Employee { No = 123, Name = "Abc", Qty = 14, Req = 5 },
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            IEnumerable<IGrouping<string, Employee>> groupedByName = Employee.GetEmployees().GroupBy(e => e.Name);
            foreach (var nameGroup in groupedByName)
            {
                Console.WriteLine($"Name: {nameGroup.Key}");
                IEnumerable<IGrouping<int, Employee>> groupedByNo = nameGroup.GroupBy(e => e.No);
                foreach (var noGroup in groupedByNo)
                {
                    Console.WriteLine($"  No: {noGroup.Key}");
                    IEnumerable<IGrouping<int, Employee>> groupedByQty = noGroup.GroupBy(e => e.Qty);
                    foreach (var qtyGroup in groupedByQty)
                    {
                        foreach (var emp in qtyGroup)
                        {
                            if (emp.Req > 0)  
                            {
                                Console.WriteLine($" Qty:{qtyGroup.Key} Req:{emp.Req}");
                            }
                        }
                    }
                }
            }

            int total = Employee.GetEmployees().Where(e => e.Req > 0).Sum(e => e.Qty);
            Console.WriteLine("=============");
            Console.WriteLine($"Total Qty (Req > 0): {total}");
            Console.ReadKey();
        }
    }
}

Today I learnt Middlewares, Action Filters and worked on LINQ Operators,GroupBy,revised C sharp Concepts and also attended Entity Framework Task