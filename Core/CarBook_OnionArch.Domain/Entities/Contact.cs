namespace CarBook_OnionArch.Domain.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

    }
}
