using CarBook_OnionArch.Dto.BrandDtos;
using CarBook_OnionArch.Dto.CarDescriptionDtos;
using CarBook_OnionArch.Dto.CarDtos;
using CarBook_OnionArch.Dto.CarFeatureDtos;
using CarBook_OnionArch.Dto.FeaturesDtos;
using CarBook_OnionArch.Dto.PricingDtos;
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
            ViewBag.Pricings = await FetchPricingsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto createCarDto)
        {
            if (createCarDto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(createCarDto.ImageFile, "cars");
                createCarDto.coverImageUrl = imagePath;
                createCarDto.bigImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
                ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
                ViewBag.Brands = await FetchBrandsAsync();
                ViewBag.Features = await FetchFeaturesAsync();
                ViewBag.Pricings = await FetchPricingsAsync();
                return View(createCarDto);
            }

            //Create Car
            var jsonData = JsonSerializer.Serialize(createCarDto);
            var formData = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var client = httpClientFactory.CreateClient();
            var responseCar = await client.PostAsync("https://localhost:7020/api/Cars/create", formData);

            if(!responseCar.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to create car.");
                return View(createCarDto);
            }

            var carJson = await responseCar.Content.ReadAsStringAsync();
            //End of Create Car

            //Get Created Car Id
            var createdCar = JsonSerializer.Deserialize<ResultGetCarByIdDto>(carJson);
            int carId = createdCar!.id;
            //End of Get Created Car Id

            //Create Car Description
            var descriptionDto = new CreateCarDescriptionDto
            {
                Detail = createCarDto.carDescriptions!.First().detail!,
                CarId = carId
            };

            var descriptionJson = JsonSerializer.Serialize(descriptionDto);
            var descriptionContent = new StringContent(descriptionJson, System.Text.Encoding.UTF8, "application/json");
            var responseDescription = await client.PostAsync("https://localhost:7020/api/CarDescriptions", descriptionContent);
            if (!responseDescription.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to add car description.");
                return View(createCarDto);
            }
            //End of Create Car Description


            //Create Car Features
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
            //End of Create Car Features

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Cars/get-car-with-relations-by-id/{id}");
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

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarDto dto)
        {
            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(dto.coverImageUrl))
                    await imageService.DeleteImageAsync(dto.coverImageUrl);

                else if (!string.IsNullOrEmpty(dto.bigImageUrl))
                    await imageService.DeleteImageAsync(dto.bigImageUrl);

                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "cars");
                dto.coverImageUrl = imagePath;
                dto.bigImageUrl = imagePath;
                ModelState.Remove("ImageUrl");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Transmissions = EnumHelper.ToSelectList<TransmissionType>();
                ViewBag.Fuels = EnumHelper.ToSelectList<FuelType>();
                ViewBag.Brands = await FetchBrandsAsync();
                return View(dto);
            }

            var jsonData = JsonSerializer.Serialize(dto);
            var formData = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var client = httpClientFactory.CreateClient();
            var response = await client.PutAsync($"https://localhost:7020/api/Cars/update/{dto.id}", formData);

            if (response.IsSuccessStatusCode)
            {
                foreach (var feature in dto.carFeatures!)
                {
                    var json = JsonSerializer.Serialize(feature);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var responseFeature = await client.PutAsync($"https://localhost:7020/api/CarFeatures/{feature.id}", content);

                    if (!responseFeature.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("", "Failed to update car feature.");
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
        public async Task<List<ResultPricingDto>> FetchPricingsAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Pricings");
            var jsonData = await response.Content.ReadAsStringAsync();
            var pricingList = JsonSerializer.Deserialize<List<ResultPricingDto>>(jsonData);
            return pricingList ?? new List<ResultPricingDto>();
        }

    }
}
