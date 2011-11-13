using GoogleReaderService.Concretes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleReaderService.UnitTests.Concretes
{
    [TestClass]
    public class GoogleReaderServiceTest
    {
        [TestMethod]
        public void Connect_WhenInstantiated_ShouldConnectToGoogleReaderAndGetAValidSID()
        {
            // Arrange
            var reader = new GoogleReader(username: "vintharas", password: "TNMXrev27");
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