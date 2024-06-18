using System;
using Xunit;
using MK.IO;
using Moq;
using MK.IO.Models;
using MK.IO.Operations;
using Castle.Core.Logging;


namespace MK.IO.Tests
{
    public class JobsOperationsTests
    {
        private Mock<MKIOClient> mockClient;

        public JobsOperationsTests()
        {
            mockClient = new Mock<MKIOClient>("subscriptionname", "token");
        }

        [Theory]
        [InlineData(null)]
        public async Task Create_WithNull(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(mockClient.Object);
            JobProperties properties = new JobProperties();

            // act & assert
            Assert.Throws<ArgumentNullException>(() => jobsOperations.Create(name, "name", properties));
            Assert.Throws<ArgumentNullException>(() => jobsOperations.Create("name", name, properties));
            Assert.Throws<ArgumentNullException>(() => jobsOperations.Create("name", "name", null));
        }

        [Theory]
        [InlineData("")]
        public async Task Create_WithEmpty(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(mockClient.Object);
            JobProperties properties = new JobProperties();

            // act & assert
            Assert.Throws<ArgumentException>(() => jobsOperations.Create(name, "name", properties));
            Assert.Throws<ArgumentException>(() => jobsOperations.Create("name", name, properties));
        }

        [Theory]
        [InlineData("name with space")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa123")]
        [InlineData("job-123&4")]
        [InlineData("job-123.4")]
        [InlineData("-job-123")]
        [InlineData("job-123-")]
        public async Task Create_JobNameErrorInName(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(mockClient.Object);
            JobProperties properties = new JobProperties();

            // act & assert
            Assert.Throws<ArgumentException>(() => jobsOperations.Create("name", name, properties));
        }

        [Theory]
        [InlineData("name-123")]
        [InlineData("name_123")]
        [InlineData("name.123")]
        [InlineData("nname--123")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public async Task Create_JobNameOK(string name)
        {
            // Arrange
            var jobsOperations = new JobsOperations(mockClient.Object);
            JobProperties properties = new JobProperties();

            var mop = new Mock<JobsOperations>(mockClient.Object);


            mop.Setup(client => client.CreateOrUpdateAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                properties,
                It.IsAny<Func<string, string, CancellationToken, Task<string>>>(),
                It.IsAny<CancellationToken>()
                )
            )
                .Returns(Task.FromResult(new JobSchema()))
                .Verifiable("CreateOrUpdateAsync was not called with the expected parameters.");


            // Act
            await mop.Object.CreateAsync("transform", name, properties);

            // Assert
            mockClient.Verify(); // Verify that CreateOrUpdateAsync was called as expected
        }
    }
}