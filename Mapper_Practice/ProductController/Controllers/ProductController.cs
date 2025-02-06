using Dtos.Dto;
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
            var products = _productService.GetById(id);
            if (products == null)
            {
                return NotFound(new { Message = "Product Not Found" });
            }
            return Ok(products);
        }

        [HttpPost("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            _productService.Add(productDto);
            return Ok("Product Created Successfully");
        }

        [HttpPut("UpdateProductById{id}")]
        public IActionResult Update(int id,ProductDTO productDto)
        {
            var result = _productService.UpdatebyId(id, productDto);
            if (!result)
                return Ok("Product Not Found");
            return Ok("Product Updated Successfully");
        }
        [HttpDelete("DeleteById{id}")]
        public IActionResult DeleteById(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound(new { Message = "Product Not Found" });
            }
            return Ok("Product Deleted Successfully");
        }

    }
}
