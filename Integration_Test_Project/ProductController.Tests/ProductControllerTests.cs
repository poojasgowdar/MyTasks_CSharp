using DAL.Data;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ProductController.Tests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;
        public ProductControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Remove existing database context
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    if (descriptor != null)
                        services.Remove(descriptor);

                    // Add new in-memory database
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseInMemoryDatabase("TestDb"));

                    // Seed database
                    using (var scope = services.BuildServiceProvider().CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                        dbContext.Database.EnsureDeleted(); // Clear old data
                        dbContext.Database.EnsureCreated(); // Create fresh in-memory DB

                        // Seed products
                        dbContext.Products.Add(new Product
                        {
                            Id = 1,
                            Name = "Bluetooth",
                            Price = 500
                        });

                        dbContext.Products.Add(new Product
                        {
                            Id = 2,
                            Name = "Laptop",
                            Price = 1000
                        });

                        dbContext.SaveChanges(); // Save seeded data
                    }
                });
            });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProducts_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/Product/GetAllProducts");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetById_ReturnsCorrectProduct()
        {
            var response = await _client.GetAsync("/api/Product/GetProductsById/1");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(content);

            Assert.Equal("Bluetooth", product.Name);  
        }

        [Fact]
        public async Task AddProduct_ReturnsCreated()
        {
            var newProduct = new ProductDTO { Name = "Bluetooth", Price = 500 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Product/CreateNewProduct", jsonContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateProduct_ReturnsUpdated()
        {
            var updateProduct = new ProductDTO { Name = "Updated Laptop", Price = 1400 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateProduct), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/Product/UpdateProductById1", jsonContent);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteProduct_ReturnsSuccess()
        {
            var response = await _client.DeleteAsync("/api/Product/DeleteProductById1");
            response.EnsureSuccessStatusCode();
        }

    }
}
