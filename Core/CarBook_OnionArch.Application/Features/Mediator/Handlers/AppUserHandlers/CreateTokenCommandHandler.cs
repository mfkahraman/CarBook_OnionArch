using CarBook_OnionArch.Application.Features.Mediator.Commands.JWTCommands;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateTokenCommandHandler(IJWTRepository repository)
        : IRequestHandler<CreateTokenCommand, string>
    {
        public async Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return await repository.CreateTokenAsync(request.userName);
        }
    }
}
