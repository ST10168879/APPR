namespace APPR.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public int? DonorId { get; set; }
        public Donor? Donor { get; set; }
        public string DonationType { get; set; } // Resource | Cash
        public int? ResourceId { get; set; }
        public Resource? Resource { get; set; }
        public int Quantity { get; set; }
        public decimal? Amount { get; set; }    // if cash
        public DateTime DonationDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } // Pending, Collected, Distributed
    }
}
