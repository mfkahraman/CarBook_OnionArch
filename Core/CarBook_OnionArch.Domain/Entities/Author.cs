namespace CarBook_OnionArch.Domain.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<Blog>? Blogs { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Comment>? Comments { get; set; }

    }
}
