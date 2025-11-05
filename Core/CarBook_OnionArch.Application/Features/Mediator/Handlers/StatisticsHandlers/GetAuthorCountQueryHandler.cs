using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAuthorCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var count = await repository.GetAuthorCountAsync(cancellationToken);
            return new GetAuthorCountQueryResult(count);
        }
    }
}
