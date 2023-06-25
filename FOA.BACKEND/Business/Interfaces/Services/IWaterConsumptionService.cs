using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IWaterConsumptionService
    {
        Task<List<WaterConsumption>> GetWaterConsumptionsByApartmentIdAsync(int apartmentId);
        Task<WaterConsumption> GetWaterConsumptionByIdAsync(int waterConsumptionId);
        Task<WaterConsumption> AddWaterConsumptionAsync(WaterConsumption waterConsumption);
        Task<WaterConsumption> UpdateWaterConsumptionAsync(WaterConsumption waterConsumption);
        Task DeleteWaterConsumptionAsync(int waterConsumptionId);
    }
}
