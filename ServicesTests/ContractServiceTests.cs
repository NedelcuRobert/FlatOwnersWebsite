using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Services;
using Moq;
using NUnit.Framework;
using FOA.BACKEND.Entities;

namespace ServicesTests
{
    [TestFixture]
    public class ContractServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IBaseRepository<Contract, int>> _contractRepositoryMock;
        private IContractService _contractService;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _contractRepositoryMock = new Mock<IBaseRepository<Contract, int>>();

            _unitOfWorkMock.Setup(uow => uow.ContractRepository).Returns(_contractRepositoryMock.Object);

            _contractService = new ContractService(_unitOfWorkMock.Object);
        }


        [Test]
        public async Task GetContractByIdAsync_WithValidContractId_ReturnsContract()
        {
            // Arrange
            int contractId = 1;
            var contract = new Contract { Id = contractId };

            _contractRepositoryMock.Setup(repo => repo.GetByIdAsync(contractId)).ReturnsAsync(contract);

            // Act
            var result = await _contractService.GetContractByIdAsync(contractId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(contractId, result.Id);
        }

        [Test]
        public async Task CreateContractAsync_WithValidContract_ReturnsCreatedContract()
        {
            // Arrange
            var contract = new Contract
            {
                ProviderName = "Test Provider",
                Amount = 100,
                ServiceName = "Test Service"
            };

            _contractRepositoryMock.Setup(repo => repo.AddAsync(contract));

            // Act
            var result = await _contractService.CreateContractAsync(contract);

            // Assert
            _contractRepositoryMock.Verify(repo => repo.AddAsync(contract), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Provider", result.ProviderName);
            Assert.AreEqual(100, result.Amount);
            Assert.AreEqual("Test Service", result.ServiceName);
        }

        [Test]
        public async Task UpdateContractAsync_WithExistingContract_ReturnsUpdatedContract()
        {
            // Arrange
            int contractId = 1;
            var existingContract = new Contract { Id = contractId, ProviderName = "Old Provider", Amount = 100, ServiceName = "Old Service" };
            var updatedContract = new Contract { Id = contractId, ProviderName = "New Provider", Amount = 200, ServiceName = "New Service" };

            _contractRepositoryMock.Setup(repo => repo.GetByIdAsync(contractId)).ReturnsAsync(existingContract);
            _contractRepositoryMock.Setup(repo => repo.Update(existingContract));

            // Act
            var result = await _contractService.UpdateContractAsync(updatedContract);

            // Assert
            _contractRepositoryMock.Verify(repo => repo.Update(existingContract), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual("New Provider", result.ProviderName);
            Assert.AreEqual(200, result.Amount);
            Assert.AreEqual("New Service", result.ServiceName);
        }

        [Test]
        public async Task UpdateContractAsync_WithNonExistingContract_ReturnsNull()
        {
            // Arrange
            int contractId = 1;
            var updatedContract = new Contract { Id = contractId, ProviderName = "New Provider", Amount = 200, ServiceName = "New Service" };

            _contractRepositoryMock.Setup(repo => repo.GetByIdAsync(contractId)).ReturnsAsync((Contract)null);

            // Act
            var result = await _contractService.UpdateContractAsync(updatedContract);

            // Assert
            _contractRepositoryMock.Verify(repo => repo.Update(It.IsAny<Contract>()), Times.Never);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Never);
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteContractAsync_WithValidContractId_CallsRemoveAndSaveMethods()
        {
            // Arrange
            int contractId = 1;

            _contractRepositoryMock.Setup(repo => repo.RemoveAsync(contractId));

            // Act
            await _contractService.DeleteContractAsync(contractId);

            // Assert
            _contractRepositoryMock.Verify(repo => repo.RemoveAsync(contractId), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }
}
