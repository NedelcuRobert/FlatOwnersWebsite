using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.Business.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork requestRepository)
        {
            _unitOfWork = requestRepository;
        }

        public async Task<Request> GetRequestByIdAsync(int requestId)
        {
            return await _unitOfWork.RequestRepository.GetByIdAsync(requestId);
        }

        public async Task<List<Request>> GetActiveRequestsAsync(string userId)
        {
            return await _unitOfWork.RequestRepository.GetByFilter(r => r.UserId == userId && r.IsActive).ToListAsync();
        }

        public async Task<Request> CreateRequestAsync(Request request)
        {
            await _unitOfWork.RequestRepository.AddAsync(request);
            _unitOfWork.Save(); // Salvăm modificările în unitatea de lucru
            return request;
        }

        public async Task<Request> UpdateRequestAsync(Request request)
        {
            var existingRequest = await _unitOfWork.RequestRepository.GetByIdAsync(request.Id);
            if (existingRequest == null)
            {
                // Cererea nu există în baza de date, poți arunca o excepție sau trata cazul în alt mod
                return null;
            }

            // Actualizăm câmpurile cererii existente cu valorile din cererea actualizată
            existingRequest.Title = request.Title;
            existingRequest.Message = request.Message;
            existingRequest.Priority = request.Priority;    
            existingRequest.IsActive = request.IsActive;
            // Actualizează și alte câmpuri, după caz

            _unitOfWork.RequestRepository.Update(existingRequest);
            _unitOfWork.Save(); // Salvăm modificările în unitatea de lucru

            return existingRequest;
        }

        public async Task DeleteRequestAsync(int requestId)
        {
            // Validează dacă utilizatorul are drepturi de ștergere asupra cererii

            await _unitOfWork.RequestRepository.RemoveAsync(requestId);
            _unitOfWork.Save(); // Salvăm modificările în unitatea de lucru
        }
    }
}
