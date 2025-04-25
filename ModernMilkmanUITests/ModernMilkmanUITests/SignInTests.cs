using Microsoft.Playwright;
using System.Diagnostics.CodeAnalysis;

namespace ModernMilkmanUITests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SignInTests : PageTest
    {
        private const string BaseUrl = "https://gb-git-ctd-milkman.vercel.app/";

        [Test]
        public async Task ShouldAcceptCookies()
        {
            await Page.GotoAsync(BaseUrl);

            // Use ID selector for Accept Cookies
            var cookieButton = Page.Locator("#onetrust-accept-btn-handler");

            if (await cookieButton.IsVisibleAsync())
            {
                await cookieButton.ClickAsync();
                await Expect(cookieButton).Not.ToBeVisibleAsync();
            }
        }

        [Test]
        public async Task SignInImageClick_ShouldNavigateToLoginPage()
        {
            var context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1280, 
                    Height = 800
                }
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync(BaseUrl);

            var cookieButton = page.Locator("#onetrust-accept-btn-handler");
            if (await cookieButton.IsVisibleAsync())
            {
                await cookieButton.ClickAsync();
            }

            var anchor = page.Locator(".hidden .flex > .items-center > .pt-1").First;

            await anchor.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = 60000
            });

            // Use force click if necessary
            await anchor.ClickAsync(new LocatorClickOptions
            {
                Force = true
            });

            await page.WaitForURLAsync("**/login");
            StringAssert.AreEqualIgnoringCase("https://gb-git-ctd-milkman.vercel.app/login", page.Url);
        } 

        [Test]
        public async Task ShouldSignInWithValidCredentials()
        {
            await Page.GotoAsync(BaseUrl);
            //await Task.Delay(5000); 
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);


            // Accept cookies if visible
            var acceptButton = Page.Locator("#onetrust-accept-btn-handler");
            if (await acceptButton.IsVisibleAsync())
            {
                await acceptButton.ClickAsync();

                // Wait until the cookie overlay is hidden
                await Page.Locator("#onetrust-consent-sdk").WaitForAsync(new()
                {
                    State = WaitForSelectorState.Hidden
                });

                await Page.Locator(".onetrust-pc-dark-filter").WaitForAsync(new()
                {
                    State = WaitForSelectorState.Hidden
                });
            }

            // Click "Get started" link
            var getStartedLink = Page.GetByRole(AriaRole.Link, new() { Name = "Get started link" });
            await Expect(getStartedLink).ToBeVisibleAsync();
            await getStartedLink.ClickAsync();

            // Verify navigation to /login (don't wait for navigation event)
            await Expect(Page).ToHaveURLAsync(new Regex(".*/login"));
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Fill login form
            await Page.FillAsync("input[placeholder='e.g 07123456789']", "07755599123");
            await Page.FillAsync("input[id='password']", "Pooja@1234");

            // Click Login
            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await Expect(loginButton).ToBeVisibleAsync();
            await Expect(loginButton).ToBeEnabledAsync();
            await loginButton.ClickAsync();

            // Validate successful login (landed on /products)
            await Expect(Page).ToHaveURLAsync(new Regex(".*/products"));

            // Wait for heading "Our Products" to confirm page is loaded
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Our Products" })).ToBeVisibleAsync();

        }
    }
}







