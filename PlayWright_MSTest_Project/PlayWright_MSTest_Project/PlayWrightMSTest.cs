using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWright_MSTest_Project
{
    [TestClass]
    public class PlayWrightMSTest:PageTest
    {
        private const string BaseUrl = "https://localhost:7160/swagger/index.html";

        [TestMethod]
        public async Task GetAllProductsTest()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "GET /api/Product/GetAllProducts", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Try it out" }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Execute" }).ClickAsync();
        }

    
        [TestMethod]
        public async Task GetProductById()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "GET /api/Product/GetProducyById{id}", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Try it out" }).ClickAsync();
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "id" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "id" }).FillAsync("1");
            await Page.Locator("#operations-Product-get_api_Product_GetProducyById_id_").GetByRole(AriaRole.Button, new() { Name = "Execute" }).ClickAsync();
        }

        //[TestMethod]
        //public async Task CreateNewProduct()
        //{
        //    try
        //    {
        //        await Page.GotoAsync(BaseUrl);
        //        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        //        await Page.WaitForSelectorAsync("text=POST /api/Product/CreateProduct", new() { Timeout = 10000 });
        //        await Page.GetByRole(AriaRole.Button, new() { Name = "POST /api/Product/CreateProduct", Exact = true }).ClickAsync();

               
        //        await Page.WaitForSelectorAsync("text=Try it out", new() { Timeout = 10000 });
        //        await Page.GetByRole(AriaRole.Button, new() { Name = "Try it out" }).ClickAsync();

               
        //        await Page.WaitForSelectorAsync("textarea", new() { Timeout = 10000 });
        //        await Page.Locator("textarea").FillAsync("{ \"name\": \"Test Product\", \"price\": 100.50 }");

             
        //        await Page.WaitForSelectorAsync("text=Execute", new() { Timeout = 10000 });
        //        await Page.GetByRole(AriaRole.Button, new() { Name = "Execute" }).ClickAsync();

               
        //        var response = await Page.WaitForResponseAsync(resp => resp.Url.Contains("/api/Product/CreateProduct") && resp.Status == 200, new() { Timeout = 30000 });

               
        //        string responseBody = await response.TextAsync();
        //        Console.WriteLine($"API Response: {responseBody}");

            
        //        Assert.IsTrue(responseBody.Contains("Test Product"), "Product creation failed!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail($"Test failed due to: {ex.Message}");
        //    }
        //}

        [TestMethod]
        public async Task DeleteProduct()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.GetByRole(AriaRole.Button, new() { Name = "delete /api/Product/DeleteProductById", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Try it out" }).ClickAsync();
            await Page.GetByRole(AriaRole.Row, new() { Name = "id integer($int32) (query)", Exact = true }).GetByPlaceholder("id").ClickAsync();
            await Page.GetByRole(AriaRole.Row, new() { Name = "id integer($int32) (query)", Exact = true }).GetByPlaceholder("id").FillAsync("1");
            await Page.Locator("#operations-Product-delete_api_Product_DeleteProductById").GetByRole(AriaRole.Button, new() { Name = "Execute" }).ClickAsync();
        }

    }
}
