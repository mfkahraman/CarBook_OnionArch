using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands
{
    public record UpdateTestimonialCommand : IRequest<bool>
    {
        public int TestimonialId { get; init; }
        public required string Name { get; init; }
        public string? Title { get; init; }
        public required string Comment { get; init; }
        public string? ImageUrl { get; init; }
    }
}
