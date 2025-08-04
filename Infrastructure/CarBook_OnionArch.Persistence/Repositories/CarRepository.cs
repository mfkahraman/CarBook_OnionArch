using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    public class CarRepository(CarBookContext context) : ICarRepository
    {
        public async Task<List<Car>> GetCarsWithBrandsAsync()
        {
            var values = await context.Cars.Include(x => x.Brand).AsNoTracking().ToListAsync();
            return values;
        }
    }
}
