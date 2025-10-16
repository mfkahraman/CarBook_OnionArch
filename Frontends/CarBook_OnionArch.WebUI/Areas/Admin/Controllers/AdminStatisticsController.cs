using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
