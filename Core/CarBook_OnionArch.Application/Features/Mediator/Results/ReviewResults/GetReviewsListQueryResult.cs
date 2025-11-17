using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;

namespace CarBook_OnionArch.Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewsListQueryResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public GetUserByIdQueryResult? User { get; set; }
        public int CarId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
