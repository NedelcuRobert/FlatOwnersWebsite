using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.Interfaces;

public interface IUnitOfWork
{
    IBaseRepository<Apartment, int> ApartmentRepository { get; set; }
    IBaseRepository<Address, int> AddressRepository { get; set; }
    IBaseRepository<User, string> UserRepository { get; set; }
    IBaseRepository<Announcement, int> AnnouncementRepository { get; set; }
    IBaseRepository<Contract, int> ContractRepository { get; set; }
    IBaseRepository<Employee, int> EmployeeRepository { get; set; }
    IBaseRepository<Invoice, int> InvoiceRepository { get; set; }
    IBaseRepository<Request, int> RequestRepository { get; set; }
    IBaseRepository<WaterConsumption, int> WaterConsumptionRepository { get; set; }
    void Save();
}