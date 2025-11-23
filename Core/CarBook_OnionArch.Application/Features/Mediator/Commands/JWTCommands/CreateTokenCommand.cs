using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.JWTCommands
{
    public record CreateTokenCommand(string userName) : IRequest<string>;
}
