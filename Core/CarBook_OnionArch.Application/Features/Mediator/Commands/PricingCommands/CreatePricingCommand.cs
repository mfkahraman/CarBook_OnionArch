using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands
{
    public record CreatePricingCommand : IRequest<GetPricingByIdQueryResult>
    {
        public required string Name { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
