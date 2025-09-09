using CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Create(CreateCarDescriptionCommand command)
        {
            try
            {
                var result = await mediator.Send(command);

                if (result == null)
                {
                    return BadRequest("Oluşturma işlemi sırasında bir sorun oluştu");
                }

                return Created();

            }
            catch (Exception ex)
            {
                return BadRequest($"Oluşturma işlemi sırasında bir sorun oluştu: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCarDescriptionCommand command)
        {
            if (id != command.Id)
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
                var result = await mediator.Send(new RemoveCarDescriptionCommand(id));

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
