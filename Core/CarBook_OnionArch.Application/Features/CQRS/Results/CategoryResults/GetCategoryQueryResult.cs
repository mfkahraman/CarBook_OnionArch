using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;

namespace CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<GetBlogsQueryResult>? Blogs { get; set; }
        public bool IsDeleted { get; set; }
    }
}
