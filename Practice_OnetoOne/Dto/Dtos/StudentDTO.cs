using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dtos
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "The Name Field is Required")]
        [StringLength(100, ErrorMessage = "The Name should be in 3 to 100 characters.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Email Field is Required")]
        public string Email { get; set; }

        public CourseDTO Course { get; set; }
    }
}
