using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SLMM;
using SLMM.Controllers;

namespace SLMMTests
{
    [TestClass]
    public class SLMMTurnAntiClockWiseTests
    {
        [TestMethod]
        public void MovingSLMMAntiClockWiseOnceFromDefaultNorthMakesItFaceWest()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            var result = sLMMController.MoveLawnMower(1);

            //Assert
            Assert.AreEqual(result.direction, Compass.West.ToString());
        }

        [TestMethod]
        public void MovingSLMMAntiClockWiseTwiceFromDefaultNorthMakesItFaceSouth()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            sLMMController.MoveLawnMower(1);
            var result = sLMMController.MoveLawnMower(1);

            //Assert
            Assert.AreEqual(result.direction, Compass.South.ToString());
        }

        [TestMethod]
        public void MovingSLMMAntiClockWiseThriceFromDefaultNorthMakesItFaceEast()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            sLMMController.MoveLawnMower(1);
            sLMMController.MoveLawnMower(1);
            var result = sLMMController.MoveLawnMower(1);

            //Assert
            Assert.AreEqual(result.direction, Compass.East.ToString());
        }

        [TestMethod]
        public void MovingSLMMAntiClockWiseFourTimesRestoresDefaultNorth()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(It.IsAny<int>(), It.IsAny<int>());

            //Act
            sLMMController.MoveLawnMower(1);
            sLMMController.MoveLawnMower(1);
            sLMMController.MoveLawnMower(1);
            var result = sLMMController.MoveLawnMower(1);

            //Assert
            Assert.AreEqual(result.direction, Compass.North.ToString());
        }
    }
}
