using dtos.dto;
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
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProductById{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found" });
            }
            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public IActionResult Add([FromBody] ProductDTO productDTO)
        {
            _productService.Add(productDTO);
             return Ok("Product added successfully");
        }

        [HttpPut("UpdateProduct{id}")]
        public IActionResult Update(int id, ProductDTO productDto)
        {
            var result = _productService.UpdateById(id, productDto);
            if (!result)
                return NotFound("Product not found");

            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProduct{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
                return NotFound("Product not found");

            _productService.DeleteById(id);
            return Ok("Product Deleted Successfully");
        }
    }
}
