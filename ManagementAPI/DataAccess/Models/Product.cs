using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Price must be greater than zero.")]
        public Decimal Price { get; set; }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage ="Stock Quantity must be greater than or equal to zero.")]
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
