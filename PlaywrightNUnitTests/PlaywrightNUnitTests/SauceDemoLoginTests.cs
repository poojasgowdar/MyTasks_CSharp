using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNUnitTests
{
    public class SauceDemoLoginTests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private const string BaseUrl = "https://www.saucedemo.com/";

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            // Define the path for the screenshot inside the "Desktop/Screenshots" folder
            string desktopFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Screenshots");
            string screenshotPath = Path.Combine(desktopFolder, "last_test_screenshot.png");

            // Ensure the directory exists
            Directory.CreateDirectory(desktopFolder);

            // Take the screenshot
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

            Console.WriteLine($"Screenshot saved at: {screenshotPath}");

            // Close browser
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [Test]
        public async Task Verify_Successful_Login_With_Valid_Credentials()
        {
            await _page.GotoAsync(BaseUrl);

            // Enter valid credentials
            await _page.FillAsync("#user-name", "standard_user");
            await _page.FillAsync("#password", "secret_sauce");

            // Click Login button
            await _page.ClickAsync("#login-button");

            // Validate successful login (URL check)
            await Assertions.Expect(_page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");

            // Take a screenshot after successful login
            string screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Screenshots", "login_success.png");
            Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

            Console.WriteLine($"Screenshot saved at: {screenshotPath}");
        }

        [Test]
        public async Task Verify_Login_Failure_With_Invalid_Credentials()
        {
            await _page.GotoAsync(BaseUrl);

            // Enter invalid credentials
            await _page.FillAsync("#user-name", "invalid_user");
            await _page.FillAsync("#password", "wrong_password");

            // Click Login button
            await _page.ClickAsync("#login-button");

            // Validate error message
            var errorMessage = await _page.InnerTextAsync("[data-test='error']");
            Assert.That(errorMessage, Does.Contain("Epic sadface: Username and password do not match any user in this service"));

            // Take a screenshot after login failure
            string screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Screenshots", "login_failure.png");
            Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

            Console.WriteLine($"Screenshot saved at: {screenshotPath}");
        }

        [Test]
        public async Task Verify_Error_Message_For_Empty_Credentials()
        {
            await _page.GotoAsync(BaseUrl);

            // Click Login button without entering anything
            await _page.ClickAsync("#login-button");

            // Validate error message
            var errorMessage = await _page.InnerTextAsync("[data-test='error']");
            Assert.That(errorMessage, Does.Contain("Epic sadface: Username is required"));

            // Take a screenshot for empty credentials case
            string screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Screenshots", "empty_credentials.png");
            Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

            Console.WriteLine($"Screenshot saved at: {screenshotPath}");
        }
    }
}

//PickLocator
//Assert Visibility
//Assert text
//Assert value
//Assert snapshot
