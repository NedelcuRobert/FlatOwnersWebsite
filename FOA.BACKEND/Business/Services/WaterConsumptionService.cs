using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.Business.Services
{
    public class WaterConsumptionService : IWaterConsumptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<WaterConsumption, int> _waterConsumptionRepository;

        public WaterConsumptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _waterConsumptionRepository = unitOfWork.WaterConsumptionRepository;
        }

        public async Task<List<WaterConsumption>> GetWaterConsumptionsByApartmentIdAsync(int apartmentId)
        {
            return await _waterConsumptionRepository.GetByFilter(wc => wc.ApartmentId == apartmentId)
                .ToListAsync();
        }

        public async Task<WaterConsumption> GetWaterConsumptionByIdAsync(int waterConsumptionId)
        {
            return await _waterConsumptionRepository.GetByIdAsync(waterConsumptionId);
        }

        public async Task<WaterConsumption> AddWaterConsumptionAsync(WaterConsumption waterConsumption)
        {
            await _waterConsumptionRepository.AddAsync(waterConsumption);
            _unitOfWork.Save();

            return waterConsumption;
        }

        public async Task<WaterConsumption> UpdateWaterConsumptionAsync(WaterConsumption waterConsumption)
        {
            var existingWaterConsumption = await _waterConsumptionRepository.GetByIdAsync(waterConsumption.Id);
            if (existingWaterConsumption == null)
            {
                // Consumul de apă nu există în baza de date, poți arunca o excepție sau trata cazul în alt mod
                return null;
            }

            // Actualizăm câmpurile consumului de apă existent cu valorile din consumul de apă actualizat
            existingWaterConsumption.ColdKitchen = waterConsumption.ColdKitchen;
            existingWaterConsumption.ColdBathroom = waterConsumption.ColdBathroom;
            existingWaterConsumption.HotKitchen = waterConsumption.HotKitchen;
            existingWaterConsumption.HotBathroom = waterConsumption.HotBathroom;
            existingWaterConsumption.CreationDate = waterConsumption.CreationDate;
            // Actualizează și alte câmpuri, după caz

            _waterConsumptionRepository.Update(existingWaterConsumption);
            _unitOfWork.Save();

            return existingWaterConsumption;
        }

        public async Task DeleteWaterConsumptionAsync(int waterConsumptionId)
        {
            await _waterConsumptionRepository.RemoveAsync(waterConsumptionId);
            _unitOfWork.Save();
        }
    }
}
