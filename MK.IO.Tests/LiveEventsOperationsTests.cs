// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Models;
using MK.IO.Operations;
using Moq;
using Newtonsoft.Json;

namespace MK.IO.Tests
{
    public class LiveEventsOperationsTests
    {
        private Mock<MKIOClient> _mockClient;
        private readonly LiveEventProperties _properties;

        public LiveEventsOperationsTests()
        {
            _mockClient = new Mock<MKIOClient>("subscriptionname", Constants.jwtFakeToken);
            _properties = new LiveEventProperties()
            {
                Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic }
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
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentNullException>(() => liveEventsOperations.Create(name, "name", _properties));
            Assert.Throws<ArgumentNullException>(() => liveEventsOperations.Create("name", name, _properties));
            Assert.Throws<ArgumentNullException>(() => liveEventsOperations.Create("name", "name", null));
        }

        [Theory]
        [InlineData("")]
        public void Create_WithEmpty(string name)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => liveEventsOperations.Create(name, "name", _properties));
            Assert.Throws<ArgumentException>(() => liveEventsOperations.Create("name", name, _properties));
        }

        [Theory]
        [InlineData("name")]
        public void Create_LiveEventSRTWithPasstroughError(string name)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            var prop = new LiveEventProperties()
            {
                Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic },
                Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.SRT }
            };

            // act & assert
            Assert.Throws<ArgumentException>(() => liveEventsOperations.Create(name, "francecentral", prop));
        }

        [Theory]
        [InlineData("name")]
        public void Create_LiveEventWithoutEncodingPropError(string name)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            var prop = new LiveEventProperties()
            {
                Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.SRT }
            };

            // act & assert
            Assert.Throws<ArgumentException>(() => liveEventsOperations.Create(name, "francecentral", prop));
        }

        [Theory]
        [InlineData("name")]
        public async Task Create_LiveEventSRTWithEncodingOK(string name)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            var mop = new Mock<LiveEventsOperations>(_mockClient.Object);

            var prop = new LiveEventProperties()
            {
                Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.Premium1080p },
                Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.SRT },
            };

            // Act
            await mop.Object.CreateAsync(name, "francecentral", prop);

            // Assert
            mop.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }

        [Theory]
        [InlineData("n")] // 1 char
        [InlineData("name with space")]
        [InlineData("2VQTsvohfWXqDiBTPaHoSHm9Zt4dbKWlb")] // 33 chars
        public void Create_LiveEventErrorInName(string name)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            // act & assert
            Assert.Throws<ArgumentException>(() => liveEventsOperations.Create(name, "francecentral", _properties));
        }

        [Theory]
        [InlineData("n1")]
        [InlineData("name-123")]
        [InlineData("name_123")]
        [InlineData("name.123")]
        [InlineData("nname--123")]
        [InlineData("2VQTsvohfWXqDiBTPaHoSHm9Zt4dbKWl")] // 32 chars
        public async Task Create_LiveEventNameOK(string name)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            var mop = new Mock<LiveEventsOperations>(_mockClient.Object);

            // Act
            await mop.Object.CreateAsync(name, "francecentral", _properties);

            // Assert
            mop.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }

        [Theory]
        [InlineData("{\"name\":\"liveevent-6de535d0\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/liveEvents/liveevent-6de535d0\",\"type\":\"Microsoft.Media/mediaservices/liveevents\",\"location\":\"francecentral\",\"tags\":{},\"properties\":{\"created\":\"2024-06-26T20:37:45.398939Z\",\"lastModified\":\"2024-07-23T08:02:06.178290Z\",\"useStaticHostname\":false,\"streamOptions\":[\"Default\"],\"input\":{\"accessControl\":{\"ip\":{\"allow\":[{\"name\":\"everyone\",\"address\":\"0.0.0.0\",\"subnetPrefixLength\":0}]}},\"endpoints\":[{\"url\":\"rtmp://in-742d58f3-3492-4909-a7d2-965a61157b10.francecentral.streaming.mediakind.com:1935/0dcea5b2-4eed-4e80-8e37-df951aa9138d\",\"protocol\":\"RTMP\"}],\"keyFrameIntervalDuration\":\"PT2S\",\"streamingProtocol\":\"RTMP\",\"accessToken\":\"0dcea5b2-4eed-4e80-8e37-df951aa9138d\"},\"encoding\":{\"encodingType\":\"PassthroughBasic\",\"presetName\":\"\",\"keyFrameInterval\":\"PT2S\",\"stretchMode\":\"AutoSize\"},\"crossSiteAccessPolicies\":{\"clientAccessPolicy\":null,\"crossDomainPolicy\":null},\"provisioningState\":\"Succeeded\",\"resourceState\":\"Stopped\",\"preview\":{\"accessControl\":{\"ip\":{\"allow\":[]}},\"streamingPolicyName\":\"Predefined_ClearStreamingOnly\",\"previewLocator\":\"03e93aca-0576-40e2-92c3-ce2f0f100998\",\"endpoints\":[{\"url\":\"https://liveevent-6de535d0-mkiotest-preview.francecentral.streaming.mediakind.com/03e93aca-0576-40e2-92c3-ce2f0f100998/manifest.mpd\",\"protocol\":\"FragmentedMP4\"}]}},\"systemData\":{\"createdBy\":\"email@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-06-26T20:37:45.398939Z\",\"lastModifiedBy\":\"email@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-07-23T08:02:06.178290Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
        [InlineData("{\"name\":\"liveevent-srt\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/liveEvents/liveevent-srt\",\"type\":\"Microsoft.Media/mediaservices/liveevents\",\"location\":\"francecentral\",\"tags\":{},\"properties\":{\"created\":\"2024-07-24T04:07:50.363640Z\",\"lastModified\":\"2024-07-24T04:08:23.339112Z\",\"useStaticHostname\":false,\"streamOptions\":[\"Default\"],\"input\":{\"accessControl\":{\"ip\":{\"allow\":[{\"name\":\"AllowAll\",\"address\":\"0.0.0.0\",\"subnetPrefixLength\":0}]}},\"endpoints\":[{\"url\":\"srt://in-35b482ce-0a1a-41f6-88aa-47dcf590d3c5.francecentral.streaming.mediakind.com:6000?passphrase=abcdgdhfqsfh45gdsqsdksdfn&pkbkeylen=16\",\"protocol\":\"SRT\"}],\"keyFrameIntervalDuration\":\"PT2S\",\"streamingProtocol\":\"SRT\",\"accessToken\":\"abcdgdhfqsfh45gdsqsdksdfn\"},\"encoding\":{\"encodingType\":\"Standard\",\"presetName\":\"Default720p\",\"keyFrameInterval\":\"PT2S\",\"stretchMode\":\"AutoSize\"},\"crossSiteAccessPolicies\":{\"clientAccessPolicy\":null,\"crossDomainPolicy\":null},\"provisioningState\":\"Succeeded\",\"resourceState\":\"Stopped\",\"preview\":{\"accessControl\":{\"ip\":{\"allow\":[{\"name\":\"AllowAll\",\"address\":\"0.0.0.0\",\"subnetPrefixLength\":0}]}},\"streamingPolicyName\":\"Predefined_ClearStreamingOnly\",\"previewLocator\":\"9550a87c-2561-4073-8c81-167418bcea89\",\"endpoints\":[{\"url\":\"https://liveevent-srt-mkiotest-preview.francecentral.streaming.mediakind.com/9550a87c-2561-4073-8c81-167418bcea89/manifest.mpd\",\"protocol\":\"FragmentedMP4\"}]}},\"systemData\":{\"createdBy\":\"user@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-07-24T04:07:50.363640Z\",\"lastModifiedBy\":\"user@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-07-24T04:08:23.339112Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
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

            var mop = new Mock<LiveEventsOperations>(mockClient2.Object);

            // Act
            await mop.Object.CreateAsync("name", "name", _properties);

            // Assert
            mop.Verify();
        }

        [Theory]
        [InlineData("{\"name\":\"liveevent-6de535d0\",\"id\":\"/subscriptions/52907a2e-ab43-43ba-8b9f-8cb78285f665/resourceGroups/default/providers/Microsoft.Media/mediaservices/mkiotest/liveEvents/liveevent-6de535d0\",\"type\":\"Microsoft.Media/mediaservices/liveevents\",\"location\":\"francecentral\",\"tags\":{},\"properties\":{\"created\":\"2024-06-26T20:37:45.398939Z\",\"lastModified\":\"2024-07-23T08:02:06.178290Z\",\"useStaticHostname\":false,\"streamOptions\":[\"Default\"],\"input\":{\"accessControl\":{\"ip\":{\"allow\":[{\"name\":\"everyone\",\"address\":\"0.0.0.0\",\"subnetPrefixLength\":0}]}},\"endpoints\":[{\"url\":\"rtmp://in-742d58f3-3492-4909-a7d2-965a61157b10.francecentral.streaming.mediakind.com:1935/0dcea5b2-4eed-4e80-8e37-df951aa9138d\",\"protocol\":\"RTMP\"}],\"keyFrameIntervalDuration\":\"PT2S\",\"streamingProtocol\":\"RTMPERROR\",\"accessToken\":\"0dcea5b2-4eed-4e80-8e37-df951aa9138d\"},\"encoding\":{\"encodingType\":\"PassthroughBasic\",\"presetName\":\"\",\"keyFrameInterval\":\"PT2S\",\"stretchMode\":\"AutoSize\"},\"crossSiteAccessPolicies\":{\"clientAccessPolicy\":null,\"crossDomainPolicy\":null},\"provisioningState\":\"Succeeded\",\"resourceState\":\"Stopped\",\"preview\":{\"accessControl\":{\"ip\":{\"allow\":[]}},\"streamingPolicyName\":\"Predefined_ClearStreamingOnly\",\"previewLocator\":\"03e93aca-0576-40e2-92c3-ce2f0f100998\",\"endpoints\":[{\"url\":\"https://liveevent-6de535d0-mkiotest-preview.francecentral.streaming.mediakind.com/03e93aca-0576-40e2-92c3-ce2f0f100998/manifest.mpd\",\"protocol\":\"FragmentedMP4\"}]}},\"systemData\":{\"createdBy\":\"email@domain.com\",\"createdByType\":\"User\",\"createdAt\":\"2024-06-26T20:37:45.398939Z\",\"lastModifiedBy\":\"email@domain.com\",\"lastModifiedByType\":\"User\",\"lastModifiedAt\":\"2024-07-23T08:02:06.178290Z\"},\"supplemental\":{\"operation\":\"get\",\"subscription\":{\"id\":\"bf747f59-771a-4e9b-a6cd-59351c4a71d2\",\"name\":\"mkiotest\"}}}")]
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

            var mop = new Mock<LiveEventsOperations>(mockClient2.Object);

            // act & assert
            Assert.Throws<JsonSerializationException>(() => mop.Object.Create("name", "name", _properties));

            // Assert
            mop.Verify();
        }

        [Theory]
        [InlineData(64, 17)]
        [InlineData(65, 16)]
        public void Create_LiveEventErrorInTags(int sizeValue, int numberEntries)
        {
            // Arrange
            var liveEventsOperations = new LiveEventsOperations(_mockClient.Object);

            var tags = new Dictionary<string, string>();
            for (int i = 0; i < numberEntries; i++)
            {
                tags.Add(MKIOClient.GenerateUniqueName(null, sizeValue), MKIOClient.GenerateUniqueName(null, sizeValue));
            }

            // act & assert
            Assert.Throws<ArgumentException>(() => liveEventsOperations.Create("name", "francecentral", _properties, tags));
        }

        [Theory]
        [InlineData(64, 16)]
        public void Create_LiveEventNoErrorInTags(int sizeValue, int numberEntries)
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

            var mop = new Mock<LiveEventsOperations>(mockClient2.Object);

            var tags = new Dictionary<string, string>();
            for (int i = 0; i < numberEntries; i++)
            {
                tags.Add(MKIOClient.GenerateUniqueName(null, sizeValue), MKIOClient.GenerateUniqueName(null, sizeValue));
            }

            // Act
            mop.Object.Create("name", "name", _properties, tags);

            // Assert
            mop.Verify();
        }
    }
}