using Microsoft.AspNetCore.Identity;

namespace CarBook_OnionArch.Domain.Entities
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        [PersonalData]
        public required string FirstName { get; set; }
        [PersonalData]
        public required string LastName { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Rental>? Rentals { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<AppRole>? Roles { get; set; }
    }
}
