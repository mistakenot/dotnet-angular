using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Server.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int AccountId { get; set; }
    }
}
