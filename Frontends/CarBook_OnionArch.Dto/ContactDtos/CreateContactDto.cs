namespace CarBook_OnionArch.Dto.ContactDtos
{
    public class CreateContactDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
