using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayToListCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee
            {
                id=101,
                name="pooja",
                gender="female",
                sal=50000
            };
            Employee emp2 = new Employee
            {
                id = 102,
                name = "pranay",
                gender = "male",
                sal = 50000
            };

            Employee[] emp = new Employee[2];
            emp[0] = emp1;
            emp[1] = emp2;

            List<Employee> listEmployees = emp.ToList();
            foreach(Employee em in listEmployees)
            {
                Console.WriteLine("id = {0}, name = {1}, gender ={2}, sal = {3}",
                               em.id, em.name, em.gender, em.sal);
            }
            Console.ReadKey();

        }


    }

    

     class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int sal { get; set; }

    }
}
