using Microsoft.AspNetCore.Identity;

namespace APPR.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}