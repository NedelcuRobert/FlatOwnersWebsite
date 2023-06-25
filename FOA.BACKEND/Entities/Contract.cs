namespace FOA.BACKEND.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public float Amount { get; set; }
        public string ServiceName { get; set; }
        public DateTime DataAdded { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
