namespace CarBook_OnionArch.Application.Features.CQRS.Results.ContactResults
{
    public class GetContactByIdQueryResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
