using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var brandCount = await repository.GetBrandCountAsync(cancellationToken);
            return new GetBrandCountQueryResult(brandCount);
        }
    }
}
