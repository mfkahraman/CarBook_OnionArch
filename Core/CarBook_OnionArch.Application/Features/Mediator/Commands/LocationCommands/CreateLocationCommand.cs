using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands
{
    public record CreateLocationCommand : IRequest<GetLocationByIdQueryResult>
    {
        public required string Name { get; init; }
        public bool IsDeleted { get; init; } = false;


    }
}
