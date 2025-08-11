using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogsQuery : IRequest<List<GetBlogsQueryResult>>;
}
