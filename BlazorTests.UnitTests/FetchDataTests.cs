using BlazorTests.Data;
using BlazorTests.Pages;
using BlazorTests.Shared;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorTests.UnitTests
{
    public class FetchDataTests
    {
        [Fact]
        public void ShouldRenderData()
        {
            using var context = new TestContext();
            context.Services.AddSingleton<IWeatherForecastService>(_ => new WeatherForecastService());
            
            var cut = context.RenderComponent<FetchData>();
            
            var weatherInformationComponents = cut.FindComponents<WeatherInformation>();
            Assert.Equal(5, weatherInformationComponents.Count);
        }
    }
}