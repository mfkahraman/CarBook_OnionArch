using CarBook_OnionArch.Application.Features.CQRS.Results.BrandResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarPricingResults;

namespace CarBook_OnionArch.Application.Features.CQRS.Results.CarResults
{
    public class GetCarWithAllQueryResult
    {
        public int CarId { get; set; }
        public string? Model { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? BigImageUrl { get; set; }
        public int BrandId { get; set; }
        public required GetBrandQueryResult Brand { get; set; }
        public List<GetCarFeatureQueryResult>? CarFeatures { get; set; }
        public List<GetCarDescriptionQueryResult>? CarDescriptions { get; set; }
        public List<GetCarPricingQueryResult>? CarPricings { get; set; }
    }
}
