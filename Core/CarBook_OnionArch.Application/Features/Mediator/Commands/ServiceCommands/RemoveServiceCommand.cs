using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands
{
    public record RemoveServiceCommand(int Id) : IRequest<bool>;
}
