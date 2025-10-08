using System.ComponentModel.DataAnnotations;

namespace APPR.Models
{
    public class Disaster
    {
        public int DisasterId { get; set; }
        [Required] public string DisasterType { get; set; }
        [Required] public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Severity { get; set; }    // 1..5
        public string Status { get; set; }   // e.g. Active, Resolved
        public string Description { get; set; }
        public string AffectedArea { get; set; }
        public ICollection<Victim>? Victims { get; set; }
        public ICollection<Allocation>? Allocations { get; set; }
    }
}