using Microsoft.EntityFrameworkCore;
using New_ASPCORE_WEB_API.DBModels;

namespace New_ASPCORE_WEB_API.Context
{
    public class SchoolContext : DbContext
    {
        IConfiguration Configuration { get; }

        //Adding Migrations
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public SchoolContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            //configure the relationship between Student and Course


            //many-to-many 


            // modelBuilder.Entity<Student>()
            //.HasOne<Course>(s => s.Course)//One-to-One
            //.WithMany(c => c.Students)//One-to-many
            //.HasForeignKey(s => s.CourseId);

            //Fluent API
            //configure many to many relationship or student and course
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });


            //configure default values for student
            modelBuilder.Entity<Student>()
           .Property(s => s.DateAdded)
           .HasDefaultValueSql("getdate()");

            //seed Data
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Maths", Description = "Mathematics" },
                new Course { Id = 2, Name = "Science", Description = "Biology" },
                new Course { Id = 3, Name = "English", Description = "Story" }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "John",
                    StudentAddress = "America",
                    StudentEmail = "Jojn@gmail.com",
                    //CourseId = 1,
                    StudentDOB = new DateTime(2000, 1, 1),
                    StudentGender = "Male",
                    StudentPhone = "123-456-789"
                },

                new Student
                {
                    StudentId = 2,
                    StudentName = "Megha",
                    StudentAddress = "Africa",
                    StudentEmail = "Dayal@gmail.com",
                    //CourseId = 2,
                    StudentDOB = new DateTime(2002, 2, 2),
                    StudentGender = "Female",
                    StudentPhone = "122-456-789"
                }
            );
            //seed student courses
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { StudentId = 1, CourseId = 1 },
                new StudentCourse { StudentId = 1, CourseId = 2 },
                new StudentCourse { StudentId = 2, CourseId = 3 }
          
                 );
        }
    }
}
