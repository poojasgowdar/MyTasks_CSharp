using Dtos.dto;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

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

        [HttpGet("GetProductById{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetById(id);
                if (product == null)
                {
                    return NotFound(new { message = $"Product with ID {id} not found." });
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("CreateNewProduct")]
        public IActionResult Add([FromBody] ProductCreateDto productDto)
        {
            try
            {
                var response = _productService.Add(productDto);
                if (response.Success)
                {
                    return CreatedAtAction(nameof(GetById), new { id = response.Message }, response);
                    
                }
                return BadRequest(new { message = response.Message });

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
      

    }
}
