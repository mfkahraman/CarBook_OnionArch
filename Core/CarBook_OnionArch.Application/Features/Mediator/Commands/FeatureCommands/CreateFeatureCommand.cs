using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands
{
    public record CreateFeatureCommand : IRequest<GetFeatureByIdQueryResult>
    {
        public required string Name { get; init; }
    }
}
