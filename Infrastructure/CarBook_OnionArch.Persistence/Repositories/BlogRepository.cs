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
                .Where(b => !b.IsDeleted && !b.Author!.IsDeleted && !b.Category!.IsDeleted)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Comments!.Where(x => !x.IsDeleted))
                .AsNoTracking()
                .ToListAsync();
            return values;
        }
    }
}
