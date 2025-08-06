using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
