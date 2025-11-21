namespace CarBook_OnionArch.Domain.Entities
{
    public class AppRole : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<User>? Users { get; set; }
        public bool IsDeleted { get; set; }
    }
}
