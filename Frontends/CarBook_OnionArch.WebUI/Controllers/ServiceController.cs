using CarBook_OnionArch.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class ServiceController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Hizmetler";
            ViewBag.Subtitle = "Hizmetlerimiz";
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
