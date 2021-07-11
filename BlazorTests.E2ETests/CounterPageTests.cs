using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace BlazorTests.E2ETests
{
    public class IndexTitleTests
    {
        [Fact]
        public async Task ShouldIncreaseCounterByOne()
        {
            // Arrange
using var playwright = await Playwright.CreateAsync();
var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = true,
});
var page = await browser.NewPageAsync();
await page.GotoAsync("https://localhost:5001/counter");
await page.ScreenshotAsync(new PageScreenshotOptions {Path = "before_click.png"});
            
            // Act
await page.ClickAsync(":text('Click me')", new PageClickOptions
{
    ClickCount = 2,
});

            // Assert
await page.ScreenshotAsync(new PageScreenshotOptions {Path = "after_click.png"});
var counter = await page.QuerySelectorAsync("p");
var content = await counter.InnerTextAsync();
Assert.Equal("Current count: 2", content);
        }
    }
}