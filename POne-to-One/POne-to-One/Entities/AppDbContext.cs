using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POne_to_One.Entities
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
            modelBuilder.Entity<Student>()
                .HasOne(c => c.Course)
                .WithOne(s => s.Student)    
                .HasForeignKey<Course>(c => c.StudentId);
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "Surya", LastName = "Tejas" },
                new Student { StudentId = 2, FirstName = "Arya", LastName = "Teja" },
                new Student { StudentId = 3, FirstName = "Suresh", LastName = "Kumar" },
                new Student { StudentId = 4, FirstName = "Aditi", LastName = "Prabhu" }
                );
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Science",StudentId = 2},
                new Course { CourseId = 2, CourseName = "Social", StudentId = 1 },
                new Course { CourseId = 3, CourseName = "Maths",  StudentId = 3 }
                );


        }
    }
}
