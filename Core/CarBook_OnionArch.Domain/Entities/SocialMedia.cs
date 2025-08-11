namespace CarBook_OnionArch.Domain.Entities
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
