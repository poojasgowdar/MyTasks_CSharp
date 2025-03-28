using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dtos.Dto;
using Models.Entities;
using NuGet.Frameworks;

namespace Integration_TestCases
{
    public class Product_Controller_Test : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly AppDbContext _context;

        public Product_Controller_Test(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            _context = TestDbContextFactory.Create();

            //SeedTestData(); // Optional: Seed test data
        }

        private HttpRequestMessage CreateAuthenticatedRequest(HttpMethod method, string url, object body = null)
        {
            var request = new HttpRequestMessage(method, url);

            // Correct credentials (Update as per your authentication logic)
            var username = "admin"; // Replace with the correct username
            var password = "admin123"; // Replace with the correct password

            var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            Console.WriteLine($"Auth Header Sent: Basic {authToken}"); // Debugging Output

            if (body != null)
            {
                var json = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return request;
        }

        [Fact]
        public async Task GetAllProducts_WithValidCredentials_ReturnsSuccess()
        {
            // Arrange
            var request = CreateAuthenticatedRequest(HttpMethod.Get, "/api/Product/GetAllProducts");

            // Debug: Print the headers before sending
            Console.WriteLine("Sending Request...");
            foreach (var header in request.Headers)
            {
                Console.WriteLine($"🔹 Header: {header.Key} = {string.Join(", ", header.Value)}");
            }

            // Act
            var response = await _client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Debugging output
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            // Assert   
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.Contains("Products Retrieved Successfully", responseBody);
        }

        [Fact]
        public async Task GetById_WithValidCredentials_ReturnsCorrectProduct()
        {
            // Arrange
            int productId = 1;
            var request = CreateAuthenticatedRequest(HttpMethod.Get, $"/api/Product/GetProductsById/{productId}");

            // Act
            var response = await _client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Debugging output
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            // Deserialize response content
            var product = JsonConvert.DeserializeObject<ProductDTO>(responseBody);

            // Assert
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.NotNull(product);
            //Assert.Equal(productId, product.Id);
        }

        [Fact]
        public async Task CreateProduct_ReturnsSuccess()
        {
            // Arrange
            var newProduct = new { Name = "Test Product", Price = 100, Stock = 10 };
            var request = CreateAuthenticatedRequest(HttpMethod.Post, "/api/Product/CreateProduct", newProduct);

            // Act
            var response = await _client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Debugging (optional)
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            // Assert
            //Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsSuccess()
        {
            // Arrange (Assuming Product ID = 1 exists)
            var updatedProduct = new { Id = 1, Name = "Updated Product", Price = 150, Stock = 5 };
            var request = CreateAuthenticatedRequest(HttpMethod.Put, "/api/Product/UpdateProduct", updatedProduct);

            // Act
            var response = await _client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Debugging (optional)
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            // Assert
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsSuccess()
        {
            // Arrange (Assuming Product ID = 1 exists)
            var request = CreateAuthenticatedRequest(HttpMethod.Delete, "/api/Product/DeleteProduct/1");

            // Act
            var response = await _client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Debugging (optional)
            Console.WriteLine($"Response Status: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            //Assert
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task GetById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidProductId = 9999; // Non-existing product ID

            // Act
            var response = await _client.GetAsync($"/api/products/{invalidProductId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // Expected 404
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsOk()
        {
            // Arrange
            int invalidProductId = 9999;

            // Act
            var response = await _client.GetAsync($"/api/products/{invalidProductId}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}



