using CarBook_OnionArch.Dto.FeaturesDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFeatureController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Features");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var features = JsonSerializer.Deserialize<List<ResultFeatureDto>>(jsonData);

            int pageSize = 10;
            int pageNumber = page ?? 1;
            var pagedList = features?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/Features/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var feature = JsonSerializer.Deserialize<UpdateFeatureDto>(jsonData);
            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateFeatureDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(updateFeatureDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/Features/{updateFeatureDto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the feature.");
                return View(updateFeatureDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Features/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}