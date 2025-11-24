using CarBook_OnionArch.Application.Features.Mediator.Results.MessageResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.MessageQueries
{
    public record GetMessagesListQuery : IRequest<List<GetMessagesListQueryResult>>;
}
