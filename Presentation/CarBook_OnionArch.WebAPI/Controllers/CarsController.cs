using CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Queries.CarQueries;
using CarBook_OnionArch.Application.Features.Mediator.Queries.RentalQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(CreateCarCommandHandler createHandler,
                                  UpdateCarCommandHandler updateHandler,
                                  RemoveCarCommandHandler removeHandler,
                                  GetCarByIdQueryHandler getByIdHandler,
                                  GetCarQueryHandler getAllQueryHandler,
                                  GetCarWithBrandQueryHandler withBrandQueryHandler,
                                  GetCarWithAllQueryHandler carWithAllHandler,
                                  GetCarWithRelationsByIdQueryHandler withRelationsByIdHandler,
                                  IMediator mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await getAllQueryHandler.Handle();

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("get-cars-with-brands")]
        public async Task<IActionResult> GetCarsWithBrands()
        {
            var values = await withBrandQueryHandler.Handle();

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("get-cars-with-all")]
        public async Task<IActionResult> GetCarsWithAll()
        {
            var values = await carWithAllHandler.Handle();

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await getByIdHandler.Handle(new GetCarByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpGet("get-car-with-relations-by-id/{id}")]
        public async Task<IActionResult> GetCarWithRelationsById(int id)
        {
            var value = await withRelationsByIdHandler.Handle(new GetCarByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpGet("get-available-cars/{startDate}/{endDate}")]
        public async Task<IActionResult> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            var availableCars = await mediator.Send(new GetAvailableCarsQuery(startDate, endDate));
            if (availableCars == null || !availableCars.Any())
            {
                return NotFound("Kullanılabilir araç bulunamadı.");
            }
            return Ok(availableCars);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {
            try
            {
                var result = await createHandler.Handle(command);

                if (result == null)
                {
                    return BadRequest("Oluşturma işlemi sırasında bir sorun oluştu");
                }

                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

            }
            catch (Exception ex)
            {
                return BadRequest($"Oluşturma işlemi sırasında bir sorun oluştu: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCarCommand command)
        {
            try
            {
                if (id != command.Id)
                    return BadRequest("URL'deki id ile gövdedeki id uyuşmuyor.");

                var result = await updateHandler.Handle(command);

                if (!result)
                    return BadRequest("Kayıt güncellenirken bir sorun oluştu");

                return Ok("Başarılı şekilde güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest($"Güncelleme işlemi sırasında bir sorun oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await removeHandler.Handle(new RemoveCarCommand(id));

                if (!result)
                {
                    return BadRequest($"{id} Id nolu kayıt silinirken bir hata oluştu.");
                }

                return Ok($"{id} Id nolu kayıt başarıyla silindi.");
            }

            catch (Exception ex)
            {
                return BadRequest($"Silme işlemi sırasında bir sorun oluştu: {ex.Message}");
            }
        }
    }
}
