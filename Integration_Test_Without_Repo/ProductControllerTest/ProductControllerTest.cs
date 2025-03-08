using DTOs.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductControllerTest
{
    public class ProductControllerTest:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public ProductControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    if (descriptor != null) services.Remove(descriptor);

                    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));

                    using (var scope = services.BuildServiceProvider().CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();

                        dbContext.Products.Add(new Product { Id = 1, Name = "Bluetooth", Price = 500 });
                        dbContext.Products.Add(new Product { Id = 2, Name = "Laptop", Price = 1000 });
                        dbContext.SaveChanges();    
                    }
                });
            });

            _client = _factory.CreateClient();
        }

        [Fact]
        public void GetAllProducts_ReturnsSuccess()
        {
            var response = _client.GetAsync("/api/Product/GetAllProducts").Result;
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public void GetById_ReturnsCorrectProduct()
        {
            var response = _client.GetAsync("/api/Product/GetProductById/1").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<Product>(content);
            Assert.NotNull(product);
            Assert.Equal("Bluetooth", product.Name);
        }

        [Fact]
        public void AddProduct_ReturnsCreated()
        {
            var newProduct = new Product { Name = "Tablet", Price = 300 };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/Product/CreateNewProduct", jsonContent).Result;
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public void AddProduct_Correct()
        {
            var newProduct=new Product { Name="Tablet"}
        }

        [Fact]
        public void UpdateProduct_ReturnsUpdated()
        {
            var updatedProduct = new Product
            {
                Id = 1,
                Name = "Wireless Bluetooth",
                Price = 600
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedProduct), Encoding.UTF8, "application/json");
            var response = _client.PutAsync("/api/Product/UpdateProductById/1", jsonContent).Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getResponse = _client.GetAsync("/api/Product/GetProductById/1").Result;
            var content = getResponse.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<Product>(content);
            Assert.NotNull(product);
            Assert.Equal("Wireless Bluetooth", product.Name);
            Assert.Equal(600, product.Price);
        }

        [Fact]
        public void DeleteProduct_ReturnsNoContent()
        {
            var response = _client.DeleteAsync("/api/Product/DeleteProductById/1").Result;
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var getResponse = _client.GetAsync("/api/Product/GetProductById/1").Result;
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode); 
        }

        [Fact]
        public void Delete_ReturnsNoContent()
        {
            var response = _client.DeleteAsync("/api/Product/DeleteProductById/1").Result;
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            var getResponse = _client.GetAsync("/api/Product/GetProductByID/1").Result;
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);

            var response = _client.DeleteAsync("/api/Product/DeleteProductById/1").Result;
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
            var response = _client.GetAsync("/api/Product/GetProductByID/1").Result;

        }

    }
}
