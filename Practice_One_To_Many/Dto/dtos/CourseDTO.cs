using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.dtos
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "The CourseName Field is Required")]
        [StringLength(100, ErrorMessage = "The CourseName should be in 3 to 100 characters", MinimumLength = 3)]
        public string CourseName { get; set; }

    }
}
