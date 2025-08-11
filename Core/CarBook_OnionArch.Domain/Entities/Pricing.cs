namespace CarBook_OnionArch.Domain.Entities
{
    public class Pricing : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CarPricing>? CarPricings { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
