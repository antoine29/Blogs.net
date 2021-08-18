namespace BasicProject.Data.Tests
{
    using BasicProject.Data;
    using BasicProject.Domain;

    using Xunit;

    public class CheckSystemDAOTests
    {
        [Fact]
        public void GetCurrentStatus_WhenParametersAreValid_ShouldReturnApplicationHealthInfo()
        {
            // Arrange
            var subjectUnderTest = new CheckSystemDAO();
            var name = "Test Service";
            var version = "1.2";

            // Act
            var result = subjectUnderTest.GetCurrentStatus(name, version);

            // Assert
            Assert.IsType<ApplicationHealthInfo>(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(version, result.Version);
        }
    }
}
