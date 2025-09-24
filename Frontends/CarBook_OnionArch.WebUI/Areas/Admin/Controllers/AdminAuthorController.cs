using CarBook_OnionArch.Dto.AboutDtos;
using CarBook_OnionArch.Dto.AuthorDtos;
using CarBook_OnionArch.WebUI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAuthorController(IHttpClientFactory httpClient,
                                       IImageService imageService) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Authors");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var Authors = JsonSerializer.Deserialize<List<ResultAuthorDto>>(jsonData);

            int pageSize = 5;
            int pageNumber = page ?? 1;
            var pagedList = Authors?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "authors");
                dto.imageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(dto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Authors", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the Author.");
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/Authors/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var Author = JsonSerializer.Deserialize<UpdateAuthorDto>(jsonData);
            return View(Author);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAuthorDto dto)
        {
            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(dto.imageUrl))
                    await imageService.DeleteImageAsync(dto.imageUrl);

                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "authors");
                dto.imageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(dto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/Authors/{dto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the Author.");
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Authors/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}