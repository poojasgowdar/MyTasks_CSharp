using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMilkmanUIPlaywrightTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CombinedSignInTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private const string BaseUrl = "https://gb-git-ctd-milkman.vercel.app/";

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = false });
            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1280, Height = 800 }
            });
            _page = await _context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _context.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [Test]
        public async Task CompleteSignInFlow_WithValidCredentials()
        {
            await _page.GotoAsync(BaseUrl);

            // Accept cookies if visible using helper
            await AcceptCookiesIfVisibleAsync();

            // Wait for overlay to disappear
            await WaitForCookieOverlayToDisappearAsync();

            // Start sign-in flow
            var getStartedLink = _page.GetByRole(AriaRole.Link, new() { Name = "Get started link" });
            Assert.IsTrue(await getStartedLink.IsVisibleAsync(), "Get started link not visible");
            await getStartedLink.ClickAsync();

            await _page.WaitForURLAsync("**/login", new() { Timeout = 60000 });

            await _page.FillAsync("input[placeholder='e.g 07123456789']", "07755599128");
            await _page.FillAsync("input[id='password']", "Clarke@123");

            // Wait again for overlay before login
            await WaitForCookieOverlayToDisappearAsync();

            var loginBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            Assert.IsTrue(await loginBtn.IsVisibleAsync(), "Login button not visible");
            Assert.IsTrue(await loginBtn.IsEnabledAsync(), "Login button not enabled");
            await loginBtn.ClickAsync();

            await _page.WaitForURLAsync("**/products", new() { Timeout = 60000 });

            var heading = _page.GetByRole(AriaRole.Heading, new() { Name = "Our Products" });
            await heading.WaitForAsync(new() { Timeout = 60000 });
            Assert.IsTrue(await heading.IsVisibleAsync(), "Heading 'Our Products' not visible");
        }

        // Reusable helper for accepting cookies
        private async Task AcceptCookiesIfVisibleAsync()
        {
            var cookieButton = _page.GetByRole(AriaRole.Button, new() { Name = "Accept All Cookies" });

            try
            {
                await cookieButton.WaitForAsync(new LocatorWaitForOptions
                {
                    Timeout = 5000,
                    State = WaitForSelectorState.Visible
                });

                await cookieButton.ClickAsync();
                Console.WriteLine("Accepted cookies.");
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Cookie popup did not appear within the timeout. Skipping cookie acceptance.");
            }
        }

        // Reusable helper to wait for overlay to disappear
        private async Task WaitForCookieOverlayToDisappearAsync()
        {
            var overlay = _page.Locator(".onetrust-pc-dark-filter");

            if (await overlay.IsVisibleAsync())
            {
                Console.WriteLine("Waiting for cookie overlay to disappear...");
                await overlay.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Hidden,
                    Timeout = 60000
                });
                Console.WriteLine("Overlay gone.");
            }
            else
            {
                Console.WriteLine("No cookie overlay found. Continuing...");
            }
        }

    }
}
