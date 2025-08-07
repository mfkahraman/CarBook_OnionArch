using CarBook_OnionArch.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Banners/get-all");
            if(!response.IsSuccessStatusCode)
            {
                return Content("Error fetching banners");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultBannerDto>>(jsonData)
                ?? throw new Exception("Banner UI katmanına getirilemedi");
            var value = values.FirstOrDefault();
            return View(value);
        }
    }
}
