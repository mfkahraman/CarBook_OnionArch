using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult AdmLayout()
        {
            return View();
        }

        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }


    }
}
