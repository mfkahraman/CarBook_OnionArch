using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands
{
    public record UpdateServiceCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public string? IconUrl { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
