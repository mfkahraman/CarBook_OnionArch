using CarBook_OnionArch.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class BlogController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Blogs/get-blogs-with-details");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching blogs");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var values = JsonSerializer.Deserialize<List<ResultBlogWithDetailsDto>>(jsonData);
            return View(values);
        }
    }
}
