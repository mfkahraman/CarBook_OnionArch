using CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public record CreateSocialMediaCommand : IRequest<GetSocialMediaByIdQueryResult>
    {
        public required string Name { get; init; }
        public string? Url { get; init; }
        public string? Icon { get; init; }
    }
}
