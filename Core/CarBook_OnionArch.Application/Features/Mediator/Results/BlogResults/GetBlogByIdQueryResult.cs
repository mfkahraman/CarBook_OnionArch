using CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
        public GetAuthorByIdQueryResult? Author { get; set; }
        public int CategoryId { get; set; }
        public GetCategoryByIdQueryResult? Category { get; set; }
        public List<GetCommentsQueryResult>? Comments { get; set; }
    }
}
