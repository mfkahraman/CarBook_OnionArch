using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAverageWeeklyRentPriceQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetAverageWeeklyRentPriceQuery, GetAverageWeeklyRentPriceQueryResult>
    {
        public async Task<GetAverageWeeklyRentPriceQueryResult> Handle(GetAverageWeeklyRentPriceQuery request, CancellationToken cancellationToken)
        {
            var price = await repository.GetAverageWeeklyRentPriceAsync(cancellationToken);
            return new GetAverageWeeklyRentPriceQueryResult(price);
        }
    }
}
