using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public record UpdateFooterAddressCommand : IRequest<bool>
    {
        public int FooterAddressId { get; init; }
        public required string Description { get; init; }
        public required string Address { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
    }
}
