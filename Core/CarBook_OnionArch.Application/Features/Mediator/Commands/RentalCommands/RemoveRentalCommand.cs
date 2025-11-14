using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.RentalCommands
{
    public record RemoveRentalCommand(int Id) : IRequest<bool>;
}
