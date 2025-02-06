using DataModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AddDbContext _context;

        public ProductController(AddDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllProducts")]

        //public IEnumerable<Product> GetAll()
        //{
        //    return _context.Products;
        //}

        //public IActionResult GetAll()
        //{
        //    var products = _context.Products.ToList();
        //    return Ok(products);
        //}
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost("AddNewProduct")]
        public IActionResult AddNewProduct(Product product)
        {
            //if (product == null)
            //{
            //    return BadRequest("Product data is required.");
            //}

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }


        [HttpPost("UpdateProductById")]
        public IActionResult UpdateById(int id,Product updateProduct)
        {
            if (updateProduct == null || id != updateProduct.ProductId)
            {
                return BadRequest("Invalid Product Data");
            }

            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} not found");
            }
            existingProduct.Name = updateProduct.Name;
            existingProduct.Price = updateProduct.Price;
            _context.SaveChanges();
            return Ok($"Product with ID {id} is updated");
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            var product = _context.Products.FirstOrDefault(p=>p.ProductId == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok($"Product with ID {id} has been deleted");
        }

    }
}
