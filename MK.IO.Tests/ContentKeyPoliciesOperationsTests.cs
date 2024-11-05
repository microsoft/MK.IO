// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Models;
using MK.IO.Operations;
using Moq;

namespace MK.IO.Tests
{
    public class ContentKeyPoliciesOperationsTests
    {
        private Mock<MKIOClient> mockClient;

        public ContentKeyPoliciesOperationsTests()
        {
            mockClient = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);
        }

        [Theory]
        [InlineData(null)]
        public void Create_WithNull(string name)
        {
            // Arrange
            var operations = new ContentKeyPoliciesOperations(mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentNullException>(() => operations.Create(name, new ContentKeyPolicyProperties("description", new List<ContentKeyPolicyOption>())));
            Assert.Throws<ArgumentNullException>(() => operations.Create("name", null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("name with space")]
        public void Create_WithEmptyOrSpace(string name)
        {
            // Arrange
            var operations = new ContentKeyPoliciesOperations(mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => operations.Create(name, new ContentKeyPolicyProperties("description", new List<ContentKeyPolicyOption>())));
        }

        [Theory]
        [InlineData("{\"name\":\"testpolcreate\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/contentKeyPolicies/testpolcreate\",\"type\":\"Microsoft.Media/mediaservices/contentKeyPolicies\",\"supplemental\":{\"id\":\"3b2c47e3-e5a6-408c-9ff4-45fcf7396885\",\"state\":\"Created\"},\"properties\":{\"options\":[{\"name\":\"option1\",\"restriction\":{\"issuer\":\"issuer\",\"audience\":\"audience\",\"@odata.type\":\"#Microsoft.Media.ContentKeyPolicyTokenRestriction\",\"requiredClaims\":[{\"claimType\":\"urn:microsoft:azure:mediaservices:contentkeyidentifier\"}],\"restrictionTokenType\":\"Jwt\",\"primaryVerificationKey\":{\"keyValue\":\"\",\"@odata.type\":\"#Microsoft.Media.ContentKeyPolicySymmetricTokenKey\"},\"alternateVerificationKeys\":[]},\"configuration\":{\"@odata.type\":\"#Microsoft.Media.ContentKeyPolicyWidevineConfiguration\",\"widevineTemplate\":\"{}\"}}],\"description\":\"Mydescription\",\"created\":\"2024-06-25T17:14:16.861426Z\",\"lastModified\":\"2024-06-25T17:14:16.861441Z\"},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-06-25T17:14:16.861426Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-06-25T17:14:16.861441Z\"}}")]
        public void Create_DeserializationOK(string json)
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

            var mop = new Mock<ContentKeyPoliciesOperations>(mockClient2.Object);

            // Act
            mop.Object.Create("ckname", new ContentKeyPolicyProperties("description", new List<ContentKeyPolicyOption>()));

            // Assert
            mockClient2.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }

        [Theory]
        [InlineData("{\"name\":\"testpolcreate\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/contentKeyPolicies/testpolcreate\",\"type\":\"Microsoft.Media/mediaservices/contentKeyPolicies\",\"supplemental\":{\"id\":\"3b2c47e3-e5a6-408c-9ff4-45fcf7396885\",\"state\":\"Created\"},\"properties\":{\"options\":[{\"name\":\"option1\",\"restriction\":{\"issuer\":\"issuer\",\"audience\":\"audience\",\"@odata.type\":\"#Microsoft.Media.ContentKeyPolicyTokenRestriction\",\"requiredClaims\":[{\"claimType\":\"urn:microsoft:azure:mediaservices:contentkeyidentifier\"}],\"restrictionTokenType\":\"Jwt\",\"primaryVerificationKey\":{\"keyValue\":\"\",\"@odata.type\":\"#Microsoft.Media.ContentKeyPolicySymmetricTokenKey\"},\"alternateVerificationKeys\":[]},\"configuration\":{\"@odata.type\":\"#Microsoft.Media.ContentKeyPolicyWidevineConfiguration\",\"widevineTemplate\":\"{}\"}}],\"description\":\"Mydescription\",\"created\":\"XXXXXX\",\"lastModified\":\"2024-06-25T17:14:16.861441Z\"},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-06-25T17:14:16.861426Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-06-25T17:14:16.861441Z\"}}")]
        public void Create_DeserializationFormatError(string json)
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

            var mop = new Mock<ContentKeyPoliciesOperations>(mockClient2.Object);

            // act & assert
            Assert.Throws<FormatException>(() => mop.Object.Create("ckname", new ContentKeyPolicyProperties("description", new List<ContentKeyPolicyOption>())));

            // Assert
            mockClient2.Verify(); // Verify that Create was called as expected
        }
    }
}