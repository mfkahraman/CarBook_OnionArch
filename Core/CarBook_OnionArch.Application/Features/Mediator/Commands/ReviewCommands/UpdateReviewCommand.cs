using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.ReviewCommands
{
    public class UpdateReviewCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
