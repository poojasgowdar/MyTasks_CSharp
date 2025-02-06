using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Application.Models
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
