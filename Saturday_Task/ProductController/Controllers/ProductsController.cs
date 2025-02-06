using Dtos.Dto;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace ProductController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IService _productService;

        public ProductsController(IService productService)
        {
            _productService = productService;
        }

     
        [HttpPost("CreateNewProduct")]
        public IActionResult CreateProduct([FromBody] CreateProductDto request)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price
                };

                _productService.Add(product, request.CategoryIds);

                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, request);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        [HttpGet("GetProductById{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("UpdateProductById{id}")]
        public IActionResult UpdateProductById(int id,ProductCreate product)
        {
            if (product == null)
            {
                return BadRequest(new { message = "Product data is null" });
            }
            try
            {
                var response = _productService.UpdateProductById(id, product);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("DeleteProductById")]
        public IActionResult DeleteProductById(int id)
        {
            try
            {
                var product = _productService.DeleteProductById(id);
                return Ok(product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
