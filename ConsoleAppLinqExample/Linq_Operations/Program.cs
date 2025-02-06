using System;

namespace Linq_Operations
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }

        public int EmployeeSal { get; set; }


        static void Main(string[] args)
        {
            List<Employee> employee = new List<Employee>
        {
            new Employee { EmployeeId=1, EmployeeName="Diamond",EmployeeAge=20,EmployeeSal=5000},
            new Employee { EmployeeId=2, EmployeeName="Gold",EmployeeAge=30, EmployeeSal=6000},
            new Employee { EmployeeId=3, EmployeeName="Pearl",EmployeeAge=33,EmployeeSal=3000},
            new Employee { EmployeeId=4, EmployeeName="Ruby",EmployeeAge=21,EmployeeSal=10000 },
            new Employee { EmployeeId=5, EmployeeName="Silver",EmployeeAge=42,EmployeeSal=2000 }
        };

            //Average Age
            var averageAge = employee.Average(s => s.EmployeeAge);
            Console.WriteLine($"Average Age is: {averageAge}");

            //Count of Employees
            var countOfEmployees = employee.Count();
            Console.WriteLine($"Total Employees is: {countOfEmployees}");

            //Minimum Age
            var minAge = employee.Min(s => s.EmployeeAge);
            Console.WriteLine($"Minimum Age: {minAge}");

            //Maximum Age
            var maxAge = employee.Max(s => s.EmployeeAge);
            Console.WriteLine($"Maximum Age: {maxAge}");

            //Sum of Ages
            var sumOfSal = employee.Sum(s => s.EmployeeSal);
            Console.WriteLine($"Sum of Ages: {sumOfSal}");

          
            // Check if List Contains a Specific Student by Name
            bool containsDiamond = employee.Any(s => s.EmployeeName == "Diamond");
            Console.WriteLine($"Contains Diamond: {containsDiamond}");

            //Age 25
            bool aboveAge = employee.Any(s => s.EmployeeAge > 25);
            Console.WriteLine($"Any employee Above 25: {aboveAge}");
    


            Console.ReadKey();




        }
    }
}