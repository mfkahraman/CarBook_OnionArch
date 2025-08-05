using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands
{
    public record UpdatePricingCommand : IRequest<bool>
    {
        public int PricingId { get; init; }
        public required string Name { get; init; }
    }
}
