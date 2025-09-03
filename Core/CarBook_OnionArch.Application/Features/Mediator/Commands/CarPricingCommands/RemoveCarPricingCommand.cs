using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarPricingCommands
{
    public record RemoveCarPricingCommand(int id): IRequest<bool>;
}
