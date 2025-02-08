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
            modelBuilder.Entity<Student>()
             .HasMany(s => s.Courses)
             .WithOne(c => c.Student)
             .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Student>().HasData
            (  
                new Student { Id=1,Name="Meena",Email="meena@gmail.com"},
                new Student { Id=2,Name="Puru", Email="puru@gmail.com"},
                new Student { Id=3,Name="Ramya",Email="Ramya@gmail.com" }
            );

            modelBuilder.Entity<Course>().HasData
           (
               new Course { CourseId = 1, CourseName = "Java", StudentId = 1},
               new Course { CourseId = 2, CourseName = "Sql", StudentId = 1},
               new Course { CourseId = 3, CourseName = "Csharp", StudentId = 2}
           );
        }
    }
}
