using CarBook_OnionArch.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.PricingQueries
{
    public record GetPricingQuery : IRequest<List<GetPricingQueryResult>>;
}
