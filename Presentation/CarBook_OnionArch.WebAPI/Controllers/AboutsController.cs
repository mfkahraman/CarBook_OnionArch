using CarBook_OnionArch.Application.Features.CQRS.Commands.AboutCommands;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(CreateAboutCommandHandler createHandler,
                                  UpdateAboutCommandHandler updateHandler,
                                  RemoveAboutCommandHandler removeHandler,
                                  GetAboutByIdQueryHandler getByIdHandler,
                                  GetAboutQueryHandler getAllQueryHandler) : ControllerBase
    {
        [HttpGet("get-all-abouts")]
        public async Task<IActionResult> GetAll()
        {
            var values = await getAllQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("get-about-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await getByIdHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("create-about")]
        public async Task<IActionResult> Create(CreateAboutCommand command)
        {
            try
            {
                await createHandler.Handle(command);
            }
            catch (Exception)
            {
                return BadRequest("Oluşturma işlemi sırasında bir sorun oluştu");
            }
            return Created();
        }

        [HttpPut("update-about")]
        public async Task<IActionResult> Update(UpdateAboutCommand command)
        {
            try
            {
                await updateHandler.Handle(command);
            }
            catch (Exception)
            {
                return BadRequest("Güncelleme işlemi sırasında bir sorun oluştu");
            }
            return Ok("Başarılı şekilde güncellendi");
        }

        [HttpDelete("delete-about/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await removeHandler.Handle(new RemoveAboutCommand(id));
            }
            catch (Exception)
            {
                return BadRequest("Silme işlemi sırasında bir sorun oluştu");
            }
            return Ok("Başarılı şekilde silindi");
        }
    }
}
