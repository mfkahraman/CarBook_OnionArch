using CarBook_OnionArch.Dto.CarDtos;
using CarBook_OnionArch.Dto.UserDtos;
using CarBook_OnionArch.WebUI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class UserController(IHttpClientFactory httpClient, IImageService imageService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "users");
                dto.imagePath = imagePath;
                ModelState.Remove("ImagePath");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var client = httpClient.CreateClient();
            var jsonContent = JsonSerializer.Serialize(dto);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Users", content);
            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Kullanıcınız başarıyla oluşturuldu, artık giriş yapabilirsiniz!" });
            }
            else
            {
                return Json(new { success = false, message = "Kayıt işlemi sırasında bir sorun oluştu. Lütfen bilgileri eksiksiz doldurun ve tekrar deneyin" });
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
