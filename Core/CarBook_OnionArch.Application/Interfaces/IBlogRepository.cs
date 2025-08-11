using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetBlogsWithRelations();
    }
}
