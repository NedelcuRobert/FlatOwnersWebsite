using FOA.BACKEND.Entities;

namespace FOA.BACKEND.Business.DTO
{
    public class ProfileDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int ApartmentNumber { get; set; }
        public string PhoneNumber { get; set; } 
        public string ProfilePicture { get; set; }
    }
}
