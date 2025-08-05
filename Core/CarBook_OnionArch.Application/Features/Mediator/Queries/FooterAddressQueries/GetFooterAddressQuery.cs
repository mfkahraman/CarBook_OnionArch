using CarBook_OnionArch.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public record GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>;
}
