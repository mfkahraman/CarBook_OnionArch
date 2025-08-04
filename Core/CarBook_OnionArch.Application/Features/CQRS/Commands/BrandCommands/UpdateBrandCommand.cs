namespace CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands
{
    public record UpdateBrandCommand
    {
        public int BrandId { get; init; }
        public required string Name { get; init; }
    }
}
