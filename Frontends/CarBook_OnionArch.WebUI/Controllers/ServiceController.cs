using CarBook_OnionArch.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class ServiceController(IHttpClientFactory httpClient) : Controller
    {
        public IActionResult Index()
        {
            var client = httpClient.CreateClient("ServicesClient");
            var response = client.GetAsync("https://localhost:7020/api/Services");
            if (!response.Result.IsSuccessStatusCode)
            {
                return Content("Error fetching services");
            }
            var jsonData = response.Result.Content.ReadAsStringAsync().Result;
            var values = JsonSerializer.Deserialize<List<ResultServiceDto>>(jsonData);
            return View(values);
        }
    }
}
