using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.DataAccess.EFCore;
using FOA.BACKEND.Entities;

namespace FOA.BACKEND.DataAccess.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly FOAContext _dbContext;
    private bool disposedValue;

    public IBaseRepository<Apartment, int> ApartmentRepository { get; set; }
    public IBaseRepository<Address, int> AddressRepository { get; set; }
    public IBaseRepository<User, string> UserRepository { get; set; }
    public IBaseRepository<Announcement, int> AnnouncementRepository { get; set; }
    public IBaseRepository<Contract, int> ContractRepository { get; set; }
    public IBaseRepository<Employee, int> EmployeeRepository { get; set; }
    public IBaseRepository<Invoice, int> InvoiceRepository { get; set; }
    public IBaseRepository<Request, int> RequestRepository { get; set; }
    public IBaseRepository<WaterConsumption, int> WaterConsumptionRepository { get; set; }

    public UnitOfWork(
        FOAContext dbContext,
        IBaseRepository<Apartment, int> apartmentRepository,
        IBaseRepository<Address, int> addressRepository,
        IBaseRepository<User, string> userRepository,
        IBaseRepository<Announcement, int> announcementRepository,
        IBaseRepository<Contract, int> contractRepository,
        IBaseRepository<Employee, int> employeeRepository,
        IBaseRepository<Invoice, int> invoiceRepository,
        IBaseRepository<Request, int> requestRepository,
        IBaseRepository<WaterConsumption, int> waterConsumptionRepository
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        ApartmentRepository = apartmentRepository ?? throw new ArgumentNullException(nameof(apartmentRepository));
        AddressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        AnnouncementRepository = announcementRepository ?? throw new ArgumentNullException(nameof(announcementRepository));
        ContractRepository = contractRepository ?? throw new ArgumentNullException(nameof(contractRepository));
        EmployeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        InvoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        RequestRepository = requestRepository ?? throw new ArgumentNullException(nameof(requestRepository));
        WaterConsumptionRepository = waterConsumptionRepository ?? throw new ArgumentNullException(nameof(waterConsumptionRepository));

    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}