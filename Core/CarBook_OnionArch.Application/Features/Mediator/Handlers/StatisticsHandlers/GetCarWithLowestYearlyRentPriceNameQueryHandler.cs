using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarWithLowestYearlyRentPriceNameQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetCarWithLowestYearlyRentPriceNameQuery, GetCarWithLowestYearlyRentPriceNameQueryResult>
    {
        public async Task<GetCarWithLowestYearlyRentPriceNameQueryResult> Handle(GetCarWithLowestYearlyRentPriceNameQuery request, CancellationToken cancellationToken)
        {
            var car = await repository.GetCarWithLowestYearlyRentPriceNameAsync(cancellationToken);
            return new GetCarWithLowestYearlyRentPriceNameQueryResult(car);
        }
    }
}
