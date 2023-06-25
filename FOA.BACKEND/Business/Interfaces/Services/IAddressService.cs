using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IAddressService
    {
        Task<Address?> CreateAddress(Address address);
        Task<Address?> GetAddressByIdAsync(int addressId);
    }
}
