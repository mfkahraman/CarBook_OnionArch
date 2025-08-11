namespace CarBook_OnionArch.Domain.Entities
{
    public class CarDescription : IEntity
    {
        public int Id { get; set; }
        public required string Detail { get; set; }
        public int CarId { get; set; }
        public required Car Car { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
