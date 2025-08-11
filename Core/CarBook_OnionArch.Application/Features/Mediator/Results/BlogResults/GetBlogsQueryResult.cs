namespace CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogsQueryResult
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? AuthorName { get; set; }
        public string? CategoryName { get; set; }
    }
}
