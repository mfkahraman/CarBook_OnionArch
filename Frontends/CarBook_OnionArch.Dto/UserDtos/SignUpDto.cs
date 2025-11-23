using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Dto.UserDtos
{
    public class SignUpDto
    {
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string userName { get; set; }
        public required string email { get; set; }
        public required string passwordHash { get; set; }
        public required string passwordRepeat { get; set; }
        public string? imagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
