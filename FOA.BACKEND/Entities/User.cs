using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace FOA.BACKEND.Entities
{
    public class User : IdentityUser
    {
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get;set; }
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public string Token { get; set; }

    }
}
