namespace CarBook_OnionArch.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public required string Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
    }
}
