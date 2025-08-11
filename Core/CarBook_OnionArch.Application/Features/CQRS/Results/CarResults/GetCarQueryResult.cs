namespace CarBook_OnionArch.Application.Features.CQRS.Results.CarResults
{
    public class GetCarQueryResult
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? BigImageUrl { get; set; }
        public int BrandId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
