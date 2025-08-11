using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public record UpdateSocialMediaCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Url { get; init; }
        public string? Icon { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
