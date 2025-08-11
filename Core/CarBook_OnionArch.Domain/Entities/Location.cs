namespace CarBook_OnionArch.Domain.Entities
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
