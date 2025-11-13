using CarBook_OnionArch.Dto.CategoriesDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.BlogViewComponents
{
    public class BlogCategoriesComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Categories");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching blogs");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var values = JsonSerializer.Deserialize<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
    }
}