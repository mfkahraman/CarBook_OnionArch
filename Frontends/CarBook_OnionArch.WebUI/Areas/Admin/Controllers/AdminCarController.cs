using CarBook_OnionArch.Dto.BrandDtos;
using CarBook_OnionArch.Dto.CarDtos;
using CarBook_OnionArch.Dto.CarFeatureDtos;
using CarBook_OnionArch.Dto.FeaturesDtos;
using CarBook_OnionArch.WebUI.Extensions;
using CarBook_OnionArch.WebUI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace CarBook_OnionArch.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCarController(IHttpClientFactory httpClientFactory,
                                    IImageService imageService) : Controller
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
            if (createCarDto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(createCarDto.ImageFile, "cars");
                createCarDto.CoverImageUrl = imagePath;
                createCarDto.BigImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
                ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
                ViewBag.Brands = await FetchBrandsAsync();
                ViewBag.Features = await FetchFeaturesAsync();
                return View(createCarDto);
            }

            var jsonData = JsonSerializer.Serialize(createCarDto);
            var formData = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var client = httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7020/api/Cars/create", formData);

            if (response.IsSuccessStatusCode)
            {
                var carJson = await response.Content.ReadAsStringAsync();
                var createdCar = JsonSerializer.Deserialize<ResultGetCarByIdDto>(carJson);
                int carId = createdCar!.id;

                var allFeatures = await FetchFeaturesAsync();

                var selectedFeatureIds = Request.Form["SelectedFeatureIds"].ToList();

                foreach (var feature in allFeatures)
                {
                    var dto = new CreateCarFeatureDto
                    {
                        CarId = carId,
                        FeatureId = int.Parse(feature.Value),
                        IsAvailable = selectedFeatureIds.Contains(feature.Value)
                    };

                    var json = JsonSerializer.Serialize(dto);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var responseFeature = await client.PostAsync("https://localhost:7020/api/CarFeatures", content);

                    if (!responseFeature.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "Failed to add car feature.");
                        return View(createCarDto);
                    }
                }

                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Cars/get-by-id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<UpdateCarDto>(jsonData);

            if (dto == null)
            {
                return NotFound();
            }

            ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
            ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
            ViewBag.Brands = await FetchBrandsAsync();
            ViewBag.Features = await FetchFeaturesAsync();

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCarDto dto)
        {
            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(dto.CoverImageUrl))
                    await imageService.DeleteImageAsync(dto.CoverImageUrl);

                else if (!string.IsNullOrEmpty(dto.BigImageUrl))
                    await imageService.DeleteImageAsync(dto.BigImageUrl);

                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "cars");
                dto.CoverImageUrl = imagePath;
                dto.BigImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
                ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
                ViewBag.Brands = await FetchBrandsAsync();
                ViewBag.Features = await FetchFeaturesAsync();
                return View(dto);
            }

            var jsonData = JsonSerializer.Serialize(dto);
            var formData = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var client = httpClientFactory.CreateClient();
            var response = await client.PutAsync("https://localhost:7020/api/Cars/update", formData);

            if (response.IsSuccessStatusCode)
            {
                int carId = dto!.Id;

                var allFeatures = await FetchFeaturesAsync();

                var selectedFeatureIds = Request.Form["SelectedFeatureIds"].ToList();

                foreach (var feature in allFeatures)
                {
                    var carFeatureDto = new CreateCarFeatureDto
                    {
                        CarId = carId,
                        FeatureId = int.Parse(feature.Value),
                        IsAvailable = selectedFeatureIds.Contains(feature.Value)
                    };

                    var json = JsonSerializer.Serialize(carFeatureDto);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var responseFeature = await client.PostAsync("https://localhost:7020/api/CarFeatures", content);

                    if (!responseFeature.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "Failed to add car feature.");
                        return View(dto);
                    }
                }

                return RedirectToAction("Index");
            }


            return View("Error");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Cars/delete/{id}");
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
