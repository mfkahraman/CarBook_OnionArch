using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands
{
    public record RemoveAppRoleCommand(int id) : IRequest<bool>;
}
