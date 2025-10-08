namespace APPR.Models
{
    public class TaskAssignment
    {
        public int TaskAssignmentId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int MaxVolunteers { get; set; }
        public string Status { get; set; }
        public ICollection<VolunteerTask>? VolunteerTasks { get; set; }
    }

}
