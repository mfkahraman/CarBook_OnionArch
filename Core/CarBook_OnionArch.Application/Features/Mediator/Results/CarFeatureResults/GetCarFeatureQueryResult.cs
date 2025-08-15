using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public required GetFeatureQueryResult Feature { get; set; }
        public bool IsAvailable { get; set; }
    }
}
