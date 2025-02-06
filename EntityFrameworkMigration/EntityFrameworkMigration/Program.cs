using EntityFrameworkMigration;
using EntityFrameworkMigration.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class Program
{
    public static void Main(String[] args)
    {
        using (var context = new Schoolcontext())
        {
            //var student = new Student
            //{
            //    StudentName = "Prem",
            //    StudentAddress = "Davanagere",
            //    studentEmail = "premgowdar19@gmail.com",
            //    StudentDOB = new DateTime(2002, 2, 26),
            //    StudentGender = "Male",
            //    StudentPhone = "555-555-55555"
            //};
            //context.Teachers.Add(new Teacher
            //{
            //    Name="Shwetha",
            //    Email="shwetha12@gmail.com",
            //    Phone="444-444-44444"
            //});

            //context.Students.Add(student);
            //context.SaveChanges();

            Console.WriteLine("DB Status after getting data...");
            var student = context.Students.FirstOrDefault();
            //Console.WriteLine(student.StudentName);
            DisplayState(context.ChangeTracker.Entries());

            var student1 = new Student
            {
                StudentName = "Bhaskar",
                StudentAddress = "234-555-7777",
                studentEmail = "bhaskar12@gmail.com",
                StudentDOB = new DateTime(2003, 3, 23),
                StudentGender = "Male",
                StudentPhone = "555-343-6754",
                CourseId=1
            };
            context.Students.Add(student1);
            Console.WriteLine("DB Status after adding data...");
            DisplayState(context.ChangeTracker.Entries());
            context.SaveChanges();



        }
    }

    public static void DisplayState(IEnumerable<EntityEntry> entities)
    {
        foreach(var entity in entities)
        {
            Console.WriteLine($"Entity: {entity.Entity.GetType().Name}, State:{entity.State}");
        }
    }
}