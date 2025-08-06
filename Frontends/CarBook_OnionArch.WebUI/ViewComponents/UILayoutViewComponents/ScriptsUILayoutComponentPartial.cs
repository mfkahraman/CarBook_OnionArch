using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.ViewComponents.UILayoutViewComponents
{
    public class ScriptsUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
