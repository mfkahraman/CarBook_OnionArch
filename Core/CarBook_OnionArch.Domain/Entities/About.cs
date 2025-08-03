namespace CarBook_OnionArch.Domain.Entities
{
    public class About
    {
        public int AboutID { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
