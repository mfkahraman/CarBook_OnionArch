using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook_OnionArch.WebUI.Extensions
{
    public static class EnumHelper
    {
        public static List<SelectListItem> ToSelectList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new SelectListItem
                {
                    Value = Convert.ToInt32(e).ToString(),
                    Text = e.ToString()
                })
                .ToList();
        }
    }
}