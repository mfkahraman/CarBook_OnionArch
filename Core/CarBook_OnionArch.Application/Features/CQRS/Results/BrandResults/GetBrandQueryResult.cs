namespace CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
