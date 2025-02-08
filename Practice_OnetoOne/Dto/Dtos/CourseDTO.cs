using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dtos
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "The Street Field is Required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "The City Field is Required")]
        public string City { get; set; }
    }
}
