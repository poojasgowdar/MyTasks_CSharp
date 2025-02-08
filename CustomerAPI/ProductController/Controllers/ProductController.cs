using Dtos.dto;
using Entities.Models;
using Interface.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

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
        public IActionResult GetAll()
        {
            try
            {
                var products = _productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetProductById")]
        public IActionResult GetById(int id)
        {
            try
            {
               var product = _productService.GetById(id);

                if (product == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return NotFound(new { message = $"Product with ID {id} not found." });
                }

                _logger.LogInformation("Product with ID {ProductId} retrieved successfully.", id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching product with ID {ProductId}.", id);
                return StatusCode(500, new { message = "An error occurred while fetching the product." });
            }
        }
        



        [HttpPost("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductCreateDto productDto)
        {
            try
            {
                var response = _productService.Add(productDto);
                _logger.LogInformation("Product created successfully ");
                return CreatedAtAction(nameof(GetById), new { id = response.Message }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new product.");
                return StatusCode(500, new { message = "An error occurred while creating the product." });
            }
        }


        [HttpPut("UpdateProductById/{id}")]
        public IActionResult UpdateById(int id, [FromBody] ProductUpdateDto productDto)
        {
            try
            {
                _logger.LogInformation("Attempting to update product with ID {ProductId} using data: {@ProductUpdateDto}", id, productDto);

                var response = _productService.UpdateById(id, productDto);

                if (response.Success)
                {
                    _logger.LogInformation("Product with ID {ProductId} updated successfully.", id);
                    return Ok(response);
                }

                _logger.LogWarning("Product with ID {ProductId} not found for update.",id);
                return NotFound(new { message = response.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating product with ID {ProductId}.", id);
                return StatusCode(500, new { message = "An error occurred while updating the product." });
            }
        }


        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to delete product with ID {ProductId}.", id);

                var response = _productService.DeleteById(id);

                if (response.Success)
                {
                    _logger.LogInformation("Successfully deleted product with ID {ProductId}.", id);
                    return Ok(response);
                }

                _logger.LogWarning("Product with ID {ProductId} not found for deletion. Message: {Message}", id, response.Message);
                return NotFound(new { message = response.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting product with ID {ProductId}.", id);
                return StatusCode(500, new { message = "An error occurred while deleting the product." });
            }
        }

    }
}
