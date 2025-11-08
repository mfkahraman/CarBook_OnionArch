using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetGasolineCarCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetGasolineCarCountQuery, GetGasolineCarCountQueryResult>
    {
        public async Task<GetGasolineCarCountQueryResult> Handle(GetGasolineCarCountQuery request, CancellationToken cancellationToken)
        {
            var count = await repository.GetGasolineCarCountAsync(cancellationToken);
            return new GetGasolineCarCountQueryResult(count);
        }
    }
}
