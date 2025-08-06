using CarBook_OnionArch.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.AboutViewComponents
{
    public class AboutUsComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient("AboutClient");
            var responseMessage = await client.GetAsync("https://localhost:7020/api/Abouts/get-all");
            
            if(!responseMessage.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);

        }
    }   
}
