using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtos.dto
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "The CourseName Field is Required")]
        public string CourseName { get; set; }
        
        
    }
}
