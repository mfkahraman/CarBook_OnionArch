using CarBook_OnionArch.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class CarController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Cars/get-cars-with-all");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);
            
            int pagesize = 6;
            int pageNumber = page ?? 1;
            var pagedList = values?.ToPagedList(pageNumber, pagesize);
            return View(pagedList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime startDate, DateTime endDate,int? page)
        {
            var client = httpClientFactory.CreateClient();

            string sDate = Uri.EscapeDataString(startDate.ToString("O")); // "O" = round-trip ISO 8601
            string eDate = Uri.EscapeDataString(endDate.ToString("O"));

            var url = $"https://localhost:7020/api/Cars/get-available-cars?startDate={sDate}&endDate={eDate}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);
            int pagesize = 6;
            int pageNumber = page ?? 1;
            var pagedList = values?.ToPagedList(pageNumber, pagesize);
            return View(pagedList);
        }
    }
}