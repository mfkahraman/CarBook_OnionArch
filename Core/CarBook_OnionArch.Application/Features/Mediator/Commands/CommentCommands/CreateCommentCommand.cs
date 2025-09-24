using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands
{
    public record CreateCommentCommand : IRequest<GetCommentByIdQueryResult>
    {
        public required string Content { get; init; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public int BlogId { get; init; }
        public int AuthorId { get; init; }
    }
}
