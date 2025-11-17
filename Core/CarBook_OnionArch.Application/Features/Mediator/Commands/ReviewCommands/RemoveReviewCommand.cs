using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands
{
    public record RemoveReviewCommand(int Id) : IRequest<bool>;
}
