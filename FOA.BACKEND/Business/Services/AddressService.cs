using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Address?> CreateAddress(Address address)
        {

            await _unitOfWork.AddressRepository.AddAsync(address);
            _unitOfWork.Save();

            var result = _unitOfWork.AddressRepository.GetByFilter(a => a.City == address.City && a.Street == address.Street && a.Building == address.Building && a.ApartmentNumber == address.ApartmentNumber);

            return result.ToList().FirstOrDefault();
        }

        public async Task<Address?> GetAddressByIdAsync(int addressId)
        {
            return await _unitOfWork.AddressRepository.GetByIdAsync(addressId);
        }

    }
}
