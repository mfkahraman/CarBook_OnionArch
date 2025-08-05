using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.LocationQueries
{
    public record GetLocationByIdQuery(int Id) : IRequest<GetLocationByIdQueryResult>;
}
