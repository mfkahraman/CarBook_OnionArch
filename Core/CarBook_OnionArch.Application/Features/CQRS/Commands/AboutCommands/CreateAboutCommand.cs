namespace CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands
{
    public record CreateAboutCommand
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
