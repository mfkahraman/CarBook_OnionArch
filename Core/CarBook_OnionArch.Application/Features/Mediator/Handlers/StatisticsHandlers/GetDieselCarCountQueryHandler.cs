using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetDieselCarCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetDieselCarCountQuery, GetDieselCarCountQueryResult>
    {
        public async Task<GetDieselCarCountQueryResult> Handle(GetDieselCarCountQuery request, CancellationToken cancellationToken)
        {
            var dieselCarCount = await repository.GetDieselCarCountAsync(cancellationToken);
            return new GetDieselCarCountQueryResult(dieselCarCount);
        }
    }
}
