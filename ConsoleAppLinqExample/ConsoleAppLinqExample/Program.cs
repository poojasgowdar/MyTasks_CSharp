using ConsoleAppLinqExample;
using System.Linq;
public class Program
{
    static void Main(string[] args)
    { 
        //create a list of students
        List<Student> students = new List<Student>
        {
            new Student { StudentId=1, StudentName="John", Age=18},
            new Student { StudentId=2, StudentName="Jane", Age=20},
            new Student { StudentId=3, StudentName="Smith", Age=15},
            new Student { StudentId=4, StudentName="Sam", Age=26},
            new Student { StudentId=5, StudentName="krish", Age=24},
            new Student { StudentId=5, StudentName="krish", Age=24},
        };

        //foreach(Student student in students)
        //{
        //    if (student.Age > 20  && student.Age<30)
        //    {
        //        Console.WriteLine(student.StudentName);
        //    }
        //}
        //LINQ Query to select students aged 20 or above

        //var result = from student in students
        //             where student.Age >= 20
        //             select student;
        //var result = students.Where(x => x.Age > 20);
        //foreach (var student in result)
        //{
        //    Console.WriteLine(student.StudentName);
        //}

        //var res = students.OrderBy(s => s.StudentName);
        //Console.WriteLine("Id\t Name\t Age");
        //foreach (var student in res)
        //{
        //    // Console.WriteLine(student.StudentName);
        //    Console.WriteLine(student.StudentId + "\t" + student.StudentName + "\t" + student.Age);
        //}
        //var res = students.OrderByDescending(s => s.StudentName);
        //Console.WriteLine("Id\t Name\t Age");
        //foreach (var student in res)
        //{
        //    // Console.WriteLine(student.StudentName);
        //    Console.WriteLine(student.StudentId + "\t" + student.StudentName + "\t" + student.Age);
        //}

        //var res = students.Select(s => s.StudentName).Distinct();
        //foreach(var student in res)
        //{
        //    Console.WriteLine(student);
        //}

        //Projection
        var res = students.Select(s => new { Name = s.StudentName, Age = s.Age });
        foreach(var student in res)
        {
            Console.WriteLine(student.Name + "\t" + student.Age);
        }
        Console.ReadKey();





    }
}