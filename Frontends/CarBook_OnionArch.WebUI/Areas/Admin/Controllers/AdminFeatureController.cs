using CarBook_OnionArch.Dto.FeaturesDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFeatureController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Features");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var features = JsonSerializer.Deserialize<List<ResultFeatureDto>>(jsonData);

            return View(features);
        }
    }
}
