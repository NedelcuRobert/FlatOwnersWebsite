using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IApartmentService
    {
        Task<List<Apartment>> GetUserApartmentsAsync(string userId);
        Task<Apartment> GetApartmentByIdAsync(int apartmentId);
        Task<Apartment> CreateApartmentAsync(ApartmentDTO apartment);
        Task<Apartment> UpdateApartmentAsync(Apartment apartment);
        Task DeleteApartmentAsync(int apartmentId);
    }
}
