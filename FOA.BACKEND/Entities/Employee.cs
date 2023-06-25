namespace FOA.BACKEND.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public float Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DataAdded { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
