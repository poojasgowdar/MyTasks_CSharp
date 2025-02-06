using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBy1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
              new Employee { Id = 1, Name = "Alice", Department = "HR" },
              new Employee { Id = 2, Name = "Bob", Department = "IT" },
              new Employee { Id = 3, Name = "Charlie", Department = "IT" },
              new Employee { Id = 4, Name = "David", Department = "Finance" },
              new Employee { Id = 5, Name = "Eve", Department = "HR" }

           };
        }
    }

    class Program
    {
        static void Main(String[] args)
        {

            var groupByDepartment = Employee.GetEmployees().GroupBy(e => e.Department);
            foreach (var  group in groupByDepartment)
            {
                Console.WriteLine($"Department :{group.Key}");
                foreach (var gp in group)
                {
                    Console.WriteLine($" - Name: {gp.Name}");
                }
            }
            Console.ReadKey();
        }
    }

      
    
}
