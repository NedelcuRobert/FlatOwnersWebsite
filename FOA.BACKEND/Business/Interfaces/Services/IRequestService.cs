using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IRequestService
    {
        Task<Request> GetRequestByIdAsync(int requestId);
        Task<List<Request>> GetActiveRequestsAsync(string userId);
        Task<Request> CreateRequestAsync(Request request);
        Task<Request> UpdateRequestAsync(Request request);
        Task DeleteRequestAsync(int requestId);
    }
}
