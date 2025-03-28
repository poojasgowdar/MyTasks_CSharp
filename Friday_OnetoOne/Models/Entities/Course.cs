using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The CourseName Field is Required")]
        public string CourseName { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
       
    }
}
