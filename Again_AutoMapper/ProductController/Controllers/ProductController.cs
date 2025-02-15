﻿using dtos.Dto;
using Interfaces.Interface;
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
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("GetProductsById{id}")]
        [BasicAuthorization]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound(new { Message = "Product Not Found" });
            }
            return Ok(product);
        }

        [HttpPost("CreateNewProduct")]
        [BasicAuthorization]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            _productService.Add(productDto);
            return Ok(productDto);
        }

        [HttpPut("UpdateProductById{id}")]
        [BasicAuthorization]
        public IActionResult Update(int id, ProductDTO productDto)
        {
            var result = _productService.UpdateById(id, productDto);
            if (!result)
            {
                return NotFound("Product Not Found");
            }
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("DeleteProductById{id}")]
        [BasicAuthorization]
        public IActionResult DeleteById(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
                return NotFound("Product Not Found");

            _productService.DeleteById(id);
            return Ok("Product Deleted Successfully");
        }
    }
}
