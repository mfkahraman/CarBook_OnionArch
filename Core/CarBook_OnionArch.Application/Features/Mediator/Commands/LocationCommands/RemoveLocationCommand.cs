using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands
{
    public record RemoveLocationCommand(int Id) : IRequest<bool>;
}
