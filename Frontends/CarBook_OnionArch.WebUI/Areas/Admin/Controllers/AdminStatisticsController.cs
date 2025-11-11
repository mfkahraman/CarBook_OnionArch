using CarBook_OnionArch.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStatisticsController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            StatisticsDto statisticsDto = new StatisticsDto();
            statisticsDto.authorCount = await GetAuthorCountAsync(cancellationToken);
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
            var value = JsonSerializer.Deserialize<StatisticsDto>(jsonData);
            return value?.authorCount ?? 0;
        }
    }
}
