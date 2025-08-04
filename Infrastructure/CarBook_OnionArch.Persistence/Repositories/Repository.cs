using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class Repository<T>(CarBookContext context) 
        : IRepository<T> where T : class
    {
        public async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id)
                ?? throw new Exception("Girilen id ile kayıt bulunamadı");
        }

        public async Task RemoveAsync(int id)
        {
            var record = await context.Set<T>().FindAsync(id)
               ?? throw new Exception("Girilen id ile kayıt bulunamadı");
            context.Set<T>().Remove(record);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
