// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Moq;
using MK.IO.Operations;
using System.Text.Json;

namespace MK.IO.Tests
{
    public class AssetsOperationsTests
    {
        private Mock<MKIOClient> mockClient;

        public AssetsOperationsTests()
        {
            mockClient = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);
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
            var mockClient2 = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);

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

        [Theory]
        [InlineData("{\"name\":\"ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/assets/ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252\",\"type\":\"Microsoft.Media/mediaservices/assets\",\"properties\":{\"assetId\":\"bcf8655e-9f8a-4f97-8fb6-c81962d859dd\",\"created\":\"2024-03-26T14:51:19.125280Z\",\"lastModified\":\"2024-03-26T14:51:22.180123Z\",\"alternateId\":\"\",\"description\":null,\"container\":\"asset-ac71836f-cc24-4614-af60-2fe2ae7f811e\",\"storageAccountName\":\"amsxpfrstorage\",\"storageEncryptionFormat\":null,\"encryptionScope\":null,\"containerDeletionPolicy\":\"Retain\"},\"labels\":{},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-03-26T14:51:19.125280Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-03-26T14:51:22.180123Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
        public async Task Create_DeserializationOK(string json)
        {
            var mockClient2 = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);

            mockClient2.Setup(client => client.CreateObjectPutAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
                )
            )
                .Returns(Task.FromResult(json))
                .Verifiable("CreateObjectPutAsync was not called with the expected parameters.");

            var mop = new Mock<AssetsOperations>(mockClient2.Object);

            // Act
            mop.Object.CreateOrUpdate("assetname", "container", "storagename");

            // Assert
            mockClient2.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }

        [Theory]
        [InlineData("{\"name\":\"ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/assets/ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252\",\"type\":\"Microsoft.Media/mediaservices/assets\",\"properties\":{\"assetId\":\"bcf8655e-9f8a-4f97-8fb6-c81962d859dd\",\"created\":\"2024-03-26T14:51:19.125280Z\",\"lastModified\":\"2024-03-26T14:51:22.180123Z\",\"alternateId\":\"\",\"description\":null,\"container\":\"asset-ac71836f-cc24-4614-af60-2fe2ae7f811e\",\"storageAccountName\":\"amsxpfrstorage\",\"storageEncryptionFormat\":null,\"encryptionScope\":null,\"containerDeletionPolicy\":\"Rein\"},\"labels\":{},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-03-26T14:51:19.125280Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-03-26T14:51:22.180123Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
        public async Task Create_DeserializationError(string json)
        {
            var mockClient2 = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);

            mockClient2.Setup(client => client.CreateObjectPutAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
                )
            )
                .Returns(Task.FromResult(json))
                .Verifiable("CreateObjectPutAsync was not called with the expected parameters.");

            var mop = new Mock<AssetsOperations>(mockClient2.Object);

            // act & assert
            Assert.Throws<JsonException>(() => mop.Object.CreateOrUpdate("assetname", "container", "storagename"));

            // Assert
            mockClient2.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }
    }
}