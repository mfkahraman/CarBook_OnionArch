namespace CarBook_OnionArch.Domain.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
    }
}
