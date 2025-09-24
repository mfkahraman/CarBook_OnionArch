using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands
{
    public record UpdateLocationCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public required string Name { get; init; }
    }
}
