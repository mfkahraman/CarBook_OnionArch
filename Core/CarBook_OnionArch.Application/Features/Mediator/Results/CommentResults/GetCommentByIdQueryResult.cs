using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentByIdQueryResult
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
        public GetBlogByIdQueryResult? Blog { get; set; }
        public int AuthorId { get; set; }
        public GetAuthorByIdQueryResult? Author { get; set; }
    }
}
