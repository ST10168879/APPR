namespace APPR.Models
{
    public class Allocation
    {
        public int AllocationId { get; set; }
        public int DisasterId { get; set; }
        public Disaster? Disaster { get; set; }
        public int ResourceId { get; set; }
        public Resource? Resource { get; set; }
        public int QuantityAllocated { get; set; }
        public DateTime AllocationDate { get; set; } = DateTime.UtcNow;
    }
}