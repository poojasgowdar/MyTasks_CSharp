using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        //foreign key
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
