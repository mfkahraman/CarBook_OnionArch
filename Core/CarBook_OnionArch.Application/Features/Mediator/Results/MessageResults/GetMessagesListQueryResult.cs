namespace CarBook_OnionArch.Application.Features.Mediator.Results.MessageResults
{
    public class GetMessagesListQueryResult
    {
        public int Id { get; set; }
        public required string Sender { get; set; }
        public int SenderId { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
