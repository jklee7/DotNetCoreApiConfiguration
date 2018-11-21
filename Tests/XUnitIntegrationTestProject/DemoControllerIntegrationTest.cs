using System.Net;
using System.Threading.Tasks;
using WebApplication1;
using Xunit;
using FluentAssertions;

namespace XUnitIntegrationTestProject
{
    public class DemoControllerIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DemoControllerIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CanGetHelloMessage()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var httpResponse = await client.GetAsync("/");
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            // Assert
            httpResponse.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            responseContent.Should().Be("Hello! This is a demo WebApp");
        }
    }
}
