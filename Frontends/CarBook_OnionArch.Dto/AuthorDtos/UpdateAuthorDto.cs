using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Dto.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int id { get; set; }
        public string? fullName { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
