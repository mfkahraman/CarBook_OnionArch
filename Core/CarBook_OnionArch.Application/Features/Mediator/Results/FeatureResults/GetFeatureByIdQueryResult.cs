namespace CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureByIdQueryResult
    {
        public int FeatureId { get; set; }
        public required string Name { get; set; }
    }
}
