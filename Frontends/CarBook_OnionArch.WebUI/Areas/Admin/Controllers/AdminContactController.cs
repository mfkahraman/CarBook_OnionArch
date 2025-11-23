using CarBook_OnionArch.Dto.ContactDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminContactController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Contacts");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var contacts = JsonSerializer.Deserialize<List<ResultContactDto>>(jsonData);

            int pageSize = 10;
            int pageNumber = page ?? 1;
            var pagedList = contacts?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Contacts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}