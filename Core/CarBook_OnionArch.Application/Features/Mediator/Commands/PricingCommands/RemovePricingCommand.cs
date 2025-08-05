using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.PricingCommands
{
    public record RemovePricingCommand(int Id) : IRequest<bool>;
}
