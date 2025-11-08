using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandWithMostCarsNameQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetBrandWithMostCarsNameQuery, GetBrandWithMostCarsNameQueryResult>
    {
        public async Task<GetBrandWithMostCarsNameQueryResult> Handle(GetBrandWithMostCarsNameQuery request, CancellationToken cancellationToken)
        {
            var brandName = await repository.GetBrandWithMostCarsNameAsync(cancellationToken);
            return new GetBrandWithMostCarsNameQueryResult(brandName);
        }
    }
}
