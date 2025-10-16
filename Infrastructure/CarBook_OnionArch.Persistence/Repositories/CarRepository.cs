using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class CarRepository(AppDbContext context) : ICarRepository
    {
        public async Task<List<Car>> GetCarsWithAllAsync()
        {
            return await context.Cars
                .Where(x => !x.IsDeleted && !x.Brand.IsDeleted)
                .Include(x => x.Brand)
                .Include(x => x.CarFeatures!
                    .Where(cf => !cf.IsDeleted && !cf.Feature.IsDeleted))
                        .ThenInclude(cf => cf.Feature)
                .Include(x => x.CarDescriptions!.Where(cd => !cd.IsDeleted))
                .Include(x => x.CarPricings!
                    .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted))
                        .ThenInclude(cp => cp.Pricing)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Car>> GetCarsWithBrandsAsync()
        {
            var values = await context.Cars.Include(x => x.Brand).AsNoTracking().ToListAsync();
            return values;
        }

        public Task<Car> GetCarWithRelationsById(int id)
        {
            return context.Cars
                .Where(x => x.Id == id && !x.IsDeleted && !x.Brand.IsDeleted)
                .Include(x => x.Brand)
                .Include(x => x.CarFeatures!
                    .Where(cf => !cf.IsDeleted && !cf.Feature.IsDeleted))
                        .ThenInclude(cf => cf.Feature)
                .Include(x => x.CarDescriptions!.Where(cd => !cd.IsDeleted))
                .Include(x => x.CarPricings!
                    .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted))
                        .ThenInclude(cp => cp.Pricing)
                .FirstOrDefaultAsync()!;
        }

        public async Task<int> GetCarCountAsync()
        {
            var carCount = await context.Cars
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return carCount;
        }
    }
}
