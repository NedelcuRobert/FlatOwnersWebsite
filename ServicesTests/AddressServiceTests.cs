using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Services;
using FOA.BACKEND.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace ServicesTests
{
    [TestFixture]
    public class AddressServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IBaseRepository<Address, int>> _addressRepositoryMock;
        private IAddressService _addressService;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _addressRepositoryMock = new Mock<IBaseRepository<Address, int>>();

            _unitOfWorkMock.Setup(uow => uow.AddressRepository).Returns(_addressRepositoryMock.Object);

            _addressService = new AddressService(_unitOfWorkMock.Object);
        }

        [Test]
        public async Task CreateAddress_WithValidAddress_ReturnsCreatedAddress()
        {
            // Arrange
            var address = new Address
            {
                City = "Test City",
                Street = "Test Street",
                Building = "Test Building",
                ApartmentNumber = 5
            };

            var addresses = new List<Address>
            {
                new Address { Id = 1, City = "Test City", Street = "Test Street", Building = "Test Building", ApartmentNumber = 3 },
                new Address { Id = 2, City = "Test City", Street = "Test Street", Building = "Test Building", ApartmentNumber = 4 },
                new Address { Id = 3, City = "Test City", Street = "Test Street", Building = "Test Building", ApartmentNumber = 5 }
            };

            var queryableAddresses = addresses.AsQueryable();

            _unitOfWorkMock.Setup(uow => uow.AddressRepository).Returns(_addressRepositoryMock.Object);
            _addressRepositoryMock.Setup(repo => repo.AddAsync(address));

            _addressRepositoryMock.Setup(repo => repo.GetByFilter(It.IsAny<Expression<Func<Address, bool>>>())).Returns(queryableAddresses);

            var result = await _addressService.CreateAddress(address);

            _addressRepositoryMock.Verify(repo => repo.AddAsync(address), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual("Test City", result.City);
            Assert.AreEqual("Test Street", result.Street);
            Assert.AreEqual("Test Building", result.Building);
            Assert.AreEqual(3, result.ApartmentNumber);
        }

        [Test]
        public async Task GetAddressByIdAsync_WithValidAddressId_ReturnsAddress()
        {
            int addressId = 1;
            var address = new Address { Id = addressId };

            _addressRepositoryMock.Setup(repo => repo.GetByIdAsync(addressId)).ReturnsAsync(address);

            var result = await _addressService.GetAddressByIdAsync(addressId);

            Assert.IsNotNull(result);
            Assert.AreEqual(addressId, result.Id);
        }
    }
}
