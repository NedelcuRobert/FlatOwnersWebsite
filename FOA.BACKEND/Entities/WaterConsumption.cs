namespace FOA.BACKEND.Entities
{
    public class WaterConsumption
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public int ColdKitchen { get; set; }   
        public int ColdBathroom { get; set;}
        public int HotKitchen { get; set; }
        public int HotBathroom { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
