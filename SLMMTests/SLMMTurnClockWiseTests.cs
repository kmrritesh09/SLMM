using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SLMM;
using SLMM.Controllers;

namespace SLMMTests
{
    [TestClass]
    public class SLMMTurnClockWiseTests
    {
        [TestMethod]
        public void MovingSLMMClockWiseOnceFromDefaultNorthMakesItFaceEast()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            var result = sLMMController.MoveLawnMower(0);

            //Assert
            Assert.AreEqual(result.direction, Compass.East.ToString());
        }

        [TestMethod]
        public void MovingSLMMClockWiseTwiceFromDefaultNorthMakesItFaceSouth()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            sLMMController.MoveLawnMower(0);
            var result = sLMMController.MoveLawnMower(0);

            //Assert
            Assert.AreEqual(result.direction, Compass.South.ToString());
        }

        [TestMethod]
        public void MovingSLMMClockWiseThriceFromDefaultNorthMakesItFaceWest()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(0);
            var result = sLMMController.MoveLawnMower(0);

            //Assert
            Assert.AreEqual(result.direction, Compass.West.ToString());
        }

        [TestMethod]
        public void MovingSLMMClockWiseFourTimesRestoresDefaultNorth()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(0);
            var result = sLMMController.MoveLawnMower(0);

            //Assert
            Assert.AreEqual(result.direction, Compass.North.ToString());
        }
    }
}
