namespace CarBook_OnionArch.Domain.Entities
{
    public class CarFeature : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public required Car Car { get; set; }
        public int FeatureId { get; set; }
        public required Feature Feature { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
