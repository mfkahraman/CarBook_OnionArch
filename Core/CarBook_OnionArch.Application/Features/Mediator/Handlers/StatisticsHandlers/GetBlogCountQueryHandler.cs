using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var count = await repository.GetBlogCountAsync(cancellationToken);
            return new GetBlogCountQueryResult(count);
        }
    }
}
