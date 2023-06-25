namespace FOA.BACKEND.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public float Amount { get; set; }
        public DateTime CreationDate {get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
