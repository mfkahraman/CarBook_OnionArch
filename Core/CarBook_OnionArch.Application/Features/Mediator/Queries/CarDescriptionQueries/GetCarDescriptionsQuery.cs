using CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public record GetCarDescriptionsQuery : IRequest<List<GetCarDescriptionQueryResult>>;
}
