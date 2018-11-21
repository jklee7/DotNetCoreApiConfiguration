using System;
using Xunit;
using Moq;
using WebApplication1;
using WebApplication1.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1
{
    public class DemoControllerTest
    {
        [Fact]
        public void GetHello_ReturnsExpectedResult()
        {
            // Arrange
            var mockMessageServiceReturn = "Hello World";
            var mockService = new Mock<IMessageService>();
            mockService.Setup(svc => svc.GetMessage())
                .Returns(mockMessageServiceReturn);

            var controller = new DemoController(mockService.Object);

            // Act
            var result = controller.GetHello();
            var okResult = result as OkObjectResult;

            // Assert
            okResult.Should().NotBe(null);
            okResult?.StatusCode.Should().Be(200);
            okResult?.Value.Should().Be("Hello World");
        }
    }
}
