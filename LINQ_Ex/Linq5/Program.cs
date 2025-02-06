using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq5
{
    public class Program
    {
        private static object products;

        static void Main(string[] args)
        {
            var products = new List<Product>
               {
                    new Product { Name = "Laptop", Category = "Electronics", Price = 1000 },
                    new Product { Name = "Headphones", Category = "Electronics", Price = 200 },
                    new Product { Name = "Phone", Category = "Electronics", Price = 800 },
                    new Product { Name = "Desk", Category = "Furniture", Price = 150 },
                };

            //var result = from product in products
            //             where product.Category == "Electronics"
            //             orderby product.Price descending
            //             select new { product.Name, product.Price };

            var result = products.Where(p => p.Category == "Electronics")
                               .OrderByDescending(p => p.Price)
                               .Select(p => new { p.Name, p.Price });

            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
            }
            Console.ReadKey();

        }
    }
}
 