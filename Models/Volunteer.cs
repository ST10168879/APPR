namespace APPR.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public string FullName { get; set; }
        public string ContactInfo { get; set; }
        public string Skills { get; set; }
        public ICollection<VolunteerTask>? VolunteerTasks { get; set; }
    }

    public class VolunteerTask
    {
        public int VolunteerTaskId { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer? Volunteer { get; set; }
        public int TaskAssignmentId { get; set; }
        public TaskAssignment? TaskAssignment { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
    }
}
