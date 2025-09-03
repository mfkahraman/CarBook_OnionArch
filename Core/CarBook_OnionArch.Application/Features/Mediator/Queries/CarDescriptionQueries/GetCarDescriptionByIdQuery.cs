using CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public record GetCarDescriptionByIdQuery(int id) : IRequest<GetCarDescriptionByIdQueryResult>;
}
