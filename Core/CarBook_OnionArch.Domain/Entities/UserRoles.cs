namespace CarBook_OnionArch.Domain.Entities
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int RoleId { get; set; }
        public AppRole? Role { get; set; }
        public bool IsDeleted { get; set; }
    }
}
