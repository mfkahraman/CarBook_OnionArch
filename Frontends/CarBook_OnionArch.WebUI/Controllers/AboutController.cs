using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Hakkımızda";
            ViewBag.Subtitle = "Hakkımızda Daha Fazla Bilgi";
            return View();
        }
    }
}
