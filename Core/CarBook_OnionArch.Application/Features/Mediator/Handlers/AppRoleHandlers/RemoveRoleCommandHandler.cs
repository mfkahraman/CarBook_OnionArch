using CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class RemoveRoleCommandHandler(IAppRoleRepository repository)
        : IRequestHandler<RemoveAppRoleCommand, bool>
    {
        public async Task<bool> Handle(RemoveAppRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteRoleAsync(request.id);
            if (!result.Succeeded)
            {
                throw new Exception("Role delete failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return true;
        }
    }
}
