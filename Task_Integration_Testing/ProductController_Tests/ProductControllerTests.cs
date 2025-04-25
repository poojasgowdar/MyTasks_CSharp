using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductController_Tests
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
        public async Task GetAllProducts_ReturnsNotFound_WhenRouteIsIncorrect()
        {
            var response = await _client.GetAsync("/api/Product/GetAllProduct");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
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
        public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Assuming product with ID 9999 doesn't exist
            var response = await _client.GetAsync("/api/Product/GetProductsById/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Fact]
        public async Task GetById_ReturnsBadRequest_WhenIdIsInvalid()
        {
            var response = await _client.GetAsync("/api/Product/GetProductsById/0");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ReturnsBadRequest_WhenIdIsNonNumeric()
        {
            var response = await _client.GetAsync("/api/Product/GetProductsById/abc");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddProduct_ReturnsCreated()
        {
            var newProduct = new ProductDTO { Id =1, Name = "Bluetooth", Price = 500 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Product/CreateNewProduct", jsonContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task AddProduct_ReturnsBadRequest_WhenNameIsMissing()
        {
            var invalidProduct = new ProductDTO { Id = 2, Name = null, Price = 700 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(invalidProduct), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Product/CreateNewProduct", jsonContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTestItem_ReturnsUpdated()
        {
            var updateProduct = new ProductDTO { Id = 1,Name = "LenovoLaptop", Price = 1000 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateProduct), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Product/UpdateProductById/1", jsonContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var getResponse = await _client.GetAsync("/api/Product/GetProductsById/1");
            var content = await getResponse.Content.ReadAsStringAsync();
            var updatedProduct = JsonConvert.DeserializeObject<ProductDTO>(content);

            Assert.Equal("LenovoLaptop", updatedProduct.Name);
            Assert.Equal(1000, updatedProduct.Price);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsSuccess()
        {
            var getResponse = await _client.GetAsync("/api/Product/GetProductsById/1");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var response = await _client.DeleteAsync("/api/Product/DeleteProductById/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var deletedResponse = await _client.GetAsync("/api/Product/GetProductsById/1");
            Assert.Equal(HttpStatusCode.NotFound, deletedResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            var response = await _client.DeleteAsync("/api/Product/DeleteProductById/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}

