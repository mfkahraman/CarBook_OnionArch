using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public record RemoveCarFeatureCommand(int Id) : IRequest<bool>;
}
