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
    }
}
