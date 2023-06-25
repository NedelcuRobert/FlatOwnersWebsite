using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Services;
using FOA.BACKEND.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;
using System.Diagnostics.Contracts;

namespace ServicesTests
{
    [TestFixture]
    public class WaterConsumptionServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IBaseRepository<WaterConsumption, int>> _waterConsumptionRepositoryMock;
        private IWaterConsumptionService _waterConsumptionService;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _waterConsumptionRepositoryMock = new Mock<IBaseRepository<WaterConsumption, int>>();

            _unitOfWorkMock.Setup(uow => uow.WaterConsumptionRepository).Returns(_waterConsumptionRepositoryMock.Object);

            _waterConsumptionService = new WaterConsumptionService(_unitOfWorkMock.Object);
        }


        [Test]
        public async Task GetWaterConsumptionByIdAsync_WithValidWaterConsumptionId_ReturnsWaterConsumption()
        {
            // Arrange
            int waterConsumptionId = 1;
            var waterConsumption = new WaterConsumption { Id = waterConsumptionId };

            _waterConsumptionRepositoryMock.Setup(repo => repo.GetByIdAsync(waterConsumptionId)).ReturnsAsync(waterConsumption);

            // Act
            var result = await _waterConsumptionService.GetWaterConsumptionByIdAsync(waterConsumptionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(waterConsumptionId, result.Id);
        }

        [Test]
        public async Task AddWaterConsumptionAsync_WithValidWaterConsumption_ReturnsAddedWaterConsumption()
        {
            // Arrange
            var waterConsumption = new WaterConsumption { ApartmentId = 1, ColdKitchen = 10, ColdBathroom = 20, HotKitchen = 30, HotBathroom = 40 };

            _waterConsumptionRepositoryMock.Setup(repo => repo.AddAsync(waterConsumption));

            // Act
            var result = await _waterConsumptionService.AddWaterConsumptionAsync(waterConsumption);

            // Assert
            _waterConsumptionRepositoryMock.Verify(repo => repo.AddAsync(waterConsumption), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(waterConsumption.ApartmentId, result.ApartmentId);
            Assert.AreEqual(waterConsumption.ColdKitchen, result.ColdKitchen);
            Assert.AreEqual(waterConsumption.ColdBathroom, result.ColdBathroom);
            Assert.AreEqual(waterConsumption.HotKitchen, result.HotKitchen);
            Assert.AreEqual(waterConsumption.HotBathroom, result.HotBathroom);
        }

        [Test]
        public async Task UpdateWaterConsumptionAsync_WithValidWaterConsumption_ReturnsUpdatedWaterConsumption()
        {
            // Arrange
            var existingWaterConsumption = new WaterConsumption { Id = 1, ApartmentId = 1, ColdKitchen = 10, ColdBathroom = 20, HotKitchen = 30, HotBathroom = 40 };
            var updatedWaterConsumption = new WaterConsumption { Id = 1, ApartmentId = 1, ColdKitchen = 15, ColdBathroom = 25, HotKitchen = 35, HotBathroom = 45 };

            _waterConsumptionRepositoryMock.Setup(repo => repo.GetByIdAsync(existingWaterConsumption.Id)).ReturnsAsync(existingWaterConsumption);
            _waterConsumptionRepositoryMock.Setup(repo => repo.Update(existingWaterConsumption));

            // Act
            var result = await _waterConsumptionService.UpdateWaterConsumptionAsync(updatedWaterConsumption);

            // Assert
            _waterConsumptionRepositoryMock.Verify(repo => repo.GetByIdAsync(existingWaterConsumption.Id), Times.Once);
            _waterConsumptionRepositoryMock.Verify(repo => repo.Update(existingWaterConsumption), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedWaterConsumption.ColdKitchen, result.ColdKitchen);
            Assert.AreEqual(updatedWaterConsumption.ColdBathroom, result.ColdBathroom);
            Assert.AreEqual(updatedWaterConsumption.HotKitchen, result.HotKitchen);
            Assert.AreEqual(updatedWaterConsumption.HotBathroom, result.HotBathroom);
        }

        [Test]
        public async Task DeleteWaterConsumptionAsync_WithValidWaterConsumptionId_DeletesWaterConsumption()
        {
            // Arrange
            int waterConsumptionId = 1;

            _waterConsumptionRepositoryMock.Setup(repo => repo.RemoveAsync(waterConsumptionId));

            // Act
            await _waterConsumptionService.DeleteWaterConsumptionAsync(waterConsumptionId);

            // Assert
            _waterConsumptionRepositoryMock.Verify(repo => repo.RemoveAsync(waterConsumptionId), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }
}
