namespace CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands
{
    public record UpdateCarCommand
    {
        public int CarId { get; init; }
        public string? Model { get; init; }
        public int Mileage { get; init; }
        public string? Transmission { get; init; }
        public byte Seat { get; init; }
        public byte Luggage { get; init; }
        public string? Fuel { get; init; }
        public string? CoverImageUrl { get; init; }
        public string? BigImageUrl { get; init; }
        public int BrandId { get; init; }
    }
}
