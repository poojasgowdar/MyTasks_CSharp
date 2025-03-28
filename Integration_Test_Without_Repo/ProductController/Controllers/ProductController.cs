using DTOs.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace ProductController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            _logger.LogInformation("Fetching all products...");
            var products = _productService.GetAllProducts();
            if(products==null || !products.Any())
            {
                _logger.LogWarning("No Products Found");
                 return NotFound("No products available");
            }
            _logger.LogInformation("Products fetched successfully.");
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation($"Fetching product with ID: {id}");
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return NotFound(new { Message = "Product Not Found" });
            }
            _logger.LogInformation($"Product with ID {id} fetched successfully.");
            return Ok(product);
        }

        [HttpPost("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                _logger.LogWarning("Invalid product data provided.");
                return BadRequest("Invalid product data.");
            }

            _logger.LogInformation("Creating a new product...");
            var createdProduct = _productService.AddProduct(productDto);

            _logger.LogInformation($"Product created successfully with ID: {createdProduct.Id}");
            return CreatedAtAction(nameof(Add), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("UpdateProductById/{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDto)
        {
            _logger.LogInformation($"Updating product with ID: {id}");

            if (productDto == null)
            {
                _logger.LogWarning("Invalid product data provided for update.");
                return BadRequest("Invalid product data.");
            }

            var result = _productService.UpdateProduct(id, productDto);

            if (!result)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return NotFound("Product Not Found");
            }

            _logger.LogInformation($"Product with ID {id} updated successfully.");
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Deleting product with ID: {id}");
            var existingProduct = _productService.GetProductById(id);

            if (existingProduct == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return NotFound("Product Not Found");
            }

            _productService.DeleteById(id);
            _logger.LogInformation($"Product with ID {id} deleted successfully.");
            return NoContent();
        }
    }
}
