using CarBook_OnionArch.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class ContactController(IHttpClientFactory httpClientFactory) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7020/api/Contacts/create", content);
            if(!responseMessage.IsSuccessStatusCode)
            {
                return Content("Error occurred while sending the message.");
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
