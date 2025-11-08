using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAverageWeeklyRentPriceQuery : IRequest<GetAverageWeeklyRentPriceQueryResult>;
}
