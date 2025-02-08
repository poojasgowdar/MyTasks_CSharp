using Dto.Dtos;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _logger.LogInformation("Fetching All Products");
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProducyById{id}")]
        public IActionResult GetProductById(int id)
        {
            _logger.LogInformation($"Fetching Product with Id{id}");
            var products = _productService.GetProductById(id);
            if (products == null)
            {
                _logger.LogWarning($"Product with Id{id} not Found");
                return NotFound(new { Message = "Product Not found" });
            }
            return Ok(products);
        }

        [HttpPut("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            _logger.LogInformation($"Creating a new Product:{productDto.Name}");
            _productService.Add(productDto);
            return Ok("Product Created Successfully");
        }

        [HttpPost("UpdateProductById")]
        public IActionResult Update(int id,[FromBody] ProductDTO productDto)
        {
            _logger.LogInformation($"Updating a Product with Id{id}");
            var result = _productService.UpdateById(id, productDto);
            if (!result)
            {
                _logger.LogWarning($"Product with Id{id} not found");
                //return BadRequest();
                return NotFound(new { Message = "Product Not Found" });
            }
            _logger.LogInformation($"Product with Id{id} updated succesfully");
            return Ok("Product Created Successfully");
        }

        [HttpDelete("DeleteProductById")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Deleting a Product with Id{id}");
            var products = _productService.GetProductById(id);
            if (products == null)
            {
                _logger.LogWarning($"Product with Id{id} Not found");
                 return NotFound(new { Message = "Product Not Found" });
            }
            _logger.LogInformation($"Product with Id{id} Deleted successfully");
            return Ok("Product Deleted Successfully");
        }

    }
}
