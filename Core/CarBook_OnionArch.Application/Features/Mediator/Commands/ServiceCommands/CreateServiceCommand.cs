using CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands
{
    public record CreateServiceCommand : IRequest<GetServiceByIdQueryResult>
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public string? IconUrl { get; init; }
    }
}
