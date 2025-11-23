using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands
{
    public record AddAppUserToRoleCommand(int userId, string roleName) : IRequest<bool>;
}
