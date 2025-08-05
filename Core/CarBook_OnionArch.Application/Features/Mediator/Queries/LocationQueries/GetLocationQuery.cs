using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.LocationQueries
{
    public record GetLocationQuery : IRequest<List<GetLocationQueryResult>>;
}
