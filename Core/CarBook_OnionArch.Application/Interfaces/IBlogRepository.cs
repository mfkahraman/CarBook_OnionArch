using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogsWithDetailsAsync();
        Task<Blog> GetBlogByIdWithDetailsAsync(int id);
    }
}
