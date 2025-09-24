using CarBook_OnionArch.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAboutController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Abouts");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var abouts = JsonSerializer.Deserialize<List<ResultAboutDto>>(jsonData);

            int pageSize = 10;
            int pageNumber = page ?? 1;
            var pagedList = abouts?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createAboutDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(createAboutDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Abouts", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the about.");
                return View(createAboutDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/Abouts/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var about = JsonSerializer.Deserialize<UpdateAboutDto>(jsonData);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateAboutDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(updateAboutDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/Abouts/{updateAboutDto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the about.");
                return View(updateAboutDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Abouts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}