using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProductService;

namespace ProductController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProductsById/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound(new { Message = "Product Not Found" });
            }
            return Ok(product);
        }

        [HttpPost("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            var createdProduct = _productService.Add(productDto);
            if (createdProduct == null)
            {
                return BadRequest("Product could not be created.");
            }
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("UpdateProductById/{id}")]
        public IActionResult UpdateProductById(int id, [FromBody] ProductDTO productDto)
        {
            var result = _productService.Update(id, productDto);
            if (!result)
            {
                return NotFound("Product Not Found");
            }
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult DeleteById(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
                return NotFound("Product Not Found");

            _productService.Delete(id);
            return Ok("Product Deleted Successfully");
        }

    }
}

