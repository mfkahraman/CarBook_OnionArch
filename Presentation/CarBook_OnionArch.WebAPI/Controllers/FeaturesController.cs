using CarBook_OnionArch.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook_OnionArch.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetFeatureQueryResult>>> GetAll()
        {
            var values = await mediator.Send(new GetFeatureQuery());

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFeatureByIdQueryResult>> GetById(int id)
        {
            var value = await mediator.Send(new GetFeatureByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult<GetFeatureByIdQueryResult>> Create(CreateFeatureCommand command)
        {
            try
            {
                var result = await mediator.Send(command);

                if (result == null)
                {
                    return BadRequest("Oluşturma işlemi sırasında bir sorun oluştu");
                }

                return CreatedAtAction(nameof(GetById), new { id = result.FeatureId }, result);

            }
            catch (Exception ex)
            {
                return BadRequest($"Oluşturma işlemi sırasında bir sorun oluştu: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateFeatureCommand command)
        {
            if (id != command.FeatureId)
                return BadRequest("URL'deki id ile gövdedeki id uyuşmuyor.");

            try
            {
                var result = await mediator.Send(command);

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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await mediator.Send(new RemoveFeatureCommand(id));

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
