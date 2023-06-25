using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Services;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServicesTests
{
    [TestFixture]
    public class ApartmentServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IBaseRepository<Apartment, int>> _apartmentRepositoryMock;
        private Mock<IAddressService> _addressServiceMock;
        private IApartmentService _apartmentService;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _apartmentRepositoryMock = new Mock<IBaseRepository<Apartment, int>>();
            _addressServiceMock = new Mock<IAddressService>();

            _unitOfWorkMock.Setup(uow => uow.ApartmentRepository).Returns(_apartmentRepositoryMock.Object);

            _apartmentService = new ApartmentService(_unitOfWorkMock.Object, _addressServiceMock.Object);
        }

        [Test]
        public async Task GetApartmentByIdAsync_WithValidApartmentId_ReturnsApartment()
        {
            // Arrange
            int apartmentId = 1;
            var apartment = new Apartment { Id = apartmentId };

            _apartmentRepositoryMock.Setup(repo => repo.GetByIdAsync(apartmentId)).ReturnsAsync(apartment);

            // Act
            var result = await _apartmentService.GetApartmentByIdAsync(apartmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(apartmentId, result.Id);
        }

        [Test]
        public async Task CreateApartmentAsync_WithValidApartmentDTO_ReturnsCreatedApartment()
        {
            // Arrange
            var apartmentDTO = new ApartmentDTO
            {
                City = "Test City",
                Street = "Test Street",
                Building = "Test Building",
                ApartmentNumber = "Test Apartment",
                UserId = "Test User",
                NumberOfPersons = 2,
                Surface = 100,
                PhoneNumber = "1234567890"
            };
            var createdApartment = new Apartment
            {
                City = apartmentDTO.City,
                Street = apartmentDTO.Street,
                Building = apartmentDTO.Building,
                ApartmentNumber = apartmentDTO.ApartmentNumber,
                UserId = apartmentDTO.UserId,
                NumberOfPersons = apartmentDTO.NumberOfPersons,
                Surface = apartmentDTO.Surface,
                PhoneNumber = apartmentDTO.PhoneNumber,
                DataAdded = It.IsAny<DateTime>(),
                LastUpdate = It.IsAny<DateTime>()
            };

            _apartmentRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Apartment>()));

            // Act
            var result = await _apartmentService.CreateApartmentAsync(apartmentDTO);

            // Assert
            _apartmentRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Apartment>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(apartmentDTO.City, result.City);
            Assert.AreEqual(apartmentDTO.Street, result.Street);
            // Add more assertions for other properties
        }

        [Test]
        public async Task UpdateApartmentAsync_WithExistingApartment_ReturnsUpdatedApartment()
        {
            // Arrange
            int apartmentId = 1;
            var existingApartment = new Apartment { Id = apartmentId, NumberOfPersons = 2, Surface = 100, PhoneNumber = "1234567890" };
            var updatedApartment = new Apartment { Id = apartmentId, NumberOfPersons = 3, Surface = 120, PhoneNumber = "9876543210" };

            _apartmentRepositoryMock.Setup(repo => repo.GetByIdAsync(apartmentId)).ReturnsAsync(existingApartment);
            _apartmentRepositoryMock.Setup(repo => repo.Update(It.IsAny<Apartment>()));

            // Act
            var result = await _apartmentService.UpdateApartmentAsync(updatedApartment);

            // Assert
            _apartmentRepositoryMock.Verify(repo => repo.Update(It.IsAny<Apartment>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedApartment.NumberOfPersons, result.NumberOfPersons);
            Assert.AreEqual(updatedApartment.Surface, result.Surface);
            // Add more assertions for other properties
        }

        [Test]
        public async Task UpdateApartmentAsync_WithNonExistingApartment_ReturnsNull()
        {
            // Arrange
            int apartmentId = 1;
            var updatedApartment = new Apartment { Id = apartmentId, NumberOfPersons = 3, Surface = 120, PhoneNumber = "9876543210" };

            _apartmentRepositoryMock.Setup(repo => repo.GetByIdAsync(apartmentId)).ReturnsAsync((Apartment)null);

            // Act
            var result = await _apartmentService.UpdateApartmentAsync(updatedApartment);

            // Assert
            _apartmentRepositoryMock.Verify(repo => repo.Update(It.IsAny<Apartment>()), Times.Never);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Never);
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteApartmentAsync_WithValidApartmentId_CallsRemoveAndSaveMethods()
        {
            // Arrange
            int apartmentId = 1;

            _apartmentRepositoryMock.Setup(repo => repo.RemoveAsync(apartmentId));

            // Act
            await _apartmentService.DeleteApartmentAsync(apartmentId);

            // Assert
            _apartmentRepositoryMock.Verify(repo => repo.RemoveAsync(apartmentId), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }
    }
}
