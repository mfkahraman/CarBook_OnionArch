namespace CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults
{
    public class GetSocialMediaByIdQueryResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
    }
}
