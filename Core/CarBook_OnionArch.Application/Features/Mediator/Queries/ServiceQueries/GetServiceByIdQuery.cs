using CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.ServiceQueries
{
    public record GetServiceByIdQuery(int Id) : IRequest<GetServiceByIdQueryResult>;
}
