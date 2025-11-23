using CarBook_OnionArch.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminFooterController(IHttpClientFactory httpClient) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/FooterAddresses");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var footerAddresses = JsonSerializer.Deserialize<List<ResultFooterAddressDto>>(jsonData);

            int pageSize = 10;
            int pageNumber = page ?? 1;
            var pagedList = footerAddresses?.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressDto createFooterAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createFooterAddressDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(createFooterAddressDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/FooterAddresses", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the footer address.");
                return View(createFooterAddressDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var client = httpClient.CreateClient();
            var response = client.GetAsync($"https://localhost:7020/api/FooterAddresses/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var footerAddress = JsonSerializer.Deserialize<UpdateFooterAddressDto>(jsonData);
            return View(footerAddress);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFooterAddressDto updateFooterAddressDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateFooterAddressDto);
            }
            var client = httpClient.CreateClient();
            var jsonData = JsonSerializer.Serialize(updateFooterAddressDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7020/api/FooterAddresses/{updateFooterAddressDto.id}", content);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the footer address.");
                return View(updateFooterAddressDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClient.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/FooterAddresses/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}