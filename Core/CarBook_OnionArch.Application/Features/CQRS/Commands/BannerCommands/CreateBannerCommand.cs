namespace CarBook_OnionArch.Application.Features.CQRS.Commands.BannerCommands
{
    public record CreateBannerCommand
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public string? VideoDescription { get; init; }
        public string? VideoUrl { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
