using CarBook_OnionArch.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.RentalFilterComponents
{
    public class RentalFilterComponentPartial(IHttpClientFactory httpClient) 
        : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Locations");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching locations");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var locations = JsonSerializer.Deserialize<List<ResultGetLocationsDto>>(jsonData);
            return View(locations);
        }
    }
}
