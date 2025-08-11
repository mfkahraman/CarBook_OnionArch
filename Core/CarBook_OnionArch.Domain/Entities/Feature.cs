namespace CarBook_OnionArch.Domain.Entities
{
    public class Feature : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CarFeature>? CarFeatures { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
