namespace CarBook_OnionArch.Domain.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public required string Name { get; set; }
        public List<CarFeature>? CarFeatures { get; set; }
    }
}
