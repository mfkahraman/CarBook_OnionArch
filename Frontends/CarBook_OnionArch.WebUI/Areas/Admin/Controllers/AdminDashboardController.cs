using CarBook_OnionArch.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            StatisticsDto statisticsDto = new StatisticsDto();
            statisticsDto.AverageDailyRentPrice = await GetAverageDailyRentPriceAsync(cancellationToken);
            statisticsDto.AverageWeeklyRentPrice = await GetAverageWeeklyRentPriceAsync(cancellationToken);
            statisticsDto.AverageMonthlyRentPrice = await GetAverageMonthlyRentPriceAsync(cancellationToken);
            statisticsDto.CarCount = await CarCountAsync(cancellationToken);
            statisticsDto.CarCountUnder1000Km = await GetCarCountUnder1000KmAsync(cancellationToken);
            statisticsDto.DieselCarCount = await GetDieselCarCountAsync(cancellationToken);
            statisticsDto.LocationCount = await GetLocationCountAsync(cancellationToken);

            return View(statisticsDto);

        }

        public async Task<int> CarCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-car-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultCarCountDto>(jsonData);
            return value?.carCount ?? 0;
        }
        public async Task<decimal> GetAverageDailyRentPriceAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-average-daily-rent-price", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetAverageDailyRentPriceDto>(jsonData);
            return value?.averageDailyRentPrice ?? 0;
        }
        public async Task<decimal> GetAverageWeeklyRentPriceAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-average-weekly-rent-price", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetAverageWeeklyRentPriceDto>(jsonData);
            return value?.averageWeeklyRentPrice ?? 0;
        }
        public async Task<decimal> GetAverageMonthlyRentPriceAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-average-monthly-rent-price", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetAverageMonthlyRentPriceDto>(jsonData);
            return value?.averageMonthlyRentPrice ?? 0;
        }
        public async Task<int> GetCarCountUnder1000KmAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-car-count-under-1000-km", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetCarCountUnder1000KmDto>(jsonData);
            return value?.carCount ?? 0;
        }
        public async Task<int> GetDieselCarCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-diesel-car-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetDieselCarCountDto>(jsonData);
            return value?.dieselCarCount ?? 0;
        }
        public async Task<int> GetLocationCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-location-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetLocationCountDto>(jsonData);
            return value?.locationCount ?? 0;
        }
    }
}
