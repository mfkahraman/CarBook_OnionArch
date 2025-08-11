namespace CarBook_OnionArch.Domain.Entities
{
    public class About : IEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
