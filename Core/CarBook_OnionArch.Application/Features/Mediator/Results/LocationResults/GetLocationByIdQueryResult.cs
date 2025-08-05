namespace CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults
{
    public class GetLocationByIdQueryResult
    {
        public int LocationId { get; set; }
        public required string Name { get; set; }
    }
}
