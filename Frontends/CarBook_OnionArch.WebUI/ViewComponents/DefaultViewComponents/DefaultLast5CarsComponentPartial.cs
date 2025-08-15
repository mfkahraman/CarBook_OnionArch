using CarBook_OnionArch.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultLast5CarsComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7020/api/Cars/get-cars-with-all");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return Content("Error fetching data");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);
            var last5Cars = values?.OrderByDescending(x=> x.id).Take(5).ToList();
            return View(last5Cars);
        }
    }
}