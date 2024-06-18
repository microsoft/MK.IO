using System;
using Xunit;
using MK.IO;
using Moq;
using MK.IO.Models;
using MK.IO.Operations;
using Castle.Core.Logging;


namespace MK.IO.Tests
{
    public class AssetsOperationsTests
    {
        private Mock<MKIOClient> mockClient;

        public AssetsOperationsTests()
        {
            mockClient = new Mock<MKIOClient>("subscriptionname", "token");
        }

        [Theory]
        [InlineData(null)]
        public async Task Create_WithNull(string name)
        {
            // Arrange
            var assetsOperations = new AssetsOperations(mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentNullException>(() => assetsOperations.CreateOrUpdate(name, "containername", "storagename"));
            Assert.Throws<ArgumentNullException>(() => assetsOperations.CreateOrUpdate("assetname", "containername", name));
        }

        [Theory]
        [InlineData("")]
        public async Task Create_WithEmpty(string name)
        {
            // Arrange
            var assetsOperations = new AssetsOperations(mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => assetsOperations.CreateOrUpdate(name, "containername", "storagename"));
            Assert.Throws<ArgumentException>(() => assetsOperations.CreateOrUpdate("assetname", name, "storagename"));
            Assert.Throws<ArgumentException>(() => assetsOperations.CreateOrUpdate("assetname", "containername", name));
        }

        [Theory]
        [InlineData("name with space")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa123")]
        [InlineData("name-123&4")]
        [InlineData("name--1234")]
        [InlineData("name-123.4")]
        [InlineData("-name-123")]
        [InlineData("name-123-")]
        [InlineData("Name-123")]
        [InlineData("a")]
        [InlineData("12")]
        public async Task Create_ContainerNameError(string name)
        {
            // Arrange
            var assetsOperations = new AssetsOperations(mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => assetsOperations.CreateOrUpdate("assetname", name, "storagename"));
        }

        [Theory]
        [InlineData("name-123")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(null)]
        public async Task Create_ContainerNameOK(string name)
        {
            var mockClient2 = new Mock<MKIOClient>("subscriptionname", "token");

            mockClient2.Setup(client => client.CreateObjectPutAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
                )
            )
                .Returns(Task.FromResult("{}"))
                .Verifiable("CreateObjectPutAsync was not called with the expected parameters.");

            var mop = new Mock<AssetsOperations>(mockClient2.Object);

            // Act
            mop.Object.CreateOrUpdate("assetname", name, "storagename");

            // Assert
            mockClient2.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }
    }
}