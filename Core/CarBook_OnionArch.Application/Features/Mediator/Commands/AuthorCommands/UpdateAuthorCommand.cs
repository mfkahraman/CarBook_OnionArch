using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
