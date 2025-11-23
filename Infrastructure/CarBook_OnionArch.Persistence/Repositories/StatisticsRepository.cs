using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook_OnionArch.Persistence.Repositories
{
    internal class StatisticsRepository(AppDbContext context)
        : IStatisticsRepository
    {
        public async Task<int> GetAuthorCountAsync(CancellationToken cancellationToken)
        {
            var authorCount = await context.Authors
                .Where(x => !x.IsDeleted)
                .CountAsync(cancellationToken);
            return authorCount;
        }

        public async Task<int> GetAutomaticTransmissionCarCountAsync(CancellationToken cancellationToken)
        {
            var count = await context.Cars
                .Where(c => !c.IsDeleted && c.Transmission == "Otomatik")
                .CountAsync(cancellationToken);
            return count;
        }

        public async Task<decimal> GetAverageDailyRentPriceAsync(CancellationToken cancellationToken)
        {
            var dailyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Günlük" && !cp.Car.IsDeleted)
                .Select(cp => cp.Amount).AverageAsync(cancellationToken);

            if (dailyPrices == 0)
                return 0;

            return dailyPrices;
        }

        public async Task<decimal> GetAverageMonthlyRentPriceAsync(CancellationToken cancellationToken)
        {
            var monthlyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Aylık" && !cp.Car.IsDeleted)
                .Select(cp => cp.Amount).AverageAsync(cancellationToken);

            if (monthlyPrices == 0)
                return 0;

            return monthlyPrices;
        }

        public async Task<decimal> GetAverageWeeklyRentPriceAsync(CancellationToken cancellationToken)
        {
            var weeklyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Haftalık" && !cp.Car.IsDeleted)
                .Select(cp => cp.Amount).AverageAsync(cancellationToken);

            if (weeklyPrices == 0)
                return 0;

            return weeklyPrices;
        }

        public async Task<int> GetBlogCountAsync(CancellationToken cancellationToken)
        {
            var blogCount = await context.Blogs
                .Where(x => !x.IsDeleted)
                .CountAsync(cancellationToken);
            return blogCount;
        }

        public async Task<string> GetBlogWithMostCommentsTitleAsync(CancellationToken cancellationToken)
        {
            var blogTitle = await context.Comments
                .Where(c => !c.IsDeleted && !c.Blog!.IsDeleted)
                .GroupBy(c => c.Blog!.Title)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync(cancellationToken) ?? "Bilinmiyor";
            return blogTitle;
        }

        public async Task<int> GetBrandCountAsync(CancellationToken cancellationToken)
        {
            var brandCount = await context.Brands
                .Where(x => !x.IsDeleted)
                .CountAsync(cancellationToken);
            return brandCount;
        }

        public async Task<string> GetBrandWithMostCarsNameAsync(CancellationToken cancellationToken)
        {
            var brand = await context.Cars
                .Where(c => !c.IsDeleted && !c.Brand.IsDeleted)
                .GroupBy(c => c.Brand.Name)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync(cancellationToken);
            return brand ?? "Bilinmiyor";
        }

        public async Task<int> GetCarCountAsync(CancellationToken cancellationToken)
        {
            var carCount = await context.Cars
                .Where(x => !x.IsDeleted)
                .CountAsync(cancellationToken);
            return carCount;
        }

        public async Task<int> GetCarCountUnder1000KmAsync(CancellationToken cancellationToken)
        {
            var count = await context.Cars
                .Where(c => !c.IsDeleted && c.Mileage < 1000)
                .CountAsync(cancellationToken);
            return count;
        }

        public async Task<string> GetCarWithHighestDailyRentPriceNameAsync(CancellationToken cancellationToken)
        {
            var carWithMaxPrice = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Car.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Günlük")
                .Include(cp=> cp.Car.Brand)
                .OrderByDescending(cp => cp.Amount)
                .Select(cp => $"{cp.Car.Brand.Name} {cp.Car.Model}")
                .FirstOrDefaultAsync(cancellationToken);

            return carWithMaxPrice ?? "Bilinmiyor";
        }

        public async Task<string> GetCarWithLowestYearlyRentPriceNameAsync(CancellationToken cancellationToken)
        {
            var carWithMinPrice = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Car.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Yıllık")
                .Include(cp=> cp.Car.Brand)
                .OrderBy(cp => cp.Amount)
                .Select(cp => $"{cp.Car.Brand.Name} {cp.Car.Model}")
                .FirstOrDefaultAsync(cancellationToken);

            return carWithMinPrice ?? "Bilinmiyor";
        }

        public async Task<int> GetDieselCarCountAsync(CancellationToken cancellationToken)
        {
            var count = await context.Cars
                .Where(c => !c.IsDeleted && c.Fuel == "Dizel")
                .CountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetGasolineCarCountAsync(CancellationToken cancellationToken)
        {
            var count = await context.Cars
                .Where(c => !c.IsDeleted && c.Fuel == "Benzin")
                .CountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetLocationCountAsync(CancellationToken cancellationToken)
        {
            var locationCount = await context.Locations
                .Where(x => !x.IsDeleted)
                .CountAsync(cancellationToken);
            return locationCount;
        }
    }
}