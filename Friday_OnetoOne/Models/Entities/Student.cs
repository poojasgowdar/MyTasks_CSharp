using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The Name Field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Email Field is Required")]
        public string Email { get; set; }
        public Course Course { get; set; }

    }
}   
