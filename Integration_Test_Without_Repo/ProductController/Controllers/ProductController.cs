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
        public ProductController(IService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(new { Message = "Product Not Found" });
            }
            return Ok(product);
        }

        [HttpPost("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            var createdProduct = _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(Add), new { id = createdProduct.Id }, createdProduct);
        }
        [HttpPut("UpdateProductById/{id}")]
        public IActionResult Update(int id,ProductDTO productDto)
        {
            var result = _productService.UpdateProduct(id, productDto);
            if (!result)
            {
                return NotFound("Employee Not Found");
            }
            return Ok("Employee Updated Successfully");
        }

        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound("Product Not Found");

            _productService.DeleteById(id); 
            return NoContent(); 
        }
    }
}
