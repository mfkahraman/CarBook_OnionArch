using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class AddAppUserToRoleCommandHandler(IAppUserRepository repository)
        : IRequestHandler<AddAppUserToRoleCommand, bool>
    {
        public async Task<bool> Handle(AddAppUserToRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.AddUserToRoleAsync(request.userId, request.roleName);
            if (!result.Succeeded)
            {
                throw new Exception("ddUserToRole failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return true;
        }
    }
}
