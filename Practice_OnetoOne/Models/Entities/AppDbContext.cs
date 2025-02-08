using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
            .HasOne(s => s.Course)
            .WithOne(a => a.Student)
            .HasForeignKey<Course>(a => a.StudentId);

            modelBuilder.Entity<Student>().HasData
            ( 
                new Student { Id=1,Name="Pooja",Email="poojagowdar19@gmail.com"},
                new Student { Id=2,Name="Pradeep", Email = "pradeepgowdar19@gmail.com" },
                new Student { Id=3,Name="Yashu", Email = "yashugowdar19@gmail.com" }
            );

            modelBuilder.Entity<Course>().HasData
            (
                new Course { Id = 1, Street = "Vidyanagar", City = "Davanagere", StudentId = 2 },
                new Course { Id = 2, Street = "Manjunath Nagar", City = "Bangalore", StudentId = 1 },
                new Course { Id = 3, Street = "RR Nagar", City = "Mysore", StudentId = 3 }
            );

        }

    }
}
