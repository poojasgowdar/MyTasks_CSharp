using Microsoft.Playwright;

namespace PlaywrightAPIEndpointsTesting
{
    [TestClass]
    public class PlaywrightAPITesting 
    {
        private static IPlaywright _playwright;
        private static IAPIRequestContext _api;

        [ClassInitialize]
        public static async Task Setup(TestContext context)
        {
            _playwright = await Playwright.CreateAsync();

            _api = await _playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://localhost:7175/swagger/index.html",
                IgnoreHTTPSErrors = true
            });
        }

        [ClassCleanup]
        public static async Task Cleanup()
        {
            await _api.DisposeAsync();
            _playwright.Dispose();
        }

        [TestMethod]
        public async Task GetAllProducts_Returns200()
        {
            var response = await _api.GetAsync("https://localhost:7175/api/Product/GetAllProducts"); 
            Assert.IsTrue(response.Ok, $"Expected status 200 OK, but got: {response.Status}");
        }

        [TestMethod]
        public async Task GetProductById_Returns200_WhenProductExists()
        {
            int id = 1; 
            var response = await _api.GetAsync("https://localhost:7175/api/Product/GetProductById1");
            Assert.IsTrue(response.Ok, $"Expected status 200 OK, but got: {response.Status}");
            var responseBody = await response.TextAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseBody), "Response body should not be empty.");
        }

        [TestMethod]
        public async Task CreateProduct_Returns201Created_WhenValidInput()
        {
            var productDto = new
            {
                Name = "Nike Air Max Shoes",
                Price = 99.99,
            };

            var response = await _api.PostAsync(
                "https://localhost:7175/api/Product/CreateProduct",
                new APIRequestContextOptions
                {
                    DataObject = productDto
                });

            Assert.AreEqual(201, response.Status, $"Expected status 201 Created, but got: {response.Status}");

            var responseBody = await response.JsonAsync();

            Assert.IsNotNull(responseBody);
            Assert.AreEqual(productDto.Name, responseBody?.GetProperty("name").ToString(), "Product name mismatch.");
        }

        [TestMethod]
        public async Task CreateBulkProducts_Returns201Created_WhenValidInput()
        {
            var productList = new[]
            {
                new
                {
                   Name = "HP Pavilion Laptop",
                   Price = 50.00
                },
                new
                {
                   Name = "Sony WH-1000XM5 Headphones",
                   Price = 75.00,   
                }
            };

            var response = await _api.PostAsync(
                "https://localhost:7175/api/Product/CreateBulkProducts",
                new APIRequestContextOptions
                {
                    DataObject = productList
                });

            Assert.AreEqual(201, response.Status, $"Expected status 201 Created, but got: {response.Status}");

            var responseBody = await response.JsonAsync();

            Assert.IsNotNull(responseBody, "Response body should not be null.");
            //Assert.IsTrue(responseBody.ValueKind == System.Text.Json.JsonValueKind.Array, "Expected response to be an array.");
            //Assert.IsTrue(responseBody.GetArrayLength() >= 2, "Expected at least 2 products to be created.");
           
        }

        [TestMethod]
        public async Task UpdateProductById_Returns200()
        {
            // Arrange: create a product first if needed, here we assume ID 1 exists
            var updatePayload = new
            {
                Name = "JBL Flip 6 Speaker",
                Price = 9999
            };

            // Act
            var response = await _api.PutAsync("https://localhost:7175/api/Product/UpdateProductById5", new()
            {
                DataObject = updatePayload
            });

            // Assert
            Assert.AreEqual(200, response.Status, $"Expected 200 OK, but got: {response.Status}");
            var responseBody = await response.TextAsync();
            Assert.IsTrue(responseBody.Contains("Product Updated Successfully"), "Update message not found in response.");
        }

        [TestMethod]
        public async Task DeleteProductById_Returns204()
        {
            // Arrange: Assume product with ID 1 exists

            // Act
            var response = await _api.DeleteAsync("https://localhost:7175/api/Product/DeleteById4");

            // Assert
            Assert.AreEqual(204, response.Status, $"Expected 204 No Content, but got: {response.Status}");

        }

    }
}
    

