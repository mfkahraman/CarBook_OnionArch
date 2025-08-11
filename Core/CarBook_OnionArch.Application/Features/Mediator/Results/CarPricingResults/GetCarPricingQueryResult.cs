using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public required GetPricingQueryResult Pricing { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }

    }
}
