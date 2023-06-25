using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FOA.BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("{contractId}")]
        public async Task<ActionResult<Contract>> GetContractById(int contractId)
        {
            var contract = await _contractService.GetContractByIdAsync(contractId);

            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        [HttpGet]
        public async Task<ActionResult<List<Contract>>> GetAll()
        {
            var contracts = await _contractService.GetAllContractsAsync();

            if (contracts == null)
            {
                return NotFound();
            }

            return Ok(contracts);
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> CreateContract([FromBody] ContractDTO contractDTO)
        {
            var contract = new Contract
            {
                ProviderName = contractDTO.ProviderName,
                Amount = contractDTO.Amount,
                ServiceName = contractDTO.ServiceName,
                DataAdded = DateTime.UtcNow,
            };

            var createdContract = await _contractService.CreateContractAsync(contract);

            return Ok(createdContract);
        }

        [HttpPut("{contractId}")]
        public async Task<ActionResult<Contract>> UpdateContract(int contractId, [FromBody] ContractDTO contractDTO)
        {
            var existingContract = await _contractService.GetContractByIdAsync(contractId);

            if (existingContract == null)
            {
                return NotFound();
            }

            existingContract.ProviderName = contractDTO.ProviderName;
            existingContract.Amount = contractDTO.Amount;
            existingContract.ServiceName = contractDTO.ServiceName;
            // Actualizează și alte proprietăți, după caz

            var updatedContract = await _contractService.UpdateContractAsync(existingContract);

            return Ok(updatedContract);
        }

        [HttpDelete("{contractId}")]
        public async Task<ActionResult> DeleteContract(int contractId)
        {
            var existingContract = await _contractService.GetContractByIdAsync(contractId);

            if (existingContract == null)
            {
                return NotFound();
            }

            await _contractService.DeleteContractAsync(contractId);

            return NoContent();
        }
    }
}
