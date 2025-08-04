namespace CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }

    }
}
