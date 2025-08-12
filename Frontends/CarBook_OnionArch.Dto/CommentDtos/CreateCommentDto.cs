namespace CarBook_OnionArch.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
