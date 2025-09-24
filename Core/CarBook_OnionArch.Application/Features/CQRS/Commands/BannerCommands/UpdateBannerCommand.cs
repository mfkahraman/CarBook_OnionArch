namespace CarBook_OnionArch.Application.Features.CQRS.Commands.BannerCommands
{
    public record UpdateBannerCommand
    {
        public int Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public string? VideoDescription { get; init; }
        public string? VideoUrl { get; init; }
    }
}
