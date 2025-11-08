using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetLocationCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var locationCount = await repository.GetLocationCountAsync(cancellationToken);
            return new GetLocationCountQueryResult(locationCount);
        }
    }
}
