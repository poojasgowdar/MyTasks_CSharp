using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string studentEmail { get; set; }

        public string StudentPhone { get; set; }
        public DateTime StudentDOB { get; set; }
        public string StudentGender { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course Course { get; set; }


    }
}
