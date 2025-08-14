using CarBook_OnionArch.Dto.BrandDtos;
using CarBook_OnionArch.Dto.CarDtos;
using CarBook_OnionArch.Dto.FeaturesDtos;
using CarBook_OnionArch.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCarController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Cars/get-cars-with-all");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
            ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
            ViewBag.Brands = await FetchBrandsAsync();
            ViewBag.Features = await FetchFeaturesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto createCarDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
                ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
                ViewBag.Brands = await FetchBrandsAsync();
                ViewBag.Features = await FetchFeaturesAsync();
                return View(createCarDto);
            }

            var client = httpClientFactory.CreateClient();

            using var formData = new MultipartFormDataContent();

            // Diğer alanlar
            formData.Add(new StringContent(createCarDto.BrandId.ToString()), "BrandId");
            formData.Add(new StringContent(createCarDto.Model ?? ""), "Model");
            formData.Add(new StringContent(createCarDto.Mileage.ToString()), "Mileage");
            formData.Add(new StringContent(createCarDto.Transmission ?? ""), "Transmission");
            formData.Add(new StringContent(createCarDto.Seat.ToString()), "Seat");
            formData.Add(new StringContent(createCarDto.Luggage.ToString()), "Luggage");
            formData.Add(new StringContent(createCarDto.Fuel ?? ""), "Fuel");

            // Resim dosyası
            if (createCarDto.ImageFile != null && createCarDto.ImageFile.Length > 0)
            {
                var streamContent = new StreamContent(createCarDto.ImageFile.OpenReadStream());
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(createCarDto.ImageFile.ContentType);
                formData.Add(streamContent, "ImageFile", createCarDto.ImageFile.FileName);
            }

            var response = await client.PostAsync("https://localhost:7020/api/Cars/create", formData);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }


        public async Task<List<SelectListItem>> FetchBrandsAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Brands/get-all");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandList = values!
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()
                }).ToList();
            return brandList;
        }
        public async Task<List<SelectListItem>> FetchFeaturesAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Features");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultFeatureDto>>(jsonData);
            List<SelectListItem> brandList = values!
                .Select(x => new SelectListItem
                {
                    Text = x.name,
                    Value = x.id.ToString()
                }).ToList();
            return brandList;
        }

    }
}
