namespace CarBook_OnionArch.Domain.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Car>? Cars { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
