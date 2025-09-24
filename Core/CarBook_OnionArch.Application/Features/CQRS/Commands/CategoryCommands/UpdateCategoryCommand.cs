namespace CarBook_OnionArch.Application.Features.CQRS.Commands.CategoryCommands
{
    public record UpdateCategoryCommand
    {
        public int Id { get; init; }
        public required string Name { get; init; }
    }
}
