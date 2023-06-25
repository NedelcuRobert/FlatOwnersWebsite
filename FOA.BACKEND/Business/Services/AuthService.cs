using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using FOA.BACKEND.Business.Interfaces.Services;

namespace FOA.BACKEND.Business.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly JwtSecurityTokenHandler _jwtHandler;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IEmailSender _emailSender;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<SignInResult> Authenticate(LoginDTO input)
    {
        var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, true, false);

        return result;
        
    }

    public async Task<bool> AddUser(RegisterDTO input)
    {


        return true;
    }

    public async Task<string> CreateJwtToken(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var key = Encoding.ASCII.GetBytes("key");

        var identity = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Role, roles.First()),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
        });

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials
        };

        var token = _jwtHandler.CreateToken(tokenDescriptor);

        return _jwtHandler.WriteToken(token);
    }

}
