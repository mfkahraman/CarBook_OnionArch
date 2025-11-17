using System.ComponentModel.DataAnnotations;

namespace CarBook_OnionArch.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public List<Rental>? Rentals { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Review>? Reviews { get; set; }
    }
}
