using CarBook_OnionArch.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebUI.ViewComponents.BlogViewComponents
{
    public class CreateCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int blogId)
        {
            var model = new CreateCommentDto
            {
                BlogId = blogId,
                Content = string.Empty,
                CreatedDate = DateTime.UtcNow,
                AuthorId = 0,
                IsDeleted = false

            };
            return View(model);
        }
    }
}
