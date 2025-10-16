using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    internal class StatisticsRepository(AppDbContext context)
        : IStatisticsRepository
    {
        public async Task<int> GetAuthorCountAsync()
        {
            var authorCount = await context.Authors
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return authorCount;
        }

        public Task<int> GetAutomaticTransmissionCarCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetAverageDailyRentPriceAsync()
        {
            var dailyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Daily" && !cp.Car.IsDeleted)
                .Select(cp => cp.Pricing) // Assuming CarPricing has a Price property
                .ToListAsync();

            if (dailyPrices.Count == 0)
                return 0;

            return dailyPrices.Average(cp => cp.CarPricing);
        }

        public async Task<decimal> GetAverageMonthlyRentPriceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetAverageWeeklyRentPriceAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetBlogCountAsync()
        {
            var blogCount = await context.Blogs
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return blogCount;
        }

        public Task<string> GetBlogWithMostCommentsTitleAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetBrandCountAsync()
        {
            var brandCount = await context.Brands
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return brandCount;
        }

        public Task<string> GetBrandWithMostCarsNameAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCarCountAsync()
        {
            var carCount = await context.Cars
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return carCount;
        }

        public Task<int> GetCarCountUnder1000KmAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCarWithHighestDailyRentPriceNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCarWithLowestDailyRentPriceNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetElectricCarCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetGasolineCarCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLocationCountAsync()
        {
            var locationCount = await context.Locations
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return locationCount;
        }
    }
}
