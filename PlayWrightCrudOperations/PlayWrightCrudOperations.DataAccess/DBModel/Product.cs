using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightCrudOperations.DataAccess 
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name Field is Required")]
        [StringLength(100, ErrorMessage = "The Name must be in 3 to 100 characters.", MinimumLength = 3)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Price Field is Required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price should be greater than zero")]
        public decimal Price { get; set; }
    }
}
