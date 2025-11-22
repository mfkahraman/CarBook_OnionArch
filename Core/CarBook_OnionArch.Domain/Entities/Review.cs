namespace CarBook_OnionArch.Domain.Entities
{
    public class Review : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
