namespace CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogsQueryResult
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
