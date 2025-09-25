using CarBook_OnionArch.Dto.AuthorDtos;
using CarBook_OnionArch.Dto.BlogDtos;
using CarBook_OnionArch.Dto.CategoriesDtos;
using CarBook_OnionArch.WebUI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController(IHttpClientFactory httpClient,
                                       IImageService imageService) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Blogs/get-blogs-with-details");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var Blogs = JsonSerializer.Deserialize<List<ResultBlogByIdWithDetailsDto>>(jsonData);

            int pageSize = 5;
            int pageNumber = page ?? 1;
            var pagedList = Blogs?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await FetchAuthorsAsync();
            ViewBag.Categories = await FetchCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "Blogs");
                dto.coverImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            dto.createdDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                ViewBag.Authors = await FetchAuthorsAsync();
                ViewBag.Categories = await FetchCategoriesAsync();
                return View(dto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(dto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Blogs", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the Blog.");
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/Blogs/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var Blog = JsonSerializer.Deserialize<UpdateBlogDto>(jsonData);

            ViewBag.Authors = await FetchAuthorsAsync();
            ViewBag.Categories = await FetchCategoriesAsync();

            return View(Blog);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogDto dto)
        {
            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(dto.coverImageUrl))
                    await imageService.DeleteImageAsync(dto.coverImageUrl);

                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "Blogs");
                dto.coverImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Authors = await FetchAuthorsAsync();
                ViewBag.Categories = await FetchCategoriesAsync();
                return View(dto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(dto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/Blogs/{dto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the Blog.");
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Blogs/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        public async Task<List<SelectListItem>> FetchAuthorsAsync()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Authors");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultAuthorDto>>(jsonData);
            List<SelectListItem> authorList = values!
                .Select(x => new SelectListItem
                {
                    Text = x.fullName,
                    Value = x.id.ToString()
                }).ToList();
            return authorList;
        }
        public async Task<List<SelectListItem>> FetchCategoriesAsync()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Categories");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryList = values!
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()
                }).ToList();
            return categoryList;
        }
    }
}