using GoogleReaderService.Concretes;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleReaderService.IntegrationTests.Tests
{
    [TestClass]
    public class GoogleReaderServiceTest
    {
        [TestMethod]
        public void Connect_WhenInstantiated_ShouldConnectToGoogleReaderAndGetAValidSID()
        {
            // Arrange
            var reader = new GoogleReader(username: "xxxxx", password: "xxxxx");
            // Act
            reader.Connect();
            // Assert
            Assert.AreEqual(expected: "", actual: reader.Sid);
        }

        [TestMethod]
        public void Connect_WhenInstantiated_ShouldConnectToGoogleReaderAndGetAValidToken()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}