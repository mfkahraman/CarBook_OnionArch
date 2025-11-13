using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.ViewComponents.RentalFilterComponents
{
    public class RentalFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
