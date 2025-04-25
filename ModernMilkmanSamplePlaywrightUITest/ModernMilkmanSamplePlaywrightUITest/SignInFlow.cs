using Microsoft.Playwright;
using Newtonsoft.Json;

namespace ModernMilkmanSamplePlaywrightUITest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SignInFlow
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;   
        private IPage _page;
        private const string BaseUrl = "https://gb-git-ctd-milkman.vercel.app/";

        [SetUp]
        public async Task SetUp()
        {
            var config = JsonConvert.DeserializeObject<BrowserConfig>(File.ReadAllText("playwright.settings.json"));

            int timeout = config.Timeout;

            // Initialize Playwright
            _playwright = await Playwright.CreateAsync();

            // Use a switch statement to launch the browser based on the config
            switch (config.Browser.ToLower())
            {
                case "chromium":
                    _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = config.Headless, // Use the headless flag from config
                        Timeout = timeout // Set the timeout value
                    });
                    break;

                case "msedge":
                    _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Channel = "msedge",  // Specify the Edge browser channel
                        Headless = config.Headless,
                        Timeout = timeout // Set the timeout value
                    });
                    break;

                case "chrome":
                    _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Channel = "chrome",  // Specify the Chrome browser channel
                        Headless = config.Headless,
                        Timeout = timeout // Set the timeout value
                    });
                    break;

                default:
                    throw new Exception($"Browser configuration '{config.Browser}' not recognized.");
            }

            //_playwright = await Playwright.CreateAsync();
            //_browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            //{
            //    Channel = "msedge", // This specifies the Microsoft Edge browser
            //    Headless = false
            //});
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
        public async Task CompleteSignInFlow_ForRepeatOrder()
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

            await _page.FillAsync("input[placeholder='e.g 07123456789']", "07755591266");
            await _page.FillAsync("input[id='password']", "Smith@123");

            // Wait again for overlay before login
            await WaitForCookieOverlayToDisappearAsync();

            var loginBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            Assert.IsTrue(await loginBtn.IsVisibleAsync(), "Login button not visible");
            Assert.IsTrue(await loginBtn.IsEnabledAsync(), "Login button not enabled");
            await loginBtn.ClickAsync();

            // Wait for URL change, adjust this to the actual post-login URL
            await _page.WaitForURLAsync("https://gb-git-ctd-milkman.vercel.app/", new() { Timeout = 60000 });

            // Now automatically click on the "Our products" link after login
            var ourProductsLink = _page.GetByRole(AriaRole.Link, new() { Name = "Our products" });
            Assert.IsTrue(await ourProductsLink.IsVisibleAsync(), "'Our products' link not visible");
            await ourProductsLink.ClickAsync();

            // Wait for navigation to /products
            await _page.WaitForURLAsync("**/products", new() { Timeout = 60000 });

            var heading = _page.GetByRole(AriaRole.Heading, new() { Name = "Our Products" });
            await heading.WaitForAsync(new() { Timeout = 60000 });
            Assert.IsTrue(await heading.IsVisibleAsync(), "Heading 'Our Products' not visible");

            // Interact with products
            await _page.GetByRole(AriaRole.Listitem)
                       .Filter(new() { HasText = "Freshly Squeezed Orange Juice£2.60 / pint" })
                       .GetByRole(AriaRole.Button, new() { Name = "Add" })
                       .ClickAsync();
            await _page.WaitForTimeoutAsync(1000);

            // Click the "Repeat Order" section
            await _page.GetByRole(AriaRole.Radio, new() { Name = "Repeat Order" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "+" }).First.ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "+" }).Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "+" }).Nth(2).ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = "Add to Basket" }).ClickAsync();

            var continueShoppingButton = _page.GetByRole(AriaRole.Button, new() { Name = "Continue shopping" });

            // Ensure it is visible before clicking
            Assert.IsTrue(await continueShoppingButton.IsVisibleAsync(), "'Continue shopping' button is not visible");

            // Click the button
            await continueShoppingButton.ClickAsync();

            // Wait for the redirection to the products page
            await _page.WaitForURLAsync("**/products", new() { Timeout = 10000 });

            // Optionally verify that the products page loaded by checking for a heading or product list
            var productsHeading = _page.GetByRole(AriaRole.Heading, new() { Name = "Our Products" });
            Assert.IsTrue(await productsHeading.IsVisibleAsync(), "User was not redirected to the products page after clicking 'Continue shopping'");

            await _page.GetByRole(AriaRole.Listitem)
                     .Filter(new() { HasText = "Sanetra Sourdough" })
                     .GetByRole(AriaRole.Button, new() { Name = "Add" })
                     .ClickAsync();
            await _page.WaitForTimeoutAsync(1000);

           // Click on "One Time Order" radio button
            await _page.GetByRole(AriaRole.Radio, new() { Name = "One Time Order" }).ClickAsync();

            // Optionally, verify that it is checked
            var radioButton = _page.GetByRole(AriaRole.Radio, new() { Name = "One Time Order" });
            Assert.True(await radioButton.IsCheckedAsync(), "One Time Order radio button should be selected.");

            await _page.GetByRole(AriaRole.Button, new() { Name = "+" }).First.ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add to Basket" }).ClickAsync();

            // Click "Go to your Basket" button
            var goToBasketButton = _page.Locator("button.w-full.button.lg.primary");
            Assert.IsTrue(await goToBasketButton.IsVisibleAsync(), "'Go to your Basket' button not visible");
            await goToBasketButton.ClickAsync();

            // Wait for redirection to basket page
            await _page.WaitForURLAsync("https://gb-git-ctd-milkman.vercel.app/basket", new() { Timeout = 60000 });

            // Wait for and click "Continue to delivery" link
            await _page.WaitForSelectorAsync("a[href='/basket/delivery-details']", new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            var continueToDeliveryButton = _page.Locator("a[href='/basket/delivery-details']");
            Assert.IsTrue(await continueToDeliveryButton.IsVisibleAsync(), "'Continue to delivery' link not visible");
            await continueToDeliveryButton.ClickAsync();

            // Wait for redirection to delivery details page
            await _page.WaitForURLAsync("https://gb-git-ctd-milkman.vercel.app/basket/delivery-details", new() { Timeout = 60000 });

            // Wait for and click "Checkout securely" button
            await _page.WaitForSelectorAsync("button[type='submit']", new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            var checkoutButton = _page.Locator("button[type='submit']");
            Assert.IsTrue(await checkoutButton.IsVisibleAsync(), "'Checkout securely' button not visible");
            await checkoutButton.ClickAsync();

            // Wait for redirection to checkout page
            await _page.WaitForURLAsync("https://gb-git-ctd-milkman.vercel.app/checkout", new() { Timeout = 60000 });
            // Locate the actual iframe element as a Locator
            var iframeLocator = _page.Locator("iframe[name^='__privateStripeFrame']").First;
            var iframeElementHandle = await iframeLocator.ElementHandleAsync();
            var stripeFrame = await iframeElementHandle.ContentFrameAsync();

            if (stripeFrame == null)
                throw new Exception("Stripe iframe not loaded");

            var cardInput = stripeFrame.Locator("input[name='number']");
            await cardInput.ClickAsync();

            foreach (char digit in "6011111111111117")
            {
                await _page.Keyboard.PressAsync(digit.ToString());
                await Task.Delay(100);
            }

            // Wait for the iframe that contains the card details
            var iframeElement = _page.FrameLocator("iframe[name^='__privateStripeFrame']").First;
            await iframeElement.Locator("input[name='expiry']").WaitForAsync(new() { Timeout = 10000 });

            // Enter Expiry Date: 05/25
            var expiryField = iframeElement.Locator("input[name='expiry']");
            await expiryField.ClickAsync();
            await expiryField.FillAsync("05 / 25");
            var expiryValue = await expiryField.InputValueAsync();

            // Trim spaces or ensure no spaces before comparing
            Assert.AreEqual("05 / 25", expiryValue.Replace(" ", " "));

            var iframeElements = _page.FrameLocator("iframe[name^='__privateStripeFrame']").First;
            await iframeElement.Locator("input[name='cvc']").WaitForAsync(new() { Timeout = 10000 });

            // Enter CVC: 123
            var cvcField = iframeElements.Locator("input[name='cvc']");
            await cvcField.ClickAsync();  // Ensure the field is focused
            await cvcField.FillAsync("123");  // Fill the CVC value
            var cvcValue = await cvcField.InputValueAsync();  //Get the unified

            // Assert that the value is as expected
            Assert.AreEqual("123", cvcValue);

            // Click the Pay button
            // Locate the Pay button and wait for it to appear
            var payButton = _page.Locator("button:has-text('Pay £15.59')");
            await payButton.WaitForAsync(new() { Timeout = 60000 }); // Wait for 60 seconds
            await payButton.ClickAsync();

            // Wait for payment confirmation text to appear
            var processingText = _page.GetByText("Payment is Processing!We are");
            await processingText.WaitForAsync(new() { Timeout = 60000 });

            // Wait for the Thank You message (confirmation of order)
            var thankYouLocator = _page.Locator("div").Filter(new() { HasText = "Thank you!Your order has been" }).First;
            await thankYouLocator.WaitForAsync(new() { Timeout = 60000 });
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

    public class BrowserConfig
    {
        public string Browser { get; set; }
        public bool Headless { get; set; }
        public int Timeout { get; set; } // Timeout should be an int, not string

    }
}
