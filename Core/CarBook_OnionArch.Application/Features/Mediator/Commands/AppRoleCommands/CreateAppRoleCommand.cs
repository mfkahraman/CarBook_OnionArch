using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands
{
    public record CreateAppRoleCommand(string roleName) : IRequest<GetAppRoleByIdQueryResult>;
}