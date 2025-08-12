using CarBook_OnionArch.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.BlogViewComponents
{
    public class RecentBlogsComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Blogs/get-blogs-with-details");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching blogs");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var values = JsonSerializer.Deserialize<List<ResultBlogWithDetailsDto>>(jsonData);
            var lastFiveBlogs = values?.OrderByDescending(x => x.createdDate).Take(5).ToList();
            return View(lastFiveBlogs);
        }
    }
}