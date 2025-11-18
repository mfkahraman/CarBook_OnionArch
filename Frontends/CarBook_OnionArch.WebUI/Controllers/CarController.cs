using CarBook_OnionArch.Dto.CarDtos;
using CarBook_OnionArch.Dto.LocationDtos;
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
        public async Task<IActionResult> AvailableCars(ReservationDetailsDto reservationDto, int? page)
        {
            var client = httpClientFactory.CreateClient();

            string sDate = Uri.EscapeDataString(reservationDto.StartDate.ToString("O")); // "O" = round-trip ISO 8601
            string eDate = Uri.EscapeDataString(reservationDto.EndDate.ToString("O"));

            var url = $"https://localhost:7020/api/Cars/get-available-cars?startDate={sDate}&endDate={eDate}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<List<ResultCarWithRelationsDto>>(jsonData);

            TempData["ReservationDto"] = JsonSerializer.Serialize(reservationDto);

            int pagesize = 6;
            int pageNumber = page ?? 1;
            var pagedList = values?.ToPagedList(pageNumber, pagesize);
            return View(pagedList);
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Cars/get-car-with-relations-by-id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var car = JsonSerializer.Deserialize<ResultCarWithRelationsDto>(jsonData);
            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> ReservationDetails(int carId, decimal dailyPrice)
        {
            var reservationDetailsDto = JsonSerializer.Deserialize<ReservationDetailsDto>(TempData["ReservationDto"]?.ToString() ?? string.Empty);
            if (reservationDetailsDto == null)
            {
                return View("Error");
            }

            var client = httpClientFactory.CreateClient();
            var pickOffResponse = await client.GetAsync($"https://localhost:7020/api/Locations/{reservationDetailsDto.PickUpLocationId}");
            var dropOffResponse = await client.GetAsync($"https://localhost:7020/api/Locations/{reservationDetailsDto.DropOffLocationId}");
            var carResponse = await client.GetAsync($"https://localhost:7020/api/Cars/get-car-with-relations-by-id/{carId}");
            if (!pickOffResponse.IsSuccessStatusCode || !dropOffResponse.IsSuccessStatusCode || !carResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var jsonData = await pickOffResponse.Content.ReadAsStringAsync();
            var pickUpLocation = JsonSerializer.Deserialize<ResultGetLocationDto>(jsonData);

            jsonData = await dropOffResponse.Content.ReadAsStringAsync();
            var dropOffLocation = JsonSerializer.Deserialize<ResultGetLocationDto>(jsonData);

            jsonData = await carResponse.Content.ReadAsStringAsync();
            var car = JsonSerializer.Deserialize<ResultCarWithRelationsDto>(jsonData);

            reservationDetailsDto.PickUpLocationName = pickUpLocation?.name;
            reservationDetailsDto.DropOffLocationName = dropOffLocation?.name;
            reservationDetailsDto.CarName = car?.brand?.name + " " + car?.model;

            reservationDetailsDto.CarId = carId;
            reservationDetailsDto.UserId = Random.Shared.Next(1, 11); //Rastgele userId ataması
            reservationDetailsDto.DailyPrice = dailyPrice;
            reservationDetailsDto.TotalPrice = dailyPrice * (decimal)(reservationDetailsDto.EndDate - reservationDetailsDto.StartDate).TotalDays;
            reservationDetailsDto.Status = "Rezervasyon Alindi";

            return View(reservationDetailsDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateRentalDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonContent = JsonSerializer.Serialize(dto);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Rentals", content);
            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Kiralama talebiniz başarıyla oluşturuldu!" });
            }
            else
            {
                return Json(new { success = false, message = "Kiralama talebi oluşturmak için giriş yapmalısınız. Sizi giriş sayfasına yönlendiriyorum." });
            }
        }
    }
}