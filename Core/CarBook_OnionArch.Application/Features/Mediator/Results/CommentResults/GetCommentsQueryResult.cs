using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentsQueryResult
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
