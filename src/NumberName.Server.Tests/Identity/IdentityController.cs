using Microsoft.Extensions.Logging;
using Moq;
using NumberName.Server.Identity.Model;
using NumberName.Server.Identity.Services;
using Xunit;
using SUT = NumberName.Server.Identity;

namespace NumberName.Server.Tests.Identity
{
    public class IdentityController
    {
        [Fact]
        public void HttpGetServerIdentity()
        {
            // Arrange
            var apiServerName = "Test-Server";
            var serverIdentity = new ServerIdentity() { ServerName = apiServerName };

            var mockIdentityService = new Mock<IIdentityService>();
            var mockLogger = new Mock<ILogger<SUT.IdentityController>>();

            mockIdentityService
                .Setup(service => service.GetServerIdentity())
                .Returns(serverIdentity);
            var controller = new SUT.IdentityController(mockIdentityService.Object, mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.Same(serverIdentity, result.Value);
        }
    }
}