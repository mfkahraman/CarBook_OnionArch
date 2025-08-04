using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class Repository<T>(CarBookContext context)
        : IRepository<T> where T : class
    {
        public bool Create(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id)
                ?? throw new Exception("Girilen id ile kayıt bulunamadı");
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var record = await context.Set<T>().FindAsync(id)
                    ?? throw new Exception("Girilen id ile kayıt bulunamadı");

                context.Set<T>().Remove(record);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
