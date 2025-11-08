using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController(IMediator mediator)
        : ControllerBase
    {
        [HttpGet("get-author-count")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var result = await mediator.Send(new GetAuthorCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-automatic-transmission-car-count")]
        public async Task<IActionResult> GetAutomaticTransmissionCarCount()
        {
            var result = await mediator.Send(new GetAutomaticTransmissionCarCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-average-daily-rent-price")]
        public async Task<IActionResult> GetAverageDailyRentPrice()
        {
            var result = await mediator.Send(new GetAverageDailyRentPriceQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-average-monthly-rent-price")]
        public async Task<IActionResult> GetAverageMonthlyRentPrice()
        {
            var result = await mediator.Send(new GetAverageMonthlyRentPriceQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-average-weekly-rent-price")]
        public async Task<IActionResult> GetAverageWeeklyRentPrice()
        {
            var result = await mediator.Send(new GetAverageWeeklyRentPriceQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-blog-count")]
        public async Task<IActionResult> GetBlogCount()
        {
            var result = await mediator.Send(new GetBlogCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-blog-with-most-comments-title")]
        public async Task<IActionResult> GetBlogWithMostCommentsTitle()
        {
            var result = await mediator.Send(new GetBlogWithMostCommentsTitleQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-brand-count")]
        public async Task<IActionResult> GetBrandCount()
        {
            var result = await mediator.Send(new GetBrandCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-brand-with-most-cars-name")]
        public async Task<IActionResult> GetBrandWithMostCarsName()
        {
            var result = await mediator.Send(new GetBrandWithMostCarsNameQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-car-count")]
        public async Task<IActionResult> GetCarCount()
        {
            var result = await mediator.Send(new GetCarCountQuery());

            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(result);
        }

        [HttpGet("get-car-count-under-1000-km")]
        public async Task<IActionResult> GetCarCountUnder1000Km()
        {
            var result = await mediator.Send(new GetCarCountUnder1000KmQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-car-with-highest-daily-rent-price-name")]
        public async Task<IActionResult> GetCarWithHighestDailyRentPrice()
        {
            var result = await mediator.Send(new GetCarWithHighestDailyRentPriceNameQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-car-with-lowest-yearly-rent-price-name")]
        public async Task<IActionResult> GetCarWithLowestYearlyRentPriceName()
        {
            var result = await mediator.Send(new GetCarWithLowestYearlyRentPriceNameQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-diesel-car-count")]
        public async Task<IActionResult> GetDieselCarCount()
        {
            var result = await mediator.Send(new GetDieselCarCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-gasoline-car-count")]
        public async Task<IActionResult> GetGasolineCarCount()
        {
            var result = await mediator.Send(new GetGasolineCarCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }

        [HttpGet("get-location-count")]
        public async Task<IActionResult> GetLocationCount()
        {
            var result = await mediator.Send(new GetLocationCountQuery());
            if (result == null)
            {
                return NotFound("Veri bulunamadı");
            }
            return Ok(result);
        }
    }
}
