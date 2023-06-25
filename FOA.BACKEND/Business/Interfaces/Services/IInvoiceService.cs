using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDTO>> GetInvoicesByApartmentIdAsync(int apartmentId);
        Task<InvoiceDTO> GetInvoiceByIdAsync(int invoiceId);
        Task<List<InvoiceDTO>> GetAllInvoicesAsync();
        Task CreateInvoiceAsync();
        Task DeleteInvoiceAsync(int invoiceId);
        Task MarkInvoiceAsPaidAsync(int invoiceId);
    }
}
