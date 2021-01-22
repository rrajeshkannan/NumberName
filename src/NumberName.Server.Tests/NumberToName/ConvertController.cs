using Microsoft.Extensions.Logging;
using Moq;
using NumberName.Server.NumberToName.Model;
using NumberName.Server.NumberToName.Services;
using Xunit;
using SUT = NumberName.Server.NumberToName;

namespace NumberName.Server.Tests.NumberToName
{
    public class ConvertController
    {
        [Fact]
        public void HttpPost()
        {
            // Arrange
            uint number = 10;
            var numberInWords = "test-10";

            var output = new NumberNameOutput { Value = number, ValueInWords = numberInWords };

            var mockConversionService = new Mock<IConversionService>();
            var mockLogger = new Mock<ILogger<SUT.ConvertController>>();

            mockConversionService
                .Setup(service => service.ConvertFrom(It.IsAny<NumberNameInput>()))
                .Returns(output);
            var controller = new SUT.ConvertController(mockConversionService.Object, mockLogger.Object);

            // Act
            var result = controller.Post(new Mock<NumberNameInput>().Object);

            // Assert
            Assert.Same(output, result.Value);
        }
    }
}