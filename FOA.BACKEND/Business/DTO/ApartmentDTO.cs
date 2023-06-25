using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.DTO
{
    public class ApartmentDTO
    {
        public string UserId { get; set; }
        public int NumberOfPersons { get; set; }
        public int Surface { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
