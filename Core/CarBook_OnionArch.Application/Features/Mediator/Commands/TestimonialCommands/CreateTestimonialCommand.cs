using CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands
{
    public record CreateTestimonialCommand : IRequest<GetTestimonialByIdQueryResult>
    {
        public required string Name { get; init; }
        public string? Title { get; init; }
        public required string Comment { get; init; }
        public string? ImageUrl { get; init; }
        public bool IsDeleted { get; init; } = false;

    }
}
