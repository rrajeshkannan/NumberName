using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;
using SUT = NumberName.Server.Identity.Services;

namespace NumberName.Server.Tests
{
    public class IdentityService
    {
        [Fact]
        public void ServerIdentity()
        {
            // Arrange
            var apiServerNameKey = "ApiServerName";
            var apiServerNameValue = "Test-Server";

            var configurationValues = new Dictionary<string, string>
            {
                {apiServerNameKey, apiServerNameValue},
                // {"Nested:Key1", "NestedValue1"},
                // {"Nested:Key2", "NestedValue2"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurationValues)
                .Build();

            var service = new SUT.IdentityService(configuration);

            // Act
            var identity = service.GetServerIdentity();

            // Assert
            Assert.Equal(apiServerNameValue, identity.ServerName);
        }
    }
}