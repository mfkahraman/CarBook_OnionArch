namespace CarBook_OnionArch.Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public required string Name { get; set; }
        public List<CarPricing>? CarPricings { get; set; }
    }
}
