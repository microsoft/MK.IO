// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Moq;
using MK.IO.Models;
using MK.IO.Operations;
using System.Text.Json;

namespace MK.IO.Tests
{
    public class JobsOperationsTests
    {
        private Mock<MKIOClient> _mockClient;
        private readonly JobProperties _properties;

        public JobsOperationsTests()
        {
            _mockClient = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);
            _properties = new JobProperties()
            {
                Outputs = [new JobOutputAsset() { AssetName = "name" }]
            };

            _mockClient.Setup(client => client.CreateObjectPutAsync(
              It.IsAny<string>(),
              It.IsAny<string>(),
              It.IsAny<CancellationToken>()
              )
          )
              .Returns(Task.FromResult("{}"))
              .Verifiable("CreateObjectPutAsync was not called with the expected parameters.");
        }

        [Theory]
        [InlineData(null)]
        public void Create_WithNull(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(_mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentNullException>(() => jobsOperations.Create(name, "name", _properties));
            Assert.Throws<ArgumentNullException>(() => jobsOperations.Create("name", name, _properties));
            Assert.Throws<ArgumentNullException>(() => jobsOperations.Create("name", "name", null));
        }

        [Theory]
        [InlineData("")]
        public void Create_WithEmpty(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(_mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => jobsOperations.Create(name, "name", _properties));
            Assert.Throws<ArgumentException>(() => jobsOperations.Create("name", name, _properties));
        }

        [Theory]
        [InlineData("name with space")]
        [InlineData("kgMRYYUBi2Le3LAtuVDq220v4914MHud0Tmj6onzumNzkJP9gDPlZNmNunDp7lomsS0DUucyMAcSFzmxHFfH2wTgEVnCpzAamHMNTGyfsbk4WdB9LAlVPmmSlg3vhAduj2VQTsvohfWXqDiBTPaHoSHm9Zt4dbKWlAPxplgh3rdBiRVS45X9XELTgDC1bumc70icB4vQNVQ00cxcP9rkRNFXa2guqQQ5aZ0DiMGnN2qVXoXIvHD7rpdCDMD8WwxRWlaib")] // 261 chars
        [InlineData("job-123&4")]
        [InlineData("job-123.4")]
        [InlineData("-job-123")]
        [InlineData("job-123-")]
        public void Create_JobNameErrorInName(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(_mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => jobsOperations.Create("name", name, _properties));
        }

        [Theory]
        [InlineData("name-123")]
        [InlineData("name_123")]
        [InlineData("name.123")]
        [InlineData("nname--123")]
        [InlineData("kgMRYYUBi2Le3LAtuVDq220v4914MHud0Tmj6onzumNzkJP9gDPlZNmNunDp7lomsS0DUucyMAcSFzmxHFfH2wTgEVnCpzAamHMNTGyfsbk4WdB9LAlVPmmSlg3vhAduj2VQTsvohfWXqDiBTPaHoSHm9Zt4dbKWlAPxplgh3rdBiRVS45X9XELTgDC1bumc70icB4vQNVQ00cxcP9rkRNFXa2guqQQ5aZ0DiMGnN2qVXoXIvHD7rpdCDMD8WwxRWlai")] // 260 chars
        public async Task Create_JobNameOK(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(_mockClient.Object);

            var mop = new Mock<JobsOperations>(_mockClient.Object);

            // Act
            await mop.Object.CreateAsync("transform", name, _properties);

            // Assert
            mop.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }

        [Theory]
        [InlineData("{\"name\":\"live-to-mp4-6a3413a8\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/transforms/ConverterAllBitrateInterleaved/jobs/live-to-mp4-6a3413a8\",\"type\":\"Microsoft.Media/mediaservices/transforms/jobs\",\"properties\":{\"created\":\"2024-06-18T11:58:47.351891Z\",\"description\":\"Myjobwhichprocesses'asset-ec0688cc'to'asset-ec0688cc-mp4'with'ConverterAllBitrateInterleaved'transform.\",\"lastModified\":\"2024-06-18T11:59:06.511738Z\",\"priority\":\"Normal\",\"state\":\"Finished\",\"input\":{\"files\":[\"*\"],\"assetName\":\"asset-ec0688cc\",\"@odata.type\":\"#Microsoft.Media.JobInputAsset\"},\"outputs\":[{\"label\":\"BuiltInAssetConverterPreset_0\",\"state\":\"Finished\",\"endTime\":\"2024-06-18T11:59:06.394517Z\",\"progress\":100,\"assetName\":\"asset-ec0688cc-mp4\",\"@odata.type\":\"#Microsoft.Media.JobOutputAsset\"}],\"endTime\":\"2024-06-18T11:59:06.394517Z\"},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-06-18T11:58:47.351891Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-06-18T11:59:06.511738Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
        [InlineData("{\"name\":\"job-7326300f\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/transforms/simpletransformsd/jobs/job-7326300f\",\"type\":\"Microsoft.Media/mediaservices/transforms/jobs\",\"properties\":{\"created\":\"2024-03-27T15:33:58.451407Z\",\"description\":\"Mysdencodingjob\",\"lastModified\":\"2024-03-27T15:36:43.395374Z\",\"priority\":\"High\",\"state\":\"Finished\",\"input\":{\"files\":[\"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4\"],\"@odata.type\":\"#Microsoft.Media.JobInputHttp\"},\"outputs\":[{\"label\":\"BuiltInStandardEncoderPreset_0\",\"state\":\"Finished\",\"endTime\":\"2024-03-27T15:36:36.000000Z\",\"progress\":100,\"assetName\":\"output-b19d8b84\",\"@odata.type\":\"#Microsoft.Media.JobOutputAsset\",\"startTime\":\"2024-03-27T15:36:31.000000Z\"}],\"startTime\":\"2024-03-27T15:36:31.000000Z\",\"endTime\":\"2024-03-27T15:36:36.000000Z\"},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-03-27T15:33:58.451407Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-03-27T15:36:43.395374Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
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

            var mop = new Mock<JobsOperations>(mockClient2.Object);

            // Act
            await mop.Object.CreateAsync("name", "name", _properties);

            // Assert
            mop.Verify();
        }

        [Theory]
        [InlineData("{\"name\":\"live-to-mp4-6a3413a8\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/transforms/ConverterAllBitrateInterleaved/jobs/live-to-mp4-6a3413a8\",\"type\":\"Microsoft.Media/mediaservices/transforms/jobs\",\"properties\":{\"created\":\"2024-06-18T11:58:47.351891Z\",\"description\":\"Myjobwhichprocesses'asset-ec0688cc'to'asset-ec0688cc-mp4'with'ConverterAllBitrateInterleaved'transform.\",\"lastModified\":\"2024-06-18T11:59:06.511738Z\",\"priority\":\"Normal\",\"state\":\"FinishedXX\",\"input\":{\"files\":[\"*\"],\"assetName\":\"asset-ec0688cc\",\"@odata.type\":\"#Microsoft.Media.JobInputAssetXX\"},\"outputs\":[{\"label\":\"BuiltInAssetConverterPreset_0\",\"state\":\"Finhed\",\"endTime\":\"2024-06-18T11:59:06.394517Z\",\"progress\":100,\"assetName\":\"asset-ec0688cc-mp4\",\"@odata.type\":\"#Microsoft.Media.JobOutputAsset\"}],\"endTime\":\"2024-06-18T11:59:06.394517Z\"},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-06-18T11:58:47.351891Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-06-18T11:59:06.511738Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
        [InlineData("{\"name\":\"job-7326300f\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/transforms/simpletransformsd/jobs/job-7326300f\",\"type\":\"Microsoft.Media/mediaservices/transforms/jobs\",\"properties\":{\"created\":\"2024-03-27T15:33:58.451407Z\",\"description\":\"Mysdencodingjob\",\"lastModified\":\"2024-03-27T15:36:43.395374Z\",\"priority\":\"High\",\"state\":\"FinishedXXX\",\"input\":{\"files\":[\"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4\"],\"@odata.type\":\"#Microsoft.Media.JobInputHttpXX\"},\"outputs\":[{\"label\":\"BuiltInStandardEncoderPreset_0\",\"state\":\"Finished\",\"endTime\":\"2024-03-27T15:36:36.000000Z\",\"progress\":100,\"assetName\":\"output-b19d8b84\",\"@odata.type\":\"#Microsoft.Media.JobOutputAsset\",\"startTime\":\"2024-03-27T15:36:31.000000Z\"}],\"startTime\":\"2024-03-27T15:36:31.000000Z\",\"endTime\":\"2024-03-27T15:36:36.000000Z\"},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-03-27T15:33:58.451407Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-03-27T15:36:43.395374Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
        public void Create_DeserializationError(string json)
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

            var mop = new Mock<JobsOperations>(mockClient2.Object);

            // act & assert
            Assert.Throws<JsonException>(() => mop.Object.Create("name", "name", _properties));

            // Assert
            mop.Verify();
        }
    }
}