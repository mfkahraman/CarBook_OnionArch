using CarBook_OnionArch.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStatisticsController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            StatisticsDto statisticsDto = new StatisticsDto();
            statisticsDto.AuthorCount = await GetAuthorCountAsync(cancellationToken);
            statisticsDto.AutomaticTransmissionCarCount = await GetAutomaticTransmissionCarCountAsync(cancellationToken);
            statisticsDto.AverageDailyRentPrice = await GetAverageDailyRentPriceAsync(cancellationToken);
            statisticsDto.AverageWeeklyRentPrice =  await GetAverageWeeklyRentPriceAsync(cancellationToken);
            statisticsDto.AverageMonthlyRentPrice = await GetAverageMonthlyRentPriceAsync(cancellationToken);
            statisticsDto.BlogCount = await GetBlogCountAsync(cancellationToken);
            statisticsDto.BlogWithMostCommentsTitle = await GetBlogWithMostCommentsTitle(cancellationToken);
            statisticsDto.BrandCount = await GetBrandCountAsync(cancellationToken);


            statisticsDto.CarCount = await CarCountAsync(cancellationToken);
            return View(statisticsDto);
        }

        public async Task<int> GetAuthorCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-author-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetAuthorCountResultDto>(jsonData);
            return value?.authorCount ?? 0;
        }
        public async Task<int> GetAutomaticTransmissionCarCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-automatic-transmission-car-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetAutomaticTransmissionCarCountDto>(jsonData);
            return value?.count ?? 0;
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
        public async Task<int> GetBlogCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-blog-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetBlogCountDto>(jsonData);
            return value?.count ?? 0;
        }
        public async Task<string> GetBlogWithMostCommentsTitle(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-blog-with-most-comments-title", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return "Error";
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetBlogWithMostCommentsTitleDto>(jsonData);
            return value?.title ?? "Error";
        }
        public async Task<int> GetBrandCountAsync(CancellationToken cancellationToken)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Statistics/get-brand-count", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var jsonData = await response.Content.ReadAsStringAsync(cancellationToken);
            var value = JsonSerializer.Deserialize<ResultGetBrandCountDto>(jsonData);
            return value?.brandCount ?? 0;
        }
    }
}
