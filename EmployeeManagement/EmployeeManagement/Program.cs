using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }

    class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();

        // Add Employee
        public void AddEmployee(Employee emp)
        {
            if (employees.Any(e => e.Id == emp.Id))
            {
                Console.WriteLine("Error: Employee with this ID already exists!");
                return;
            }
            employees.Add(emp);
            Console.WriteLine("Employee added successfully!\n");
        }

        // View All Employees
        public void ViewEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.\n");
                return;
            }
            Console.WriteLine("\nEmployee List:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary:C}");
            }
            Console.WriteLine();
        }

        // Search Employee by ID
        public void SearchEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Employee not found.\n");
                return;
            }
            Console.WriteLine($"\nID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary:C}\n");
        }

        // Delete Employee by ID
        public void DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Employee not found.\n");
                return;
            }
            employees.Remove(emp);
            Console.WriteLine("Employee deleted successfully!\n");
        }

        // Sort Employees by Salary (Descending)
        public void SortEmployeesBySalary()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.\n");
                return;
            }
            var sortedEmployees = employees.OrderByDescending(e => e.Salary).ToList();
            Console.WriteLine("\nEmployees Sorted by Salary:");
            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary:C}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            EmployeeService employeeService = new EmployeeService();
            while (true)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Sort Employees by Salary");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Employee ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Department: ");
                        string department = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        employeeService.AddEmployee(new Employee { Id = id, Name = name, Department = department, Salary = salary });
                        break;

                    case 2:
                        employeeService.ViewEmployees();
                        break;

                    case 3:
                        Console.Write("Enter Employee ID to search: ");
                        int searchId = int.Parse(Console.ReadLine());
                        employeeService.SearchEmployee(searchId);
                        break;

                    case 4:
                        Console.Write("Enter Employee ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        employeeService.DeleteEmployee(deleteId);
                        break;

                    case 5:
                        employeeService.SortEmployeesBySalary();
                        break;

                    case 6:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 6.\n");
                        break;
                }
            }
        }
    }

}
