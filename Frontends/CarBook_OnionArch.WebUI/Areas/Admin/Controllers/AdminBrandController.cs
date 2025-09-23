using CarBook_OnionArch.Dto.BrandDtos;
using CarBook_OnionArch.Dto.FeaturesDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBrandController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Brands");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var brands = JsonSerializer.Deserialize<List<ResultBrandDto>>(jsonData);

            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto createBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createBrandDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(createBrandDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Brands", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the brand.");
                return View(createBrandDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/Brands/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var brand = JsonSerializer.Deserialize<UpdateBrandDto>(jsonData);
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandDto updateBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateBrandDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(updateBrandDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/Brands/{updateBrandDto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the brand.");
                return View(updateBrandDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Brands/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}