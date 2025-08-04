namespace CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandByIdQueryResult
    {
        public int BrandId { get; set; }
        public required string Name { get; set; }
    }
}
