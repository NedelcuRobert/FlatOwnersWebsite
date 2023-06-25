namespace FOA.BACKEND.Business.DTO
{
    public class InvoiceDTO
    {
        public int ApartmentId { get; set; }
        public float Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
