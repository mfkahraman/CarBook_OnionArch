using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public record RemoveFooterAddressCommand(int Id) : IRequest<bool>;
}
