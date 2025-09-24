namespace CarBook_OnionArch.Application.Features.CQRS.Commands.CategoryCommands
{
    public record CreateCategoryCommand
    {
        public required string Name { get; init; }
    }
}
