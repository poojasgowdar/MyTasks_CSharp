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
        public IActionResult GetAll([FromQuery] string name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = _productService.GetAllProducts(name, page, pageSize);
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

        [HttpPost("CreateBulkProducts")]
        public IActionResult AddBulk([FromBody] List<ProductDTO> productDtos)
        {

            _productService.AddBulk(productDtos);
            return Ok("Bulk Products added successfully");
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
        [HttpDelete("DeleteBulkProducts")]
        public IActionResult DeleteBulk([FromBody] List<int> ids)
        {
            bool isDeleted =_productService.DeleteBulkProducts(ids);
            if (!isDeleted)
                return NotFound(new { Message = "No matching products found for deletion." });
            return Ok("Products deleted successfully.");
        }


    }
}
