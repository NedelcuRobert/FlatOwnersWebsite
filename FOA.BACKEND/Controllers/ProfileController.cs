using FOA.BACKEND.Entities;
using FOA.BACKEND.Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FOA.BACKEND.Business.Interfaces.Services;

namespace FOA.BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAddressService _addressService;

        public ProfileController(UserManager<User> userManager, IAddressService addressService)
        {
            _userManager = userManager;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var address = await _addressService.GetAddressByIdAsync(user.AddressId);

            var profileDTO = new ProfileDTO
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                City = address.City,
                Street = address.Street,
                Building = address.Building,
                ApartmentNumber = address.ApartmentNumber,
                ProfilePicture = user.ProfilePicture
            };

            return Ok(profileDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ProfileDTO>> UpdateProfile([FromBody] ProfileDTO updatedProfile)
        {
            var user = await _userManager.FindByIdAsync(updatedProfile.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var address = await _addressService.GetAddressByIdAsync(user.AddressId);

            user.FirstName = updatedProfile.FirstName;
            user.LastName = updatedProfile.LastName;
            user.PhoneNumber = updatedProfile.PhoneNumber;
            address.City = updatedProfile.City;
            address.Street= updatedProfile.Street;
            address.Building = updatedProfile.Building;
            address.ApartmentNumber = updatedProfile.ApartmentNumber;
            user.ProfilePicture = updatedProfile.ProfilePicture;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var updatedProfileDTO = new ProfileDTO
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                City = address.City,
                Street = address.Street,
                Building = address.Building,
                ApartmentNumber = address.ApartmentNumber,
                ProfilePicture = user.ProfilePicture
            };

            return Ok(updatedProfileDTO);
        }

        [HttpGet("get-profile-picture/{userId}")]
        public async Task<ActionResult<string>> GetProfilePicture(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var profilePictureUrl = user.ProfilePicture;
            return Ok(profilePictureUrl);
        }
    }
}
