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
        public IActionResult GetById(int id)
        {
            var products = _productService.GetProductById(id);
            if (products == null)
            {
                return NotFound(new{ Message = "Product Not Found"});
            }
            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            var createdProduct = _productService.Add(productDto);
            if (createdProduct == null)
            {
                return BadRequest("Product could not be created.");
            }
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPost("CreateBulkProducts")]
        public IActionResult AddBulk([FromBody] List<ProductDTO> productDtos)
        {
            var createdProducts = _productService.AddBulk(productDtos);
            if (createdProducts == null || !createdProducts.Any())
            {
                return BadRequest("Products could not be created.");
            }
            return Created("", createdProducts); 
        }

        [HttpPut("UpdateProductById{id}")]
        public IActionResult Add(int id,[FromBody] ProductDTO productDto)
        {
            var result = _productService.UpdateById(id, productDto);
            if (!result)
            {
                return NotFound("Product Not Found");
            }
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteById{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetProductById(id);
            if(existingProduct==null)
                return NotFound("Product Not Found");
            _productService.DeleteById(id);
            return NoContent();
        }
    }
}
