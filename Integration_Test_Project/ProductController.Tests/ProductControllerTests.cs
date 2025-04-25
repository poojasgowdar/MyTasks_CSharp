using DAL.Data;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit;

namespace ProductController.Tests
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        public ProductControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProducts_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/Product/GetAllProducts");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ReturnsCorrectProduct()
        {
            var response = await _client.GetAsync("/api/Product/GetProductsById/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(content);

            Assert.Equal("Bluetooth", product.Name);
            Assert.Equal(500, product.Price);
        }

        [Fact]
        public async Task AddProduct_ReturnsCreated()
        {
            var newProduct = new ProductDTO { Name = "Bluetooth", Price = 500 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Product/CreateNewProduct", jsonContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTestItem_ReturnsUpdated()
        {
            var updateProduct = new ProductDTO { Name = "LenovoLaptop", Price = 1000 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateProduct), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Product/UpdateProductById/1", jsonContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Verify update
            var getResponse = await _client.GetAsync("/api/Product/GetProductsById/1");
            var content = await getResponse.Content.ReadAsStringAsync();
            var updatedProduct = JsonConvert.DeserializeObject<ProductDTO>(content);

            Assert.Equal("LenovoLaptop", updatedProduct.Name);
            Assert.Equal(1000, updatedProduct.Price);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsSuccess()
        {
            // Check if the product exists before deleting
            var getResponse = await _client.GetAsync("/api/Product/GetProductsById/1");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            // Delete the product
            var response = await _client.DeleteAsync("/api/Product/DeleteProductById/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Verify product no longer exists
            var deletedResponse = await _client.GetAsync("/api/Product/GetProductsById/1");
            Assert.Equal(HttpStatusCode.NotFound, deletedResponse.StatusCode);
        }
    }
}
