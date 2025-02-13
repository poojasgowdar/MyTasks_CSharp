using Dtos.Dto;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductController.Helpers;

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
        [BasicAuthorization]
        public IActionResult GetAll([FromQuery] string name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = _productService.GetAllProducts(name, page, pageSize);
            return Ok(products);
        }
       
        [HttpGet("GetProductById")]
        [BasicAuthorization]
        public IActionResult GetProductById(int id)
        {
            var products = _productService.GetProductsById(id);
            if (products == null)
            {
                return NotFound(new { Message = "$Product with Id {id} not Found" });
            }
            return Ok(products);
        }

        [HttpPost("CreateNewProduct")]
        [BasicAuthorization]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            _productService.Add(productDto);
            return Ok("Product Created Successfully");
        }

        [HttpPost("CreateBulkProducts")]
        [BasicAuthorization]
        public IActionResult AddBulk([FromBody] List<ProductDTO> productDtos)
        {

            _productService.AddBulk(productDtos);
            return Ok("Bulk Products added successfully");
        }

        [HttpPut("UpdateProductById{id}")]
        [BasicAuthorization]
        public IActionResult Update(int id, [FromBody] ProductDTO productDto)
        {
           var result = _productService.UpdateById(id, productDto);
            if (!result)
            {
                return NotFound("Product Not Found");
            }
            return Ok(new { Message = "Product Updated Successfully" });
        }

        [HttpDelete("DeleteProductById")]
        [BasicAuthorization]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetProductsById(id);
            if (existingProduct == null)
                return NotFound("Product Not Found");

            _productService.DeleteById(id);
            return Ok("Product Deleted Successfully");
        }

        [HttpDelete("DeleteBulkProducts")]
        [BasicAuthorization]
        public IActionResult DeleteBulk([FromBody] List<int> ids)
        {
            bool isDeleted = _productService.DeleteBulk(ids);
            if (!isDeleted)
                return NotFound(new { Message = "No matching products found for deletion." });
            return Ok("Products deleted successfully.");
        }


    }
}
