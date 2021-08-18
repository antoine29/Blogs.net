namespace BasicProject.Services.Tests
{
    using BasicProject.Data;
    using BasicProject.Domain;

    using System;

    using Moq;
    using Xunit;

    public class HealthServiceTests
    {
        [Fact]
        public void GetApplicationHealthInfo_WhenValidParameters_ShouldReturnApplicationHealthInfo()
        {
            // Arrange
            var context = new HealthServiceContext();
            var name = "Test Service";
            var version = new Version("0.0.1");
            var expectedResult = ApplicationHealthInfo.Hydrate(name, version.ToString());

            // Setup
            context.checkSystemDAOMock
                .Setup(dao => dao.GetCurrentStatus(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expectedResult);

            // Act
            var result = context.subjectUnderTest.GetApplicationHealthInfo(name, version);

            // Assert
            Assert.IsType<ApplicationHealthInfo>(result);
            Assert.Equal(expectedResult, result);
        }

        internal class HealthServiceContext
        {
            public Mock<ICheckSystemDAO> checkSystemDAOMock;
            public HealthService subjectUnderTest;

            public HealthServiceContext()
            {
                checkSystemDAOMock = new Mock<ICheckSystemDAO>();
                subjectUnderTest = new HealthService(checkSystemDAOMock.Object);
            }
        }
    }
}
