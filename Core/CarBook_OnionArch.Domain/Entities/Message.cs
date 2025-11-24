namespace CarBook_OnionArch.Domain.Entities
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public required string Sender { get; set; }
        public int SenderId { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public AppUser? SenderUser { get; set; }
    }
}
