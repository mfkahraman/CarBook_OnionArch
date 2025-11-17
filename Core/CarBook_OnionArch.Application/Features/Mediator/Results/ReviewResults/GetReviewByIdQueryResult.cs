using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByIdQueryResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
