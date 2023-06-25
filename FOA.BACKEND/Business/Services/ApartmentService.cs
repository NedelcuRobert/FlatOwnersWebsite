using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;
using FOA.BACKEND.Business.DTO;

namespace FOA.BACKEND.Business.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Apartment, int> _apartmentRepository;
        private readonly IAddressService _addressService;

        public ApartmentService(IUnitOfWork unitOfWork, IAddressService addressService)
        {
            _unitOfWork = unitOfWork;
            _apartmentRepository = unitOfWork.ApartmentRepository;
            _addressService = addressService;
        }

        public async Task<List<Apartment>> GetUserApartmentsAsync(string userId)
        {
            return await _apartmentRepository.GetByFilter(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<Apartment> GetApartmentByIdAsync(int apartmentId)
        {
            return await _apartmentRepository.GetByIdAsync(apartmentId);
        }

        public async Task<Apartment> CreateApartmentAsync(ApartmentDTO apartmentDTO)
        {
            var apartment = new Apartment
            {
                City = apartmentDTO.City,
                Street = apartmentDTO.Street,
                Building = apartmentDTO.Building,
                ApartmentNumber = apartmentDTO.ApartmentNumber,
                UserId = apartmentDTO.UserId,
                NumberOfPersons = apartmentDTO.NumberOfPersons,
                Surface = apartmentDTO.Surface,
                PhoneNumber = apartmentDTO.PhoneNumber,
                DataAdded = DateTime.UtcNow,
                LastUpdate = DateTime.UtcNow
            };

            await _apartmentRepository.AddAsync(apartment);
            _unitOfWork.Save();

            return apartment;
        }

        public async Task<Apartment> UpdateApartmentAsync(Apartment apartment)
        {
            var existingApartment = await _apartmentRepository.GetByIdAsync(apartment.Id);
            if (existingApartment == null)
            {
                // Apartamentul nu există în baza de date, poți arunca o excepție sau trata cazul în alt mod
                return null;
            }

            existingApartment.NumberOfPersons = apartment.NumberOfPersons;
            existingApartment.Surface = apartment.Surface;
            existingApartment.PhoneNumber = apartment.PhoneNumber;
            existingApartment.LastUpdate = DateTime.UtcNow;

            _apartmentRepository.Update(existingApartment);
            _unitOfWork.Save();

            return existingApartment;
        }

        public async Task DeleteApartmentAsync(int apartmentId)
        {
            await _apartmentRepository.RemoveAsync(apartmentId);
            _unitOfWork.Save();
        }
    }
}
