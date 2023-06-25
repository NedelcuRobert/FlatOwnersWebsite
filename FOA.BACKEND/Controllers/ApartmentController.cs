using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FOA.BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IApartmentService _apartmentService;
        
        public ApartmentController(UserManager<User> userManager , IApartmentService apartmentService)
        {
            _userManager = userManager;
            _apartmentService = apartmentService;

        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserApartments(string userId)
        {
            var apartments = await _apartmentService.GetUserApartmentsAsync(userId);
            return Ok(apartments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApartmentById(int id)
        {
            var apartment = await _apartmentService.GetApartmentByIdAsync(id);
            if (apartment == null)
                return NotFound();

            return Ok(apartment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApartment(ApartmentDTO apartment)
        {
            var createdApartment = await _apartmentService.CreateApartmentAsync(apartment);
            return CreatedAtAction(nameof(GetApartmentById), new { id = createdApartment.Id }, createdApartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApartment(int id, ApartmentEditDTO apartmentDTO)
        {
            var apartment = await _apartmentService.GetApartmentByIdAsync(id);
            if (apartment == null)
                return NotFound();

            // Actualizează valorile apartamentului cu cele din obiectul DTO
            apartment.PhoneNumber = apartmentDTO.PhoneNumber;
            apartment.NumberOfPersons = apartmentDTO.NumberOfPersons;
            apartment.LastUpdate = DateTime.UtcNow;
            // Actualizează și alte proprietăți după necesitate

            var updatedApartment = await _apartmentService.UpdateApartmentAsync(apartment);
            if (updatedApartment == null)
                return BadRequest();

            return Ok(updatedApartment);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            await _apartmentService.DeleteApartmentAsync(id);
            return NoContent();
        }
    }
}
