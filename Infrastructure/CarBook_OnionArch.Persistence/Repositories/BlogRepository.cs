using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class BlogRepository(AppDbContext context) : IBlogRepository
    {
        public List<Blog> GetBlogsWithRelations()
        {
            var values = context.Blogs
                .Include(x=> x.Author)
                .Include(x => x.Category)
                .Include(x => x.Comments)
                .AsNoTracking()
                .ToList();
            return values;
        }
    }
}
