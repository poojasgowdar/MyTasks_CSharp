using E_Commerce_Application.DataAccessLayer;
using E_Commerce_Application.Models;
using E_Commerce_Application.ServiceLayer;
using E_Commerce_Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productcontroller : ControllerBase
    {
        private readonly IProductService _productService;

        public Productcontroller(IProductService productService)
        {
            _productService = productService;
        }

        // 1. GET /api/products
        [HttpGet]
        public IActionResult GetAll([FromQuery] string name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = _productService.GetAll(name, page, pageSize);
            return Ok(products);
        }


        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetById(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        // POST: api/products
        [HttpPost]
        public IActionResult Add([FromBody] ProductCreateDto productDto)
        {
            try
            {
                var response = _productService.Add(productDto);
                return CreatedAtAction(nameof(GetById), new { id = response.Success }, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductUpdateDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest("Product ID mismatch.");

            try
            {
                var updatedProduct = _productService.UpdateById(productDto);
                return Ok(updatedProduct);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 5. DELETE /api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteById(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
