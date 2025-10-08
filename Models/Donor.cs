namespace APPR.Models;

public class Donor
{
    public int DonorId { get; set; }
    public string DonorName { get; set; }
    public string ContactInfo { get; set; }
    public ICollection<Donation>? Donations { get; set; }
}

