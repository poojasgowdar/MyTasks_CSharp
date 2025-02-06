using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIwithEFCore.Models
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

        //One-toOne
        //public int CourseId { get; set; }
        //public Course Course { get; set; }

        //Navigation Property for list of courses.
        public virtual ICollection<Course> Courses { get; set; }





    }
}
