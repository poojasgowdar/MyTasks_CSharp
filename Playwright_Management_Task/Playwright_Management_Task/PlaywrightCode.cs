using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Management_Task
{
    public class PlaywrightCode:PageTest
    {
        private string baseUrl = "https://localhost:7057/swagger/index.html";
        [Test]
        public async Task GetProductById()
        {
            await Page.GotoAsync(baseUrl);
            //Click on the GET endpoint
            await Page.GetByRole(AriaRole.Button, new() { Name = "GET /api/Product/{id}", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Try it out" }).ClickAsync();

            //Enter ID and execute
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "id" }).ClickAsync();
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "id" }).FillAsync("1");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Execute" }).ClickAsync();

            //ValidateResponse
            await Page.Locator("#swagger-ui div").Filter(new() { HasText = "Product GET/api/ProductGET/" }).Nth(2).ClickAsync();
        }

        [Test]
        public async Task CreateSingleProduct()
        {
            await Page.GotoAsync(baseUrl);
            //Click on the GET endpoint
            await Page.GetByRole(AriaRole.Button, new() { Name = "post /api/Product/CreateSingleProduct", Exact = true }).ClickAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Try it out" }).ClickAsync();

            //Fill the Request Body
            await Expect(Page.GetByRole(AriaRole.Textbox)).ToContainTextAsync("{ \"name\": \"Oppo\", \"description\": \"Good Camera\", \"price\": 80000, \"stockQuantity\": 67}");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Execute" }).ClickAsync();

        }
    }
}
