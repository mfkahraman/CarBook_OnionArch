using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAutomaticTransmissionCarCountQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetAutomaticTransmissionCarCountQuery, GetAutomaticTransmissionCarCountQueryResult>
    {
        public async Task<GetAutomaticTransmissionCarCountQueryResult> Handle(GetAutomaticTransmissionCarCountQuery request, CancellationToken cancellationToken)
        {
            var count = await repository.GetAutomaticTransmissionCarCountAsync();
            return new GetAutomaticTransmissionCarCountQueryResult(count);
        }
    }
}
