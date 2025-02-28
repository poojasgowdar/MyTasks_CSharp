using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Dto
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The Name Field should be required")]
        [StringLength(100, ErrorMessage = "The Name should be 3 to 100 characters,MinimumLength=3")]
        public string ProductName { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
