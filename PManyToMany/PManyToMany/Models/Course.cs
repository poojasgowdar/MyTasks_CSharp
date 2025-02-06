using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PManyToMany.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
