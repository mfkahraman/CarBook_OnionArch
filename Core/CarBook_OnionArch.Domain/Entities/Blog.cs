namespace CarBook_OnionArch.Domain.Entities
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Comment>? Comments { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
