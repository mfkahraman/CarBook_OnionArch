using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands
{
    public record RemoveCommentCommand(int Id) : IRequest<bool>;
}
