namespace CarBook_OnionArch.Domain.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
