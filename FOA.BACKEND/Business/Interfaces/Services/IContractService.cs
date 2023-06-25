using FOA.BACKEND.DataAccess.Repositories;
using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IContractService
    {
        Task<List<Contract>> GetAllContractsAsync();
        Task<Contract> GetContractByIdAsync(int contractId);

        Task<Contract> CreateContractAsync(Contract contract);

        Task<Contract> UpdateContractAsync(Contract contract);

        Task DeleteContractAsync(int contractId);
    }
}
