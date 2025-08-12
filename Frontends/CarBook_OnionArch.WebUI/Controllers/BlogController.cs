using CarBook_OnionArch.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class BlogController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            ViewBag.Title = "Blog";
            ViewBag.Subtitle = "Blog Listesi";
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Blogs/get-blogs-with-details");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching blogs");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultBlogWithDetailsDto>>(jsonData);

            int pageSize = 2;
            int pageNumber = page ?? 1;
            var pagedList = values?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            ViewBag.Title = "Blog";
            ViewBag.Subtitle = "Blog İçeriği";
            var client = httpClient.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Blogs/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching blog details");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<ResultBlogByIdWithDetailsDto>(jsonData);
            return View(values);
        }
    }
}