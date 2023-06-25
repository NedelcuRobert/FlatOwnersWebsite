namespace FOA.BACKEND.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string ApartmentNumber { get; set; }
        public int NumberOfPersons { get; set; }
        public int Surface { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DataAdded { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<WaterConsumption> WaterConsumptions { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
