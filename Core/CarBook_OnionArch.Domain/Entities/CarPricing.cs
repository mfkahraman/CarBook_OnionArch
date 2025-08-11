namespace CarBook_OnionArch.Domain.Entities
{
    public class CarPricing : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public required Car Car { get; set; }
        public int PricingId { get; set; }
        public required Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
