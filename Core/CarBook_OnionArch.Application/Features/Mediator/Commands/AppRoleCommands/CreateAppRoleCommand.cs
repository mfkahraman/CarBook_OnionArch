using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands
{
    public class CreateAppRoleCommand() : IRequest<GetAppRoleByIdQueryResult>
    {
        public string? Name { get; set; }
    }
}
