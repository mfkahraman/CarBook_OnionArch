﻿using CarBook_OnionArch.Application.Interfaces;
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

        public async Task<int> GetAutomaticTransmissionCarCountAsync()
        {
            var count = await context.Cars
                .Where(c=> !c.IsDeleted && c.Transmission == "Automatic")
                .CountAsync(); 
            return count;
        }

        public async Task<decimal> GetAverageDailyRentPriceAsync()
        {
            var dailyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Günlük" && !cp.Car.IsDeleted)
                .Select(cp=> cp.Amount).AverageAsync();

            if (dailyPrices == 0)
                return 0;

            return dailyPrices;
        }

        public async Task<decimal> GetAverageMonthlyRentPriceAsync()
        {
            var monthlyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Aylık" && !cp.Car.IsDeleted)
                .Select(cp => cp.Amount).AverageAsync();

            if (monthlyPrices == 0)
                return 0;

            return monthlyPrices;
        }

        public async Task<decimal> GetAverageWeeklyRentPriceAsync()
        {
            var weeklyPrices = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Haftalık" && !cp.Car.IsDeleted)
                .Select(cp => cp.Amount).AverageAsync();

            if (weeklyPrices == 0)
                return 0;

            return weeklyPrices;
        }

        public async Task<int> GetBlogCountAsync()
        {
            var blogCount = await context.Blogs
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return blogCount;
        }

        public async Task<string> GetBlogWithMostCommentsTitleAsync()
        {
            var blogTitle = await context.Comments
                .Where(c=> !c.IsDeleted && !c.Blog!.IsDeleted)
                .GroupBy(c=> c.Blog!.Title)
                .OrderByDescending(g=> g.Count())
                .Select(g=> g.Key)
                .FirstOrDefaultAsync() ?? "Bilinmiyor";
            return blogTitle;
        }

        public async Task<int> GetBrandCountAsync()
        {
            var brandCount = await context.Brands
                .Where(x => !x.IsDeleted)
                .CountAsync();
            return brandCount;
        }

        public async Task<string> GetBrandWithMostCarsNameAsync()
        {
            var brand = await context.Cars
                .Where(c => !c.IsDeleted && !c.Brand.IsDeleted)
                .GroupBy(c => c.Brand.Name)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
            return brand ?? "Bilinmiyor";
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
            var count = context.Cars
                .Where(c=> !c.IsDeleted && c.Mileage < 1000)
                .CountAsync();
            return count;
        }

        public async Task<string> GetCarWithHighestDailyRentPriceNameAsync()
        {
            var carWithMaxPrice = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Car.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Günlük")
                .OrderByDescending(cp => cp.Amount)
                .Select(cp => cp.Car.Model)
                .FirstOrDefaultAsync();

            return carWithMaxPrice ?? "Bilinmiyor";
        }

        public async Task<string> GetCarWithLowestYearlyRentPriceNameAsync()
        {
            var carWithMinPrice = await context.CarPricings
                .Where(cp => !cp.IsDeleted && !cp.Car.IsDeleted && !cp.Pricing.IsDeleted && cp.Pricing.Name == "Yıllık")
                .OrderBy(cp => cp.Amount)
                .Select(cp => cp.Car.Model)
                .FirstOrDefaultAsync();

            return carWithMinPrice ?? "Bilinmiyor";
        }

        public async Task<int> GetDieselCarCountAsync()
        {
            var count = await context.Cars
                .Where(c=> !c.IsDeleted && c.Fuel == "Diesel")
                .CountAsync();
            return count;
        }

        public async Task<int> GetGasolineCarCountAsync()
        {
            var count = await context.Cars
                .Where(c => !c.IsDeleted && c.Fuel == "Gasoline")
                .CountAsync();
            return count;
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
