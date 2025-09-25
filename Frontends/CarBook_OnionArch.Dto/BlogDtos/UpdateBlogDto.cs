using Microsoft.AspNetCore.Http;

namespace CarBook_OnionArch.Dto.BlogDtos
{
    public class UpdateBlogDto
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public string? coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int authorId { get; set; }
        public int categoryId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
