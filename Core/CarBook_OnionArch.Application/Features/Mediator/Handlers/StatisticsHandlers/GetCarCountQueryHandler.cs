using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler(IStatisticsRepository repository) 
        : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var count = await repository.GetCarCountAsync();
            return new GetCarCountQueryResult { CarCount = count };
        }
    }
}
