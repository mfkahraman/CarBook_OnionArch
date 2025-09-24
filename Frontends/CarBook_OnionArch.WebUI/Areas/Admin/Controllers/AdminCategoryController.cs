using CarBook_OnionArch.Dto.CategoriesDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Categorys");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var Categorys = JsonSerializer.Deserialize<List<ResultCategoryDto>>(jsonData);

            int pageSize = 10;
            int pageNumber = page ?? 1;
            var pagedList = Categorys?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createCategoryDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(createCategoryDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Categorys", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the Category.");
                return View(createCategoryDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/Categorys/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var Category = JsonSerializer.Deserialize<UpdateCategoryDto>(jsonData);
            return View(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateCategoryDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(updateCategoryDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/Categorys/{updateCategoryDto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the Category.");
                return View(updateCategoryDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Categorys/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}