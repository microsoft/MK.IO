// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Moq;

namespace MK.IO.Tests
{
    public class ClientOperationsTests
    {
        private Mock<MKIOClient> mockClient;

        public ClientOperationsTests()
        {
            mockClient = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);
        }

        [Theory]
        [InlineData(null)]
        public async Task CreateClient_WithNull(string name)
        {

            // act & assert
            Assert.Throws<ArgumentNullException>(() => new MKIOClient(name, Constants.jwtFakeToken));
            Assert.Throws<ArgumentNullException>(() => new MKIOClient("name", name));
        }

        [Theory]
        [InlineData("AGDTSBDH45DGD")]
        public async Task CreateClient_WithNotAJwt(string token)
        {

            // act & assert
            Assert.Throws<ArgumentException>(() => new MKIOClient("name", token));
        }

        [Theory]
        [InlineData(Constants.jwtFakeToken)]
        public void CreateClient_DeserializationOK(string token)
        {
            // Act
            var client = new MKIOClient("subscriptionname", token);

            // Assert
            Assert.NotNull(client);
        }
    }
}