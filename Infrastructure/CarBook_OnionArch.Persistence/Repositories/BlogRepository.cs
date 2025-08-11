using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class BlogRepository(AppDbContext context) : IBlogRepository
    {
        public async Task<List<Blog>> GetBlogsWithDetailsAsync()
        {
            var values = await context.Blogs
                .Include(x=> x.Author)
                .Include(x => x.Category)
                .Include(x => x.Comments)
                .AsNoTracking()
                .ToListAsync();
            return values;
        }
    }
}
