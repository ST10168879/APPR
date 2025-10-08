namespace APPR.Models
{
    public class Victim
    {
        public int VictimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }
        public string NeedsAssessment { get; set; }
        public int DisasterId { get; set; }
        public Disaster? Disaster { get; set; }
    }
}