using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AuthorCommands
{
    public class CreateAuthorCommand : IRequest<GetAuthorByIdQueryResult>
    {
        public required string FullName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
