using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.Business.Services
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Contract, int> _contractRepository;

        public ContractService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _contractRepository = unitOfWork.ContractRepository;
        }

        public async Task<List<Contract>> GetAllContractsAsync()
        {
            return await _contractRepository.GetAll().ToListAsync();
        }

        public async Task<Contract> GetContractByIdAsync(int contractId)
        {
            return await _contractRepository.GetByIdAsync(contractId);
        }

        public async Task<Contract> CreateContractAsync(Contract contract)
        {
            await _contractRepository.AddAsync(contract);
            _unitOfWork.Save();

            return contract;
        }

        public async Task<Contract> UpdateContractAsync(Contract contract)
        {
            var existingContract = await _contractRepository.GetByIdAsync(contract.Id);
            if (existingContract == null)
            {
                // Contractul nu există în baza de date, poți arunca o excepție sau trata cazul în alt mod
                return null;
            }

            // Actualizăm câmpurile contractului existent cu valorile din contractul actualizat
            existingContract.ProviderName = contract.ProviderName;
            existingContract.Amount = contract.Amount;
            existingContract.ServiceName = contract.ServiceName;
            // Actualizează și alte câmpuri, după caz

            _contractRepository.Update(existingContract);
            _unitOfWork.Save();

            return existingContract;
        }

        public async Task DeleteContractAsync(int contractId)
        {
            await _contractRepository.RemoveAsync(contractId);
            _unitOfWork.Save();
        }
    }
}
