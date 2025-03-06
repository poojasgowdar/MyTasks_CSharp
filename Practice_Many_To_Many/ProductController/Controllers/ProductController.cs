using DTOs.Dto;
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

        [HttpGet("GetProductById{id}")]
        public IActionResult GetProductById(int id)
        {
            var student = _productService.GetById(id);
            if (student == null)
                return NotFound(new { Message = "Product Not Found" });

            return Ok(student);
        }

        [HttpPost("CreateNewProduct")]
        public IActionResult AddProduct([FromBody] ProductDTO productDto)
        {
            if (productDto == null || productDto.CategoryIds == null || !productDto.CategoryIds.Any())
            {
                return NotFound(new { Message = "Product data or category IDs are missing." });
            }

            _productService.Add(productDto, productDto.CategoryIds);
            return Ok(new { Message = "Product Created Successfully" });
        }


        [HttpPut("UpdateById{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDto)
        {
            var result = _productService.Update(id, productDto);
            if (!result)
                return NotFound(new { Message = "Product Not Found" });
            return Ok(new { Message = "Product Updated Successfully" });
        }
        [HttpDelete("DeleteById{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return Ok(new { Message = "Product Not Found" });
            }
            _productService.Delete(id);
            return Ok(new { Message = "Product Deleted Successfully" });
        }
    }
}
