using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Playwright_Task
{
    public class Playwright_Task:PageTest
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
