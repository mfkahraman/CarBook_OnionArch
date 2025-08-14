using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands
{
    public record CreateCarCommand
    {
        public string? Model { get; init; }
        public int Mileage { get; init; }
        public string? Transmission { get; init; }
        public byte Seat { get; init; }
        public byte Luggage { get; init; }
        public string? Fuel { get; init; }
        public string? CoverImageUrl { get; set; }
        public string? BigImageUrl { get; set; }
        public int BrandId { get; init; }
        public bool IsDeleted { get; init; } = false;
        public IFormFile? ImageFile { get; set; }

    }
}
