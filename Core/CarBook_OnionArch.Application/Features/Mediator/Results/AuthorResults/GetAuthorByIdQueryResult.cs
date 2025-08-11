using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults
{
    public class GetAuthorByIdQueryResult
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<GetBlogsQueryResult>? Blogs { get; set; }
        public bool IsDeleted { get; set; }
    }
}
