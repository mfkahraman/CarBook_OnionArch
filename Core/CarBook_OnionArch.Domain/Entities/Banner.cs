namespace CarBook_OnionArch.Domain.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoUrl { get; set; }
    }
}
