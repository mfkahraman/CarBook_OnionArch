using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands
{
    public record RemoveFeatureCommand(int Id) : IRequest<bool>;
}
