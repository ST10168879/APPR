using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using APPR.Models;

namespace APPR.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Disaster> Disasters { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
    }
}