using BlazorTests.Pages;
using Bunit;
using Xunit;

namespace BlazorTests.UnitTests
{
    public class PowerToTests
    {
        [Fact]
        public void ShouldCalculatePowerOfEnteredBase()
        {
            using var context = new TestContext();
            var cut = context.RenderComponent<PowerOf>(
                parameterBuilder => parameterBuilder.Add(selector => selector.Pow, 2));
            cut.Find("input").Change("3");
            
            cut.Find("button").Click();

            Assert.Equal("9", cut.Find("p").TextContent);
        }
    }
}