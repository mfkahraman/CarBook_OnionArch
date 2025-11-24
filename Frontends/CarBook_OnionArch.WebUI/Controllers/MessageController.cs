using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
