using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SLMM;
using SLMM.Controllers;
using System;

namespace SLMMTests
{
    [TestClass]
    public class MoveSLMMForwardTests
    {
        public int length = 5;
        public int breadth = 4;
        [TestMethod]
        public void MovingSLMMForwardInNorthIncreasesYAxisPosition()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);

            //Act
            var result = sLMMController.MoveLawnMower(2);

            //Assert
            Assert.AreEqual(result.yAxisPosition, 1);
        }

        [TestMethod]
        public void MovingSLMMForwardInNorthMoreThanBreadthThrowsException()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);

            //Act
            for (int i = 0; i < breadth; i++)
            {
                sLMMController.MoveLawnMower(2);
            }

            try
            {
                sLMMController.MoveLawnMower(2);
            }
            catch(Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Invalid command for current position of SLMM");
            }
        }

        [TestMethod]
        public void MovingSLMMForwardInEastMoreThanLengthThrowsException()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);
            sLMMController.MoveLawnMower(0);
            for (int i = 0; i < length; i++)
            {
                sLMMController.MoveLawnMower(2);
            }

            //Act
            try
            {
                sLMMController.MoveLawnMower(2);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Invalid command for current position of SLMM");
            }
        }

        [TestMethod]
        public void MovingSLMMForwardInEastIncreasesXAxisPosition()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);
            sLMMController.MoveLawnMower(0);

            //Act
            var result = sLMMController.MoveLawnMower(2);

            //Assert
            Assert.AreEqual(result.xAxisPosition, 1);
        }

        [TestMethod]
        public void MovingSLMMForwardInWestBeyondXPositionZeroThrowsException()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);
            sLMMController.MoveLawnMower(1);

            //Act
            try
            {
                sLMMController.MoveLawnMower(2);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Invalid command for current position of SLMM");
            }
        }

        [TestMethod]
        public void MovingSLMMForwardInWestDecreasesXAxisPosition()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(2);
            sLMMController.MoveLawnMower(2);
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(0);

            //Act
            var result = sLMMController.MoveLawnMower(2);

            //Assert
            Assert.AreEqual(result.xAxisPosition, 1);
        }

        [TestMethod]
        public void MovingSLMMForwardInSouthDecreasesYAxisPosition()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);
            sLMMController.MoveLawnMower(2);
            sLMMController.MoveLawnMower(2);
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(0);

            //Act
            var result = sLMMController.MoveLawnMower(2);

            //Assert
            Assert.AreEqual(result.yAxisPosition, 1);
        }

        [TestMethod]
        public void MovingSLMMForwardInSouthBeyondYPositionZeroThrowsException()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            SLMMController sLMMController = new SLMMController(mockConfiguration.Object);
            sLMMController.SetAreaOfFieldAndResetSLMM(length, breadth);
            sLMMController.MoveLawnMower(0);
            sLMMController.MoveLawnMower(0);

            //Act
            try
            {
                sLMMController.MoveLawnMower(2);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Invalid command for current position of SLMM");
            }
        }
    }
}
