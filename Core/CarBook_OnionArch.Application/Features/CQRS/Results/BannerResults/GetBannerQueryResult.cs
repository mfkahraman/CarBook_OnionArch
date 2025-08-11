namespace CarBook_OnionArch.Application.Features.CQRS.Results.BannerResults
{
    public class GetBannerQueryResult
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoUrl { get; set; }
        public bool IsDeleted { get; set; }

    }
}
