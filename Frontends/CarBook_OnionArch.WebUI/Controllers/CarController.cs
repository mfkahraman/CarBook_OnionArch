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
            var response = await client.GetAsync("https://localhost:7020/api/Cars/get-cars-with-brands");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithBrandDto>>(jsonData);
            return View(values);
        }
    }
}
