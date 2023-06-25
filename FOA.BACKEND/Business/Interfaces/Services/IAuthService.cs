using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> CreateJwtToken(User user);
    }
}
