using CarBook_OnionArch.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public record CreateFooterAddressCommand : IRequest<GetFooterAddressByIdQueryResult>
    {
        public required string Description { get; init; }
        public required string Address { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
