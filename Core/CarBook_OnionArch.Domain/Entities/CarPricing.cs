namespace CarBook_OnionArch.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public required Car Car { get; set; }
        public int PricingId { get; set; }
        public required Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
