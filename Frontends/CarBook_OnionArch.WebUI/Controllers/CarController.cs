using CarBook_OnionArch.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class CarController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Cars/get-cars-with-all");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime startDate, DateTime endDate)
        {
            var formattedStart = Uri.EscapeDataString(startDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            var formattedEnd = Uri.EscapeDataString(endDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Cars/get-available-cars/{formattedStart}/{formattedEnd}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);
            return View(values);
        }
    }
}