using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many relationship configuration
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId);

            // Seed Data for Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Ravi",  StudentEmail = "Ravi@123" },
                new Student { StudentId = 2, StudentName = "Shiva", StudentEmail = "Shiva@123" },
                new Student { StudentId = 3, StudentName = "Tom",   StudentEmail = "Tom@123" },
                new Student { StudentId = 4, StudentName = "Jerry", StudentEmail = "Jerry@123" }
            );

            // Seed Data for Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Java", StudentId = 2 },
                new Course { CourseId = 2, CourseName = "CSharp", StudentId = 1 },
                new Course { CourseId = 3, CourseName = "Python", StudentId = 3 },
                new Course { CourseId = 4, CourseName = "HTML", StudentId = 2 }
            );
        }



    }
}
