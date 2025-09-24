using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Dto.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string? fullName { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
