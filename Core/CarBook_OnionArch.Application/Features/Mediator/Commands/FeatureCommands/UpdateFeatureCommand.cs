using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands
{
    public record UpdateFeatureCommand : IRequest<bool>
    {
        public int FeatureId { get; init; }
        public required string Name { get; init; }
    }
}
