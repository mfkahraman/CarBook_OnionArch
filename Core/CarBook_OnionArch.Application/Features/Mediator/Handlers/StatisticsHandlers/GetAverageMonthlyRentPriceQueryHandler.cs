using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAverageMonthlyRentPriceQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetAverageMonthlyRentPriceQuery, GetAverageMonthlyRentPriceQueryResult>
    {
        public async Task<GetAverageMonthlyRentPriceQueryResult> Handle(GetAverageMonthlyRentPriceQuery request, CancellationToken cancellationToken)
        {
            var averageMonthlyRentPrice = await repository.GetAverageMonthlyRentPriceAsync(cancellationToken);
            return new GetAverageMonthlyRentPriceQueryResult(averageMonthlyRentPrice);
        }
    }
}
