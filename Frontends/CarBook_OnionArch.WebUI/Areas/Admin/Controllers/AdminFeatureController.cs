using CarBook_OnionArch.Dto.FeaturesDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFeatureController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index()
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createFeatureDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(createFeatureDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Features", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the feature.");
                return View(createFeatureDto);
            }
            return RedirectToAction("Index");
        }
    }
}
