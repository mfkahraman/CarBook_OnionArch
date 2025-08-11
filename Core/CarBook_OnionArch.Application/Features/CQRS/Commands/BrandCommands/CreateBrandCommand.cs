namespace CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public required string Name { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
