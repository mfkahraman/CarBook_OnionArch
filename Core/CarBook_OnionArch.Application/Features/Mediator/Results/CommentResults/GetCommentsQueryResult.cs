namespace CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentsQueryResult
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorImageUrl { get; set; }


    }
}
