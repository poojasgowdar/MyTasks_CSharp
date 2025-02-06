using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Practice_CRUD_OPERATION_API.Models;

namespace Practice_CRUD_OPERATION_API.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        private readonly IConfiguration _configuration;

        // Constructor to inject IConfiguration
        public SchoolContext(DbContextOptions<SchoolContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Student)
                .HasForeignKey(s => s.CourseId);
            //.OnDelete(DeleteBehavior.Cascade); // Set cascading delete if necessary
            //seed Data
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Maths" },
                new Course { CourseId = 2, Title = "Science" },
                new Course { CourseId = 3, Title = "English" }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "John",
                    StudentAge = 25,
                    CourseId = 1
                },

                new Student
                {
                    StudentId = 2,
                    StudentName = "Thomas",
                    StudentAge = 26,
                    CourseId = 2
                }
            );
        }
    }
}
