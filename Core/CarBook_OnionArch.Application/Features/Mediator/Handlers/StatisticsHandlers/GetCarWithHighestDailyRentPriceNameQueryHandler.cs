using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarWithHighestDailyRentPriceNameQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetCarWithHighestDailyRentPriceNameQuery, GetCarWithHighestDailyRentPriceNameQueryResult>
    {
        public async Task<GetCarWithHighestDailyRentPriceNameQueryResult> Handle(GetCarWithHighestDailyRentPriceNameQuery request, CancellationToken cancellationToken)
        {
            var carName = await repository.GetCarWithHighestDailyRentPriceNameAsync(cancellationToken);
            return new GetCarWithHighestDailyRentPriceNameQueryResult(carName);
        }
    }
}
