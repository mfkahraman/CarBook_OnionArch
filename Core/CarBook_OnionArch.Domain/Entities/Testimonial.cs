namespace CarBook_OnionArch.Domain.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }
        public required string Comment { get; set; }
        public string? ImageUrl { get; set; }
    }
}
