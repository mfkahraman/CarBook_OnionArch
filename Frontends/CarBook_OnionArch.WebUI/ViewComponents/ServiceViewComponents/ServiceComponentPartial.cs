using CarBook_OnionArch.Dto.FooterAddressDtos;
using CarBook_OnionArch.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.ServiceViewComponents
{
    public class ServiceComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient("ServicesClient");
            var response = await client.GetAsync("https://localhost:7020/api/Services");
            if (!response.IsSuccessStatusCode)
            {
                return Content("Error fetching services");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var values = JsonSerializer.Deserialize<List<ResultServiceDto>>(jsonData);
            return View(values);

        }
    }
}