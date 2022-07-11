using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SLMM;
using SLMM.Controllers;

namespace SLMMTests
{
    [TestClass]
    public class SLMMResetTests
    {
        [TestMethod]
        public void SetAreaOfFieldAppliesFieldLengthCorrectly()
        {
            // Arrange
            int length = 5;
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);

            //Act
            var result = sLMMController.SetAreaOfFieldAndResetSLMM(length, It.IsAny<int>());

            //Assert
            Assert.AreEqual(result.SetLength, length);
        }

        [TestMethod]
        public void SetAreaOfFieldAppliesFieldBreadthCorrectly()
        {
            // Arrange
            int breadth = 6;
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);

            //Act
            var result = sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), breadth);

            //Assert
            Assert.AreEqual(result.SetBreadth, breadth);
        }

        [TestMethod]
        public void ResetSLMMASetsXAxisPositionOfSLMMZero()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);

            //Act
            var result = sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Assert
            Assert.AreEqual(result.xAxisPosition, 0);
        }

        [TestMethod]
        public void ResetSLMMASetsYAxisPositionOfSLMMZero()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);

            //Act
            var result = sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Assert
            Assert.AreEqual(result.yAxisPosition, 0);
        }

        [TestMethod]
        public void ResetSLMMASetsDirectionOfSLMMNorth()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);

            //Act
            var result = sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Assert
            Assert.AreEqual(result.direction, Compass.North.ToString());
        }
    }
}