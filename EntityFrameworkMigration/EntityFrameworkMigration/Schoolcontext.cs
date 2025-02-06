using EntityFrameworkMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMigration
{
    public class Schoolcontext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VGHCOFD;Database=SchoolDataB;Trusted_Connection=True;Integrated Security=True;Encrypt=false;");
        }

        //seed method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "Maths", Description = "Maths is a tough subject" });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 2, Name = "Science", Description = "Environmental Science" });
            modelBuilder.Entity<Course>().HasData(new Course { Id = 3, Name = "Social", Description = "History" });

            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 1,
                Name = "Pushpa",
                Email = "pushpa@gmail.com",
                Phone="666-666-666"
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId=1,
                StudentName="Vignesh",
                StudentAddress="123-456-789",
                studentEmail="vignesh@gmail.com",
                StudentDOB=new DateTime(2006,6,13),
                StudentGender="Male",
                StudentPhone="565-908-765",
                CourseId=1

            });
            
        }

    }
}
