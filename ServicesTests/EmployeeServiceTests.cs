using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Services;
using FOA.BACKEND.Entities;
using Moq;
using NUnit.Framework;

namespace ServicesTests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IBaseRepository<Employee, int>> _employeeRepositoryMock;
        private IEmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _employeeRepositoryMock = new Mock<IBaseRepository<Employee, int>>();
            _unitOfWorkMock.Setup(uow => uow.EmployeeRepository).Returns(_employeeRepositoryMock.Object);
            _employeeService = new EmployeeService(_unitOfWorkMock.Object);
        }

        [Test]
        public async Task CreateEmployeeAsync_ValidEmployee_ReturnsCreatedEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Salary = 5000
            };

            _employeeRepositoryMock.Setup(repo => repo.AddAsync(employee)).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(uow => uow.Save()).Verifiable();

            var result = await _employeeService.CreateEmployeeAsync(employee);

            Assert.AreEqual(employee, result);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Test]
        public async Task UpdateEmployeeAsync_ExistingEmployee_ReturnsUpdatedEmployee()
        {
            var employeeId = 1;
            var existingEmployee = new Employee
            {
                Id = employeeId,
                FirstName = "John",
                LastName = "Doe",
                Salary = 5000
            };
            var updatedEmployee = new Employee
            {
                Id = employeeId,
                FirstName = "Jane",
                LastName = "Doe",
                Salary = 6000
            };

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(employeeId)).ReturnsAsync(existingEmployee);
            _employeeRepositoryMock.Setup(repo => repo.Update(updatedEmployee)).Verifiable();
            //_unitOfWorkMock.Setup(uow => uow.Save()).Verifiable();

            var result = await _employeeService.UpdateEmployeeAsync(updatedEmployee);

            Assert.AreEqual(updatedEmployee, result);
          //  _unitOfWorkMock.Verify(uow => uow.Save(), Times.Once);
        }

        [Test]
        public async Task UpdateEmployeeAsync_NonExistingEmployee_ReturnsNull()
        {
            var employeeId = 1;
            var nonExistingEmployee = new Employee
            {
                Id = employeeId,
                FirstName = "John",
                LastName = "Doe",
                Salary = 5000
            };

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(employeeId)).ReturnsAsync((Employee)null);

            var result = await _employeeService.UpdateEmployeeAsync(nonExistingEmployee);

            Assert.IsNull(result);
            _employeeRepositoryMock.Verify(repo => repo.Update(nonExistingEmployee), Times.Never);
            _unitOfWorkMock.Verify(uow => uow.Save(), Times.Never);
        }
    }
}
