using System.ComponentModel.DataAnnotations;

namespace FOA.BACKEND.Business.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Building { get; set; }
        [Required]
        public string ApartmentNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
