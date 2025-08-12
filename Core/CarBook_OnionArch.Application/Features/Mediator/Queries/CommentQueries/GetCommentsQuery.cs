using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.CommentQueries
{
    public record GetCommentsQuery : IRequest<List<GetCommentsQueryResult>>;
}
