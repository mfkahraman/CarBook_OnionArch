namespace CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults
{
    public class GetTestimonialByIdQueryResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }
        public required string Comment { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; }

    }
}
