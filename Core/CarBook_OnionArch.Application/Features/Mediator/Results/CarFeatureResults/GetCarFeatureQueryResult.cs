using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureQueryResult
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public required GetFeatureQueryResult Feature { get; set; }
        public bool IsAvailable { get; set; }
    }
}
