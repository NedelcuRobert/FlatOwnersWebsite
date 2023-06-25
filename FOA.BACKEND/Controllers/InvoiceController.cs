using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FOA.BACKEND.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("apartment/{apartmentId}")]
        public async Task<ActionResult<List<InvoiceDTO>>> GetInvoicesByApartmentId(int apartmentId)
        {
            var invoices = await _invoiceService.GetInvoicesByApartmentIdAsync(apartmentId);
            return Ok(invoices);
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<InvoiceDTO>> GetInvoiceById(int invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceDTO>>> GetAll()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            if (invoices == null)
            {
                return NotFound();
            }
            return Ok(invoices);
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice()
        {
            await _invoiceService.CreateInvoiceAsync();
            return Ok();
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            await _invoiceService.DeleteInvoiceAsync(invoiceId);
            return NoContent();
        }

        [HttpPost("{invoiceId}/markaspaid")]
        public async Task<IActionResult> MarkInvoiceAsPaid(int invoiceId)
        {
            await _invoiceService.MarkInvoiceAsPaidAsync(invoiceId);
            return NoContent();
        }
    }
}
