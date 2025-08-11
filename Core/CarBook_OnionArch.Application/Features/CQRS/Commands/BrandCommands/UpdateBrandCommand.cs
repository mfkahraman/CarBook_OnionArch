namespace CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands
{
    public record UpdateBrandCommand
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
