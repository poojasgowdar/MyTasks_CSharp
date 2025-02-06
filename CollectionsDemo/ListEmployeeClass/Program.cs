using System;
using System.Collections.Generic;


namespace ListEmployeeClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //create Employee Objects
            Employee employee1 = new Employee()
            {
                Id = 101,
                Name="Pooja",
                Salary="50000",
                Gender="Female"

            };
            Employee employee2 = new Employee()
            {
                Id = 102,
                Name = "Ayra",
                Salary = "40000",
                Gender = "Female"

            };
            Employee employee3 = new Employee()
            {
                Id = 103,
                Name = "Yashas",
                Salary = "3000",
                Gender = "Male"

            };
            Employee employee4 = new Employee()
            {
                Id = 103,
                Name = "Ritu",
                Salary = "70000",
                Gender = "Female"

            };
            Employee employee5 = new Employee()
            {
                Id = 103,
                Name = "Sridhar",
                Salary = "900",
                Gender = "Male"

            };

            List<Employee> list = new List<Employee>()
            {
                employee1,
                employee2,
                employee3,
                employee4,
                employee5
            };

            Dictionary<int, Employee> dicemp = new Dictionary<int, Employee>();
            dicemp.Add(employee1.Id, employee1);
            dicemp.Add(employee2.Id, employee2);
            dicemp.Add(employee3.Id, employee3);

            foreach(KeyValuePair<int,Employee> kvp in dicemp )
            {
                Console.WriteLine(kvp.Key);
            }

            Console.WriteLine("The total no of Keys:" +dicemp.Count);


            //Exists
            Console.WriteLine("Exists");
            if (list.Exists(x => x.Name.StartsWith("S")))
            {
                Console.WriteLine("\nList contains Employees whose Name Starts With S");
            }
            else
            {
                Console.WriteLine("\nList does not Contain Any Employee whose Name Starts With S");
            }

        
            //Contains
            Console.WriteLine("\nContains Method Check Employee2 Object");
            if (list.Contains(employee2))
            {
                Console.WriteLine("Employe2 Object Contains in the List");
            }
            else
            {
                Console.WriteLine("Employe2 Object Does Not Contains in the List");
            }

         

            //Find
            Console.WriteLine("\nFind Method");
            Employee emp = list.Find(employee => employee.Gender == "Male");
            Console.WriteLine($"ID = {emp.Id}, Name = {emp.Name}, Gender = {emp.Gender}, Salary = {emp.Salary}");

            //FindAll()
            Console.WriteLine("\nFindAll Method");
            List<Employee> em = list.FindAll(employee => employee.Gender == "Male");
            foreach (Employee fem in em)
            {
                Console.WriteLine($"ID = {fem.Id}, Name = {fem.Name}, Gender = {fem.Gender}, Salary = {fem.Salary}");
            }

            //FindIndex()
            Console.WriteLine($"\nGender is Male = {list.FindIndex(employee => employee.Gender == "Male")}");
           

            //FindLastIndex()
            Console.WriteLine($"\nGender is Male = {list.FindLastIndex(employee => employee.Gender == "Male")}");
            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Gender { get; set; }


    }
}
