namespace CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionQueryResult
    {
        public int Id { get; set; }
        public required string Detail { get; set; }
        public int CarId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
