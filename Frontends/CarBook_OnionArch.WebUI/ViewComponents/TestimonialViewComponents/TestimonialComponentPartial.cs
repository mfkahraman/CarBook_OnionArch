using CarBook_OnionArch.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.ViewComponents.TestimonialViewComponents
{
    public class TestimonialComponentPartial(IHttpClientFactory httpClient) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClient.CreateClient("TestimonialClient");
            var responseMessage = await client.GetAsync("https://localhost:7020/api/Testimonials");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return Content("Error fetching testimonials");
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
    }
}
