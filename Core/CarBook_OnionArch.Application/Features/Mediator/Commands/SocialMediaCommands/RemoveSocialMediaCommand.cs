using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public record RemoveSocialMediaCommand(int Id) : IRequest<bool>;
}
