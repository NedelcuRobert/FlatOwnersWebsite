using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Employee, int> _employeeRepository;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = unitOfWork.EmployeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAll().ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            _unitOfWork.Save();

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
            {
                // Angajatul nu există în baza de date, poți arunca o excepție sau trata cazul în alt mod
                return null;
            }

            // Actualizăm câmpurile angajatului existent cu valorile din angajatul actualizat
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Salary = employee.Salary;
            // Actualizează și alte câmpuri, după caz

            _employeeRepository.Update(existingEmployee);
            _unitOfWork.Save();

            return existingEmployee;
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            await _employeeRepository.RemoveAsync(employeeId);
            _unitOfWork.Save();
        }
    }
}
