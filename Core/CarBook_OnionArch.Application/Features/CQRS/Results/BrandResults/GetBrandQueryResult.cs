namespace CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryResult
    {
        public int BrandId { get; set; }
        public required string Name { get; set; }
    }
}
