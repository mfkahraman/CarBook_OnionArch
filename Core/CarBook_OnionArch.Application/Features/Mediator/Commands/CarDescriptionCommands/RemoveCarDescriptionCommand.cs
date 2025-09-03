using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public record RemoveCarDescriptionCommand(int id) : IRequest<bool>;
}
