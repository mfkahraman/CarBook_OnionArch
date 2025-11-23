using CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetAppRolesListQueryResult>>> GetAll()
        {
            var values = await mediator.Send(new GetAppRolesListQuery());

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAppRoleByIdQueryResult>> GetById(int id)
        {
            var value = await mediator.Send(new GetAppRoleByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult<GetAppRoleByIdQueryResult>> Create(CreateAppRoleCommand command)
        {
            try
            {
                var result = await mediator.Send(command);

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await mediator.Send(new RemoveAppRoleCommand(id));

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