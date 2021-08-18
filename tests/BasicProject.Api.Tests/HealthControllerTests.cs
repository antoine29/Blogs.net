namespace BasicProject.Api.Tests
{
    using BasicProject.Api.controllers;
    using BasicProject.Domain;
    using BasicProject.Logger;
    using BasicProject.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class HealthControllerTests
    {
        [Fact]
        public void Index_WhenIsAbleToCheckStatus_ShouldReturnOk()
        {
            // Arrange
            var context = new HealthControllerContext();
            var expectedResult = ApplicationHealthInfo.Hydrate("Test Service", "1.0");

            // Setup
            context.healthServiceMock
                .Setup(service => service.GetApplicationHealthInfo(It.IsAny<string>(), It.IsAny<System.Version>()))
                .Returns(expectedResult);

            // Act
            var result = context.subjectUnderTest.Index();

            // Assert
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, (result as ObjectResult).StatusCode);
        }

        [Fact]
        public void Index_WhenNameIsNull_ShouldReturnOk()
        {
            // Arrange
            var context = new HealthControllerContext();
            var expectedResult = ApplicationHealthInfo.Hydrate(null, "1.0");

            // Setup
            context.healthServiceMock
                .Setup(service => service.GetApplicationHealthInfo(
                    It.IsAny<string>(),
                    It.IsAny<System.Version>()))
                .Returns(expectedResult);

            // Act
            var result = context.subjectUnderTest.Index();

            // Assert
            Assert.IsType<ObjectResult>(result);
            var statusCodeResult = result as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, statusCodeResult.StatusCode);
        }

        internal class HealthControllerContext
        {
            public Mock<IHealthService> healthServiceMock;
            public Mock<Ilogger> loggerMock;
            public HealthController subjectUnderTest;

            public HealthControllerContext()
            {
                healthServiceMock = new Mock<IHealthService>();
                loggerMock = new Mock<Ilogger>();

                subjectUnderTest = new HealthController(healthServiceMock.Object, loggerMock.Object);
            }
        }
    }
}
