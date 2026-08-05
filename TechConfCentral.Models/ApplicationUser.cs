using Microsoft.AspNetCore.Identity;

namespace TechConfCentral.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Many-to-many relationship
        public ICollection<SavedTalk> SavedTalks { get; set; } = new List<SavedTalk>();
    }
}
