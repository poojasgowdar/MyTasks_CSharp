using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New_ASPCORE_WEB_API.DBModels
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentEmail { get; set; }

        public string StudentPhone { get; set; }
        public DateTime StudentDOB { get; set; }
        public string StudentGender { get; set; }
        public DateTime DateAdded { get; set; }

        //No need to use when fluent api is used
       // [ForeignKey("CourseId")]

        //public int CourseId { get; set; }
        //Navigation property
        //one-to-one
        // a student can have only one course
        //public Course Course { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
