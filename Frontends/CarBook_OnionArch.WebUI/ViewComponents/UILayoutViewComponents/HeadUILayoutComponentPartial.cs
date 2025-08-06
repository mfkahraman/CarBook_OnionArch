using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.ViewComponents.UILayoutViewComponents
{
    public class HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
