using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The Name Field is Required")]
        [StringLength(100, ErrorMessage = "The Name Field should be 3 to 100 characters.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price Field should be required ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price should be greater than zero")]
        public double Price { get; set; }
    }
}
