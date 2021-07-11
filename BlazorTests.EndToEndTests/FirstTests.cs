using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace BlazorTests.EndToEndTests
{
    public class FirstTests
    {
        [Fact]
        public async Task ShouldClickButton()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {Headless = true});
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://localhost:44363/counter");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
        }
    }
}