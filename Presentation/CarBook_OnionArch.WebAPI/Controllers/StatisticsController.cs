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
    }
}
