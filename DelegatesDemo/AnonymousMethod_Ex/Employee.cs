using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace AnonymousMethod_Ex
{
   internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

     }

    class Program
    { 
        //Defining a delegate
        public delegate bool SalaryCriteria(Employee emp);
        static void Main(string[] args)
        {
            List<Employee> employee = new List<Employee>
            {
                    new Employee{ Id = 101, Name = "Pranaya", Gender = "Male",   Salary = 100000},
                    new Employee{ Id = 102, Name = "Prem",    Gender = "Female", Salary = 2000},
                    new Employee{ Id = 103, Name = "Anurag",  Gender = "Male",   Salary = 30000},
                    new Employee{ Id = 104, Name = "Preety",  Gender = "Female", Salary = 4000},
                    new Employee{ Id = 104, Name = "Sambit",  Gender = "Male",   Salary = 6000},
                    new Employee{ Id = 105, Name = "Meena",   Gender="Female",   Salary=5000}
            };

            var a = employee.OrderBy(x => x.Name);
            foreach(var i in a)
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("===========================");
            //1.Find()
            var firstHighestSalary = employee.Find(emp=>emp.Salary > 5000);
            Console.WriteLine($"Employee having highest Salary:  { firstHighestSalary.Name}, { firstHighestSalary.Salary}");
            Console.WriteLine("=========================");

            //2.FindLast()
            var lastHighestSalary = employee.FindLast(emp=>emp.Salary > 5000);
            Console.WriteLine($"Employee having last highest Salary:{lastHighestSalary.Name},{lastHighestSalary.Salary}");
            Console.WriteLine("========================");

            //3.FindAll()
            var nameStartswithP = employee.FindAll(emp => emp.Name.StartsWith("P"));
            // Console.WriteLine($"Employee Name starts with letter P are: {nameStartswithP.Name}");
            Console.WriteLine("Employees Name starts with letter P are:");
            foreach(var emp in nameStartswithP)
            {
                Console.WriteLine($"{emp.Name}");
            }
            Console.WriteLine("=========================");

            //4.FindIndex()

            var searchName = employee.FindIndex(emp => emp.Name == "Anurag");
            if (searchName != -1) // Check if the employee is found
            {
                Console.WriteLine($"Index: {searchName}, Name: {employee[searchName].Name}");
            }
            else
            {
                Console.WriteLine("Employee with the name 'Anurag' not found.");
            }
            Console.WriteLine("=============================");

            //5.FindLastIndex()
            var indexLastLowSalary = employee.FindLastIndex(emp => emp.Salary < 5000);
            Console.WriteLine($"Employee with last low Salary : {indexLastLowSalary}");
            Console.WriteLine("=======================");

            //6.contains
            var targetEmployee = new Employee {Name = "Priyanka" };
            bool containsEmployee = employee.Contains(targetEmployee); // Always false because it's a different object reference
            Console.WriteLine($"Does the list contain Priyanka (new object)? {containsEmployee}");

            //7.Exists: Check if any employee has salary = 5000
            bool existsSalary5000 = employee.Exists(emp => emp.Salary == 5000);
            Console.WriteLine($"Does any employee have a Salary of 5000? {existsSalary5000}");

            // TrueForAll() 
            bool allSalariesPositive = employee.TrueForAll(emp => emp.Salary > 5000);
            Console.WriteLine("All salaries are positive: " + allSalariesPositive);

            






            //SalaryCriteria criteria = IsSalaryGreaterThan5000;

            //Console.WriteLine("Employees with salary greater than 5000:");
            //foreach (var emp in employee)
            //{
            //    if (criteria(emp))
            //    {
            //        Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}, Gender: {emp.Gender}");
            //    }
            //}
            Console.ReadKey();
        }
        public static bool IsSalaryGreaterThan5000(Employee emp)
        {
            return emp.Salary > 5000;
        }
    } 
}
