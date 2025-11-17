using CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest<GetReviewByIdQueryResult>
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
