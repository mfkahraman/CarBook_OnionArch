using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Dto.CarDtos
{
    public class CreateCarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string? Model { get; set; }
        public int Mileage { get; set; }
        public string? Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? Fuel { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
