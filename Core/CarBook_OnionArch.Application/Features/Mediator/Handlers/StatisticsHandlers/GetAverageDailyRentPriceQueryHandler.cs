using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAverageDailyRentPriceQueryHandler
        (IStatisticsRepository repository)
        : IRequestHandler<GetAverageDailyRentPriceQuery, GetAverageDailyRentPriceQueryResult>
    {
        public async Task<GetAverageDailyRentPriceQueryResult> Handle(GetAverageDailyRentPriceQuery request, CancellationToken cancellationToken)
        {
            var averagePrice = await repository.GetAverageDailyRentPriceAsync(cancellationToken);
            return new GetAverageDailyRentPriceQueryResult(averagePrice);
        }
    }
}
