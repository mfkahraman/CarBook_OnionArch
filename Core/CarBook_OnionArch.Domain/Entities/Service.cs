namespace CarBook_OnionArch.Domain.Entities
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
