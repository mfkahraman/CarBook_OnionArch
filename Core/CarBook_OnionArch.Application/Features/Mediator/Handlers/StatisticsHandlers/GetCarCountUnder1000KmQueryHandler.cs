using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountUnder1000KmQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetCarCountUnder1000KmQuery, GetCarCountUnder1000KmQueryResult>
    {
        public async Task<GetCarCountUnder1000KmQueryResult> Handle(GetCarCountUnder1000KmQuery request, CancellationToken cancellationToken)
        {
            var carCount = await repository.GetCarCountUnder1000KmAsync(cancellationToken);
            return new GetCarCountUnder1000KmQueryResult(carCount);
        }
    }
}
