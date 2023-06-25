using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Services;
using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FOA.BACKEND.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly PasswordHasher<IdentityUser> passwordHasher;
    private readonly IAuthService _authService;
    private readonly IAddressService _addressService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IAuthService authService, IAddressService addressService, ITokenService tokenService) 
    {
        _signInManager = signInManager;
        _userManager = userManager; 
        _authService = authService;
        _addressService = addressService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Authenticate(LoginDTO input)
    {
        if (input == null)
        {
            return BadRequest();
        }

        
        var user = await _userManager.FindByEmailAsync(input.Email);

        if (user == null)
        {
            return BadRequest();
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
        
        if (!result.Succeeded)
        {
            return BadRequest();
        }

        return new UserDTO
        {
            Email = user.Email,
            Username = user.Id,
            Token = _tokenService.CreateToken(user)
        };
      
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO input)
    {
        var address = new Address
        {
            City = input.City,
            Building = input.Building,
            Street = input.Street,
            ApartmentNumber = Int32.Parse(input.ApartmentNumber)
        };

        var createdAddress = await _addressService.CreateAddress(address);

        var user = new User
        {
            Email = input.Email,
            UserName = input.FirstName + input.LastName,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Address = createdAddress,
            AddressId = createdAddress.Id,
            Token = "test",
            EmailConfirmed = true,
            ProfilePicture = "https://www.nicepng.com/png/detail/933-9332131_profile-picture-default-png.png"
        };

        var result = await _userManager.CreateAsync(user, input.Password);

        if(!result.Succeeded)
        {
            return BadRequest();
        }

        return new UserDTO
        {
            Email = user.Email,
            Username = user.Id,
            Token = _tokenService.CreateToken(user)
        };
    }
}
