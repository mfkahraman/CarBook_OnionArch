namespace CarBook_OnionArch.Domain.Entities
{
    public class FooterAddress : IEntity
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
