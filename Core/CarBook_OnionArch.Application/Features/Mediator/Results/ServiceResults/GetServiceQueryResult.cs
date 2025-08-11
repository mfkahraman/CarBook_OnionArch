namespace CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults
{
    public class GetServiceQueryResult
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public bool IsDeleted { get; set; }

    }
}
