using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class CarRepository(AppDbContext context) : ICarRepository
    {
        public Task<List<Car>> GetCarsWithAllAsync()
        {
            var values = context.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarFeatures)
                .Include(x => x.CarDescriptions)
                .Include(x => x.CarPricings!)
                    .ThenInclude(x => x.Pricing)
                .AsNoTracking()
                .ToListAsync();
            return values;
        }

        public async Task<List<Car>> GetCarsWithBrandsAsync()
        {
            var values = await context.Cars.Include(x => x.Brand).AsNoTracking().ToListAsync();
            return values;
        }

    }
}
