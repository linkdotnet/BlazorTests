using BlazorTests.Pages;
using Bunit;
using Xunit;

namespace BlazorTests.UnitTests
{
    public class CounterTests
    {
        [Fact]
        public void ShouldIncrementOnClick()
        {
            using var context = new TestContext();
            var cut = context.RenderComponent<Counter>();
            
            cut.Find("button").Click();
            
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
            Assert.Equal("Current count: 1", cut.Find("p").TextContent); 
        }
    }
}