using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Domain.Entities
{
    public class AppRole : IdentityRole<int>, IEntity
    {
        public List<AppUser>? AppUsers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
