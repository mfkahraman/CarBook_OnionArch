using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands
{
    public record RemoveAuthorCommand(int Id) : IRequest<bool>;
}
