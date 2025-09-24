using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class Repository<T>(AppDbContext context)
        : IRepository<T> where T : class, IEntity
    {
        public bool Create(T entity)
        {
            try
            {
                entity.IsDeleted = false;
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
            return await context.Set<T>()
                .Where(x=> !x.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>()
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Girilen id ile kayıt bulunamadı");
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var record = await context.Set<T>()
                    .Where(x => x.Id == id && !x.IsDeleted)
                    .FirstOrDefaultAsync()
                    ?? throw new Exception("Girilen id ile kayıt bulunamadı");
                record.IsDeleted = true;
                context.Set<T>().Update(record);

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
                //entity.IsDeleted = false;
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
