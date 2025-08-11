using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.BlogCommands
{
    public record RemoveBlogCommand(int Id) : IRequest<bool>;
}
