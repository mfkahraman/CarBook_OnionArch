using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class RemoveAppUserCommandHandler(IAppUserRepository repository)
        : IRequestHandler<RemoveAppUserCommand, bool>
    {
        public async Task<bool> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteUserAsync(request.Id);
            if (!result.Succeeded)
            {
                throw new Exception("User delete failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return true;
        }
    }
}