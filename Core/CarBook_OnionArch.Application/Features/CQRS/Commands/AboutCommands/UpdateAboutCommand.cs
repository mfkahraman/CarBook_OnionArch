namespace CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands
{
    public record UpdateAboutCommand
    {
        public int Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
    }
}
