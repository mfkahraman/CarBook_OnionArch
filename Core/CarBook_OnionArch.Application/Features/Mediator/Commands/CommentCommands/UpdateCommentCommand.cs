using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CommentCommands
{
    public record UpdateCommentCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public required string Content { get; init; }
        public DateTime CreatedDate { get; init; }
        public int BlogId { get; init; }
        public int AuthorId { get; init; }
    }
}
