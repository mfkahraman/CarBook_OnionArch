using CarBook_OnionArch.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.FooterAddressComponents
{
    public class FooterAddressComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7020/api/FooterAddresses");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return Content("Error fetching data");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultFooterAddressDto>>(jsonData);
            return View(values);
        }
    }
}