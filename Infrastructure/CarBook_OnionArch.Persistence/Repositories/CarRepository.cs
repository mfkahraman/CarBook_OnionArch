using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<List<Car>> GetCarsByFilterAsync(Expression<Func<Rental, bool>> filter)
        {
            var unavailableCarIds = context.Rentals
                .Where(filter)
                .Select(r => r.CarId)
                .Distinct()
                .ToList();

            var availableCars = await context.Cars
                .Where(c => !unavailableCarIds.Contains(c.Id) && !c.IsDeleted && !c.Brand.IsDeleted)
                .Include(c => c.Brand)
                .Include(c => c.CarFeatures!
                    .Where(cf => !cf.IsDeleted && !cf.Feature.IsDeleted))
                        .ThenInclude(cf => cf.Feature)
                .Include(c => c.CarDescriptions!.Where(cd => !cd.IsDeleted))
                .Include(c => c.CarPricings!
                    .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted))
                        .ThenInclude(cp => cp.Pricing)
                .AsNoTracking()
                .ToListAsync();

            return availableCars;
        }
    }
}
