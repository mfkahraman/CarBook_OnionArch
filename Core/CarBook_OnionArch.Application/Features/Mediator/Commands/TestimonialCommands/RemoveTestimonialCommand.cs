using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands
{
    public record RemoveTestimonialCommand(int Id) : IRequest<bool>;
}
