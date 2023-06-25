using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FOA.BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterConsumptionController : ControllerBase
    {
        private readonly IWaterConsumptionService _waterConsumptionService;

        public WaterConsumptionController(IWaterConsumptionService waterConsumptionService)
        {
            _waterConsumptionService = waterConsumptionService;
        }

        [HttpGet("{waterConsumptionId}")]
        public async Task<ActionResult<WaterConsumption>> GetWaterConsumptionById(int waterConsumptionId)
        {
            var waterConsumption = await _waterConsumptionService.GetWaterConsumptionByIdAsync(waterConsumptionId);

            if (waterConsumption == null)
            {
                return NotFound();
            }

            return Ok(waterConsumption);
        }

        [HttpGet("apartment/{apartmentId}")]
        public async Task<ActionResult<WaterConsumption>> GetWaterConsumptionByApartmentId(int apartmentId)
        {
            var waterConsumption = await _waterConsumptionService.GetWaterConsumptionsByApartmentIdAsync(apartmentId);

            if (waterConsumption == null)
            {
                return NotFound();
            }

            return Ok(waterConsumption);
        }

        [HttpPost]
        public async Task<ActionResult<WaterConsumption>> AddWaterConsumption([FromBody] WaterConsumptionDTO waterConsumptionDTO)
        {
            var waterConsumption = new WaterConsumption
            {
                ApartmentId = waterConsumptionDTO.ApartmentId,
                ColdKitchen = waterConsumptionDTO.ColdKitchen,
                ColdBathroom = waterConsumptionDTO.ColdBathroom,
                HotKitchen = waterConsumptionDTO.HotKitchen,
                HotBathroom = waterConsumptionDTO.HotBathroom,
                CreationDate = DateTime.Now
            };

            var addedWaterConsumption = await _waterConsumptionService.AddWaterConsumptionAsync(waterConsumption);

            return Ok(addedWaterConsumption);
        }

        [HttpPut("{waterConsumptionId}")]
        public async Task<ActionResult<WaterConsumption>> UpdateWaterConsumption(int waterConsumptionId, [FromBody] WaterConsumptionDTO waterConsumptionDTO)
        {
            var existingWaterConsumption = await _waterConsumptionService.GetWaterConsumptionByIdAsync(waterConsumptionId);

            if (existingWaterConsumption == null)
            {
                return NotFound();
            }

            existingWaterConsumption.ColdKitchen = waterConsumptionDTO.ColdKitchen;
            existingWaterConsumption.ColdBathroom = waterConsumptionDTO.ColdBathroom;
            existingWaterConsumption.HotKitchen = waterConsumptionDTO.HotKitchen;
            existingWaterConsumption.HotBathroom = waterConsumptionDTO.HotBathroom;
            existingWaterConsumption.CreationDate = DateTime.Now;

            var updatedWaterConsumption = await _waterConsumptionService.UpdateWaterConsumptionAsync(existingWaterConsumption);

            return Ok(updatedWaterConsumption);
        }

        [HttpDelete("{waterConsumptionId}")]
        public async Task<ActionResult> DeleteWaterConsumption(int waterConsumptionId)
        {
            var existingWaterConsumption = await _waterConsumptionService.GetWaterConsumptionByIdAsync(waterConsumptionId);

            if (existingWaterConsumption == null)
            {
                return NotFound();
            }

            await _waterConsumptionService.DeleteWaterConsumptionAsync(waterConsumptionId);

            return NoContent();
        }
    }
}
