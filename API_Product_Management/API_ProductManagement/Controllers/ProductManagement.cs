using Dto.Dtos;
using Entities.Models;
using Interfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Service_Layer.Services;

namespace API_ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductManagement : ControllerBase
    {
        private readonly IService _productService;

        private static List<Product> _products = new List<Product>();

        private readonly IMemoryCache _cache;

        //public ProductManagement(IService productService)
        //{
        //    _productService = productService;
        //}


        public ProductManagement(IService productService, IMemoryCache cache)
        {
            _productService = productService;
            _cache = cache;
        }
        //public ProductManagement(IMemoryCache cache)
        //{
        //    _cache = cache;
        //}


        //[HttpGet("GetProductById")]
        //public IActionResult GetById(int id)
        //{
        //    try
        //    {
        //        var product = _productService.GetById(id);
        //        return Ok(product);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}


        // GET: api/products


        [HttpGet("GetProductById")]
        public IActionResult GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }



        //[HttpPost("CreateProduct")]
        //public IActionResult Add([FromBody] ProductCreateDto productDto)
        //{
        //    try
        //    {
        //        var response = _productService.Add(productDto);
        //        return CreatedAtAction(nameof(GetById), new { id = response.Success }, response);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var product = new Product
            {
                Id = _products.Count + 1,
                Name = productDto.Name,
                Price = productDto.Price,

            };

            _products.Add(product);


            _cache.Remove("productsList");

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


        //[HttpPut("UpdateProduct")]
        //public IActionResult Update(int id, [FromBody] ProductUpdateDto productDto)
        //{
        //    if (id != productDto.Id)
        //        return BadRequest("Product ID mismatch.");

        //    try
        //    {
        //        var updatedProduct = _productService.UpdateById(productDto);
        //        return Ok(updatedProduct);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // PUT: api/products/{id}
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            _cache.Remove("products");

            return NoContent();
        }

        //[HttpDelete("DeleteById")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        _productService.DeleteById(id);
        //        return NoContent();
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        //DELETE: api/products/{id}
        [HttpDelete("DeleteById")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            _products.Remove(product);
            _cache.Remove("products");

            return NoContent();
        }




    }
}
