using CarBook_OnionArch.Dto.CarDtos;
using CarBook_OnionArch.Dto.RentalDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using X.PagedList.Extensions;

namespace CarBook_OnionArch.WebUI.Controllers
{
    public class CarController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Cars/get-cars-with-all");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);

            int pagesize = 6;
            int pageNumber = page ?? 1;
            var pagedList = values?.ToPagedList(pageNumber, pagesize);
            return View(pagedList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RentalDto rentalDto, int? page)
        {
            var client = httpClientFactory.CreateClient();

            string sDate = Uri.EscapeDataString(rentalDto.StartDate.ToString("O")); // "O" = round-trip ISO 8601
            string eDate = Uri.EscapeDataString(rentalDto.EndDate.ToString("O"));

            var url = $"https://localhost:7020/api/Cars/get-available-cars?startDate={sDate}&endDate={eDate}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);

            TempData["RentalDto"] = JsonSerializer.Serialize(rentalDto);

            int pagesize = 6;
            int pageNumber = page ?? 1;
            var pagedList = values?.ToPagedList(pageNumber, pagesize);
            return View(pagedList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(int carId, decimal dailyPrice)
        {
            var rentalDto = JsonSerializer.Deserialize<RentalDto>(TempData["RentalDto"]?.ToString() ?? string.Empty);
            if (rentalDto == null)
            {
                return View("Error");
            }

            var createRentalDto = new CreateRentalDto
            {
                CarId = carId,
                StartDate = rentalDto.StartDate,
                EndDate = rentalDto.EndDate,
                PickUpLocationId = rentalDto.PickupLocationId,
                DropOffLocationId = rentalDto.DropoffLocationId,
                DailyPrice = dailyPrice,
                UserId = Random.Shared.Next(1, 11), // 1-10 arasinda rastgele userId
                TotalPrice = dailyPrice * (rentalDto.EndDate - rentalDto.StartDate).Days,
                Status = "Rezervasyon Alindi"
            };

            var client = httpClientFactory.CreateClient();
            var jsonContent = JsonSerializer.Serialize(createRentalDto);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Rentals", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                return View("Error");
            }
        }
    }
}