namespace CarBook_OnionArch.Application.Features.CQRS.Commands.ContactCommands
{
    public record UpdateContactCommand
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Email { get; init; }
        public required string Subject { get; init; }
        public required string Message { get; init; }
        public DateTime SendDate { get; init; }
    }
}
