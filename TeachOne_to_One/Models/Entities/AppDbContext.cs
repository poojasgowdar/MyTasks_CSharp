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
            .HasIndex(p => p.Name)
            .IsUnique();

            modelBuilder.Entity<Student>()
            .HasOne(s=>s.Course)
            .WithOne(a=>a.Student)
            .HasForeignKey<Course>(c => c.StudentId);


            modelBuilder.Entity<Student>().HasData
            (
                new Student { Id=1,Name="Pooja",Email="poojagowdar19@gmail.com"},
                new Student { Id=2,Name="Pranaya", Email = "pranayagowdar19@gmail.com" },
                new Student { Id=3,Name="Amit", Email = "amitgowdar19@gmail.com" }
            );

            modelBuilder.Entity<Course>().HasData
            (
                new Course { Id=1,CourseName="Java",StudentId=2},
                new Course { Id=2,CourseName="CSharp", StudentId=1},
                new Course { Id=3,CourseName="C++", StudentId=3}
            );
        }
    }
}
