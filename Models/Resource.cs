namespace APPR.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceType { get; set; }   // Food, Clothing, Medical
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Location { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Status { get; set; }         // Available, Allocated
        public ICollection<Allocation>? Allocations { get; set; }
    }
}