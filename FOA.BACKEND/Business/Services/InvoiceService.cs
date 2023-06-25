using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.EntityFrameworkCore;

namespace FOA.BACKEND.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Invoice, int> _invoiceRepository;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _invoiceRepository = unitOfWork.InvoiceRepository;
        }

        public async Task<List<InvoiceDTO>> GetInvoicesByApartmentIdAsync(int apartmentId)
        {
            var invoices = await _invoiceRepository.GetByFilter(i => i.ApartmentId == apartmentId)
                .ToListAsync();

            var invoiceDTOs = invoices.Select(i => new InvoiceDTO
            {
                ApartmentId = i.ApartmentId,
                Amount = i.Amount,
                CreationDate = i.CreationDate,
                DueDate = i.DueDate
            }).ToList();

            return invoiceDTOs;
        }

        public async Task<InvoiceDTO> GetInvoiceByIdAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                return null;
            }

            var invoiceDTO = new InvoiceDTO
            {
                ApartmentId = invoice.ApartmentId,
                Amount = invoice.Amount,
                CreationDate = invoice.CreationDate,
                DueDate = invoice.DueDate
            };

            return invoiceDTO;
        }

        public async Task<List<InvoiceDTO>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAll().ToListAsync();

            var invoiceDTOs = invoices.Select(i => new InvoiceDTO
            {
                ApartmentId = i.ApartmentId,
                Amount = i.Amount,
                CreationDate = i.CreationDate,
                DueDate = i.DueDate
            }).ToList();

            return invoiceDTOs;
        }

        public async Task CreateInvoiceAsync()
        {
            // 1. Get all apartments
            var apartments = await _unitOfWork.ApartmentRepository.GetAll().ToListAsync();

            // 2. Calculate the total salary from each Employee Salary row
            float totalSalary = await _unitOfWork.EmployeeRepository.GetAll().SumAsync(s => s.Salary);

            // 3. Calculate total pay amount from each Contract
            float totalPayAmount = await _unitOfWork.ContractRepository.GetAll().SumAsync(c => c.Amount);

            // 4. Divide costs to sum of people from all apartments
            int totalPeopleCount = apartments.Sum(a => a.NumberOfPersons);
            float costsPerPerson = (totalPayAmount + totalSalary ) / totalPeopleCount;

            // 5. Create invoices for each apartment with pay amount = number of persons * costs
            foreach (var apartment in apartments)
            {
                float invoiceAmount = apartment.NumberOfPersons * costsPerPerson;

                var waterConsumption = await _unitOfWork.WaterConsumptionRepository.
                    GetByFilter(w => w.ApartmentId == apartment.Id).ToListAsync();

                var lastConsumption = waterConsumption.LastOrDefault();

                var pay = lastConsumption != null ? invoiceAmount + 10 * (lastConsumption.HotKitchen + lastConsumption.ColdKitchen +
                    lastConsumption.ColdBathroom + lastConsumption.ColdKitchen) : invoiceAmount;

                var newInvoice = new Invoice
                {
                    ApartmentId = apartment.Id,
                    Amount = pay,
                    CreationDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(30),
                    IsPaid = false
                };

                await _invoiceRepository.AddAsync(newInvoice);
            }

            _unitOfWork.Save();
        }

        public async Task DeleteInvoiceAsync(int invoiceId)
        {
            await _invoiceRepository.RemoveAsync(invoiceId);
            _unitOfWork.Save();
        }

        public async Task MarkInvoiceAsPaidAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                return;
            }

            invoice.IsPaid = true;
            _invoiceRepository.Update(invoice);
            _unitOfWork.Save();
        }
    }
}
