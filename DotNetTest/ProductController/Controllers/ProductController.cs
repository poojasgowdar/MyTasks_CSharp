using Dto.Dtos;
using Entities.Models;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ProductController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService _productService;
        private readonly IMemoryCache _memoryCache;

        public ProductController(IService productService, IMemoryCache memoryCache)
        {
            _productService = productService;
            _memoryCache = memoryCache;
        }

        [HttpGet("GetProductById/{id}")]
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
