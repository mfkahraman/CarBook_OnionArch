using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Dto.AboutDtos
{
    public class CreateAboutDto
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
