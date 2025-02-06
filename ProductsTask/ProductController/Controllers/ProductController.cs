using Azure;
using Dtos.Dto;
using Entities.Models;
using Filter.Filters;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Caching.Memory;
using Services.ServiceLayer;


namespace ProductController.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IService _productService;

        public ProductController(IMemoryCache memoryCache, IService productService)
        {
            _memoryCache = memoryCache;
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var cacheKey = "productList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Product> products))
            {
                products = _productService.GetAll().ToList();
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };
                _memoryCache.Set(cacheKey, products, cacheOptions);
            }
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
              if (!_memoryCache.TryGetValue($"Product_{id}", out var product))
                {
                   product = _productService.GetById(id);
                    if (product == null)
                    {
                        return NotFound(new { message = $"Product with ID {id} not found." });
                    }
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromMinutes(30)) 
                   .SetAbsoluteExpiration(TimeSpan.FromHours(6)); 
                   _memoryCache.Set($"Product_{id}", product, cacheEntryOptions);
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
            if (productDto == null)
            {
                return BadRequest(new { message = "Product data is null." });
            }

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


        [HttpPut("UpdateProductById/{id}")]
        public IActionResult UpdateById(int id, [FromBody] ProductUpdateDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(new { message = "Product data is null." });
            }
            try
            {
                var response = _productService.UpdateById(id, productDto);
                if (response.Success)
                {
                    return Ok(response);
                }
                return NotFound(new { message = response.Message });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



        // DELETE api/products/5
        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                var response = _productService.DeleteById(id);
                if (response.Success)
                {
                    return Ok(response);
                }
                return NotFound(new { message = response.Message });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
